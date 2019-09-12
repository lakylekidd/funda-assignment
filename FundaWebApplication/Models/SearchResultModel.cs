using System.Collections.Generic;

namespace FundaWebApplication.Models
{
    public class SearchResultModel
    {
        public List<PropertyModel> Objects { get; set; }
        public PagingModel Paging { get; set; }
    }
}
