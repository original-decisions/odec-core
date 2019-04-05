namespace odec.Framework.Infrastructure.ORM.EF
{
    /// <summary>
    /// Configuration options for the Entity Framework.
    /// </summary>
    public class EFOptions
    {
        /// <summary>
        /// Assembly used to store migrations 
        /// </summary>
        public string MigrationAssembly { get; set; }
        /// <summary>
        /// <see cref="ConnectionOption"/> to store the connection and type of the connection.
        /// </summary>
        public ConnectionOptions ConnectionOption { get; set; }

    }
}
