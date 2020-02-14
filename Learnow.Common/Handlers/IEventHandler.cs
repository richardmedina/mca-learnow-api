using Learnow.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Common.Handlers
{
    interface IEventHandler<in TEvent> : IHandler<IEvent> where TEvent : IEvent
    {
    }
}
