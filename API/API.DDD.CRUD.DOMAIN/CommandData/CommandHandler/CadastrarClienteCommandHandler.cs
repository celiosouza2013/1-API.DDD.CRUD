using API.DDD.CRUD.DOMAIN.CommandData.Base;
using API.DDD.CRUD.DOMAIN.CommandData.Resultado;
using API.DDD.CRUD.DOMAIN.Entities;
using API.DDD.CRUD.DOMAIN.Repositories;
using API.DDD.CRUD.DOMAIN.CommandData.Command;
using System;

namespace API.DDD.CRUD.DOMAIN.CommandData.CommandHandler
{
    public class CadastrarClienteCommandHandler : ICommandHandler<CadastrarClienteCommand, ResultadoCommand>
    {
        private readonly IClienteInsertRepository _repositorio;
        //private IApplicationLogger _appLogger;

        public CadastrarClienteCommandHandler(IClienteInsertRepository repositorio /*, IApplicationLogger appLogger*/)
        {
            _repositorio = repositorio;
            //_appLogger = appLogger;
        }

        public ResultadoCommand Handle(CadastrarClienteCommand command)
        {
            ResultadoCommand _resultado = new ResultadoCommand();

            try
            {
                //Validar Dados do Cliente
                bool isCPFValido = Util.ValidaCPF.IsCpfValido(command.Cpf.ToString());
                if (isCPFValido)
                {
                    Cliente _cliente = new Cliente();
                    Cliente _clienteResultado = new Cliente();

                    _cliente.Id = command.Id;
                    _cliente.Nome = command.Nome;
                    _cliente.Cpf = command.Cpf;
                    _cliente.Email = command.Email;
                    _cliente.Telefone = command.Telefone;
                    _cliente.DataNascimento = command.DataNascimento;
                    _cliente.DataHoraInclusao = DateTime.Now;

                    _clienteResultado = _repositorio.Inserir(_cliente);

                    if (_clienteResultado.DataHoraInclusao != _cliente.DataHoraInclusao)
                    {
                        _resultado.Codigo = 0;
                        _resultado.Mensagem = $"Cliente já existente Id: { _clienteResultado.Id}";
                    }
                    else
                    {
                        _resultado.Codigo = 0;
                        _resultado.Mensagem = $"Cliente inserido com sucesso Id: { _cliente.Id}";
                    }
                }
                else
                {
                    _resultado.Codigo = 1;
                    _resultado.Mensagem = $"O CPF informado é inválido";
                }
            }
            catch (Exception)
            {
                //_appLogger.LogarErro(new LoggingRecord()
                //{
                //    Titulo = "Erro durante a operação de cadastro do Cliente",
                //    Mensagem = exp.ToString(),
                //    Level = Level.ERRO_GERAL,
                //    Params = new System.Collections.Generic.Dictionary<string, object>() { { "CadastrarClienteCommand", command } },

                //    Fonte = "CadastrarClienteCommandHandler"
                //}, exp);

                _resultado.Codigo = 1;
                _resultado.Mensagem = "Ocorreu um erro interno verifique a entrada de logging ";

            }

            return _resultado;
        }
    }
}