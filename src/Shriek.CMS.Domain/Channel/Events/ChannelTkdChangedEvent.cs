using System;
using Shriek.CMS.Domain.Channel.ValueObjects;
using Shriek.Events;

namespace Shriek.CMS.Domain.Channel.Events
{
    public class ChannelTkdChangedEvent : Event<Guid>
    {
        public TkdValueObject Tkd { get; set; }
    }
}