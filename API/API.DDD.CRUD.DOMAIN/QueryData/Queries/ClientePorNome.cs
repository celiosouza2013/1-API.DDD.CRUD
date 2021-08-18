using API.DDD.CRUD.DOMAIN.QueryData.Util;

namespace API.DDD.CRUD.DOMAIN.QueryData.Queries
{
    public class ClientePorNome : IQuery
    {
        public ClientePorNome(string nome)
        {
            Nome = nome;
        }
        public string Nome { get; }
    }
}
