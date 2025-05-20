using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio

{
     public class Pokemon
    {
        public int Numero { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public string  UrlImagen { get; set; }

        public Elemento Tipo { get; set; }     //elemento tiene id y descripcion de la clase Elemento
        public Elemento Debilidad  { get; set; }// elemento tiene id y descripcion de la clase Elemento

    }
}
                                        