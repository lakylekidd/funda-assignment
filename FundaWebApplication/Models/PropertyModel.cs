namespace FundaWebApplication.Models
{
    public class PropertyModel : AgencyModel
    {
        /// <summary>
        /// The id of the listing
        /// </summary>
        public int GlobalId { get; set; }
        /// <summary>
        /// Determines whether or not the property has been rented
        /// </summary>
        public bool IsVerhuurd { get; set; }
        /// <summary>
        /// Determines whether or not the property has been bought
        /// </summary>
        public bool IsVerkocht { get; set; }
        /// <summary>
        /// Determines whether or not the property has been bought or rented
        /// </summary>
        public bool IsVerkochtOfVerhuurd { get; set; }
        /// <summary>
        /// The total price of the property
        /// </summary>
        public int KoopprijsTot { get; set; }
    }
}
