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
    public class DAUsuario
    {
        public int AgregarUsuario(Usuario usuario) {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_AGREGAR_USUARIO", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@NOMBRE", usuario.NombreCompleto));
            _Comand.Parameters.Add(new SqlParameter("@USERNAME", usuario.Username));
            _Comand.Parameters.Add(new SqlParameter("@CORREO", usuario.Correo));
            _Comand.Parameters.Add(new SqlParameter("@CEDULA", usuario.Cedula));
            _Comand.Parameters.Add(new SqlParameter("@PASS", usuario.Pass));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return Resultado;
        }

        public int ModificarUsuario(Usuario usuario)
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_MODIFICAR_USUARIO", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@USERNAME", usuario.Username));
            _Comand.Parameters.Add(new SqlParameter("@PASS", usuario.Pass));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return Resultado;
        }

        public int EliminarUsuario(Usuario usuario)
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_ELIMINAR_USUARIO", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@USERNAME", usuario.Username));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return Resultado;
        }

        public Usuario BuscarUsuario(string _user) {
            Usuario usuario = new Usuario();
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_BUSCAR_USUARIO", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@USERNAME", _user));
            IDataReader _reader = _Comand.ExecuteReader();
            while (_reader.Read()) {
                usuario.IDUsuario = _reader.GetInt32(0);
                usuario.NombreCompleto = _reader.GetString(1);
                usuario.Username = _reader.GetString(2);
                usuario.Correo = _reader.GetString(3);
                usuario.Cedula = _reader.GetString(4);
                usuario.Pass = _reader.GetString(5);
            }
            _conn.Close();
            return usuario;
        }

        public List<Usuario> BuscarUsuarioCed(string _ced)
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_BUSCAR_USUARIO_CED", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@CED", _ced));
            IDataReader _reader = _Comand.ExecuteReader();
            List<Usuario> _list = new List<Usuario>();
            while (_reader.Read())
            {
                Usuario usuario = new Usuario();
                usuario.IDUsuario = _reader.GetInt32(0);
                usuario.NombreCompleto = _reader.GetString(1);
                usuario.Username = _reader.GetString(2);
                usuario.Correo = _reader.GetString(3);
                usuario.Cedula = _reader.GetString(4);
                _list.Add(usuario);
            }
            _conn.Close();
            return _list;
        }

        public List<Usuario> ConsultarUsuarios()
        {
            IDbConnection _conn = DASoftColitas.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SP_CONSULTAR_USUARIOS", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _Comand.ExecuteReader();
            List<Usuario> _list = new List<Usuario>();
            while (_reader.Read())
            {
                Usuario usuario = new Usuario();
                usuario.IDUsuario = _reader.GetInt32(0);
                usuario.NombreCompleto = _reader.GetString(1);
                usuario.Username = _reader.GetString(2);
                usuario.Correo = _reader.GetString(3);
                usuario.Cedula = _reader.GetString(4);
                _list.Add(usuario);
            }
            _conn.Close();
            return _list;
        }

    }
}
