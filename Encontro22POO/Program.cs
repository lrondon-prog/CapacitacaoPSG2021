using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encontro22POO
{
    class Program
    {
        static void Main(string[] args)
        {
            PessoaFisica teste1 = new PessoaFisica();
            teste1.CodCliente = 1;
            teste1.Nome = "Luiz";
            teste1.CPF = "123456";
            teste1.DataInclusao = DateTime.Now;
            teste1.Endereco = "Rua X, 123";
            teste1.RG = "123456";
            teste1.TituloEleitor = "123456";

            PessoaFisica teste2 = new PessoaFisica() 
            { 
                CodCliente = 2,
                Nome = "João",
                CPF = "456789",
                DataInclusao = DateTime.Now,
                Endereco = "Rua Y, 456",
                RG = "456789",
                TituloEleitor = "456789"
            };

            PessoaFisica teste3 = new PessoaFisica(
                3,
                "Paulo",
                "Rua Z, 789",
                "987654",
                "987654",
                "987654",
                DateTime.Now
                );
        }
    }
}
