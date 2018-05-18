using System;
using Shriek.Domains;

namespace Shriek.CMS.Domain.Abstracts
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TAggregateKey"></typeparam>
    public class _AggregateRoot<TAggregateKey> : AggregateRoot<TAggregateKey>
        where TAggregateKey : IEquatable<TAggregateKey>
    {
        #region property

        /// <summary>
        /// 如果实体（带Guid）被创建后，该值就是DB生成的值
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; protected set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public string Creator { get; protected set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        public DateTime EditDate { get; protected set; }

        /// <summary>
        /// 编辑者
        /// </summary>
        public string Editor { get; protected set; }

        #endregion property

        #region ctor

        /// <summary>
        ///
        /// </summary>
        /// <param name="aggregateId"></param>
        protected _AggregateRoot(TAggregateKey aggregateId)
            : base(aggregateId)
        {
            this.CreateDate = this.EditDate = DateTime.Now;
            this.Editor = this.Creator = "sys";
        }

        #endregion ctor
    }
}