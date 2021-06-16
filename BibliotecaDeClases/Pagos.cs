using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClases
{
    public class Pagos
    {
        public string NumPago { get; set; }
        public string ID_Colaborador { get; set; }
        public string Concepto { get; set; }
        public string Fecha { get; set; }
        public double Cantidad { get; set; }
    }
}
