
namespace Model.PostParametersModels
{
    public class BasePostParameterListModel
    {
        const int maxPageSize = 2;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        public string SearchQuery { get; set; }
        public string OrderBy { get; set; }
    }
}
