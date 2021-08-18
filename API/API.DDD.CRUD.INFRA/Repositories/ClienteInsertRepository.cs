using API.DDD.CRUD.DOMAIN.Entities;
using API.DDD.CRUD.DOMAIN.Repositories;
using API.DDD.CRUD.INFRA.EF.Context;
using System;
using System.Linq;

namespace API.DDD.CRUD.INFRA.Repositories
{
    public class ClienteInsertRepository : IClienteInsertRepository
    {
        private readonly DataContext _context;       
        public ClienteInsertRepository()
        {            
            _context = new DataContext();            
        }

        public Cliente Inserir(Cliente source)
        {
            try
            {
                //Verifica se o cliente informado já está cadastrado
                Cliente cliente = new Cliente();
                cliente = _context.Clientes.Where(e => e.Cpf == source.Cpf).FirstOrDefault();

                //Se o cliente informado não existir, insere
                if (cliente == null)
                {
                    _context.Clientes.Add(source);
                    _context.SaveChanges();

                   // _logger.LogInformation($"Operação para inserir cliente realizada com sucesso! Cliente {source}");

                    return source;
                }
                else
                {
                    return cliente;
                }
            }
            catch (Exception)
            {
                //_logger.LogError($"Erro na operação para inserir cliente! Cliente {source} /r/n Erro {ex}");

                throw new Exception("Ocorreu um erro durante a persistência dos dados informados do cliente");
                
            }
        }
    }
}
