namespace WebApp.Models
{
    public class ProductoFormulaViewModel
    {
        public string NombreProducto { get; set; }
        public List<MaterialAsignadoViewModel> Materiales { get; set; }
    }

    public class MaterialAsignadoViewModel
    {
        public int IdFormula { get; set; } // Material disponible
        public decimal Cantidad { get; set; }
    }

}
