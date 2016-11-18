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

                string consulta = "insert into estudiante ([est_dni],[est_apellidos],[est_nombres],[est_sexo],[est_edad],[est_nacimiento],[est_celular],[est_direccion],[est_foto],[est_excelencia],[est_otro],[estado],[apo_dni],[col_id]) values (@_dni,@_apellidos,@_nombres,@_sexo,@_edad,@_nacimiento,@_celular,@_direccion,@_foto,@_excelencia,@_otroRec,@_estado,@_apo_dni, @_col_id)";
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

        public MEstudiante buscarEstudiantePorDni(string dni) {
            MEstudiante temp_est=new MEstudiante();
            int con = 0;
            try
            {
               SqlConnection conexion = conectar.obtenerConexion();

                string consulta = "select [est_dni],[est_apellidos],[est_nombres],[est_edad],[est_sexo],[est_nacimiento],[est_celular],[est_direccion],[est_excelencia], [est_otro],[apo_dni],[col_id]from estudiante where est_dni=@dni";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@dni", dni);
                SqlDataReader dr = comando.ExecuteReader();

                

                while (dr.Read())
                {

                    string apellidos = (string)dr["est_apellidos"];
                    string nombres = (string)dr["est_nombres"];
                    int edad = (Int32)dr["est_edad"];
                    string sexo = (string)dr["est_sexo"];
                    DateTime fecha = (DateTime)dr["est_nacimiento"];
                    string celular = (string)dr["est_celular"];
                    string direccion = (string)dr["est_direccion"];
                    string premio = (string)dr["est_excelencia"];
                    string otro = (string)dr["est_otro"];
                    string dniApo = (string)dr["apo_dni"];
                    int idCol = (Int32)dr["col_id"];
                    con++;
                    temp_est = new MEstudiante(dni,apellidos,nombres,sexo,edad,fecha,celular,direccion,premio,otro);
                    
                    
                }

                conexion.Dispose();
                conexion.Close();
                if (con > 0)
                {
                    return temp_est;
                }
                else {
                    return null;
                }
                

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;

            }
        }

        public String buscarColegioAsinadoEstudiante(string dni) {
            string nombreColegio = "";
            try
            {
                SqlConnection conexion = conectar.obtenerConexion();

                string consulta = "select [col_nombre] from colegio as col inner join estudiante as est on col.col_id = est.col_id where est.est_dni=@dni";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@dni", dni);
                SqlDataReader dr = comando.ExecuteReader();


                while (dr.Read())
                {

                    nombreColegio = (string)dr["col_nombre"];

                }

                conexion.Dispose();
                conexion.Close();

                return nombreColegio;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return nombreColegio;

            }
        }

        public string buscarApoderadoAsignadoEstudiante(string dni) {
            string dniApoderado = "";
            try
            {
                SqlConnection conexion = conectar.obtenerConexion();

                string consulta = "select [apo_dni] from estudiante where est_dni=@dni";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@dni", dni);
                SqlDataReader dr = comando.ExecuteReader();


                while (dr.Read())
                {

                    
                    dniApoderado = (string)dr["apo_dni"];
                    

                }
                conexion.Dispose();
                conexion.Close();

                return dniApoderado;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return dniApoderado;

            }
        }


        //fin---
    }
}
