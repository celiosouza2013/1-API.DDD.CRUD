using API.DDD.CRUD.DOMAIN.QueryData.Util;

namespace API.DDD.CRUD.DOMAIN.QueryData.Queries
{
    public class ClientePorId : IQuery
    {
        public ClientePorId(int idCliente)
        {
            Id = idCliente;
        }
        public int Id { get; }
    }
}
