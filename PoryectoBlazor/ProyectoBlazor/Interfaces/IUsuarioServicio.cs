using Modelos;

namespace ProyectoBlazor.Interfaces
{
    public interface IUsuarioServicio
    {
        Task<Usuario> GetPorCodigo(string codigo);
    }
}
