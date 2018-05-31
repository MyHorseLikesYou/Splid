using MyApp.Core.Contracts;
using System;

namespace Splid.Domain.Events
{
    public class GroupCreatedEvent : IEvent, IDomainEvent
    {
        public Guid GroupId { get; set; }
    }
}
