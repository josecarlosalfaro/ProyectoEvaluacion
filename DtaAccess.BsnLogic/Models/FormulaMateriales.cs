using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;

namespace DtaAccess.BsnLogic.Models
{
    public class FormulaMateriales
    {
        [Key]
        public int IdFormulaMaterial { get; set; }
        public int IdFormula { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }

    }
}
