using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DASoftColitas
    {
        private static string Conn = @"Data Source=DESKTOP-2QUMSDI\SQLEXPRESS;Initial Catalog=SoftColitas;Integrated Security=True";

        public static IDbConnection Conexion() {
            return new SqlConnection(Conn);
        }

        public static IDbCommand ObtenerComando(string pComando, IDbConnection pCon) {
            return new SqlCommand(pComando, pCon as SqlConnection);
        }


    }
}
