namespace VotingApplication.Models.API_Models
{
    public class VoteVM
    {
        public int VoterId { get; set; }
        public int CandidateId { get; set; }
        public int CategoryId { get; set; }
    }
}
