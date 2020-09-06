using System;
using System.Collections.Generic;
using VotingApplication.Entities.Common;

namespace VotingApplication.Entities
{
    public class Category : KeyedEntityBase<int>
    {
        public string Name { get; set; }
        public virtual IEnumerable<Candidate> Candidates { get; set; }
    }
}
