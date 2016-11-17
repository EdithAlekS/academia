using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public class MEstudiante
    {
        public string Dni { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public DateTime Nacimiento { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        
        public string Excelencia { get; set; }
        public string OtroReconocimiento { get; set; }
      

        public MEstudiante() {

        }
        public MEstudiante(string _dni, string _apellidos, string _nombres, string _sexo, int _edad, DateTime _nacimiento, string _celular, string _direccion, PictureBox _foto, string _excelencia, string _otroRec)
        {
            Dni = _dni;
            Apellidos= _apellidos;
            Nombres = _nombres;
            Sexo= _sexo;
            Edad= _edad;
            Nacimiento= _nacimiento;
            Celular = _celular;
            Direccion = _direccion;
            Excelencia = _excelencia;
            OtroReconocimiento = _otroRec;
            
    }
        

    }

   
}
