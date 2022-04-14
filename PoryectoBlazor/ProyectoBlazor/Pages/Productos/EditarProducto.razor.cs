using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoBlazor.Interfaces;

namespace ProyectoBlazor.Pages.Productos;

partial class EditarProducto
{
    
    [Inject] private IProductoServicio _productoServicio { get; set; }

    [Parameter]public string Codigo { get; set; }

    Producto product = new Producto();


    protected override async Task OnInitializedAsync()
    {
        if (!string.IsNullOrEmpty(Codigo))
        {
            product = await _productoServicio.GetPorCodigo(Codigo);
        }
        
       
    }
}
