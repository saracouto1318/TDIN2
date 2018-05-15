using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTService.Database
{
    public class AccessDao
    {
        private static AccessDao instance;

        public static AccessDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccessDao();
                }
                return instance;
            }
        }

        public SqlConnection Conn { get; }

        public AccessDao()
        {
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString);
        }
    }
}
