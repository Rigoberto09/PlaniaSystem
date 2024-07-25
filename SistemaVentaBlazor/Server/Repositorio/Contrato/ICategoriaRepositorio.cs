using SistemaPlania.Server.Models;

namespace SistemaPlania.Server.Repositorio.Contrato
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> Lista();
    }
}
