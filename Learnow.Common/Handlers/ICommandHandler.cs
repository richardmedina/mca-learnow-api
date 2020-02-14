using Learnow.Common.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Common.Handlers
{
    public interface ICommandHandler<in TCommand> : IHandler<TCommand> where TCommand : ICommand
    {
    }
}
