using System.Collections.Generic;

namespace FundaWebApplication.Models
{
    /// <summary>
    /// The search result model class contains details about the current search result
    /// such as a list of <see cref="PropertyModel"/> and a <see cref="PagingModel"/>
    /// </summary>
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
