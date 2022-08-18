using System;
using System.Threading.Tasks;
using LocFácil.Business.Models;

namespace LocFácil.Business.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
       // Task<Cliente> ObterClienteReserva(int id);
    }
}
