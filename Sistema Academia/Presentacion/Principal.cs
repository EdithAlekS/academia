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
        String ciclo { get; set; }
        public Principal(string nom_ciclo)
        {
            ciclo = nom_ciclo;
            InitializeComponent();

            llenarCamposPorDefecto();
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
            sexos.Add("Masculido");
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
    }
}
