using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoBlazor.Interfaces;

namespace ProyectoBlazor.Pages.Productos
{
    partial class NuevoProducto
    {
        [Inject] private IProductoServicio productoServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] SweetAlertService Swal { get; set; }

        private Producto product = new Producto();

        protected async Task Guardar()
        {
            if (string.IsNullOrEmpty(product.Codigo) || string.IsNullOrEmpty(product.Descripcion))
            {
                return;
            }

            bool edito = await productoServicio.Actualizar(product);
            if (edito)
            {
                await Swal.FireAsync("Felicidades", "Producto actualizado con éxito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "Producto no pudo ser actualizado", SweetAlertIcon.Error);
            }

            navigationManager.NavigateTo("/Productos");
        }
        protected async Task Cancelar()
        {
            navigationManager.NavigateTo("/Productos");
        }
    }
}
