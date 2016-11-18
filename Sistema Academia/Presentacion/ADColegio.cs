using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Presentacion
{
    class ADColegio
    {
        public ADColegio() {

        }

        public bool registrarColegio(MColegio col) {
            try
            {
                SqlConnection conexion = conectar.obtenerConexion();

                string consulta = "insert into colegio ([col_nombre],[col_direccion],[col_distrito],[col_provincia],[col_departamento],[estado])values(@_nombre,@_direccion,@_distrito,@_provincia,@_departamento, 'a')";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@_nombre", col.Nombre);
                comando.Parameters.AddWithValue("@_direccion", col.Ubicacion);
                comando.Parameters.AddWithValue("@_distrito", col.Distrito);
                comando.Parameters.AddWithValue("@_provincia", col.Provincia);
                comando.Parameters.AddWithValue("@_departamento", col.Departamento);


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
                MessageBox.Show("Error al registrar colegio: " + e.ToString());
                return false;
            }
        }


        public void autocompletarColegio(TextBox col) {

            try {
                SqlConnection conexion = conectar.obtenerConexion();
                string consulta = "select col_nombre from colegio where estado = 'a'";
                SqlCommand comando = new SqlCommand(consulta, conexion);

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {

                    col.AutoCompleteCustomSource.Add((string)dr["col_nombre"]);
                }

                conexion.Dispose();
                conexion.Close();

               
            }
            catch (Exception e) {

                MessageBox.Show("Error al autocompletar Inst. Educ. " + e.ToString());
            }
           
        }

        public MColegio buscarColegio(string nombre) {
            
            try {
                MColegio temp = new MColegio();
                int cont = 0;

                SqlConnection conexion = conectar.obtenerConexion();
                string consulta = "select col_id,col_nombre, col_direccion, col_distrito,col_provincia, col_departamento from colegio where col_nombre = @nombre and estado = 'a'";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@nombre", nombre);

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    int codigo = (Int32)dr["col_id"];
                    string direccion = (string)dr["col_direccion"];
                    string distrito = (string)dr["col_distrito"];
                    string provincia = (string)dr["col_provincia"];
                    string departamento = (string)dr["col_departamento"];
                    cont++;
                    temp = new MColegio(codigo, nombre, direccion, distrito, provincia, departamento);
                   
                }

                conexion.Dispose();
                conexion.Close();
                if (cont > 0) {
                    return temp;
                }


                return null;
            } catch (Exception e) {
                MessageBox.Show("Error al buscar colegio "+e.ToString());
                return null;
            }


            
        }
    }
}
