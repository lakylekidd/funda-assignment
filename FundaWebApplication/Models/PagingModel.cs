namespace FundaWebApplication.Models
{
    /// <summary>
    /// Model that determines the current paging details of the query
    /// </summary>
    public class PagingModel
    {
        public int AantalPaginas { get; set; }
        public int HuidigePagina { get; set; }
        public string VolgendeUrl { get; set; }
        public string VorigeUrl { get; set; }
    }
}
