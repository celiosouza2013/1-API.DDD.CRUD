using API.DDD.CRUD.DOMAIN.Entities;
using API.DDD.CRUD.DOMAIN.Repositories;
using API.DDD.CRUD.INFRA.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace API.DDD.CRUD.INFRA.Repositories
{
    public class ClienteReadRepository : IReadClienteRepository
    {
        private  DataContext _context;
        
        public ClienteReadRepository()
        {
            _context = new DataContext();           
        }

        public Cliente FindById(object id)
        {
            try
            {
                int _id = Convert.ToInt32(id);
                Cliente _cliente = _context.Clientes.Where(e => e.Id == _id).FirstOrDefault();
                return _cliente;
            }
            catch (Exception)
            {                
                throw new Exception("Ocorreu um erro durante a pesquisa do cliente por Id");
            }
        }

        public IEnumerable<Cliente> FindItensByCriteria(Expression<Func<Cliente, bool>> query)
        {
            var _resultado = _context.Clientes.Where(query).ToList();
            return _resultado;
        }
    }
}
