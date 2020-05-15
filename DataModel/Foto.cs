using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Foto
    {
        public int IDFoto { get; set; }
        public int IDRescate { get; set; }
        public byte [] Imagen { get; set; }
        public string NombreImg { get; set; }
    }
}
