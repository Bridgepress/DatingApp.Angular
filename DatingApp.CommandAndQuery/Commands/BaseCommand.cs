namespace DatingApp.CommandAndQuery.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public int Id { get; }

        public BaseCommand()
        {
            Id = 0;
        }

        protected BaseCommand(int Id)
        {
            this.Id = Id;
        }
    }

    public abstract class BaseCommand<TResult> : ICommand<TResult>
    {
        public int Id { get; }

        protected BaseCommand()
        {
            this.Id = 0;
        }

        protected BaseCommand(int id)
        {
            Id = id;
        }
    }
}
