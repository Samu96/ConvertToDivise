using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dom;

namespace servicioConversion
{
    public class servicio
    {

        List<factores> factores = new List<factores>();
        public double convertir(string Origen, string destino, double valor)
        {
            if (Origen.Equals(destino)) {
                return 1*valor;
            }
        
            factores f = factores.First(c => c.Origen == Origen && c.Destino == destino);
            return valor * f.valor;
            
        }

        public void crearMonedasCambios()
        {
            factores euro1 = new factores("EUR", "GBP", 0.89);
            factores euro2 = new factores("EUR", "USD", 1.13);
            factores euro3 = new factores("EUR", "CNY", 7.77);


            factores dolar1 = new factores("USD", "EUR", 0.89);
            factores dolar2 = new factores("USD", "GBP", 0.79);
            factores dolar3 = new factores("USD", "CNY", 6.91);

            factores libra1 = new factores("GBP", "EUR", 1.12);
            factores libra2 = new factores("GBP", "USD", 1.27);
            factores libra3 = new factores("GBP", "CNY", 8.77);

            factores yen1 = new factores("CNY", "EUR", 0.13);
            factores yen2 = new factores("CNY", "USD", 0.89);
            factores yen3 = new factores("CNY", "GBP", 0.14);

            factores.Add(euro1);
            factores.Add(euro2);
            factores.Add(euro3);

            factores.Add(dolar1);
            factores.Add(dolar2);
            factores.Add(dolar3);

            factores.Add(libra1);
            factores.Add(libra2);
            factores.Add(libra3);

            factores.Add(yen1);
            factores.Add(yen2);
            factores.Add(yen3);
        }
        public void ObtenerMonedasCambios()
        {
            
        }
        public List<Moneda> obtenerMonedas()
        {
            return new Dominion().fileMonedas();
        }
    }
}
