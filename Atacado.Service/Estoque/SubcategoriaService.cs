using Atacado.DAL.Model;
using Atacado.Mapping.Estoque;
using Atacado.POCO.Model;
using Atacado.Repository.Estoque;
using Atacado.Service.Ancestor;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Estoque
{
    public class SubcategoriaService :
       GenericService<DbContext, subcategoria, SubcategoriaPoco>,
       IService<SubcategoriaPoco>
    {

        public SubcategoriaService(DbContext contexto)
        {
            this.repositorio = new SubcategoriaRepository(contexto);
            this.mapa = new SubcategoriaMap();
        }

        public SubcategoriaPoco Incluir(SubcategoriaPoco poco)
        {
            subcategoria cat = this.mapa.GetMapper.Map<subcategoria>(poco);
            subcategoria nova = this.repositorio.Add(cat);
            SubcategoriaPoco novoPoco = this.mapa.GetMapper.Map<SubcategoriaPoco>(nova);
            return novoPoco;
        }

        public SubcategoriaPoco Atualizar(SubcategoriaPoco poco)
        {
            subcategoria cat = this.mapa.GetMapper.Map<subcategoria>(poco);
            subcategoria alterada = this.repositorio.Edit(cat);
            SubcategoriaPoco novoPoco = this.mapa.GetMapper.Map<SubcategoriaPoco>(alterada);
            return novoPoco;
        }

        public SubcategoriaPoco Excluir(int id)
        {
            subcategoria cat = this.repositorio.Read(ct => ct.catid == id);
            subcategoria excluida = this.repositorio.Delete(cat);
            SubcategoriaPoco novoPoco = this.mapa.GetMapper.Map<SubcategoriaPoco>(excluida);

            return novoPoco;
        }


        public SubcategoriaPoco Obter(int id)
        {
            subcategoria dominio = this.repositorio.Read(cat => cat.catid == id);
            SubcategoriaPoco poco = this.mapa.GetMapper.Map<SubcategoriaPoco>(dominio);
            return poco;

        }

        public IEnumerable<SubcategoriaPoco> ObterTodos()
        {
            List<subcategoria> lista = this.repositorio.Browse().ToList();
            List<SubcategoriaPoco> listaPoco = this.mapa.GetMapper.Map<List<SubcategoriaPoco>>(lista);
            return listaPoco;

        }

    }
}
