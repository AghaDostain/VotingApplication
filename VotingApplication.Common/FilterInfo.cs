using VotingApplication.Common.Enumeration;

namespace VotingApplication.Common
{
    public class FilterInfo
    {
        public string Field { get; set; }
        public FilterOperators Op { get; set; }
        public object Value { get; set; }
    }
}
