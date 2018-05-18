using System;
using Shriek.Events;

namespace Shriek.CMS.Domain.Channel.Events
{
    public class ChannelChangedEvent : Event<Guid>
    {
        /// <summary>
        /// 频道名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 链接用的别名
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 是否关联地域
        /// </summary>
        public bool ConnectArea { get; set; }

        /// <summary>
        /// 是否默认
        /// </summary>
        public bool Default { get; set; }
    }
}