using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace LocFácil.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Adicionar(TEntity entity); //método adicionar onde vai ser recebida desde que seja filha de entity -(TEntity é genérico podia ser outro nome)
        Task<TEntity> ObterPorId(int id); //retorna uma entidade
        Task<List<TEntity>> ObterTodos(); //retorna uma lista de entidades
        Task Atualizar(TEntity entity);
        Task Remover(int id); //void - não retorna nada assim como Adicionar

        //Serve para buscar qualquer entidade(coleção) atraves de qualquer parametro
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate); //passar uma expressão lambda dentro do método(buscar) para buscar qualquer entidade por qualquer parâmetro

        //retorna o número de linha afetadas
        Task<int> SaveChanges();
    }
}
