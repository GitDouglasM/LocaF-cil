using LocFácil.Business.Interfaces;
using LocFácil.Business.Models;
using LocFácil.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocFácil.Data.Repository
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(MeuDbContext context) : base(context) { }

        //public async Task<Veiculo> ObterVeiculoCliente(int id)
        //{
        //    return await Db.Veiculos.AsNoTracking()
        //        .Include(f => f.Cliente)
        //        .FirstOrDefaultAsync(v => v.Id == id);
        //}

        public async Task<IEnumerable<Veiculo>> ObterVeiculosPorCliente(int clienteId)
        {
            return await Buscar(v => v.Id == clienteId);
        }
    }
}
