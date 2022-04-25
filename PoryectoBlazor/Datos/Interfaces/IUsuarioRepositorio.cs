using Modelos;

namespace Datos.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> GetPorCodigo(string codigo);
        Task<bool> ValidaUsuario(Login login);
    }
}
