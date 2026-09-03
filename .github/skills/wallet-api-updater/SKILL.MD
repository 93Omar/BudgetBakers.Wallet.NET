---
name: wallet-api-updater
description: Aggiorna il wrapper .NET delle API Wallet by BudgetBakers a partire dai file OpenAPI e dal diff tra versioni, implementando direttamente le modifiche nel codice e verificando build e test.
---

## Scopo

Questa skill aggiorna il wrapper .NET che espone classi per chiamare, tramite HttpClient, le API di Wallet by BudgetBakers, adeguandolo ai cambiamenti delle specifiche OpenAPI.

La skill:

- Legge i file OpenAPI nella cartella `openapi` (es. `1.0.0`, `1.5.0`, `2.0.0`).
- Legge il file di diff tra versioni (es. `diff_1.5.0_2.0.0`).
- Implementa direttamente le modifiche necessarie nel codice C# del wrapper.
- Rispetta le convenzioni di struttura e code styling del progetto (incluse le regole in `.editorconfig` e quanto descritto in `copilot-instructions.md`).
- Verifica che il progetto buildi e che i test passino dopo le modifiche.
- Produce un report finale che descrive cosa è stato cambiato.

## Quando attivarsi

Attivati quando l’utente:

- Chiede di aggiornare il wrapper delle API Wallet in seguito a un cambiamento delle specifiche.
- Fornisce o fa riferimento a:
  - un file di diff (`diff_{{versione_precedente}}_{{versione_nuova}}.json`),
  - o a una nuova versione del file OpenAPI nella cartella `openapi`.

Esempi di prompt che devono attivare questa skill:

- “Aggiorna il wrapper alle nuove API Wallet usando il diff 1.5.0 → 2.0.0”
- “Adatta il client alle modifiche delle API di Wallet, ho messo il nuovo OpenAPI e il diff in openapi”
- “Implementa i cambiamenti delle API Wallet nel wrapper .NET”

## Contesto da considerare

Prima di agire:

1. Leggi il file `copilot-instructions.md` presente nel repository per comprendere:
   - la struttura del progetto,
   - le convenzioni architetturali,
   - gli standard di codice e organizzazione dei file.
2. Leggi il file `.editorconfig` per rispettare:
   - formattazione,
   - naming,
   - stili C#.
3. Analizza la codebase esistente per inferire:
   - pattern usati per i client HTTP,
   - struttura dei modelli (DTO, request/response),
   - gestione degli errori, logging, estensioni, ecc.
4. Non fidarti ciecamente della sezione che descrive lo scope della libreria in `copilot-instructions.md` (es. "solo GET/lettura"): verifica sempre direttamente nel codice (cartella `Services/Clients/`) quali verbi HTTP sono già implementati per ciascun client, perché la documentazione può non essere aggiornata rispetto al codice reale.

## Input tipici

La skill può ricevere:

- Riferimenti a file nella cartella `openapi`:
  - File OpenAPI versione precedente (es. `1.5.0`)
  - File OpenAPI versione nuova (es. `2.0.0`)
  - File di diff (es. `diff_1.5.0_2.0.0.json`)
- Oppure istruzioni generiche come “usa l’ultima versione in openapi e il relativo diff”.

Se non è chiaro quale sia la versione corrente o il diff da usare, chiedi conferma all’utente prima di procedere.

### Nota tecnica sul file di diff

I file `diff_{{versione_precedente}}_{{versione_nuova}}.json` possono essere codificati in **UTF-16** e di dimensioni considerevoli (anche >90KB). Prima di analizzarli:

- Non leggerli con un semplice tool di visualizzazione testo grezzo: su UTF-16 il risultato può essere illeggibile (mojibake).
- Convertili in UTF-8 (es. `Get-Content -Raw -Encoding Unicode` seguito da `ConvertFrom-Json`) e naviga la struttura a sezioni mirate (es. `paths.modified`, `components.schemas.modified`) invece di leggerlo per intero.

## Procedura di aggiornamento

### 1. Analisi del diff e delle specifiche

1. Leggi il file di diff (`diff_{{versione_precedente}}_{{versione_nuova}}.json`).
2. Se necessario, confronta con il file OpenAPI della nuova versione per:
   - comprendere la struttura completa di nuovi endpoint/oggetti,
   - verificare tipi, vincoli, esempi.

Identifica:

- **Cambiamenti ai payload**:
  - property aggiunte, modificate o rimosse su oggetti esistenti,
  - oggetti/DTO aggiunti, modificati o rimossi.
- **Cambiamenti agli endpoint**:
  - nuovi endpoint,
  - modifiche a endpoint esistenti (path, metodo HTTP, parametri, body),
  - endpoint rimossi.

### 2. Pianificazione delle modifiche al codice

Sulla base dell’analisi:

1. Mappa ogni cambiamento a modifiche concrete nel codice C#:
   - classi/models da creare, modificare o eliminare,
   - interfacce/client da aggiornare (metodi, parametri, tipi di ritorno),
   - eventuali classi di supporto (extension methods, mapper, helper).
2. Assicurati che:
   - la struttura rispetti quanto definito in `copilot-instructions.md`,
   - il codice esistente venga riutilizzato dove possibile,
   - non vengano introdotti oggetti/property/endpoint obsoleti: le rimozioni vanno applicate rimuovendo direttamente il codice.
3. Verifica se più schemi OpenAPI modificati mappano allo **stesso tipo C# condiviso** (es. un oggetto "summary" riutilizzato da più risposte di scrittura): in tal caso una singola modifica al tipo condiviso copre tutti gli schemi coinvolti, evitando duplicazioni inutili.

Non è necessario mostrare all’utente il piano dettagliato prima di agire: procedi direttamente con l’implementazione.

### 3. Implementazione delle modifiche

1. **Modelli (DTO, request/response)**:
   - Aggiungi nuove classi/record per nuovi oggetti.
   - Modifica classi esistenti per:
     - aggiungere property,
     - rinominare property (se necessario, aggiorna tutti i riferimenti),
     - cambiare tipi,
     - rimuovere property o classi non più presenti nelle specifiche.
2. **Client e endpoint**:
   - Aggiungi nuovi metodi per nuovi endpoint, rispettando:
     - pattern esistenti per chiamate HttpClient,
     - gestione di query string, path parameters, body, headers.
   - Modifica metodi esistenti per riflettere cambiamenti di:
     - path,
     - verbo HTTP,
     - parametri,
     - tipo di body/request/response.
   - Rimuovi metodi/endpoint che non esistono più nelle nuove specifiche.
3. **Codice correlato**:
   - Aggiorna eventuali mapper, factory, extension methods, helper che usano gli oggetti modificati.
   - Rimuovi o adatta codice che faceva riferimento a property/oggetti/endpoint eliminati.
4. **Stile e convenzioni**:
   - Applica le regole di `.editorconfig`.
   - Segui lo stile e la struttura già presenti nel progetto (naming, organizzazione in cartelle, uso di record vs classi, gestione errori, logging, ecc.).

### 4. Verifica di copertura del diff

Prima di passare a build e test, ricontrolla esplicitamente l'elenco completo di `paths.modified` e `components.schemas.modified` (aggiunti/modificati/rimossi) del file di diff e verifica, per ciascuna voce, se è stata:

- implementata nel codice, oppure
- valutata e scartata perché puramente documentale (es. descrizioni, esempi, nuovi codici di risposta HTTP senza impatto sullo schema dati).

Non dare per scontato che una voce sia "solo doc" senza averla controllata: alcune modifiche minori nel diff (es. una property aggiunta in profondità dentro un `allOf`) sono facili da perdere in una lettura superficiale.

### 5. Verifica build e test

Dopo aver implementato tutte le modifiche:

1. Esegui la build del progetto:
   - Usa il comando appropriato (es. `dotnet build` o quello indicato nelle istruzioni del repo).
2. Se la build fallisce:
   - Analizza gli errori,
   - Correggi il codice (tipi mancanti, riferimenti a property rimosse, firme di metodi, ecc.),
   - Ripeti la build fino a successo.
3. Esegui i test:
   - Usa il comando appropriato (es. `dotnet test` o script specifici).
4. Se i test falliscono:
   - Analizza i fallimenti,
   - Correggi il codice o, se necessario, adatta i test per riflettere le nuove API (senza rompere la logica di business),
   - Ripeti i test fino a successo.

Se incontri errori che non riesci a risolvere in autonomia, descrivili chiaramente nel report finale.

### 6. Report finale

Al termine, produci una risposta all’utente che includa:

1. **Sintesi delle modifiche**:
   - Breve descrizione dei cambiamenti principali (nuovi endpoint, modifiche rilevanti ai payload, rimozioni importanti).
2. **Dettaglio per area**:
   - Elenco delle classi/models:
     - aggiunte,
     - modificate (con breve descrizione delle modifiche),
     - rimosse.
   - Elenco degli endpoint/client:
     - nuovi metodi/endpoint,
     - metodi modificati,
     - metodi/endpoint rimossi.
3. **Stato build e test**:
   - Indica se la build è andata a buon fine.
   - Indica se i test passano, e in caso negativo descrivi sinteticamente i problemi residui.
4. **Note e raccomandazioni**:
   - Eventuali punti di attenzione (es. cambiamenti che potrebbero impattare i consumatori del wrapper),
   - Suggerimenti per test manuali o scenari da verificare.

Il report deve essere in italiano, chiaro e strutturato, ma non eccessivamente lungo.

## Vincoli e regole

- Non introdurre tag `[Obsolete]`: le rimozioni vanno gestite eliminando direttamente codice (classi, property, metodi, endpoint).
- Mantieni la compatibilità con la struttura attuale del wrapper: non cambiare architettura, naming globale o organizzazione del progetto se non strettamente necessario per allinearsi alle nuove specifiche.
- Rispetta sempre:
  - `copilot-instructions.md`,
  - `.editorconfig`,
  - le convenzioni inferibili dalla codebase esistente.
- Lavora su tutto il progetto, non solo su file isolati, per garantire coerenza globale.
- Dopo ogni ciclo di modifiche, verifica sempre build e test prima di considerare il lavoro concluso.
- Se durante l'analisi crei file temporanei di supporto (es. estratti/dump parziali del diff o degli OpenAPI in `openapi/`), eliminali prima di concludere il task: la cartella `openapi` deve contenere solo i file sorgente originali.

## Lingua

- Tutte le istruzioni interne, i commenti nel codice generato e i report all’utente devono essere in **italiano**, a meno che il progetto non sia esplicitamente in inglese (in tal caso, usa l’inglese solo per il codice, mantenendo i report in italiano).