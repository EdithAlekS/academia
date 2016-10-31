using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Controlador
{
    class CicloAD
    {
        public List<string> obtenerCiclos()
        {
            SqlConnection conexion = Presen

            string consulta = "select * from asignatura";
            SqlCommand comando = new SqlCommand(consulta, conexion);

            SqlDataReader dr = comando.ExecuteReader();
            List<Comun.Curso> listaCurso = new List<Comun.Curso>();
            while (dr.Read())
            {
                int CodCurso = (Int32)dr["idAsignatura"];
                string NomCurso = (string)dr["nombre"];
                int horas = (Int32)dr["horas"];

                Comun.Curso temp = new Comun.Curso(CodCurso, NomCurso, horas);
                listaCurso.Add(temp);
            }
            conexion.Dispose();
            conexion.Close();
            return listaCurso;
        }

    }
}
