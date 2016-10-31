using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentacion.Properties;
using System.Data.SqlClient;
using System.Configuration;

namespace Presentacion
{
    public class conectar
    {
        public static String obtenerCadena() {
            return Settings.Default.academiaConnectionString;
        }

        public static SqlConnection obtenerConexion() {
            SqlConnection con = new SqlConnection(obtenerCadena());

            con.Open();
            return con;
        }
    }
}
