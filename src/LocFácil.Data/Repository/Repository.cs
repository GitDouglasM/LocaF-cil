using System;
using System.Linq;
using LocFácil.Data.Context;
using System.Threading.Tasks;
using System.Linq.Expressions;
using LocFácil.Business.Models;
using System.Collections.Generic;
using LocFácil.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocFácil.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        //protected - pois tanto repository quanto quem herda de repository pode acessar o Db
        protected readonly MeuDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        //injetando o DbContext
        protected Repository(MeuDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            //vai no banco de dados onde a expressão que passar retorna uma lista assincrona
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> ObterPorId(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task Remover(int id)
        {
            /*para remover tem duas formas:
             DbSet.Remove(await DbSet.FindAsync(id)); - vai ate o banco e busca o id*/
            DbSet.Remove(await DbSet.FindAsync(id)); //dessa forma vc exclui sem ir ao banco
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose(); // se existir, faça o dispose (liberar recursos, aplicação aberta, uma hora tera que fechar e não pode eserar o Garbage collector)
        }
    }
}
