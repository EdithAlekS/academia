using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Presentacion
{
    class ADMatricula
    {
        public string obtenerCodigo(string ciclo) {
            return "2016-20001";
        }

        public bool registrarMatricula(MMatricula matricula, string ciclo, string dni) {
            try
            {
                SqlConnection conexion = conectar.obtenerConexion();

                string consulta = "insert into matricula ([mat_codigo],[mat_nivel],[mat_grado],[mat_costo],[mat_deuda],[mat_tipo_descuento],[mat_descuento],[estado],[est_dni],[cic_nombre])values(@_codigo,@_nivel,@_grado,@_costo,@_deuda,@_tipoDescuento,@_descuento,@_estado,@_est_dni,@_cic_nombre)";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@_codigo", matricula.Codigo);
                comando.Parameters.AddWithValue("@_nivel", matricula.Nivel);
                comando.Parameters.AddWithValue("@_grado", matricula.Grado);
                comando.Parameters.AddWithValue("@_costo", matricula.Costo);
                comando.Parameters.AddWithValue("@_deuda", matricula.Deuda);
                comando.Parameters.AddWithValue("@_tipoDescuento", matricula.Tipo_De_Descuento);
                comando.Parameters.AddWithValue("@_descuento", matricula.Descuento);
                comando.Parameters.AddWithValue("@_estado", "a");
                comando.Parameters.AddWithValue("@_est_dni", dni);
                comando.Parameters.AddWithValue("@_cic_nombre", ciclo);

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
                MessageBox.Show("Error al registrar Matricula: " + e.ToString());
                return false;
            }
            
        }




    }
}
