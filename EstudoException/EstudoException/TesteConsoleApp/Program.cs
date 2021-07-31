using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando o programa....");


            try
            {
                Alfa getAlfa = new Alfa();
                getAlfa.Executar();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Ocorreu um erro: {0}", ex.Message);
            }

            Console.ReadLine();
        }
    }
}
