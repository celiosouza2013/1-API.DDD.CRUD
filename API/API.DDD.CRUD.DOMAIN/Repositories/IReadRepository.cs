using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace API.DDD.CRUD.DOMAIN.Repositories
{
    public interface IReadRepository<TResultObject> where TResultObject : class
    {
        /// <summary>
        /// Localiza um item por id
        /// </summary>
        /// <param name="id">chave identificadora do item</param>
        /// <returns>Item Pesquisado</returns>
        TResultObject FindById(object id);

        /// <summary>
        /// Localiza um item por id
        /// </summary>
        /// <param name="id">chave identificadora do item</param>
        /// <returns>Item Pesquisado</returns>
        IEnumerable<TResultObject> FindItensByCriteria(Expression<Func<TResultObject, bool>> query);
    }
}
