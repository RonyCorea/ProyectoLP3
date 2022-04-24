using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;
using ProyectoBlazor.Data;
using ProyectoBlazor.Interfaces;

namespace ProyectoBlazor.Servicios
{
    public class CompraServicio : ICompraServicio
    {
        private readonly MySQLConfiguration _configuration;
        private ICompraRepositorio compraRepositorio;

        public CompraServicio(MySQLConfiguration configuration)
        {
            _configuration = configuration;
            compraRepositorio = new CompraRepositorio(configuration.CadenaConexion);
        }
        public async Task<bool> Comprar(Compra compra)
        {
            return await compraRepositorio.Comprar(compra);
        }

        public async Task<IEnumerable<Compra>> GetLista()
        {
            return await compraRepositorio.GetLista();
        }

        public async Task<Compra> GetPorCodigo(string CodigoProducto)
        {
            return await compraRepositorio.GetPorCodigo(CodigoProducto);
        }
    }
}
