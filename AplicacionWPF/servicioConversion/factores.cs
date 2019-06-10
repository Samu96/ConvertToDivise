using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servicioConversion
{
    public class factores
    {
        public string Origen;
        public string Destino;
        public double valor;

        public factores(string origen, string destino, double valor)
        {
            this.Origen = origen;
            this.Destino = destino;
            this.valor = valor;
        }
    }
}
