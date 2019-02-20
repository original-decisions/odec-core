namespace odec.Framework.Infrastructure.ORM.EF
{
    /// <summary>
    /// Configuration options for the EF
    /// </summary>
    public class EFOptions
    {
        /// <summary>
        /// Assembly used to strore migrations
        /// </summary>
        public string MigrationAssembly { get; set; }
        /// <summary>
        /// Connections option
        /// </summary>
        public ConnectionOptions ConnectionOption { get; set; }

    }
}
