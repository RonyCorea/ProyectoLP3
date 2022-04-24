using System.ComponentModel.DataAnnotations;

namespace Modelos;

public class Compra
{
    [Required(ErrorMessage = "El Campo Id es Obligatorio")]
    public int Id { get; set; }
    [Required(ErrorMessage = "El Campo Nombre del Cliente es Obligatorio")]
    public string Cliente { get; set; }
    public DateTime Fecha { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Impuesto { get; set; }
    public decimal Total { get; set; }
    [Required(ErrorMessage = "El Campo Codigo del Producto es Obligatorio")]
    public string CodigoProducto { get; set; }



}
