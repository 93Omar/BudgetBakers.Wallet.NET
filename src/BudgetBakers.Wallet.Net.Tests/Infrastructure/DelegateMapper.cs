using BudgetBakers.Wallet.Net.Services;

namespace BudgetBakers.Wallet.Net.Tests.Infrastructure
{
    internal sealed class DelegateMapper<TSource, TDestination> : IMapper<TSource, TDestination>
    {
        private readonly Func<TSource?, TDestination?> _map;

        public DelegateMapper(Func<TSource?, TDestination?> map)
        {
            _map = map;
        }

        public TDestination? Map(TSource? source)
            => _map(source);
    }
}
