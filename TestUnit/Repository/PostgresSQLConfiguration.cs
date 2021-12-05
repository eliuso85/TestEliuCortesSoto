using System;

namespace DataAccess.test
{
    public class PostgresSQLConfiguration
    {
        public PostgresSQLConfiguration(string connectionString) => ConnectionString = connectionString;
        public string ConnectionString { get; set; }
    }
}
