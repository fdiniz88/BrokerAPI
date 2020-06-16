using System.Threading.Tasks;
using MediatR;
using Broker.Application.Configuration.Commands;

namespace Broker.Application.Configuration.Processing
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync<T>(ICommand<T> command);
    }
}