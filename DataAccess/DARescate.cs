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
    public class DARescate
    {
        
        public int AgregarRescate(Rescate rescate) {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_AGREGAR_RESCATE", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@COD_ANIMAL", rescate.CodigoAnimal));
            _Comand.Parameters.Add(new SqlParameter("@LUGAR_RESCATE", rescate.LugarRescate));
            _Comand.Parameters.Add(new SqlParameter("@FECHA_RESCATE", rescate.FechaRescate));
            _Comand.Parameters.Add(new SqlParameter("@ESPECIE", rescate.EspecieAnimal));
            _Comand.Parameters.Add(new SqlParameter("@DESCRIPCION", rescate.Descripcion));
            _Comand.Parameters.Add(new SqlParameter("@NOMBRE_REPORTE", rescate.NombreQuienReporta));
            _Comand.Parameters.Add(new SqlParameter("@IDUSUARIO", rescate.IDUsuario));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return Resultado;
        }

        public int AgregarImagenRescate(Foto foto)
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_AGREGAR_FOTO_RESCATE", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@IDRESCATE", foto.IDRescate));
            _Comand.Parameters.Add(new SqlParameter("@NOMBRE_IMG", foto.NombreImg));
            _Comand.Parameters.Add(new SqlParameter("@FOTO", foto.Imagen));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return Resultado;
        }

        public List<Foto> ObtenerFotos(string _cod)
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_OBTENER_IMAGENES", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@COD_ANIMAL", _cod));
            IDataReader _reader = _Comand.ExecuteReader();
            List<Foto> _list = new List<Foto>();
            if (_reader.Read())
            {
                Foto _foto = new Foto();
                _foto.IDFoto = _reader.GetInt32(0);
                _foto.IDRescate = _reader.GetInt32(1);
                _foto.Imagen = (byte[])_reader.GetValue(2);
                _foto.NombreImg = _reader.GetString(3);
                _list.Add(_foto);
            }
            return _list;
        }

        public int ObtenerIDRescate()
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_CONTAR_RESCATES", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _Comand.ExecuteReader();
            int pk = 0;
            if (_reader.Read())
            {
                pk = _reader.GetInt32(0);
                return pk;
            }
            return pk;
        }


            public int ModificarRescate(Rescate rescate)
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_MODIFICAR_RESCATES", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@COD_ANIMAL", rescate.CodigoAnimal));
            _Comand.Parameters.Add(new SqlParameter("@DESCRIPCION", rescate.Descripcion));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return Resultado;
        }

        public int EliminarRescate(Rescate rescate)
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_ELIMINAR_USUARIO", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@COD_ANIMAL", rescate.CodigoAnimal));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return Resultado;
        }

        public Rescate ConsultarRescate(string _cod)
        {
            Rescate rescate = new Rescate();
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_CONSULTAR_RESCATE", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@COD_ANIMAL", _cod));
            IDataReader _reader = _Comand.ExecuteReader();
            while (_reader.Read())
            {
                rescate.IDRescate = _reader.GetInt32(0);
                rescate.CodigoAnimal = _reader.GetString(1);
                rescate.LugarRescate = _reader.GetString(2);
                rescate.FechaRescate = Convert.ToDateTime(_reader.GetValue(3));
                rescate.EspecieAnimal= _reader.GetString(4);
                rescate.Descripcion = _reader.GetString(5);
                rescate.NombreQuienReporta= _reader.GetString(6);
            }
            _conn.Close();
            return rescate;
        }

        public Foto ObtenerImagenPorNombre(string nombre) {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_OBTENER_IMAGEN_POR_NOMBRE", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
            IDataReader _reader = _Comand.ExecuteReader();
            Foto foto = new Foto();
            while (_reader.Read())
            {
                foto.IDFoto = _reader.GetInt32(0);
                foto.IDRescate = _reader.GetInt32(1);
                foto.Imagen = (byte[])_reader.GetValue(2);
                foto.NombreImg = _reader.GetString(3);
            }
            _conn.Close();
            return foto;
        }
    }
}
