using Modelos;

namespace Datos.Interfaces;

public interface ICompraRepositorio
{
    Task<bool> Comprar(Compra compra);
    Task<IEnumerable<Compra>> GetLista();
    Task<Compra> GetPorCodigo(string CodigoProducto);

}
