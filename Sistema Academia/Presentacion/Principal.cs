using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Principal : Form
    {
        static ADCiclo cicloAD = new ADCiclo();
        static ADApoderado apoderadoAD = new ADApoderado();
        String ciclo { get; set; }
        MCiclo cicloActual = new MCiclo();

        static bool conforme = false;

        public Principal(string nom_ciclo)
        {
            ciclo = nom_ciclo;
            InitializeComponent();

            obtenerDetalleDeCiclo();
            llenarCamposPorDefecto();
        }

        private void obtenerDetalleDeCiclo()
        {
            cicloActual = cicloAD.obtenerCiclo(ciclo);
        }

        private void llenarCamposPorDefecto()
        {
            //creamos y llenamos valores de la lista niveles
            List<String> niveles = new List<string>();
            niveles.Add("Primaria");
            niveles.Add("Secundaria");
            niveles.Add("Pre - Universitario");

            //asignamos lista al combo de nivel
            cb_nivel.DataSource = niveles;
            cb_nivel.SelectedItem = "Pre - Universitario";

            //creamos y llenamos valores de la lista grados
            List<string> grados = new List<string>();
            grados.Add("1°");
            grados.Add("2°");
            grados.Add("3°");
            grados.Add("4°");
            grados.Add("5°");

            //asiganamos lista al combo de grado
            cb_grado.DataSource = grados;


            //creamos lista de ciclos y llenamos valores
            List<string> ciclos = new List<string>();
            ciclos = cicloAD.obtenerCiclos();

            //asignamos lista al combo de ciclos
            cb_ciclo.DataSource = ciclos;
            cb_ciclo.SelectedItem = ciclo;

            //creamos lista de sexo y llenamos valores
            List<string> sexos = new List<string>();
            sexos.Add("Masculino");
            sexos.Add("Femenino");

            //asignamos lista al combo de sexo
            cb_sexo_estudiante.DataSource = sexos;

        }

        private void label22_Click(object sender, EventArgs e)
        {
            
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void cb_nivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_costo_matricula.Clear();

            if (cb_nivel.SelectedItem.ToString() == "Primaria") {
                
                tb_costo_matricula.Text = cicloActual.primaria.ToString();

                cb_grado.Enabled = false;
            }

            if (cb_nivel.SelectedItem.ToString() == "Pre - Universitario")
            {
               
                tb_costo_matricula.Text = cicloActual.pre.ToString();

                cb_grado.Enabled = false;
                
            }

            if (cb_nivel.SelectedItem.ToString() == "Secundaria")
            {
                
                cb_grado.Enabled = true;
                cb_grado.SelectedItem = "1°";
                cb_grado.SelectedItem = "4°";
            }
        }

        private void cb_grado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_nivel.SelectedItem.ToString() == "Secundaria") { 
            tb_costo_matricula.Clear();


            if (cb_grado.SelectedItem.ToString() == "1°" || cb_grado.SelectedItem.ToString() == "2°")
            {

                tb_costo_matricula.Text = cicloActual.secundaria_a.ToString();
            }

            if (cb_grado.SelectedItem.ToString() == "3°" || cb_grado.SelectedItem.ToString() == "4°" || cb_grado.SelectedItem.ToString() == "5°")
            {

                tb_costo_matricula.Text = cicloActual.secundaria_b.ToString();
            }
        }
        }

        private void chekB_otroRec_estudiante_CheckedChanged(object sender, EventArgs e)
        {
            if (chekB_otroRec_estudiante.Checked)
            {
                tb_otroRec_estudiante.Enabled = true;
            }
            else {
                tb_otroRec_estudiante.Enabled = false;
            }
        }

        private void tb_costo_matricula_TextChanged(object sender, EventArgs e)
        {
            tb_deudaFinal.Clear();
            tb_costoNeto.Text = tb_costo_matricula.Text;
            tb_deudaFinal.Text = tb_costo_matricula.Text;
            rb_desc_ninguno.Checked = true;

            //limpiar pago

            limpiarPago();
            
        }

        private void limpiarPago()
        {
            rb_pago_parte.Checked = true;
            tb_pago_parte.Clear();
            
        }

        private void rb_desc_ninguno_CheckedChanged(object sender, EventArgs e)
        {
            tb_desc_otro.Clear();
            if (rb_desc_ninguno.Checked) {
                tb_deudaFinal.Text = tb_costo_matricula.Text;
                tb_costoNeto.Text = tb_costo_matricula.Text;
                limpiarPago();

                grB_pago.Enabled = true;
            }
        }

        private void rb_desc_becaComp_CheckedChanged(object sender, EventArgs e)
        {
            tb_costoNeto.Clear();
            tb_desc_otro.Clear();
            if (rb_desc_becaComp.Checked) {
                limpiarPago();
                grB_pago.Enabled = false;
                tb_costoNeto.Text = "0";
                tb_deudaFinal.Text = "0";
            }
        }

        private void rb_desc_mediaBec_CheckedChanged(object sender, EventArgs e)

        {
            tb_costoNeto.Clear();
            tb_desc_otro.Clear();
            if (rb_desc_mediaBec.Checked) {
                float costoBruto = float.Parse(tb_costo_matricula.Text);
                float costoNeto = costoBruto / 2;
                tb_costoNeto.Text = costoNeto.ToString();
                tb_deudaFinal.Text= costoNeto.ToString();
                limpiarPago();

                grB_pago.Enabled = true;
            }
        }

        private void rb_desc_otro_CheckedChanged(object sender, EventArgs e)
        {
            tb_desc_otro.Clear();

            if (rb_desc_otro.Checked)
            {
                tb_desc_otro.Enabled = true;
                grB_pago.Enabled = false;

                tb_costoNeto.Text = tb_codigoMatricula.Text;
            }
            else {
                tb_desc_otro.Enabled = false;
            }
        }

        private void tb_desc_otro_TextChanged(object sender, EventArgs e)
        {
            tb_costoNeto.Clear();
        

            if (tb_desc_otro.Text.ToString().Length >= 1)
            {
                float costoBruto = float.Parse(tb_costo_matricula.Text);
                float descuento = float.Parse(tb_desc_otro.Text);
                float costoNeto = costoBruto - descuento;

                tb_costoNeto.Text = costoNeto.ToString();
  
                grB_pago.Enabled = true;
            }
            
            limpiarPago();
        }

        private void tb_costoNeto_TextChanged(object sender, EventArgs e)
        {
            tb_deudaFinal.Text = tb_costoNeto.Text;
        }

        private void rb_pago_parte_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_pago_parte.Checked)
            {
                tb_pago_parte.Enabled = true;
                tb_pago_parte.Clear();
                tb_deudaFinal.Text = tb_costoNeto.Text;
            }
            else {
                tb_pago_parte.Enabled = false;
            }
        }

        private void tb_pago_parte_TextChanged(object sender, EventArgs e)
        {
            tb_deudaFinal.Text = tb_costoNeto.Text;
            if (tb_pago_parte.Text.ToString().Length >= 1) {
                float costoNeto = float.Parse(tb_costoNeto.Text);
                float monto = float.Parse(tb_pago_parte.Text);
                float deudaFinal = costoNeto - monto;

                tb_deudaFinal.Text = deudaFinal.ToString();
            }
        }

        private void rb_pago_total_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_pago_total.Checked) {
                tb_deudaFinal.Text = "0";
            }
        }

        private void btn_img_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog1.ShowDialog();
                if (this.openFileDialog1.FileName.Equals("") == false)
                {
                    pb_foto.Load(this.openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la imagen: " + ex.ToString());
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            //para validar la información
            conforme = true;

            string apo_dni = "";
            string apo_apellidos="";
            string apo_nombres="";
            string apo_celular = "";
            //validamos la información ingresada DNI
            if (tb_apo_dni.Text.ToString().Length >= 1)
            {
                

                if (tb_apo_dni.Text.ToString().Length == 8)
                {
                    
                    int num;
                    bool onlyNum = Int32.TryParse(tb_apo_dni.Text.Trim(), out num);

                    if (onlyNum)
                    {
                        apo_dni = tb_apo_dni.Text;
                        
                    }
                    else {
                        MessageBox.Show("El DNI del Apoderado no puede contener letras u otros caracteres que no sean números");
                        conforme = false;
                    }
                }
                else {
                    MessageBox.Show("Numero de DNI del apoderado invalido, número de caracteres tiene que ser 8");
                    conforme = false;
                }
            }
            else {
                MessageBox.Show("Falta ingresar el DNI del Apoderado");
                conforme = false;
            }

            //validamos la información ingresada Apellidos

            if (tb_apo_apell.Text.ToString().Length >= 1)
            {
                apo_apellidos = tb_apo_apell.Text.ToUpper();
                
            }
            else {
                MessageBox.Show("El campo Apellidos del Apoderado no puede ser nulo");
                conforme = false;
            }

            //validamos la información ingresada Nombres

            if (tb_apo_nombres.Text.ToString().Length >= 1)
            {
                apo_nombres = tb_apo_nombres.Text.ToUpper();
                
            }
            else {
                MessageBox.Show("El campo Nombres del Apoderado no puede ser nulo");
                conforme = false;
            }

            //validamos la información ingresada Celular

            if (tb_apo_cel.Text.ToString().Length >= 1)
            {
                if (tb_apo_cel.Text.ToString().Length >= 6) {

                    int num;
                    bool onlyNum = Int32.TryParse(tb_apo_cel.Text.Trim(), out num);

                    if (onlyNum)
                    {
                        apo_celular = tb_apo_cel.Text;
                        
                    }
                    else
                    {
                        MessageBox.Show("El Celular del Apoderado no puede contener letras u otros caracteres que no sean números");
                        conforme = false;
                    }


                }
                else {
                    MessageBox.Show("El celular o telefono del apoderado tiene que tener mínimo 6 caracteres");
                    conforme = false;
                }
            }
            
          

            MApoderado apo = new MApoderado(apo_dni, apo_apellidos, apo_nombres, apo_celular);

            if (conforme) {
                bool registrado = apoderadoAD.registrarApoderado(apo);

                if (registrado) {
                    MessageBox.Show("Apoderado Registrado Correctamente");
                }
            }
                     
                    
           
            
        }
    }
}
