using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DtaAccess.BsnLogic.Models
{
    public class Grupo
    {
        [Key]
        public int IdGrupo { get; set; }
        public string Nombre { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
