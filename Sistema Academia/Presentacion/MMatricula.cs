using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public class MMatricula
    {
        public string Codigo { get; set; }
        public string Nivel { get; set; }
        public int Grado { get; set; }
        public float Costo { get; set; }
        public float Deuda { get; set; }
        public string Tipo_De_Descuento { get; set; }
        public float Descuento { get; set; }

        public MMatricula() {
        }

        public MMatricula(string codigo,string nivel, int grado, float costo, float deuda,string tipoDescuento, float descuento)
        {
            Codigo = codigo;
            Nivel = nivel;
            Grado = grado;
            Costo = costo;
            Deuda = deuda;
            Tipo_De_Descuento = tipoDescuento;
            Descuento = descuento;
        }
    }
}
