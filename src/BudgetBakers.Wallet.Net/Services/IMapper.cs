using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetBakers.Wallet.Net.Services
{
    internal interface IMapper<in TSource, TDestination>
    {
        TDestination? Map(TSource? source);
    }
}
