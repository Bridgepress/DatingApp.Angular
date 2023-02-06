using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DatingApp.CommandAndQuery.Commands.ICommand;

namespace DatingApp.CommandAndQuery.Commands
{
    public abstract class InternalCommandBase : ICommand
    {
        public int Id { get; }

        protected InternalCommandBase(int id)
        {
            this.Id = id;
        }
    }

    public abstract class InternalCommandBase<TResult> : ICommand<TResult>
    {
        public int Id { get; }

        protected InternalCommandBase()
        {
            this.Id = 0;
        }

        protected InternalCommandBase(int id)
        {
            this.Id = id;
        }
    }
}
