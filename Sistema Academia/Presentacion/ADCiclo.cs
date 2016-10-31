using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Presentacion
{
    public class ADCiclo
    {

        public ADCiclo() {

        }
        public List<string> obtenerCiclos()
        {
            SqlConnection conexion = conectar.obtenerConexion();

            string consulta = "select cic_nombre from ciclo";
            SqlCommand comando = new SqlCommand(consulta, conexion);

            SqlDataReader dr = comando.ExecuteReader();
            List<string> listaCiclo = new List<string>();
            while (dr.Read())
            {
                string ciclo = (string)dr["cic_nombre"];
             
                listaCiclo.Add(ciclo);
            }
            conexion.Dispose();
            conexion.Close();
            return listaCiclo;
        }

    }
}
