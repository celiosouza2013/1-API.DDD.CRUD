using API.DDD.CRUD.DOMAIN.Entities;
using System.Collections.Generic;

namespace API.DDD.CRUD.DOMAIN.QueryData.Resultado
{
    public class ResultadoQueryClientePorId : IResultDataBase<Cliente>
    {
        public int CodigoResultado { get; set; }
        public string Mensagem { get; set; }
        public IEnumerable<Cliente> Resultado { get; set; }
    }
}
