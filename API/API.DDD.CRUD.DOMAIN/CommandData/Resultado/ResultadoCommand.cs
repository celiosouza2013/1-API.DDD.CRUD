namespace API.DDD.CRUD.DOMAIN.CommandData.Resultado
{
    public class ResultadoCommand : IResultadoCommand
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
    }
}
