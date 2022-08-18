using LocFácil.Business.Interfaces;
using LocFácil.Business.Models;
using LocFácil.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocFácil.Data.Repository
{
    public class ReservaRepository : Repository<Reserva>, IReservaRepository
    {
        public ReservaRepository(MeuDbContext context) : base(context) { }

        public async Task<IEnumerable<Reserva>> ObterReservas(int id)
        {
            return await Buscar(r => r.Id == id);
        }

        //public async Task<Reserva> ObterClienteVeiculoReserva(int id)
        //{
        //    return await Db.Reservas.AsNoTracking()
        //        .Include(c => c.Clientes)
        //        .Include(f => f.Veiculos)
        //        .FirstOrDefaultAsync(v => v.VeiculoId == id);
        //}
    }
}