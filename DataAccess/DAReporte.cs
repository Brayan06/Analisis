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
    public class DAReporte
    {
        public List<Animal> LlenarGridPorCod(string _cod) {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_LLENAR_GRID_POR_COD", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@COD", _cod));
            IDataReader _reader = _Comand.ExecuteReader();
            List<Animal> _list = new List<Animal>();
            while (_reader.Read())
            {
                Animal animal = new Animal();
                animal.CodigoAnimal = _reader.GetString(0);
                animal.Tamano = _reader.GetString(1);
                animal.EdadAprox = _reader.GetString(2);
                animal.PesoAprox = _reader.GetString(3);
                animal.Color = _reader.GetString(4);
                animal.Estado = _reader.GetString(5);
                animal.Descripcion = _reader.GetString(6);
                animal.Especie = _reader.GetString(7);
                animal.FechaIngreso = Convert.ToDateTime(_reader.GetValue(8));
                _list.Add(animal);
            }
            _conn.Close();
            return _list;
        }

        public List<Animal> LlenarGridGeneral()
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_LLENAR_GRID_GENERAL", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _Comand.ExecuteReader();
            List<Animal> _list = new List<Animal>();
            while (_reader.Read())
            {
                Animal animal = new Animal();
                animal.CodigoAnimal = _reader.GetString(0);
                animal.Tamano = _reader.GetString(1);
                animal.EdadAprox = _reader.GetString(2);
                animal.PesoAprox = _reader.GetString(3);
                animal.Color = _reader.GetString(4);
                animal.Estado = _reader.GetString(5);
                animal.Descripcion = _reader.GetString(6);
                animal.Especie = _reader.GetString(7);
                animal.FechaIngreso = Convert.ToDateTime(_reader.GetValue(8));
                _list.Add(animal);
            }
            _conn.Close();
            return _list;
        }

        public List<Animal> LlenarGridPorEspecie(string especie)
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_LLENAR_GRID_POR_ESPECIE", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@ESPECIE", especie));
            IDataReader _reader = _Comand.ExecuteReader();
            List<Animal> _list = new List<Animal>();
            while (_reader.Read())
            {
                Animal animal = new Animal();
                animal.CodigoAnimal = _reader.GetString(0);
                animal.Tamano = _reader.GetString(1);
                animal.EdadAprox = _reader.GetString(2);
                animal.PesoAprox = _reader.GetString(3);
                animal.Color = _reader.GetString(4);
                animal.Estado = _reader.GetString(5);
                animal.Descripcion = _reader.GetString(6);
                animal.Especie = _reader.GetString(7);
                animal.FechaIngreso = Convert.ToDateTime(_reader.GetValue(8));
                _list.Add(animal);
            }
            _conn.Close();
            return _list;
        }

        public List<Animal> LlenarGridPorFecha()
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_LLENAR_GRID_POR_FECHA", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _Comand.ExecuteReader();
            List<Animal> _list = new List<Animal>();
            while (_reader.Read())
            {
                Animal animal = new Animal();
                animal.CodigoAnimal = _reader.GetString(0);
                animal.Tamano = _reader.GetString(1);
                animal.EdadAprox = _reader.GetString(2);
                animal.PesoAprox = _reader.GetString(3);
                animal.Color = _reader.GetString(4);
                animal.Estado = _reader.GetString(5);
                animal.Descripcion = _reader.GetString(6);
                animal.Especie = _reader.GetString(7);
                animal.FechaIngreso = Convert.ToDateTime(_reader.GetValue(8));
                _list.Add(animal);
            }
            _conn.Close();
            return _list;
        }
    }
}
