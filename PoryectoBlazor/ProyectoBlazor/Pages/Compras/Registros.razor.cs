using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoBlazor.Interfaces;

namespace ProyectoBlazor.Pages.Compras
{
    partial class Registros
    {
        [Inject] private ICompraServicio _compraServicio { get; set; }

        private IEnumerable<Compra> comprasLista { get; set; }

        protected override async Task OnInitializedAsync()
        {
            comprasLista = await _compraServicio.GetLista();
        }
    }
}
