using System;
using Shriek.Events;

namespace Shriek.CMS.Domain.Channel.Events
{
    public class ChannelCategoryCountChangedEvent : Event<Guid>
    {
        public int CategoryCount { get; internal set; }
    }
}