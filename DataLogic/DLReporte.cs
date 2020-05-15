using DataAccess;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{
    public class DLReporte
    {
        DAReporte _dar = new DAReporte();
        public List<Animal> LlenarGridPorCod(string _cod)
        {
            return _dar.LlenarGridPorCod(_cod);
        }

        public List<Animal> LlenarGridPorFecha()
        {
            return _dar.LlenarGridPorFecha();
        }

        public List<Animal> LlenarGridPorEspecie(string especie)
        {
            return _dar.LlenarGridPorEspecie(especie);
        }

        public List<Animal> LlenarGridGeneral()
        {
            return _dar.LlenarGridGeneral();
        }
    }
}
