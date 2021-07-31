using Atacado.DAL.Model;
using Atacado.Repository.Ancestor;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repository.Estoque
{
    public class CategoriaRepository : 
        GenericRepository<DbContext, categoria>
      
    {
        public CategoriaRepository(DbContext contexto) : base(contexto)
        { }
    }
}
