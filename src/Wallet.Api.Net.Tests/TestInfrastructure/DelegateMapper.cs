using Wallet.Api.Net.Services;

namespace Wallet.Api.Net.Tests.TestInfrastructure
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
