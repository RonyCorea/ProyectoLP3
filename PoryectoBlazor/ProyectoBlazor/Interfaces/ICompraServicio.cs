using Modelos;

namespace ProyectoBlazor.Interfaces
{
    public interface ICompraServicio
    {
        Task<bool> Comprar(Compra Compra);
        Task<IEnumerable<Compra>> GetLista();
        Task<Compra> GetPorCodigo(string CodigoProducto);
    }
}
