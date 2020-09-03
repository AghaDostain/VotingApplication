namespace VotingApplication.Entities.Common
{
    public abstract class KeyedEntityBase<TValue>
    {
        public TValue Id { get; set; }
    }
}
