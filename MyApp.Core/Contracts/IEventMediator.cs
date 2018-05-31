using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Contracts
{
    public interface IEventMediator
    {
        void RaiseEvent<TEvent>(TEvent @event) where TEvent : IEvent;
        Task RaiseEventAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
