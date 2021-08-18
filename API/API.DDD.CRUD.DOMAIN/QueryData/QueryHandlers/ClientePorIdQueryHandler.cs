using API.DDD.CRUD.DOMAIN.QueryData.Queries;
using API.DDD.CRUD.DOMAIN.QueryData.Resultado;
using API.DDD.CRUD.DOMAIN.QueryData.Util;
using API.DDD.CRUD.DOMAIN.Repositories;
using System;

namespace API.DDD.CRUD.DOMAIN.QueryData.QueryHandlers
{
    public class ClientePorIdQueryHandler : IQueryHandler<ClientePorId, ResultadoQueryClientePorId>
    {
        private readonly IReadClienteRepository _repository;       

        public ClientePorIdQueryHandler(IReadClienteRepository repository)
        {
            _repository = repository;            
        }

        /// <summary>
        /// Pesquisa todos os Clientes Cadastrados por Id
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public ResultadoQueryClientePorId Handle(ClientePorId source)
        {
            ResultadoQueryClientePorId _resultado = new ResultadoQueryClientePorId();
            try
            {
                var _recurso = _repository.FindItensByCriteria(e => e.Id == source.Id);
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
