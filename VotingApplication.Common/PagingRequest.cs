namespace VotingApplication.Common
{
    public class PagingRequest
    {
        protected string sort;
        protected int pageSize;
        protected int page;

        public string Sort
        {
            get
            {
                var result = "Id";
                var definition = new { field = "", dir = "" };
                if (string.IsNullOrEmpty(this.sort))
                    return result;
                else
                {
                    return this.sort;
                }
            }
            set
            {
                sort = value;
            }
        }

        public int PageSize
        {
            get
            {
                return this.pageSize <= 0 ? 0 : this.pageSize;
            }
            set
            {
                this.pageSize = value;
            }
        }

        public int Page
        {
            get
            {
                return this.page < 0 ? 0 : this.page;
            }
            set
            {
                this.page = value;
            }
        }
    }
}
