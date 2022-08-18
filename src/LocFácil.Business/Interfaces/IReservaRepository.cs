using System;
using LocFácil.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocFácil.Business.Interfaces
{
    public interface IReservaRepository : IRepository<Reserva>
    {
        Task<IEnumerable<Reserva>> ObterReservas(int id);
    }
}