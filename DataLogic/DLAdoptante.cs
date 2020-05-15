using DataAccess;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{
    public class DLAdoptante
    {
        DAAdoptante _daa = new DAAdoptante();
        public int AgregarAdoptante(Adoptante adoptante)
        {
            return _daa.AgregarAdoptante(adoptante);
        }
        public int ModificarAdoptante(Adoptante adoptante)
        {
            return _daa.ModificarAdoptante(adoptante);
        }

        public int EliminarAdoptante(Adoptante adoptante)
        {
            return _daa.EliminarAdoptante(adoptante);
        }

        public List<Adoptante> ConsultarAdoptantes()
        {
            return _daa.ConsultarAdoptantes();
        }

        public Adoptante BuscarAdoptante(string _adop)
        {
            return _daa.BuscarAdoptante(_adop);
        }
    }
}
