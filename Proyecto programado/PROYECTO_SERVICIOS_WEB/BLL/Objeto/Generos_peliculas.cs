using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Objeto
{
    public class Generos_peliculas
    {
        public string id { get; set; }
        public string genero { get; set; }

        public Generos_peliculas() { }

        public Generos_peliculas(string id, string genero)
        {
            this.id = id;
            this.genero = genero;
        }
    }
}
