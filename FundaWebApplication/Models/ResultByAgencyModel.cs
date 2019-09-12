using System.Collections.Generic;

namespace FundaWebApplication.Models
{
    /// <summary>
    /// A class that specifies an agency with a list of <see cref="PropertyModel"/>
    /// </summary>
    public class ResultByAgencyModel : AgencyModel
    {
        /// <summary>
        /// A list of properties for current agency
        /// </summary>
        public List<PropertyModel> Properties { get; set; }
    }
}
