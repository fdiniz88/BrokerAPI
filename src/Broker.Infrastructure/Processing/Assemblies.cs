using System.Reflection;
using Broker.Application.Orders.PlaceCustomerOrder;

namespace Broker.Infrastructure.Processing
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(PlaceCustomerOrderCommand).Assembly;
    }
}