using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Presentacion
{
    class ADApoderado
    {
        public ADApoderado() {

        }

        public bool registrarApoderado(MApoderado apo) {
            try
            {
                SqlConnection conexion = conectar.obtenerConexion();

                string consulta = "insert into apoderado ([apo_dni],[apo_apellidos],[apo_nombres],[apo_celular],[estado]) values(@_dni,@_apellidos,@_nombres,@_celular,'a')";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@_dni", apo.Dni);
                comando.Parameters.AddWithValue("@_apellidos", apo.Apellidos);
                comando.Parameters.AddWithValue("@_nombres", apo.Nombres);
                comando.Parameters.AddWithValue("@_celular", apo.Celular);


                int r = comando.ExecuteNonQuery();
                conexion.Dispose();
                conexion.Close();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al registrar apoderado: " + e.ToString());
                return false;
            }
        }



        public MApoderado buscarApoderado(string dni) {
            try {
                SqlConnection conexion = conectar.obtenerConexion();
                MApoderado temp = new MApoderado();
                int cont = 0;
                string consulta = "select [apo_dni],[apo_apellidos],[apo_nombres],[apo_celular] from apoderado where [apo_dni]=@_dni";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@_dni", dni);
                 SqlDataReader dr = comando.ExecuteReader();

               
                while (dr.Read())
                {
                    string apellidos = (string)dr["apo_apellidos"];
                    string nombres = (string)dr["apo_nombres"];
                    string celular = (string)dr["apo_celular"];
                    cont++;
                    temp = new MApoderado(dni, apellidos, nombres, celular);
                    
                }

                conexion.Dispose();
                conexion.Close();
                if (cont > 0) {
                    return temp;
                }
                return null;

            }
            catch (Exception e) {
                MessageBox.Show(e.ToString());
                return null;
               
            }
        }
    }
}
