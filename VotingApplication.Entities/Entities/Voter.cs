using System;
using VotingApplication.Entities.Common;

namespace VotingApplication.Entities
{
    public class Voter : EditableEntityBase<int>
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
    }
}
