using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtaAccess.BsnLogic.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ContraseniaHash { get; set; }
        public int IdGrupo { get; set; }

    }
}
