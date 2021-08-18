using API.DDD.CRUD.DOMAIN.QueryData.Util;

namespace API.DDD.CRUD.DOMAIN.QueryData.Queries
{
    public class ClientePorCpf : IQuery
    {
        public ClientePorCpf(decimal cpf)
        {
            Cpf = cpf;
        }
        public decimal Cpf { get; }
    }
}
