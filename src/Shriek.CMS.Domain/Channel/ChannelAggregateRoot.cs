using System;
using System.Collections.Generic;
using System.Linq;
using Shriek.CMS.Domain.Abstracts;
using Shriek.CMS.Domain.Channel.Events;
using Shriek.Events;
using Shriek.Exceptions;
using Shriek.CMS.Domain.Channel.ValueObjects;

namespace Shriek.CMS.Domain.Channel
{
    public class ChannelAggregateRoot : _AggregateRoot<Guid>,
        IHandle<ChannelCreatedEvent>,
        IHandle<ChannelTkdChangedEvent>,
        IHandle<ChannelChangedEvent>,
        IHandle<ChannelExtendFieldsCreatedEvent>,
        IHandle<ChannelExtendFieldsDeletedEvent>,
        IHandle<ChannelCategoryCountChangedEvent>,
        IHandle<ChannelArticleCountChangedEvent>
    {
        #region props

        /// <summary>
        /// 频道名
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// 链接用的别名
        /// </summary>
        public string Alias { get; protected set; }

        /// <summary>
        /// 是否关联地域
        /// </summary>
        public bool ConnectArea { get; protected set; }

        /// <summary>
        /// 是否默认（因为贷款频道是默认）
        /// </summary>
        public bool Default { get; protected set; }

        /// <summary>
        /// 文章数
        /// </summary>
        public int ArticleCount { get; protected set; }

        /// <summary>
        /// 对应子栏目数
        /// </summary>
        public int CategoryCount { get; protected set; }

        /// <summary>
        /// 动态字段
        /// </summary>
        public IEnumerable<FieldValueObject> DynamicFields { get; protected set; }

        /// <summary>
        /// Tkd
        /// </summary>
        public TkdValueObject Tkd { get; protected set; }

        #endregion props

        #region ctor

        public ChannelAggregateRoot() : base(Guid.Empty)
        {
        }

        public ChannelAggregateRoot(Guid aggregateId) : base(aggregateId)
        {
            this.ArticleCount = 0;
            this.ConnectArea = false;
        }

        #endregion ctor

        #region create

        public ChannelAggregateRoot(Guid aggregateId, string name, string alias, bool connectArea, bool @default, IEnumerable<FieldValueObject> fields, TkdValueObject tkd) : base(aggregateId)
        {
            if (name.IsNullOrEmpty())
                throw new DomainException("频道名不能为空");

            if (alias.IsNullOrEmpty())
                throw new DomainException("url别名不能为空");

            if (fields.GroupBy(x => x.Field).Any(x => x.Count() > 1))
                throw new DomainException("动态字段不能有重复");

            this.ApplyChange(new ChannelCreatedEvent
            {
                AggregateId = this.AggregateId,

                Timestamp = DateTime.Now,
                Name = name,
                Alias = alias,
                ConnectArea = connectArea,
                Default = @default,
            });

            this.ChangeField(fields);

            this.UpdateTkd(tkd);

            //if (command.DynamicFields != null && command.DynamicFields.Any())
            //    foreach (var x in command.DynamicFields)
            //        this.AppendField(worker, x.Sort, x.Name, x.Field, x.Type, x.SelectValue);
            //else
            //    this.AppendField(worker, -1, "内容", "Content", InputElementType.富文本, null);

            //if (command.Tkd != null)
            //    this.UpdateTkd(worker, command.Tkd.Title, command.Tkd.Keywords, command.Tkd.Description);
        }

        public void Handle(ChannelCreatedEvent e)
        {
            this.Name = e.Name;
            this.Alias = e.Alias;
            this.ConnectArea = e.ConnectArea;
            this.Default = e.Default;

            this.CreateDate = e.Timestamp;
        }

        #endregion create

        #region change

        public void Change(string name, string alias, bool connectArea, bool @default, IEnumerable<FieldValueObject> fields, TkdValueObject tkd)
        {
            if (name.IsNullOrEmpty())
                throw new DomainException("频道名不能为空");

            if (alias.IsNullOrEmpty())
                throw new DomainException("url别名不能为空");

            if (fields.GroupBy(x => x.Field).Any(x => x.Count() > 1))
                throw new DomainException("动态字段不能有重复");

            this.ApplyChange(new ChannelChangedEvent
            {
                AggregateId = this.AggregateId,

                Timestamp = DateTime.Now,
                Name = name,
                Alias = alias,
                ConnectArea = connectArea,
                Default = @default,
            });

            this.ChangeField(fields);

            this.UpdateTkd(tkd);

            //this.DeleteFields();

            //if (command.DynamicFields != null && command.DynamicFields.Any())
            //    foreach (var x in command.DynamicFields)
            //        this.AppendField(x.Sort, x.Name, x.Field, x.Type, x.SelectValue);
            //else
            //    this.AppendField(-1, "内容", "Content", InputElementType.富文本, null);

            //if (command.Tkd != null)
            //    this.UpdateTkd(command.Tkd.Title, command.Tkd.Keywords, command.Tkd.Description);
            //else
            //    this.UpdateTkd(string.Empty, string.Empty, string.Empty);
        }

        public void Handle(ChannelChangedEvent e)
        {
            this.Name = e.Name;
            this.Alias = e.Alias;
            this.ConnectArea = e.ConnectArea;
            this.Default = e.Default;

            this.EditDate = e.Timestamp;
        }

        #endregion change

        #region change article count

        public void AddArticleCount()
        {
            this.ApplyChange(new ChannelArticleCountChangedEvent
            {
                AggregateId = this.AggregateId,
                Timestamp = DateTime.Now,
                ArticleCount = this.ArticleCount + 1
            });
        }

        public void SubArticleCount()
        {
            ApplyChange(new ChannelArticleCountChangedEvent
            {
                AggregateId = this.AggregateId,
                Timestamp = DateTime.Now,
                ArticleCount = this.ArticleCount - 1
            });
        }

        public void Handle(ChannelArticleCountChangedEvent e)
        {
            this.ArticleCount = e.ArticleCount;
            this.EditDate = e.Timestamp;
        }

        #endregion change article count

        #region change category count

        public void SubCategoryCount()
        {
            ApplyChange(new ChannelCategoryCountChangedEvent
            {
                AggregateId = this.AggregateId,
                CategoryCount = this.CategoryCount - 1,
                Timestamp = DateTime.Now
            });
        }

        public void AddCategoryCount()
        {
            ApplyChange(new ChannelCategoryCountChangedEvent
            {
                AggregateId = this.AggregateId,
                CategoryCount = this.CategoryCount + 1,
                Timestamp = DateTime.Now
            });
        }

        public void Handle(ChannelCategoryCountChangedEvent e)
        {
            this.CategoryCount = e.CategoryCount;

            this.EditDate = e.Timestamp;
        }

        #endregion change category count

        #region updateTkd

        public void UpdateTkd(TkdValueObject tkd)
        {
            ApplyChange(new ChannelTkdChangedEvent
            {
                AggregateId = this.AggregateId,

                Timestamp = DateTime.Now,
                Tkd = tkd
            });
        }

        public void Handle(ChannelTkdChangedEvent e)
        {
            this.Tkd = e.Tkd;
            this.EditDate = e.Timestamp;
        }

        #endregion updateTkd

        #region appendFields

        public void ChangeField(IEnumerable<FieldValueObject> fields)
        {
            ApplyChange(new ChannelExtendFieldsChangedEvent()
            {
                AggregateId = this.AggregateId,
                Timestamp = DateTime.Now,

                DynamicFields = fields
            });
        }

        public void AppendField(int sort, string name, string field, InputElementType Type, IDictionary<int, string> selectValue)
        {
            this.ApplyChange(new ChannelExtendFieldsCreatedEvent
            {
                AggregateId = this.AggregateId,
                Timestamp = DateTime.Now,

                Sort = sort,
                Field = field,
                Name = name,
                Type = Type,
                SelectValue = selectValue
            });
        }

        public void Handle(ChannelExtendFieldsCreatedEvent e)
        {
            this.DynamicFields = this.DynamicFields.Concat(new[] { new FieldValueObject(e.Sort, e.Name, e.Field, e.Type, e.SelectValue) });
            this.EditDate = e.Timestamp;
        }

        #endregion appendFields

        #region deleteFields

        public void DeleteFields()
        {
            ApplyChange(new ChannelExtendFieldsDeletedEvent
            {
                AggregateId = this.AggregateId,
                Timestamp = DateTime.Now
            });
        }

        public void Handle(ChannelExtendFieldsDeletedEvent e)
        {
            this.DynamicFields = new List<FieldValueObject>();

            this.EditDate = e.Timestamp;
        }

        #endregion deleteFields
    }
}