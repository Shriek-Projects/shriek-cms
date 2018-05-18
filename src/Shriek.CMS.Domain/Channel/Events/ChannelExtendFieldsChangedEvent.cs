using System;
using System.Collections.Generic;
using Shriek.CMS.Domain.Channel.ValueObjects;
using Shriek.Events;

namespace Shriek.CMS.Domain.Channel.Events
{
    public class ChannelExtendFieldsChangedEvent : Event<Guid>
    {
        /// <summary>
        /// 动态字段
        /// </summary>
        public IEnumerable<FieldValueObject> DynamicFields { get; set; }
    }
}