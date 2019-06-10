using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom
{
    public class Moneda
    {
        public string Id { get; set; }
        public string nombre { get; set; }
        public Moneda(string id , string nombre)
        {
            this.Id = id;
            this.nombre = nombre;
        }
        public override string ToString()
        {
            return Id;
        }
    }
}
