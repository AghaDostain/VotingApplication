using System;

namespace VotingApplication.Entities.Common
{
    public abstract class EditableEntityBase<TValue> : KeyedEntityBase<TValue>
    {
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
