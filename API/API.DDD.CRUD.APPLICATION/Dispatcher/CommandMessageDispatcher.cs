using API.DDD.CRUD.DOMAIN.CommandData.Base;
using API.DDD.CRUD.DOMAIN.CommandData.Resultado;
using Autofac;
using System;

namespace API.DDD.CRUD.APPLICATION.Dispatcher
{
    public class CommandMessageDispatcher
    {

        private IContainer _container;
        /// <summary>
        /// construtor do despachador
        /// </summary>
        public CommandMessageDispatcher(ContainerBuilder builder)
        {
            _container = builder.Build();
        }

        /// <summary>
        /// Procura baseado no comando passado o Tratador responsável
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public IResultadoCommand Dispatch(ICommand command)
        {
            Type _genericCommandHandlerType = typeof(ICommandHandler<,>);
            Type[] _commandHandlerCreatingArgs = { command.GetType(), typeof(ResultadoCommand) };
            Type _commandHandlerType = _genericCommandHandlerType.MakeGenericType(_commandHandlerCreatingArgs);

            dynamic _commandHandler = _container.Resolve(_commandHandlerType);
            IResultadoCommand _result = _commandHandler.Handle((dynamic)command);
            return _result;
        }
    }
}
