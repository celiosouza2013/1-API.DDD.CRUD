using API.DDD.CRUD.DOMAIN.CommandData.Command;
using API.DDD.CRUD.DOMAIN.CommandData.Resultado;
using API.DDD.CRUD.DOMAIN.QueryData.Queries;
using API.DDD.CRUD.DOMAIN.QueryData.Resultado;
using API.DDD.CRUD.APPLICATION.Dispatcher;
using API.DDD.CRUD.IOC;
using API.DDD.CRUD.WEB.Dto;
using Microsoft.AspNetCore.Mvc;
using System;


namespace API.DDD.CRUD.WEB.Controllers
{
    [Route("api/v1/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private CommandMessageDispatcher _commandDispatcher;
        private QueryMessageDispatcher _queryMessageDispatcher;

        public ClienteController()
        {
            _commandDispatcher = new CommandMessageDispatcher(ContainerConfig.CreateBuilder());
            _queryMessageDispatcher = new QueryMessageDispatcher(ContainerConfig.CreateBuilder());
        }

        /// <summary>
        /// Insere um novo Cliente
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("")]
        public IActionResult CadastraCliente([FromBody] ClienteDto dto)
        {
            try
            {
                CadastrarClienteCommand _command = new CadastrarClienteCommand();

                _command.Id = dto.Id;
                _command.Cpf = dto.Cpf;
                _command.Nome = dto.Nome;
                _command.DataNascimento = dto.DataNascimento;
                _command.Telefone = dto.Telefone;
                _command.Email = dto.Email;                

                ResultadoCommand _resultado = _commandDispatcher.Dispatch(_command) as ResultadoCommand;

                return Ok(_resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Retorna todos os Clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IActionResult BuscarCliente()
        {
            try
            {
                ClienteQuery _query = new ClienteQuery();
                var _resultado = _queryMessageDispatcher.Handle<ResultadoQueryCliente>(_query);
                return Ok(_resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Retorna o Cliente pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("id/{id}")]
        public IActionResult BuscarClientePorId(int id)
        {
            try
            {
                ClientePorId _query = new ClientePorId(id);
                var _resultado = _queryMessageDispatcher.Handle<ResultadoQueryClientePorId>(_query);
                return Ok(_resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Retorna o Cliente pelo CPF
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("cpf/{cpf}")]
        public IActionResult BuscarClientePorCpf(decimal cpf)
        {
            try
            {
                ClientePorCpf _query = new ClientePorCpf(cpf);
                var _resultado = _queryMessageDispatcher.Handle<ResultadoQueryClientePorCpf>(_query);
                return Ok(_resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Retorna o Cliente pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("nome/{nome}")]
        public IActionResult BuscarClientePorNome(string nome)
        {
            try
            {
                ClientePorNome _query = new ClientePorNome(nome);
                var _resultado = _queryMessageDispatcher.Handle<ResultadoQueryClientePorNome>(_query);
                return Ok(_resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

