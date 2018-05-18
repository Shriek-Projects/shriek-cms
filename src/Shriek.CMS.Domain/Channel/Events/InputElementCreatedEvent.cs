using System;
using Shriek.Events;

namespace Shriek.CMS.Domain.Channel.Events
{
    public class InputElementCreatedEvent : Event<Guid>
    {
        /// <summary>
        /// 字段名
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// 元素类型
        /// </summary>
        public InputElementType Type { get; set; }
    }
}