namespace VotingApplication.Models.API_Models
{
    public class CandidateVoteInfoVM
    {
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int VoteCount { get; set; }
    }
}
