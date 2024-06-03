using Microsoft.EntityFrameworkCore;

namespace Ap1_P1_FrannielArias.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    }
}
