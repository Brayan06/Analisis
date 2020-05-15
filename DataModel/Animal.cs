using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Animal
    {
        public string CodigoAnimal { get; set; }

        public byte[] Imagen { get; set; }
        public string Tamano { get; set; }
        public string EdadAprox { get; set; }
        public string PesoAprox { get; set; }
        public string Color { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public string Especie { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int IDUsuario { get; set; }
    }
}
