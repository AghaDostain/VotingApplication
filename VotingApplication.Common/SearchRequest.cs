using System.Collections.Generic;

namespace VotingApplication.Common
{
    public class SearchRequest : BaseRequest
    {
        public SearchRequest()
        {
            this.Filters = new List<FilterInfo>();
        }

        public IList<FilterInfo> Filters { get; set; }
    }
}
