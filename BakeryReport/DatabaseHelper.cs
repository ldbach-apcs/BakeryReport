using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BakeryReport
{
    public class DatabaseHelper
    {
        private const String DB_NAME = "BakeryReport";
        private String CnnVal()
        {
            return ConfigurationManager.ConnectionStrings[DB_NAME].ConnectionString;
        }

        public void DbAddIngridient(String name, int price, float quantity) {
            // This make sure each sqlConection is terminated after usage
            using (IDbConnection connection = new SqlConnection(CnnVal()))
            {


            }
        }
    }
}
