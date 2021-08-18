using System.Collections.Generic;

namespace API.DDD.CRUD.DOMAIN.QueryData.Resultado
{
    public interface IResultadoQuery<TResultObject> where TResultObject : class
    {
        int CodigoResultado { get; set; }
        string Mensagem { get; set; }
        IEnumerable<TResultObject> Resultado { get; set; }
    }
}
