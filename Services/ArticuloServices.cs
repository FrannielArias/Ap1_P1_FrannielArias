using Ap1_P1_FrannielArias.DAL;
using Ap1_P1_FrannielArias.Modelss;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;

namespace Ap1_P1_FrannielArias.Services
{
    public class ArticuloServices
    {
        private readonly Contexto _contexto;

        public ArticuloServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Extiste(int ArticulosId)
        {
            return await _contexto.Articulos
                .AnyAsync(c => c.ArticuloId == ArticulosId);
        }

        public async Task<bool> Existe(int ArticulosId)
        {
            return await _contexto.Articulos
                .AnyAsync(c => c.ArticuloId == ArticulosId);
        }

        public async Task<bool> Insertar(Articulos Articulos)
        {
            _contexto.Articulos.Add(Articulos);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Articulos Articulos)
        {
            _contexto.Update(Articulos);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Articulos Articulos)
        {
            if (await Existe(Articulos.ArticuloId))
            {
                return await Insertar(Articulos);
            }
            else
            {
                return await Modificar(Articulos);
            }
        }

        public async Task<bool> Eliminar(int ArticulosId)
        {
            var Articulos = await _contexto.Articulos
                .Where(m => m.ArticuloId == ArticulosId).ExecuteDeleteAsync();
            return Articulos > 0;
        }

        public async Task<Articulos?> Buscar(int ArticulosId)
        {
            return await _contexto.Articulos
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ArticuloId == ArticulosId);
        }

        public List<Articulos> Listar(Expression<Func<Articulos, bool>> criterio)
        {
            return _contexto.Articulos
                .AsNoTracking()
                .Where(criterio)
                .ToList();
        }
    }
}
