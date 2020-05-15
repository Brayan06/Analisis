using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAAnimal
    {
        public int AgregarAnimal(Animal animal)
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_AGREGAR_ANIMAL", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@COD_ANIMAL", animal.CodigoAnimal));
            _Comand.Parameters.Add(new SqlParameter("@IMAGEN", animal.Imagen));
            _Comand.Parameters.Add(new SqlParameter("@TAMANO", animal.Tamano));
            _Comand.Parameters.Add(new SqlParameter("@EDAD_APROX", animal.EdadAprox));
            _Comand.Parameters.Add(new SqlParameter("@PESO_APROX", animal.PesoAprox));
            _Comand.Parameters.Add(new SqlParameter("@COLOR", animal.Color));
            _Comand.Parameters.Add(new SqlParameter("@ESTADO", animal.Estado));
            _Comand.Parameters.Add(new SqlParameter("@DESCRIPCION", animal.Descripcion));
            _Comand.Parameters.Add(new SqlParameter("@ESPECIE", animal.Especie));
            _Comand.Parameters.Add(new SqlParameter("@FECHA_INGRESO", animal.FechaIngreso));
            _Comand.Parameters.Add(new SqlParameter("@IDUSUARIO", animal.IDUsuario));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return Resultado;
        }

        public int ModificarAnimal(Animal animal)
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_MODIFICAR_ANIMAL", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@COD_ANIMAL", animal.CodigoAnimal));
            _Comand.Parameters.Add(new SqlParameter("@TAMANO", animal.Tamano));
            _Comand.Parameters.Add(new SqlParameter("@EDAD_APROX", animal.EdadAprox));
            _Comand.Parameters.Add(new SqlParameter("@PESO_APROX", animal.PesoAprox));
            _Comand.Parameters.Add(new SqlParameter("@COLOR", animal.Color));
            _Comand.Parameters.Add(new SqlParameter("@ESTADO", animal.Estado));
            _Comand.Parameters.Add(new SqlParameter("@DESCRIPCION", animal.Descripcion));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return Resultado;
        }

        public int EliminarAnimal(Animal animal)
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_ELIMINAR_ANIMAL", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@COD_ANIMAL", animal.CodigoAnimal));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return Resultado;
        }

        public Animal BuscarAnimal(string _cod)
        {
            Animal animal= new Animal();
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_BUSCAR_ANIMAL", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@COD_ANIMAL", _cod));
            IDataReader _reader = _Comand.ExecuteReader();
            while (_reader.Read())
            {
                animal.CodigoAnimal = _reader.GetString(0);
                animal.Imagen= (byte[])_reader.GetValue(1);
                animal.Tamano = _reader.GetString(2);
                animal.EdadAprox= _reader.GetString(3);
                animal.PesoAprox= _reader.GetString(4);
                animal.Color= _reader.GetString(5);
                animal.Estado = _reader.GetString(6);
                animal.Descripcion = _reader.GetString(7);
                animal.Especie = _reader.GetString(8);
                animal.FechaIngreso = Convert.ToDateTime(_reader.GetValue(9));
            }
            _conn.Close();
            return animal;
        }

        public List<Animal> ConsultarAnimales() {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_CONSULTAR_ANIMAL", _conn as SqlConnection);
            IDataReader _reader = _Comand.ExecuteReader();
            List<Animal> _list = new List<Animal>();
            while (_reader.Read()) {
                Animal animal = new Animal();
                animal.CodigoAnimal = _reader.GetString(0);
                animal.Imagen = (byte[])_reader.GetValue(1);
                animal.Tamano = _reader.GetString(2);
                animal.EdadAprox = _reader.GetString(3);
                animal.PesoAprox = _reader.GetString(4);
                animal.Color = _reader.GetString(5);
                animal.Estado = _reader.GetString(6);
                animal.Descripcion = _reader.GetString(7);
                animal.Especie = _reader.GetString(8);
                animal.FechaIngreso = Convert.ToDateTime(_reader.GetValue(9));
                _list.Add(animal);
            }
            _conn.Close();
            return _list;
        }

        public List<Animal> CargarAnimales()
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_CARGAR_ANIMALES", _conn as SqlConnection);
            IDataReader _reader = _Comand.ExecuteReader();
            List<Animal> _list = new List<Animal>();
            while (_reader.Read())
            { 
            Animal animal = new Animal();
            animal.CodigoAnimal = _reader.GetString(0);
            animal.Imagen = (byte[])_reader.GetValue(1);
            animal.Estado = _reader.GetString(2);
            animal.Especie = _reader.GetString(3);
            _list.Add(animal);
            }
            _conn.Close();
            return _list;
        }
    }
}
