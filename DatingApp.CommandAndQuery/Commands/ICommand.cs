using MediatR;

namespace DatingApp.CommandAndQuery.Commands
{
    public interface ICommand : IRequest
    {
        int Id { get; }
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
        int Id { get; }
    }
}
