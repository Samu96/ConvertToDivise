using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dom
{
    public class Dominion
    {
        public List<Moneda> Monedas()
        {
            List<Moneda> devolver = new List<Moneda>();
            devolver.Add(new Moneda("EUR","Europa"));
            devolver.Add(new Moneda("USD","America"));
            devolver.Add(new Moneda("GBP","Europa"));
            devolver.Add(new Moneda("CNY","Japon"));
            return devolver;
        }
        public List<Moneda> fileMonedas()
        {
            var query = File.ReadAllLines("C:\\Users\\sdprodriguez\\source\\repos\\AplicacionWPF\\Dom\\monedero.csv").Skip(0).Where(l => l.Length > 1).ToMoneda();
            return query.ToList();
        }
    }
    public static class CarExtensions
    {
        public static IEnumerable<Moneda> ToMoneda(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Moneda(
                    columns[0],
                    columns[1]
                );
            }
        }
    }
}
