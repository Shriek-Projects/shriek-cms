using System;
using Shriek.Events;

namespace Shriek.CMS.Domain.Channel.Events
{
    public class FieldsChangedEvent : Event<Guid>
    {
        /// <summary>
        /// 元素类型
        /// </summary>
        public InputElementType Type { get; set; }

        /// <summary>
        /// 中文名
        /// </summary>
        public string Name { get; set; }
    }
}