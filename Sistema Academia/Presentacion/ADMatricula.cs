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
            try {

                string codigoMatricula = "";
                int ultRegistro = 0;

                SqlConnection conexion = conectar.obtenerConexion();
                string consulta = "select  top(1)  [mat_codigo] from matricula where [mat_codigo] like @ciclo+'%' order by [mat_codigo] DESC";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@ciclo", ciclo);
                SqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {

                    codigoMatricula = (string)dr["mat_codigo"];
                    
                }
                conexion.Dispose();
                conexion.Close();

                //procesando el codigo y creando nuevo
                if (codigoMatricula == "") {
                    codigoMatricula = ciclo + "0001";
                } else {
                    ultRegistro = Int32.Parse(codigoMatricula.Substring(6, 4))+1;
                    codigoMatricula = ciclo;

                    if (ultRegistro < 10)
                    {
                        codigoMatricula += "000" + ultRegistro;
                    }
                    else {
                        if (ultRegistro < 100)
                        {
                            codigoMatricula += "00" + ultRegistro;
                        }
                        else {
                            if (ultRegistro < 1000)
                            {
                                codigoMatricula += "0" + ultRegistro;
                            }
                            else {
                                codigoMatricula += ultRegistro;
                            }
                        }
                    }
                }
                

                MessageBox.Show(codigoMatricula);

                return codigoMatricula;

            } catch (Exception e) {
                MessageBox.Show("Error al obtener nombre de ciclo: " + e.ToString());
                return "";
            }
           
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
