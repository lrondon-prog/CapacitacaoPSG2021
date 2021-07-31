using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteConsoleApp
{
    public class Alfa
    {
        private Beta getBeta;
        public void Executar()
        {

            try
            {
                Console.WriteLine("Estou executando em Alfa");
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
