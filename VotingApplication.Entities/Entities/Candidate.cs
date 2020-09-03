using System;
using VotingApplication.Entities.Common;

namespace VotingApplication.Entities
{
    public class Candidate : KeyedEntityBase<int>
    {
        public string Name { get; set; }
        public int CatergoryId { get; set; }
    }
}
