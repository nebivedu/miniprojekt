﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Npgsql;
using System.Configuration;

namespace predstave
{

    public class BazaConn
    {
        public static string connect()
        {
            var uriString = ConfigurationManager.AppSettings["ELEPHANTSQL_URL"] ?? "postgres://rghmcidm:RXndy-JPTh4dwIPcqkmJRoFpJKCa0xRe@kandula.db.elephantsql.com:5432/rghmcidm";
            var uri = new Uri(uriString);
            var db = uri.AbsolutePath.Trim('/');
            var user = uri.UserInfo.Split(':')[0];
            var passwd = uri.UserInfo.Split(':')[1];
            var port = uri.Port > 0 ? uri.Port : 5432;
            var connStr = string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4}",
                uri.Host, db, user, passwd, port);
            return connStr;
        }
    }
}
