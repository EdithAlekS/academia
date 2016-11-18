using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Presentacion
{
    public partial class Inicio : Form
    {
        static ADCiclo cicloAD = new ADCiclo();
        public Inicio()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try {
                SqlConnection conexion = conectar.obtenerConexion();
                conexion.Dispose();
                conexion.Close();
                MessageBox.Show("Bienvenido al Sistema de la Academia");

            } catch (Exception ex) {
                MessageBox.Show("Error al conectar con el servidor: " + ex.ToString());
            }
            
           
            List<string> ciclos = new List<string>();
            ciclos = cicloAD.obtenerCiclos();
          
            ciclos.Add("Crear Ciclo");

            cb_ciclo.DataSource = ciclos;
        }

        private void cb_ciclo_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarTodo();

            if (cb_ciclo.Text == "Crear Ciclo")
            {
                groupBox1.Enabled = true;
                string nombre_ciclo = cicloAD.obtenerNombreCiclo();
                tb_nombreCiclo.Text = nombre_ciclo;
                tb_nombreCiclo.Enabled = false;
            }
            else {
                groupBox1.Enabled = false;
                string nombre_ciclo = cb_ciclo.Text;

                //llenamos el group box con la información del ciclo seleccionado
                llenarInformacionCiclo(nombre_ciclo);
            }


            }

        private void limpiarTodo()
        {
            tb_nombreCiclo.Clear();
            tb_pre.Clear();
            tb_primaria.Clear();
            tb_secundaria_b.Clear();
            tb_secuntaria_a.Clear();
        }




        private void btn_principal_Click(object sender, EventArgs e)
        {
            if (cb_ciclo.Text == "Crear Ciclo")
            {

                if (tb_nombreCiclo.Text != "" && tb_primaria.Text != "" && tb_secuntaria_a.Text != "" && tb_secundaria_b.Text != "" && tb_pre.Text != "")
                {
                    string nombre_ciclo = tb_nombreCiclo.Text;
                    DateTime inicio_ciclo = date_InicioCiclo.Value;
                    DateTime fin_ciclo = date_FinCiclo.Value;
                    float prim_ciclo = float.Parse(tb_primaria.Text);
                    float seca_ciclo = float.Parse(tb_secuntaria_a.Text);
                    float secb_ciclo = float.Parse(tb_secundaria_b.Text);
                    float pre_ciclo = float.Parse(tb_pre.Text);

                    MCiclo temp = new MCiclo(nombre_ciclo, inicio_ciclo, fin_ciclo, prim_ciclo, seca_ciclo, secb_ciclo, pre_ciclo);
                    Boolean r = cicloAD.registrarCiclo(temp);
                    if (r)
                    {
                        Principal main_form = new Principal(nombre_ciclo);
                        main_form.Show();
                        this.Visible = false;
                    }
                    else {
                        MessageBox.Show("Error al Registrar nuevo ciclo");
                    }
                }
                else
                {
                    MessageBox.Show("Faltan campos por llenar");
                }


            }

            //en el caso de que se ha seleccionado un ciclo ya existente
            else {
                //ingresamos con el valor de nombre seleccionado, que ya se ha cargado en el textBox

                Principal main_form = new Principal(tb_nombreCiclo.Text);
                main_form.Show();
                this.Visible = false;

            }
        }





        private void llenarInformacionCiclo(string nombre_ciclo)
        {
            MCiclo ciclo_relleno = cicloAD.obtenerCiclo(nombre_ciclo);

            if (ciclo_relleno != null)
            {
                tb_nombreCiclo.Text = ciclo_relleno.nombre;
                date_FinCiclo.Value = ciclo_relleno.final;
                date_InicioCiclo.Value = ciclo_relleno.inicio;
                tb_primaria.Text = ciclo_relleno.primaria.ToString();
                tb_secuntaria_a.Text = ciclo_relleno.secundaria_a.ToString();
                tb_secundaria_b.Text = ciclo_relleno.secundaria_b.ToString();
                tb_pre.Text = ciclo_relleno.pre.ToString();

            }
            else {
                MessageBox.Show("Problemas al consultar información de ciclo con el servidor");
            }
        }
    }
}
