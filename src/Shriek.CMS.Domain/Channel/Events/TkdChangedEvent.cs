using System;
using Shriek.Events;

namespace Shriek.CMS.Domain.Channel.Events
{
    public class TkdChangedEvent : Event<Guid>
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 关键词
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}