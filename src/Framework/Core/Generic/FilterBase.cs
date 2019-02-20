namespace odec.Framework.Generic
{
    /// <summary>
    /// Basic class for all Filters. 
    /// Default values Page = 1 | Rows =15 | Sidx(Order Column Name) = Name | Sord (Sort Order) = asc (ascending)
    /// </summary>
    public class FilterBase
    {
        /// <summary>
        /// Default Constructor. Initialization - Page = 1 | Rows =15 | Sidx(Order Column Name) = Name | Sord (Sort Order) = asc (ascending)
        /// </summary>
        public FilterBase()
        {
            Page = 1;
            Rows = 15;
            Sidx = "Name";
            Sord = "asc";
        }
        /// <summary>
        /// Number of rows per page
        /// </summary>
        public int Rows { get; set; }
        /// <summary>
        /// Page Number
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Sort order (asc|desc)
        /// </summary>
        public string Sord { get; set; }
        /// <summary>
        /// Order Column Name
        /// </summary>
        public string Sidx { get; set; }
    }
}
