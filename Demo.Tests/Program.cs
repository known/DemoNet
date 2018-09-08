using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Demo.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=XXX)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));User ID=XXX;Password=XXX;";
            using (var conn = new OracleConnection(connectionString))
            {
                conn.Open();
                var cmd = new OracleCommand("select code||fullname from t_module where id='1'", conn);
                var obj = cmd.ExecuteScalar();
                Console.WriteLine(obj.ToString());
            }

            Console.ReadKey();
        }
    }
}
