using Learnow.Common.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Common.Handlers
{
    public interface ICommandHandler<in T> : IHandler<T> where T : ICommand
    {
    }
}
