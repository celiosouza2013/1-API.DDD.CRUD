using API.DDD.CRUD.DOMAIN.QueryData.Queries;
using API.DDD.CRUD.DOMAIN.QueryData.Resultado;
using API.DDD.CRUD.DOMAIN.QueryData.Util;
using API.DDD.CRUD.DOMAIN.Repositories;

using System;

namespace API.DDD.CRUD.DOMAIN.QueryData.QueryHandlers
{
    public class ClientePorNomeQueryHandler : IQueryHandler<ClientePorNome, ResultadoQueryClientePorNome>
    {
        private readonly IReadClienteRepository _repository;        

        public ClientePorNomeQueryHandler(IReadClienteRepository repository)
        {
            _repository = repository;           
        }

        /// <summary>
        /// Pesquisa todos os Cliente Cadastrados por Nome
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public ResultadoQueryClientePorNome Handle(ClientePorNome source)
        {
            ResultadoQueryClientePorNome _resultado = new ResultadoQueryClientePorNome();
            try
            {
                var _recurso = _repository.FindItensByCriteria(e => e.Nome == source.Nome);
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
