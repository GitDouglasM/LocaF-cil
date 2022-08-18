using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocFácil.Business.Models;

namespace LocFácil.Business.Interfaces
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        //Task<IEnumerable<Veiculo>> ObterVeiculosPorCliente(int clienteId);
        //Task<Veiculo> ObterVeiculoCliente(int clienteId);
    }
}
