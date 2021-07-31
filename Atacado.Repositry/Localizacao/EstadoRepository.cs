using Atacado.Repository.Ancestor;
using Atacado.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Atacado.Repositry.Localizacao
{
    public class EstadoRepository : GenericRepository<DbContext, UnidadesFederacao>
    {
        public EstadoRepository(DbContext contexto) : base(contexto)
        { }
    }
}
