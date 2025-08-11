namespace WebApp.Models
{
    public class FormulaViewModel
    {
        public string NombreFormula { get; set; }
        public string Unidad { get; set; }
        public List<MaterialViewModel> Materiales { get; set; }
    }

    public class MaterialViewModel
    {
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
    }
}
