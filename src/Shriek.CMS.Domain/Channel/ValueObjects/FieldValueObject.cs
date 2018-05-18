using System.Collections.Generic;

namespace Shriek.CMS.Domain.Channel.ValueObjects
{
    public class FieldValueObject : InputElementValueObject
    {
        public FieldValueObject()
        {
        }

        public FieldValueObject(int Sort, string name, string field, InputElementType type, IDictionary<int, string> selectValue) : base(field, type)
        {
            this.SelectValue = selectValue;
            this.Name = name;
            this.Sort = Sort;
        }

        /// <summary>
        /// 搜索条件位置（-1为不搜索）
        /// </summary>
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