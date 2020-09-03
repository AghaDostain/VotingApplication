using System;
using VotingApplication.Entities.Common;

namespace VotingApplication.Entities
{
    public class Category : KeyedEntityBase<int>
    {
        public string Name { get; set; }
    }
}
