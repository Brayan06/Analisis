using DataAccess;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{
    public class DLAnimal
    {
        DAAnimal _daa = new DAAnimal();

        public int AgregarAnimal(Animal animal)
        {
            return _daa.AgregarAnimal(animal);
        }

        public int ModificarAnimal(Animal animal)
        {
            return _daa.ModificarAnimal(animal);
        }

        public int EliminarAnimal(Animal animal)
        {
            return _daa.EliminarAnimal(animal);
        }

        public Animal BuscarAnimal(string cod_animal)
        {
            return _daa.BuscarAnimal(cod_animal);
        }

        public List<Animal> ConsultarAnimales() {
            return _daa.ConsultarAnimales();
        }

        public List<Animal> CargarAnimales() {
            return _daa.CargarAnimales();
        }
    }
}
