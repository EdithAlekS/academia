using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public class MApoderado
    {
        public string Dni { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Celular { get; set; }

        public MApoderado() {
        }
        public MApoderado(string _dni, string _apellidos, string _nombres, string _celular)
        {
            Dni = _dni;
            Apellidos = _apellidos;
            Nombres = _nombres;
            Celular = _celular;
        }

    }
}
