using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoBlazor.Interfaces;

namespace ProyectoBlazor.Pages.Compras
{
    partial class NuevaCompra
    {
        [Inject] private ICompraServicio compraServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] SweetAlertService Swal { get; set; }

        private Compra compra = new Compra();

        protected async Task Comprar()
        {
            if (compra.Id==null||string.IsNullOrEmpty(compra.Cliente)|| string.IsNullOrEmpty(compra.CodigoProducto))
            {
                return;
            }

            bool inserto = await compraServicio.Comprar(compra);
            if (inserto)
            {
                await Swal.FireAsync("Felicidades", "Compra realizada con éxito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo realizar la compra", SweetAlertIcon.Error);
            }

            navigationManager.NavigateTo("/Compra");
        }
        protected async Task Cancelar()
        {
            navigationManager.NavigateTo("/Compra");
        }

        [Inject] private IProductoServicio _productoServicio { get; set; }

        private IEnumerable<Producto> productosLista { get; set; }

        protected override async Task OnInitializedAsync()
        {
            productosLista = await _productoServicio.GetLista();
        }
    }
}
