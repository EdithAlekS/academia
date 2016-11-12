using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


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

        public string obtenerNombreCiclo() {
            SqlConnection conexion = conectar.obtenerConexion();

            string consulta = "select top(1) cic_nombre from ciclo where estado='a' order by cic_nombre desc ";
            SqlCommand comando = new SqlCommand(consulta, conexion);

            SqlDataReader dr = comando.ExecuteReader();
            string ciclo = "";
            while (dr.Read())
            {
                 ciclo = (string)dr["cic_nombre"];
            }
            
            conexion.Dispose();
            conexion.Close();

            //ciclo tiene el valor del ultimo ciclo registrado.

            string año = ciclo.Substring(0,4);
            string num = ciclo.Substring(5, 1);

            DateTime hoy = DateTime.Now;
            string añoActual = hoy.Year.ToString();



            if (año == añoActual)
            {
                //si es el mismo año
                ciclo = añoActual +"-"+ (Int32.Parse(num) + 1).ToString();
            }
            else {
                //si el ultimo ciclo registrado no es del año actual
                ciclo = añoActual + "-1";
            }
            return ciclo;
        }



        public MCiclo obtenerCiclo(string nombre) {
            List<MCiclo> lista_ciclos = new List<MCiclo>();

            try
            {
                SqlConnection conexion = conectar.obtenerConexion();

                string consulta = "select [cic_nombre],[cic_inicio],[cic_fin],[cic_costo_prim],[cic_costo_sec_a],[cic_costo_sec_b],[cic_costo_pre] from ciclo where cic_nombre = @nombre";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@nombre",nombre);
                SqlDataReader dr = comando.ExecuteReader();
                
                while (dr.Read())
                {
     
                    string nombre_ciclo = (string)dr["cic_nombre"];
                    DateTime inicio_ciclo = (DateTime)dr["cic_inicio"];
                    DateTime fin_ciclo = (DateTime)dr["cic_fin"];
                    float prim_ciclo = (float)(Double)dr["cic_costo_prim"];
                    float seca_ciclo = (float)(Double)dr["cic_costo_sec_a"];
                    float secb_ciclo = (float)(Double)dr["cic_costo_sec_b"];
                    float pre_ciclo = (float)(Double)dr["cic_costo_pre"];

                    MCiclo temp = new MCiclo(nombre_ciclo, inicio_ciclo, fin_ciclo, prim_ciclo, seca_ciclo, secb_ciclo, pre_ciclo);
                    lista_ciclos.Add(temp);

                    
                }
                conexion.Dispose();
                conexion.Close();


                return lista_ciclos[0];
            }
            catch (Exception e){
                MessageBox.Show(e.ToString()+" Elementos de la lista: "+lista_ciclos.Count);
                return null;
            }

        }
        



        public Boolean registrarCiclo(MCiclo ciclo) {

            try
            {
                SqlConnection conexion = conectar.obtenerConexion();

                string consulta = "insert into ciclo ([cic_nombre],[cic_inicio],[cic_fin],[cic_costo_prim],[cic_costo_sec_a],[cic_costo_sec_b],[cic_costo_pre],[estado]) values (@_nombre,@_inicio,@_fin,@_prim,@_seca,@_secb,@_pre,'a')";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@_nombre", ciclo.nombre);
                comando.Parameters.AddWithValue("@_inicio", ciclo.inicio);
                comando.Parameters.AddWithValue("@_fin", ciclo.final);
                comando.Parameters.AddWithValue("@_prim", ciclo.primaria);
                comando.Parameters.AddWithValue("@_seca", ciclo.secundaria_a);
                comando.Parameters.AddWithValue("@_secb", ciclo.secundaria_b);
                comando.Parameters.AddWithValue("@_pre", ciclo.pre);

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
                MessageBox.Show("Error al registrar ciclo: " + e.ToString());
                return false;
            }
                  

        }

    }
}
