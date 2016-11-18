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
        static ADColegio colegioAD = new ADColegio();
        static ADEstudiante estudianteAD = new ADEstudiante();
        static ADMatricula matriculaAD = new ADMatricula();
        String ciclo { get; set; }
        MCiclo cicloActual = new MCiclo();
        bool nuevoApoderado = true;
        bool nuevoEstudiante = true;
        bool nuevoColegio = true;

        static bool conforme = false;

        public Principal(string nom_ciclo)
        {
            ciclo = nom_ciclo;
            InitializeComponent();

            obtenerDetalleDeCiclo();
            llenarCamposPorDefecto();

            colegioAD.autocompletarColegio(tb_nombre_ie);

            //obtener nombre de la matricula
            tb_codigoMatricula.Text = matriculaAD.obtenerCodigo(ciclo);
        }

        private void obtenerDetalleDeCiclo()
        {
            cicloActual = cicloAD.obtenerCiclo(ciclo);
        }

        private void llenarCamposPorDefecto()
        {
            //creamos y llenamos valores de la lista niveles
            List<String> niveles = new List<string>();
            niveles.Add("PRIMARIA");
            niveles.Add("SECUNDARIA");
            niveles.Add("PRE - UNIVERSITARIO");

            //asignamos lista al combo de nivel
            cb_nivel.DataSource = niveles;
            cb_nivel.SelectedItem = "PRE - UNIVERSITARIO";

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
            sexos.Add("MASCULINO");
            sexos.Add("FEMENINO");

            //asignamos lista al combo de sexo
            cb_sexo_estudiante.DataSource = sexos;

            //asignamos un año por deencot en fecha de nacimiento, son 15 menos del actual
            DateTime fecha = dtp_nac_estudiante.Value.AddYears(-15);
            dtp_nac_estudiante.Value = fecha;

            //asignamos imagen de usuairo por defecto
            pb_foto.Load(@"imagenes/masculino.jpg");

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



        }

        private void tb_apo_dni_TextChanged(object sender, EventArgs e)
        {
            limpiarCamposApoderado();

            if (tb_apo_dni.Text.ToString().Length == 8) {

                MApoderado apo = apoderadoAD.buscarApoderado(tb_apo_dni.Text);

                //apoderado encontrado
                if (apo != null)
                {
                    nuevoApoderado = false;

                    tb_apo_apell.Text = apo.Apellidos;
                    tb_apo_nombres.Text = apo.Nombres;
                    tb_apo_cel.Text = apo.Celular;
                }
                else {
                    nuevoApoderado = true;
                  
                   
                }
            }
        }

        private void limpiarCamposApoderado()
        {
            tb_apo_apell.Clear();
            tb_apo_nombres.Clear();
            tb_apo_cel.Clear();
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            //codigo temporal, mover luego al registro correcto

            //para validar la información
            conforme = true;

            string apo_dni = "";
            string apo_apellidos = "";
            string apo_nombres = "";
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
                    else
                    {
                        MessageBox.Show("El DNI del Apoderado no puede contener letras u otros caracteres que no sean números");
                        conforme = false;
                    }
                }
                else
                {
                    MessageBox.Show("Numero de DNI del apoderado invalido, número de caracteres tiene que ser 8");
                    conforme = false;
                }
            }
            else
            {
                MessageBox.Show("Falta ingresar el DNI del Apoderado");
                conforme = false;
            }

            //validamos la información ingresada Apellidos

            if (tb_apo_apell.Text.ToString().Length >= 1)
            {
                apo_apellidos = tb_apo_apell.Text.ToUpper();

            }
            else
            {
                MessageBox.Show("El campo Apellidos del Apoderado no puede ser nulo");
                conforme = false;
            }

            //validamos la información ingresada Nombres

            if (tb_apo_nombres.Text.ToString().Length >= 1)
            {
                apo_nombres = tb_apo_nombres.Text.ToUpper();

            }
            else
            {
                MessageBox.Show("El campo Nombres del Apoderado no puede ser nulo");
                conforme = false;
            }

            //validamos la información ingresada Celular

            if (tb_apo_cel.Text.ToString().Length >= 1)
            {
                if (tb_apo_cel.Text.ToString().Length >= 6)
                {

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
                else
                {
                    MessageBox.Show("El celular o telefono del apoderado tiene que tener mínimo 6 caracteres");
                    conforme = false;
                }
            }



            

            if (conforme)
            {

                MApoderado apo = new MApoderado(apo_dni, apo_apellidos, apo_nombres, apo_celular);

                if (nuevoApoderado)
                {
                    bool registrado = apoderadoAD.registrarApoderado(apo);

                    if (registrado)
                    {
                        MessageBox.Show("Apoderado Registrado Correctamente");
                        limpiarCamposApoderado();
                    }
                    else
                    {
                        MessageBox.Show("Error al Registrar datos de Apoderado");
                        conforme = false;
                    }
                }
                else {
                    //Se editan todos los datos de apoderado
                    limpiarCamposApoderado();
                }
                
            }

            //registro del colegio

            string col_nombre = "";
            string col_direccion = "";
            string col_distrito = "";
            string col_provincia = "";
            string col_departamento = "";

            //validamos informacion Colegio: nombre
            if (tb_nombre_ie.Text.ToString().Length >= 1)
            {
                col_nombre = tb_nombre_ie.Text.ToUpper();
            }
            else
            {
                MessageBox.Show("El campo nombre de Institución Educativa no puede estar vacio");
                conforme = false;
            }

            //validamos informacion Colegio: dirección
            if (tb_dir_ie.Text.ToString().Length >= 1)
            {
                col_direccion = tb_dir_ie.Text.ToUpper();
            }

            //validamos informacion Colegio: distrito 
            if (tb_distrito_ie.Text.ToString().Length >= 1)
            {
                col_distrito = tb_distrito_ie.Text.ToUpper();
            }

            //validamos informacion Colegio: provincia 
            if (tb_provincia_ie.Text.ToString().Length >= 1)
            {
                col_provincia = tb_provincia_ie.Text.ToUpper();
            }

            //validamos informacion Colegio: departamento 
            if (tb_dep_ie.Text.ToString().Length >= 1)
            {
                col_departamento = tb_dep_ie.Text.ToUpper();
            }


            if (conforme)
            {
                MColegio col = new MColegio(0, col_nombre, col_direccion, col_distrito, col_provincia, col_departamento);
                if (nuevoColegio)
                {
                    bool registrado = colegioAD.registrarColegio(col);

                    if (registrado)
                    {
                        //mesaje de prueba temporar (eliminarrr)
                        MessageBox.Show("Colegio Registrado");
                        limpiarCamposColegio();
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar colegio");
                        conforme = false;
                    }
                } 
                else
                {
                    //Solo se modifican los datos
                    limpiarCamposColegio();
                }

            }


            //registro del estudiante

            string est_dni = "";
            string est_apellidos = "";
            string est_nombres = "";
            int est_edad = 0;
            string est_sexo = "";
            DateTime est_fecha;
            string est_celular = "";
            string est_direccion = "";
            string est_premio = "NO";
            string est_otroRec = "";

            //validadción para el campo DNI del estudiante

            if (tb_dniEstudiante.Text.ToString().Length >= 1)
            {
                if (tb_dniEstudiante.Text.ToString().Length == 8)
                {
                    int num;
                    bool onlyNum = Int32.TryParse(tb_dniEstudiante.Text.Trim(), out num);

                    if (onlyNum)
                    {
                        est_dni = tb_dniEstudiante.Text;
                    }
                    else
                    {
                        MessageBox.Show("El campo DNI solo permite valores numericos");
                        conforme = false;
                    }
                }
                else
                {
                    MessageBox.Show("El campo DNI tiene que tener 8 caracteres");
                    conforme = false;
                }
            }
            else
            {

                MessageBox.Show("El campo DNI no puede ser vacio");
                conforme = false;
            }


            //validando campo de apellidos del Estudiante

            if (tb_apell_estudiante.Text.ToString().Length >= 1)
            {
                est_apellidos = tb_apell_estudiante.Text;
            }
            else
            {
                MessageBox.Show("El campo Apellidos del Estudiante no puede estar vacio");
                conforme = false;
            }


            //validando campo de nombres del Estudiante

            if (tb_nom_estudiante.Text.ToString().Length >= 1)
            {
                est_nombres = tb_nom_estudiante.Text;
            }
            else
            {

                MessageBox.Show("El campo Nombres del Esudiante no puede estar vacio");
                conforme = false;
            }

            //Validando campo edad del Estudiante
            if (tb_edad_estudiante.Text.ToString().Length >= 1)
            {

                int num;
                bool onlyNum = Int32.TryParse(tb_edad_estudiante.Text.Trim(), out num);
                if (onlyNum)
                {
                    if (num >= 5)
                    {
                        est_edad = num;
                    }
                    else
                    {
                        MessageBox.Show("El estudiante es aún muy joven para ser aceptado");
                        conforme = false;
                    }

                }
                else
                {
                    MessageBox.Show("El campo edad solo acepta valores numéricos");
                    conforme = false;
                }
            }


            //guardando vvalor de sexo
            est_sexo = cb_sexo_estudiante.SelectedText;

            //Guardando fehca de nacimiento

            est_fecha = dtp_nac_estudiante.Value;

            //validando campo celular del estudiante
            if (tb_cel_estudiante.Text.ToString().Length >= 1)
            {
                if (tb_cel_estudiante.Text.ToString().Length >= 6 && tb_cel_estudiante.Text.ToString().Length <= 9)
                {
                    int cel;
                    bool onlyNum = Int32.TryParse(tb_cel_estudiante.Text.Trim(), out cel);

                    if (onlyNum)
                    {
                        est_celular = tb_cel_estudiante.Text;
                    }
                    else
                    {
                        MessageBox.Show("El campo celular solo acepta valores numéricos");
                    }
                }
                else
                {
                    MessageBox.Show("El campo Celular ´tiene que tener entre 6 y 9 caracteres");
                    conforme = false;
                }
            }

            //Guardando dirección
            if (tb_dir_estudiante.Text.ToString().Length >= 1)
            {
                est_direccion = tb_dir_estudiante.Text;
            }


            //guardando valor premio de exelencia
            if (checkB_premioexce_estudiante.Checked)
            {
                est_premio = "SI";
            }

            //guardando valor de otro reconocimiento de estudiante
            if (chekB_otroRec_estudiante.Checked)
            {
                if (tb_otroRec_estudiante.Text.ToString().Length >= 1)
                {
                    est_otroRec = tb_otroRec_estudiante.Text;
                }
                else
                {
                    MessageBox.Show("No ha ingresado ningun valor a otro reconocimiento, que no sea premio de excelencia");
                }

            }

            //validad registro de estudiante

            if (conforme)
            {

                MEstudiante temp_est = new MEstudiante(est_dni, est_apellidos, est_nombres, est_sexo, est_edad, est_fecha, est_celular, est_direccion, est_premio, est_otroRec);
                MApoderado temp_apo = apoderadoAD.buscarApoderado(tb_apo_dni.Text);
                MColegio temp_col = colegioAD.buscarColegio(tb_nombre_ie.Text);

                if (nuevoEstudiante)
                {
                    //registramos al estudiante con los datos de apoderado y colegio diferentes
                    bool registrado = estudianteAD.agregarEstudiante(temp_est, temp_apo, temp_col, pb_foto);
                    if (!registrado)
                    {
                        MessageBox.Show("error al registrar Estudiante");
                        conforme = false;
                    }
                    else {
                        limpiarCamposEstudiante();
                    }
                }
                else
                {
                    //Se editan los datos del estudiante (por trabajar)
                }
            }



        }

        private void limpiarCamposEstudiante()
        {
           
            tb_apell_estudiante.Clear();
            tb_nom_estudiante.Clear();
            tb_edad_estudiante.Clear();
            tb_cel_estudiante.Clear();
            tb_dir_estudiante.Clear();
            checkB_premioexce_estudiante.Checked = false;
            chekB_otroRec_estudiante.Checked = false;
            tb_otroRec_estudiante.Clear();

            tb_nombre_ie.Clear();
            tb_apo_dni.Clear();
        }

        private void tb_nombre_ie_TextChanged(object sender, EventArgs e)
        {
            limpiarCamposColegio();
            if (tb_nombre_ie.Text.ToString().Length >= 1) {
                MColegio colBuscado = colegioAD.buscarColegio(tb_nombre_ie.Text);

                if (colBuscado != null)
                {
                    nuevoColegio = false;

                    //lleno campos con información del colegio
                    tb_dir_ie.Text = colBuscado.Ubicacion;
                    tb_distrito_ie.Text = colBuscado.Distrito;
                    tb_provincia_ie.Text = colBuscado.Provincia;
                    tb_dep_ie.Text = colBuscado.Departamento;
                }
                else {
                    nuevoColegio = true;
                }
            }

            
        }

        private void limpiarCamposColegio()
        {
            tb_dir_ie.Clear();
            tb_distrito_ie.Clear();
            tb_provincia_ie.Clear();
            tb_dep_ie.Clear();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
           
            
        }

        private void tb_dniEstudiante_TextChanged(object sender, EventArgs e)
        {
            limpiarCamposEstudiante();
            pb_foto.Load(@"imagenes/masculino.jpg");
            //si ya se ingreso el DNI completamente

            if (tb_dniEstudiante.Text.ToString().Length == 8) {
                MEstudiante est_temp = estudianteAD.buscarEstudiantePorDni(tb_dniEstudiante.Text);

                //llenamos campos de estudiante
                if (est_temp != null)
                {
                    string nombreColegio = estudianteAD.buscarColegioAsinadoEstudiante(tb_dniEstudiante.Text);
                    string dniApoderado = estudianteAD.buscarApoderadoAsignadoEstudiante(tb_dniEstudiante.Text);
                    llenarCamposDeEstudiante(est_temp, nombreColegio, dniApoderado);
                }
                else {
                   
                }
            }
        }

        private void llenarCamposDeEstudiante(MEstudiante est_temp, string nombreColegio, string dniApoderado)
        {
            limpiarCamposEstudiante();

            tb_apell_estudiante.Text = est_temp.Apellidos.ToString();
            tb_nom_estudiante.Text = est_temp.Nombres.ToString();
            tb_edad_estudiante.Text = est_temp.Edad.ToString();
            cb_sexo_estudiante.SelectedItem = est_temp.Sexo.ToString();
            dtp_nac_estudiante.Value = est_temp.Nacimiento;
            tb_cel_estudiante.Text = est_temp.Celular.ToString();
            tb_dir_estudiante.Text = est_temp.Direccion.ToString();

            //llenamos los check
            if (est_temp.Excelencia.ToString() == "SI") {
                checkB_premioexce_estudiante.Checked = true;
            }

            if (est_temp.OtroReconocimiento.ToString() != "") {
                chekB_otroRec_estudiante.Checked = true;
                chekB_otroRec_estudiante.Text = est_temp.OtroReconocimiento.ToString();
            }

            //llenamos datos en colegio y apoderado
            tb_nombre_ie.Text = nombreColegio;
            tb_apo_dni.Text = dniApoderado;

            //actualizar picture vox
            estudianteAD.verImagen(pb_foto,est_temp.Dni.ToString());
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }
    }
}
