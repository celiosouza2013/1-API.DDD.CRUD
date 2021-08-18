using API.DDD.CRUD.DOMAIN.CommandData.Base;
using API.DDD.CRUD.DOMAIN.CommandData.Command;
using API.DDD.CRUD.DOMAIN.CommandData.CommandHandler;
using API.DDD.CRUD.DOMAIN.CommandData.Resultado;
using API.DDD.CRUD.DOMAIN.QueryData.Queries;
using API.DDD.CRUD.DOMAIN.QueryData.QueryHandlers;
using API.DDD.CRUD.DOMAIN.QueryData.Resultado;
using API.DDD.CRUD.DOMAIN.QueryData.Util;
using API.DDD.CRUD.DOMAIN.Repositories;
using API.DDD.CRUD.APPLICATION.Dispatcher;
using API.DDD.CRUD.INFRA.Repositories;
using Autofac;
using API.DDD.CRUD.INFRA.EF.Context;

namespace API.DDD.CRUD.IOC
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            ContainerBuilder _containerBuider = CreateBuilder();
            return _containerBuider.Build();
        }
        public static ContainerBuilder CreateBuilder()
        {
            ContainerBuilder _containerBuilder = new ContainerBuilder();

            _containerBuilder.RegisterType<CommandMessageDispatcher>().AsSelf();
            _containerBuilder.RegisterType<QueryMessageDispatcher>().AsSelf();

            //_containerBuilder.RegisterType<ApplicationLogger>().As<IApplicationLogger>();
            
            _containerBuilder.RegisterType<DataContext>().AsSelf();

            _containerBuilder.RegisterType<ClienteReadRepository>().As<IReadClienteRepository>();
            _containerBuilder.RegisterType<ClienteInsertRepository>().As<IClienteInsertRepository>();

            _containerBuilder.RegisterType<CadastrarClienteCommandHandler>().As<ICommandHandler<CadastrarClienteCommand, ResultadoCommand>>();
            _containerBuilder.RegisterType<ClienteQueryHandler>().As<IQueryHandler<ClienteQuery, ResultadoQueryCliente>>();
            _containerBuilder.RegisterType<ClientePorIdQueryHandler>().As<IQueryHandler<ClientePorId, ResultadoQueryClientePorId>>();
            _containerBuilder.RegisterType<ClientePorCpfQueryHandler>().As<IQueryHandler<ClientePorCpf, ResultadoQueryClientePorCpf>>();
            _containerBuilder.RegisterType<ClientePorNomeQueryHandler>().As<IQueryHandler<ClientePorNome, ResultadoQueryClientePorNome>>();

            return _containerBuilder;
        }
    }
}

    

