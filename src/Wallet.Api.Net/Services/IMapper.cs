using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Api.Net.Services
{
    internal interface IMapper<in TSource, TDestination>
    {
        TDestination? Map(TSource? source);
    }
}
