using DataAccess;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{
    public class DLUsuario
    {
        DAUsuario _dau = new DAUsuario();

        public int AgregarUsuario(Usuario usuario) {
            return _dau.AgregarUsuario(usuario);
        }

        public int ModificarUsuario(Usuario usuario)
        {
            return _dau.ModificarUsuario(usuario);
        }

        public int EliminarUsuario(Usuario usuario)
        {
            return _dau.EliminarUsuario(usuario);
        }

        public Usuario BuscarUsuario(string user) {
            return _dau.BuscarUsuario(user);
        }

        public List<Usuario> BuscarUsuarioCed(string ced)
        {
            return _dau.BuscarUsuarioCed(ced);
        }

        public List<Usuario> ConsultarUsuarios()
        {
            return _dau.ConsultarUsuarios();
        }
    }
}
