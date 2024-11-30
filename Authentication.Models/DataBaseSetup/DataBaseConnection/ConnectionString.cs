using FirebirdSql.Data.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Models.DataBaseSetup.DataBaseConnection
{
    public static class ConnectionString
    {
        public static string Connection { get; private set; }

        public static void InitializeSettings(IConfiguration config)
        {
            Connection = config.GetSection("ConnectionStrings")["DefaultConnection"];
        }
    }
}
