using DataAccess;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{
    public class DLRescate
    {
        DARescate _dar = new DARescate();

        public int AgregarRescate(Rescate rescate) {
            return _dar.AgregarRescate(rescate);
        }

        public int ModificarRescate(Rescate rescate) {
            return _dar.ModificarRescate(rescate);
        }

        public int EliminarRescate(Rescate rescate) {
            return _dar.EliminarRescate(rescate);
        }

        public Rescate ConsultarRescate(string cod) {
            return _dar.ConsultarRescate(cod);
        }

        public int AgregarImagenRescate(Foto foto)
        {
            return _dar.AgregarImagenRescate(foto);
        }

        public int ObtenerIDRescate() {
            return _dar.ObtenerIDRescate();
        }

        public List<Foto> ObtenerFotos(string _cod)
        {
            return _dar.ObtenerFotos(_cod);
        }

        public Foto ObtenerImagenPorNombre(string nombre) {
            return _dar.ObtenerImagenPorNombre(nombre);
        }
    }
}
