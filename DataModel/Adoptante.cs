using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Adoptante
    {
        public int IDAdoptante { get; set; }
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string CodigoAnimal { get; set; }
        public string EstadoCalificacion { get; set; }
        public int IDUsuario { get; set; }
    }
}
