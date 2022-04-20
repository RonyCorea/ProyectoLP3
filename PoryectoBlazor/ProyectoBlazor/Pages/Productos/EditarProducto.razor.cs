using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoBlazor.Interfaces;

namespace ProyectoBlazor.Pages.Productos;

partial class EditarProducto
{
    
    [Inject] private IProductoServicio _productoServicio { get; set; }
    [Inject] NavigationManager _navigationManager { get; set; }
    [Inject] SweetAlertService Swal { get; set; }
    [Parameter]public string Codigo { get; set; }

    Producto product = new Producto();


    protected override async Task OnInitializedAsync()
    {
        if (!string.IsNullOrEmpty(Codigo))
        {
            product = await _productoServicio.GetPorCodigo(Codigo);
        }
        
       
    }

    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(product.Codigo) || string.IsNullOrEmpty(product.Descripcion))
        {
            return;
        }

        bool edito = await _productoServicio.Actualizar(product);
        if (edito)
        {
            await Swal.FireAsync("Felicidades", "Producto actualizado con éxito", SweetAlertIcon.Success);
        }
        else
        {
            await Swal.FireAsync("Error", "Producto no pudo ser actualizado", SweetAlertIcon.Error);
        }

        _navigationManager.NavigateTo("/Productos");
    }
    protected async Task Cancelar()
    {
        _navigationManager.NavigateTo("/Productos");
    }
    protected async Task Eliminar()
    {
        bool elimino = false;
        SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
        {
            Title = "¿Seguro que quiere eliminar el producto?",
            Icon = SweetAlertIcon.Question,
            ShowCancelButton = true,
            ConfirmButtonText = "Aceptar",
            CancelButtonText = "Cancelar"
        });

        if (!string.IsNullOrEmpty(result.Value))
        {
            elimino = await _productoServicio.Eliminar(product);
            if (elimino)
            {
                await Swal.FireAsync("Felicidades", "Producto eliminado con éxito", SweetAlertIcon.Success);
                _navigationManager.NavigateTo("/Productos");
            }
            else
            {
                await Swal.FireAsync("Error", "Producto no pudo ser eliminado", SweetAlertIcon.Error);
            }
        }
    }
}