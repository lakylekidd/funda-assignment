using System.Collections.Generic;

namespace FundaWebApplication.Models
{
    public class SearchResultModel
    {
        /// <summary>
        /// A list of properties for the current search result
        /// </summary>
        public List<PropertyModel> Objects { get; set; }
        /// <summary>
        /// The pagination details for the current search result
        /// </summary>
        public PagingModel Paging { get; set; }
    }
}
