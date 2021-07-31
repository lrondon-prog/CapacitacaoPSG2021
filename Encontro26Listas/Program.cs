using Encontro26Listas.Data.Atacado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encontro26Listas
{
    class Program
    {
        static void Main(string[] args)
        {
            //Engine.EngineCategorias crud = new Engine.EngineCategorias();

            AtacadoModel contexto = new AtacadoModel();
            List<categoria> crud = contexto.categorias.ToList();

            Console.WriteLine("Lista de Categorias:");

            foreach (var item in crud)
            {
                Console.WriteLine("ID: {0} - Descrição: {1}", item.catid, item.descricao);
            }
            
            Console.ReadKey();
        }
    }
}
