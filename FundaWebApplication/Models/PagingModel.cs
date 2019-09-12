namespace FundaWebApplication.Models
{
    /// <summary>
    /// Model that determines the current paging details of the query
    /// </summary>
    public class PagingModel
    {
        /// <summary>
        /// Determines the total pages of the search results
        /// </summary>
        public int AantalPaginas { get; set; }
        /// <summary>
        /// Determines the current page of the search results
        /// </summary>
        public int HuidigePagina { get; set; }
        /// <summary>
        /// Determines the next url to be called by pagination script
        /// </summary>
        public string VolgendeUrl { get; set; }
        /// <summary>
        /// Determines the previous url to be called by pagination script
        /// </summary>
        public string VorigeUrl { get; set; }
    }
}
