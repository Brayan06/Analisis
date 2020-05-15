using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{
    public class DLCorreo
    {
        DACorreo _dac = new DACorreo();
        public string EnviarCorreo(string emisor, string pass, string receptor, string ruta, string mssg, string asunto) {
            return _dac.EnvioCorreo(emisor, pass, receptor, ruta, mssg, asunto);
        }
    }
}
