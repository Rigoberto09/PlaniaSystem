using Microsoft.EntityFrameworkCore;
using SistemaPlania.Server.DataBase;
using SistemaPlania.Server.Models;
using SistemaPlania.Server.Repositorio.Contrato;

namespace SistemaPlania.Server.Repositorio.Implementacion
{
    public class RolRepositorio : IRolRepositorio
    {   
        private readonly DbventaBlazorContext _context;

        public RolRepositorio(DbventaBlazorContext context)
        {
            _context = context;
        }
        public async Task<List<Rol>> Lista()
        {
            try
            {
                return await _context.Rols.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
