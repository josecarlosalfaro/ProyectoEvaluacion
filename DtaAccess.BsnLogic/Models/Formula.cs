using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtaAccess.BsnLogic.Models
{
    public class Formula
    {
        [Key]
        public int IdFormula { get; set; }
        public string Nombre { get; set; }
        public string Unidad { get; set; }
        public ICollection<FormulaMateriales> Materiales { get; set; }

    }
}
