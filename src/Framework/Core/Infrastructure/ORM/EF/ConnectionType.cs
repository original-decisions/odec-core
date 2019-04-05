using odec.Framework.Attributes;

namespace odec.Framework.Infrastructure.ORM.EF
{
    /// <summary>
    /// Connection Types for the connection strings.
    /// </summary>
    public enum ConnectionType
    {
        /// <summary>
        /// Microsoft SQL connection string type.
        /// </summary>
        [UniqueCode(Code = "MSSQL")]
        MSSQL,
        /// <summary>
        /// MySQL connection connection string type.
        /// </summary>
        [UniqueCode(Code = "MySQL")]
        MySQL,
        /// <summary>
        /// Postgres SQL connection string type
        /// </summary>
        [UniqueCode(Code = "PostgresSQL")]
        PostgresSQL,
        /// <summary>
        /// Oracle connection connection string type.
        /// </summary>
        [UniqueCode(Code = "Oracle")]
        Oracle

    }
}
