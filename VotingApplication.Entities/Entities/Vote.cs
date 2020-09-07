using VotingApplication.Entities.Common;

namespace VotingApplication.Entities
{
    public class Vote : RestrictedEntityBase<int>
    {
        public int? VoterId { get; set; }
        public int? CandidateId { get; set; }
        public int CategoryId { get; set; }
    }
}
