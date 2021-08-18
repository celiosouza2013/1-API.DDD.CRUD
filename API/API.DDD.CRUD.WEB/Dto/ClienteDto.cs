using System;

namespace API.DDD.CRUD.WEB.Dto
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }        
    }
}