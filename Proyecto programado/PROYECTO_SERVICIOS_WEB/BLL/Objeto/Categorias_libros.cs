using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Objeto
{
    public class Categorias_libros
    {
        public string id { get; set; }
        public string categoria { get; set; }

        public Categorias_libros() { }

        public Categorias_libros(string id, string categoria)
        {
            this.id = id;
            this.categoria = categoria;
        }
    }
}
