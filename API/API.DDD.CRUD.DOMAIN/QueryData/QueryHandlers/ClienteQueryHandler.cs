using API.DDD.CRUD.DOMAIN.QueryData.Queries;
using API.DDD.CRUD.DOMAIN.QueryData.Resultado;
using API.DDD.CRUD.DOMAIN.QueryData.Util;
using API.DDD.CRUD.DOMAIN.Repositories;
using System;

namespace API.DDD.CRUD.DOMAIN.QueryData.QueryHandlers
{
    public class ClienteQueryHandler : IQueryHandler<ClienteQuery, ResultadoQueryCliente>
    {
        private readonly IReadClienteRepository _repository;       

        public ClienteQueryHandler(IReadClienteRepository repository)
        {
            _repository = repository;           
        }

        /// <summary>
        /// Pesquisa todos os Cliente Cadastrados
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public ResultadoQueryCliente Handle(ClienteQuery source)
        {
            ResultadoQueryCliente _resultado = new ResultadoQueryCliente();
            try
            {
                var _recurso = _repository.FindItensByCriteria(e => e.Id != 0);
                _resultado.CodigoResultado = 0;
                _resultado.Mensagem = "Pesquisa executada com sucesso";
                _resultado.Resultado = _recurso;
            }
            catch (Exception)
            {
                _resultado.CodigoResultado = 1;
                _resultado.Mensagem = "Ocorreu um erro interno verifique a entrada de logging";
            }
            return _resultado;
        }
    }
}
