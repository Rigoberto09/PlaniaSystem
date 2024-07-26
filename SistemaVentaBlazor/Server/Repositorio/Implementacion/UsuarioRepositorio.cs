using Microsoft.EntityFrameworkCore;
using SistemaPlania.Server.DataBase;
using SistemaPlania.Server.Models;
using SistemaPlania.Server.Repositorio.Contrato;
using System.Linq.Expressions;

namespace SistemaPlania.Server.Repositorio.Implementacion
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DbventaBlazorContext _dbContext;

        public UsuarioRepositorio(DbventaBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<Usuario>> Consultar(Expression<Func<Usuario, bool>> filtro = null)
        {
            try
            {
                // Devuelve un IQueryable, pero sin evaluación de la consulta hasta que se materialice
                IQueryable<Usuario> queryEntidad = filtro == null ? _dbContext.Usuarios : _dbContext.Usuarios.Where(filtro);
                return queryEntidad;
            }
            catch (Exception ex)
            {
                // Manejo de errores más robusto
                throw new Exception("Error al consultar usuarios", ex);
            }
        }

        public async Task<Usuario> Crear(Usuario entidad)
        {
            try
            {
                await _dbContext.Set<Usuario>().AddAsync(entidad); // Usa AddAsync en lugar de Add
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear usuario", ex);
            }
        }

        public async Task<bool> Editar(Usuario entidad)
        {
            try
            {
                _dbContext.Update(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar usuario", ex);
            }
        }

        public async Task<bool> Eliminar(Usuario entidad)
        {
            try
            {
                _dbContext.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar usuario", ex);
            }
        }

        public async Task<List<Usuario>> Lista()
        {
            try
            {
                return await _dbContext.Usuarios.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de usuarios", ex);
            }
        }

        public async Task<Usuario> Obtener(Expression<Func<Usuario, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Usuarios.Where(filtro).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuario", ex);
            }
        }
    }
}
