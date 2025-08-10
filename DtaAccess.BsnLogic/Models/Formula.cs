using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtaAccess.BsnLogic.Models
{
    public class Formula
    {
        public int IdFormula { get; set; }
        public int Nombre { get; set; }
        public string Unidad { get; set; }
        public ICollection<FormulaMateriales> Materiales { get; set; }

    }
}
