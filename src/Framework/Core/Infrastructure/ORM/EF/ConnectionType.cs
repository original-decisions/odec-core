using odec.Framework.Attributes;

namespace odec.Framework.Infrastructure.ORM.EF
{
    public enum ConnectionType
    {
        [UniqueCode(Code = "MSSQL")]
        MSSQL,
        [UniqueCode(Code = "MySQL")]
        MySQL,
        [UniqueCode(Code = "PostgresSQL")]
        PostgresSQL
    }
}
