using System;
using LocFácil.Data.Context;
using System.Threading.Tasks;
using LocFácil.Business.Models;
using LocFácil.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocFácil.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(MeuDbContext context) : base(context) { }
    }
}
