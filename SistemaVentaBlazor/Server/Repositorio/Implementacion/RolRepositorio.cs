using Microsoft.EntityFrameworkCore;
using SistemaPlania.Server.Models;
using SistemaPlania.Server.Repositorio.Contrato;

namespace SistemaPlania.Server.Repositorio.Implementacion
{
    public class RolRepositorio : IRolRepositorio
    {
        private readonly DbventaBlazorContext _dbContext;

        public RolRepositorio(DbventaBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Rol>> Lista()
        {
            try
            {
                return await _dbContext.Rols.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
