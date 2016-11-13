using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public class MColegio
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string Distrito { get; set; }
        public string Provincia { get; set; }
        public string Departamento { get; set; }


        public MColegio()
        {
        }

        public MColegio(int _codigo, string _nombre, string _ubicacion, string _distrito, string _provincia, string _departamento)
        {
            Codigo = _codigo;
            Nombre = _nombre;
            Ubicacion = _ubicacion;
            Distrito = _distrito;
            Provincia = _provincia;
            Departamento = _departamento;

        }

    }
    }
