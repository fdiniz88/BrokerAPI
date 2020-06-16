namespace Broker.Domain.Extensions
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}