using Atacado.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encontro27UsandoDAL
{
    class Program
    {
        static void Main(string[] args)
        {
            AtacadoModel crud = new AtacadoModel();
            List<Regiao> regioes = crud.Regioes.ToList();
            Console.WriteLine("Lista de Regiões:");
            foreach (var item in regioes)
            {
                Console.WriteLine("ID: {0} - Descrição: {1}", item.RegiaoID, item.Descricao);
            }
            Console.ReadKey();
        }
    }
}
