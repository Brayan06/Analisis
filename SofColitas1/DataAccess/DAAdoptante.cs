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
    public class DAAdoptante
    {
        public int AgregarAdoptante(Adoptante adoptante)
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_AGREGAR_ADOPTANTE", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@CEDULA", adoptante.Cedula));
            _Comand.Parameters.Add(new SqlParameter("@NOMBRE_COMPLETO", adoptante.NombreCompleto));
            _Comand.Parameters.Add(new SqlParameter("@TELEFONO", adoptante.Telefono));
            _Comand.Parameters.Add(new SqlParameter("@CORREO", adoptante.Correo));
            _Comand.Parameters.Add(new SqlParameter("@DIRECCION", adoptante.Direccion));
            _Comand.Parameters.Add(new SqlParameter("@CODIGO_ANIMAL", adoptante.CodigoAnimal));
            _Comand.Parameters.Add(new SqlParameter("@ESTADO", adoptante.EstadoCalificacion));
            _Comand.Parameters.Add(new SqlParameter("@IDUSUARIO", adoptante.IDUsuario));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return Resultado;
        }

        public List<Adoptante> ConsultarAdoptantes()
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_CONSULTAR_ADOPTANTES", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _Comand.ExecuteReader();
            List<Adoptante> _list = new List<Adoptante>();
            while (_reader.Read())
            {
                Adoptante adoptante = new Adoptante();
                adoptante.IDAdoptante = _reader.GetInt32(0);
                adoptante.Cedula = _reader.GetString(1);
                adoptante.NombreCompleto = _reader.GetString(2);
                adoptante.Telefono = _reader.GetString(3);
                adoptante.Correo = _reader.GetString(4);
                adoptante.Direccion = _reader.GetString(5);
                adoptante.CodigoAnimal = _reader.GetString(6);
                adoptante.EstadoCalificacion = _reader.GetString(7);
                adoptante.IDUsuario = _reader.GetInt32(8);
                _list.Add(adoptante);
            }
            _conn.Close();
            return _list;
        }

        public int ModificarAdoptante(Adoptante adoptante)
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_MODIFICAR_ADOPTANTE", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@TELEFONO", adoptante.Telefono));
            _Comand.Parameters.Add(new SqlParameter("@DIRECCION", adoptante.Direccion));
            _Comand.Parameters.Add(new SqlParameter("@CORREO", adoptante.Correo));
            _Comand.Parameters.Add(new SqlParameter("@ESTADO", adoptante.EstadoCalificacion));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return Resultado;
        }

        public int EliminarAdoptante(Adoptante adoptante)
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_ELIMINAR_ADOPTANTE", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@CEDULA", adoptante.Cedula));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return Resultado;
        }

        public Adoptante BuscarAdoptante(string _adop)
        {
            Adoptante adoptante= new Adoptante();
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_BUSCAR_ADOPTANTE", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@USERNAME", _adop));
            IDataReader _reader = _Comand.ExecuteReader();
            while (_reader.Read())
            {
                adoptante.IDAdoptante = _reader.GetInt32(0);
                adoptante.Cedula = _reader.GetString(1);
                adoptante.NombreCompleto = _reader.GetString(2);
                adoptante.Telefono = _reader.GetString(3);
                adoptante.Correo = _reader.GetString(4);
                adoptante.Direccion = _reader.GetString(5);
                adoptante.CodigoAnimal = _reader.GetString(6);
                adoptante.EstadoCalificacion = _reader.GetString(7);
                adoptante.IDUsuario = _reader.GetInt32(8);
            }
            _conn.Close();
            return adoptante;
        }

    }
}
