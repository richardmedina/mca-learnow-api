using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Learnow.Common.Handlers
{
    public interface IHandler<in THandlerItem>
    {
        Task Handle(THandlerItem item);
    }
}
