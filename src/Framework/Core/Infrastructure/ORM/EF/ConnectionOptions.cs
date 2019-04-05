using System;
using System.Linq;

namespace odec.Framework.Infrastructure.ORM.EF
{
    /// <summary>
    /// Connection object which contains some additional information in addition to the simple connection string.
    /// <see cref="ConnectionType"/>
    /// </summary>
    public class ConnectionOptions
    {
        /// <summary>
        /// Connection type (mssql, oracle, postgres, mysql)
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Connection string value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Enum based representation for known types. gives the <see cref="ConnectionType.MSSQL"/> type by default or if can't parse.
        /// </summary>
        /// <returns></returns>
        public ConnectionType GetConnectionTypeEnum()
        {
            var name = Enum.GetNames(typeof(ConnectionType)).SingleOrDefault(it => it.ToLower() == Type.ToLower());
            var result = ConnectionType.MSSQL;
            if (string.IsNullOrEmpty(name)) return result;
            Enum.TryParse(name, out result);
            return result;
        }
    }
}
