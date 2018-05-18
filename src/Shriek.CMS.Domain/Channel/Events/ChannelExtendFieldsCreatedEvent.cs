using System.Collections.Generic;

namespace Shriek.CMS.Domain.Channel.Events
{
    public class ChannelExtendFieldsCreatedEvent : InputElementCreatedEvent
    {
        public int Sort { get; set; }

        /// <summary>
        /// 中文名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 选择框下拉列表
        /// </summary>
        public IDictionary<int, string> SelectValue { get; set; }
    }
}