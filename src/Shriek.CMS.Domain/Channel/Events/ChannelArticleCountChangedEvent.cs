using System;
using Shriek.Events;

namespace Shriek.CMS.Domain.Channel.Events
{
    public class ChannelArticleCountChangedEvent : Event<Guid>
    {
        public int ArticleCount { get; set; }
    }
}