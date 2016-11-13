using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Presentacion
{
    class ADEstudiante
    {
        public ADEstudiante() {

        }

        public bool agregarEstudiante(MEstudiante est, MApoderado apo, MColegio col, PictureBox foto) {
            try
            {
                SqlConnection conexion = conectar.obtenerConexion();

                string consulta = "insert into estudiante [est_dni],[est_apellidos],[est_nombres],[est_sexo],[est_edad],[est_nacimiento],[est_celular],[est_direccion],[est_foto],[est_excelencia],[est_otro],[est_estado],[apo_dni],[col_id] values (@_dni,@_apellidos,@_nombres,@_sexo,@_edad,@_nacimiento,@_celular,@_direccion,@_foto,@_excelencia,@_otroRec,@_estado,@_apo_dni, @_col_id)";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@_dni", est.Dni);
                comando.Parameters.AddWithValue("@_apellidos", est.Apellidos);
                comando.Parameters.AddWithValue("@_nombres", est.Nombres);
                comando.Parameters.AddWithValue("@_sexo", est.Sexo);
                comando.Parameters.AddWithValue("@_edad", est.Edad);
                comando.Parameters.AddWithValue("@_nacimiento", est.Nacimiento);
                comando.Parameters.AddWithValue("@_celular", est.Celular);
                comando.Parameters.AddWithValue("@_direccion", est.Direccion);
                //colocamos formato de ingreso imagen
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                comando.Parameters.AddWithValue("@_foto", ms.GetBuffer());

                comando.Parameters.AddWithValue("@_excelencia", est.Excelencia);
                comando.Parameters.AddWithValue("@_otroRec", est.OtroReconocimiento);
                comando.Parameters.AddWithValue("@_estado", "a");
                comando.Parameters.AddWithValue("@_apo_dni", apo.Dni);
                comando.Parameters.AddWithValue("@_col_id", col.Codigo);

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
                MessageBox.Show("Error al registrar estudiante: " + e.ToString());
                return false;
            }
        }
    }
}
