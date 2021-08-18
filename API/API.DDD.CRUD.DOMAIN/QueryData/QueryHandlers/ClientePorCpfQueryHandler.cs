using API.DDD.CRUD.DOMAIN.QueryData.Queries;
using API.DDD.CRUD.DOMAIN.QueryData.Resultado;
using API.DDD.CRUD.DOMAIN.QueryData.Util;
using API.DDD.CRUD.DOMAIN.Repositories;
using System;

namespace API.DDD.CRUD.DOMAIN.QueryData.QueryHandlers
{
    public class ClientePorCpfQueryHandler : IQueryHandler<ClientePorCpf, ResultadoQueryClientePorCpf>
    {
        private readonly IReadClienteRepository _repository;        

        public ClientePorCpfQueryHandler(IReadClienteRepository repository)
        {
            _repository = repository;            
        }

        /// <summary>
        /// Pesquisa todos os clientes cadastrados por Cpf
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public ResultadoQueryClientePorCpf Handle(ClientePorCpf source)
        {
            ResultadoQueryClientePorCpf _resultado = new ResultadoQueryClientePorCpf();
            try
            {
                var _recurso = _repository.FindItensByCriteria(e => e.Cpf == source.Cpf);
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