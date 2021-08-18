using API.DDD.CRUD.DOMAIN.CommandData.Resultado;

namespace API.DDD.CRUD.DOMAIN.CommandData.Base
{
    public interface ICommandHandler<TSourceObject, TResultObject>
        where TSourceObject : ICommand
        where TResultObject : IResultadoCommand
    {
        TResultObject Handle(TSourceObject command);
    }
}
