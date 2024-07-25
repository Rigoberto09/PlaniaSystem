using SistemaPlania.Server.Models;

namespace SistemaPlania.Server.Repositorio.Contrato
{
    public interface IRolRepositorio
    {
        Task<List<Rol>> Lista();
    }
}
