using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public class MCiclo
    {
        public string nombre { get; set; }
        public DateTime inicio { get; set; }
        public DateTime final { get; set; }
        public float primaria { get; set; }
        public float secundaria_a { get; set; }
        public float secundaria_b {get;set;}
        public float pre { get; set; }

        public MCiclo() {

        }

        public MCiclo(string _nombre, DateTime _inicio, DateTime _final, float _primaria, float _secA, float _secB,float _pre)
        {
            nombre = _nombre;
            inicio = _inicio;
            final = _final;
            primaria = _primaria;
            secundaria_a = _secA;
            secundaria_b = _secB;
            pre = _pre;

        }

    }
}
