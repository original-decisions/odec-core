using System;
using System.Linq;

namespace odec.Framework.Infrastructure.ORM.EF
{
    public class ConnectionOptions
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public ConnectionType GetConnectionTypeEnum()
        {
            var name = Enum.GetNames(typeof(ConnectionType)).Where(it => it.ToLower() == Type.ToLower()).SingleOrDefault();
            var result = ConnectionType.MSSQL;
            if (string.IsNullOrEmpty(name)) return result;
            Enum.TryParse(name, out result);
            return result;
        }
    }
}
