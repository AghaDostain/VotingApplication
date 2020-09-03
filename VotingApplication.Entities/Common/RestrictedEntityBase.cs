using System;

namespace VotingApplication.Entities.Common
{
    public abstract class RestrictedEntityBase<TValue> : KeyedEntityBase<TValue>
    {
        public DateTime? CreatedOn { get; set; }
    }
}
