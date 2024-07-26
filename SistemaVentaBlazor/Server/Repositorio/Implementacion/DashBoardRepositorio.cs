using SistemaPlania.Server.DataBase;
using SistemaPlania.Server.Models;
using SistemaPlania.Server.Repositorio.Contrato;
using System.Globalization;

namespace SistemaPlania.Server.Repositorio.Implementacion
{
    public class DashBoardRepositorio : IDashBoardRepositorio
    {

        private readonly DbventaBlazorContext _context;
        public DashBoardRepositorio(DbventaBlazorContext context)
        {
            _context = context;
        }

        public async Task<int> TotalVentasUltimaSemana()
        {
            int total = 0;
            try
            {
                IQueryable<Venta> _ventaQuery = _context.Ventas.AsQueryable();

                if (_ventaQuery.Count() > 0)
                {
                    DateTime? ultimaFecha = _context.Ventas.OrderByDescending(v => v.FechaRegistro).Select(v => v.FechaRegistro).First();

                    ultimaFecha = ultimaFecha.Value.AddDays(-7);

                    IQueryable<Venta> query = _context.Ventas.Where(v => v.FechaRegistro.Value.Date >= ultimaFecha.Value.Date);
                    total = query.Count();
                }

                return total;
            }
            catch
            {
                throw;
            }
        }
        public async Task<string> TotalIngresosUltimaSemana()
        {
            decimal resultado = 0;
            try
            {
                IQueryable<Venta> _ventaQuery = _context.Ventas.AsQueryable();

                if (_ventaQuery.Count() > 0)
                {
                    DateTime? ultimaFecha = _context.Ventas.OrderByDescending(v => v.FechaRegistro).Select(v => v.FechaRegistro).First();
                    ultimaFecha = ultimaFecha.Value.AddDays(-7);
                    IQueryable<Venta> query = _context.Ventas.Where(v => v.FechaRegistro.Value.Date >= ultimaFecha.Value.Date);

                    resultado = query
                         .Select(v => v.Total)
                         .Sum(v => v.Value);
                }


                return Convert.ToString(resultado, new CultureInfo("es-PE"));
            }
            catch
            {
                throw;
            }


        }
        public async Task<int> TotalProductos()
        {
            try
            {
                IQueryable<Producto> query = _context.Productos;
                int total = query.Count();
                return total;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Dictionary<string, int>> VentasUltimaSemana()
        {
            Dictionary<string, int> resultado = new Dictionary<string, int>();
            try
            {
                IQueryable<Venta> _ventaQuery = _context.Ventas.AsQueryable();
                if (_ventaQuery.Count() > 0)
                {
                    DateTime? ultimaFecha = _context.Ventas.OrderByDescending(v => v.FechaRegistro).Select(v => v.FechaRegistro).First();
                    ultimaFecha = ultimaFecha.Value.AddDays(-7);

                    IQueryable<Venta> query = _context.Ventas.Where(v => v.FechaRegistro.Value.Date >= ultimaFecha.Value.Date);

                    resultado = query
                        .GroupBy(v => v.FechaRegistro.Value.Date).OrderBy(g => g.Key)
                        .Select(dv => new { fecha = dv.Key.ToString("dd/MM/yyyy"), total = dv.Count() })
                        .ToDictionary(keySelector: r => r.fecha, elementSelector: r => r.total);
                }


                return resultado;

            }
            catch
            {
                throw;
            }

        }
    }
}
