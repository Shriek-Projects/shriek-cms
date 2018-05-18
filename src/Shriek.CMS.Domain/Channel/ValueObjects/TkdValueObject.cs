using System;
using System.ComponentModel;

using Shriek.CMS.Domain.Abstracts;
using Shriek.Domains;

namespace Shriek.CMS.Domain.Channel.ValueObjects
{
    [Serializable]
    public class TkdValueObject : ValueObject<TkdValueObject>
    {
        public TkdValueObject()
        {
        }

        public TkdValueObject(string title, string keywords, string description)
        {
            this.Title = title;
            this.Keywords = keywords;
            this.Description = description;
        }

        /// <summary>
        /// 标题
        /// </summary>
        [DisplayName("标题")]
        public string Title { get; set; }

        /// <summary>
        /// 关键词
        /// </summary>
        [DisplayName("关键词")]
        public string Keywords { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DisplayName("文章摘要")]
        public string Description { get; set; }

        protected override bool EqualsCore(TkdValueObject other)
        {
            return other.Title == this.Title && other.Keywords == this.Keywords && other.Description == this.Description;
        }

        protected override int GetHashCodeCore()
        {
            return this.Title.GetHashCode() ^ this.Keywords.GetHashCode() ^ this.Description.GetHashCode();
        }
    }
}