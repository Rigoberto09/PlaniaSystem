using Microsoft.EntityFrameworkCore;
using SistemaPlania.Server.DataBase;
using SistemaPlania.Server.Models;
using SistemaPlania.Server.Repositorio.Contrato;

namespace SistemaPlania.Server.Repositorio.Implementacion
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly DbventaBlazorContext _dbContext;

        public CategoriaRepositorio(DbventaBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Categoria>> Lista()
        {
            try
            {
                return await _dbContext.Categorias.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
