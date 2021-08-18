using API.DDD.CRUD.DOMAIN.CommandData.Base;
using System;

namespace API.DDD.CRUD.DOMAIN.CommandData.Command
{
    public class CadastrarClienteCommand : ICommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataHoraInclusao { get; set; }
    }
}
