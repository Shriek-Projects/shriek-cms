using Shriek.CMS.Domain.Abstracts;
using Shriek.Domains;

namespace Shriek.CMS.Domain.Channel.ValueObjects
{
    public class InputElementValueObject : ValueObject<InputElementValueObject>
    {
        public InputElementValueObject()
        {
        }

        public InputElementValueObject(string field, InputElementType type)
        {
            this.Field = field;
            this.Type = type;
        }

        /// <summary>
        /// 字段名
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// 元素类型
        /// </summary>
        public InputElementType Type { get; set; }

        protected override bool EqualsCore(InputElementValueObject other)
        {
            return this.Field == other.Field && this.Type == other.Type;
        }

        protected override int GetHashCodeCore()
        {
            return this.Field.GetHashCode() ^ this.Type.GetHashCode();
        }
    }
}