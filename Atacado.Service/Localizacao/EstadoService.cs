
using Atacado.POCO.Model;
using Atacado.DAL.Model;
using Atacado.Repository.Localizacao;
using Atacado.Service.Ancestor;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atacado.Mapping.Localizacao;
using Atacado.Repositry.Localizacao;

namespace Atacado.Service.Localizacao
{
    public class EstadoService :
        GenericService<DbContext, UnidadesFederacao, EstadoPoco>,
        IService<EstadoPoco>
    {
        public EstadoService(DbContext contexto)
        {
            this.repositorio = new EstadoRepository(contexto);
            this.mapa = new EstadoMapping();
        }

        public EstadoPoco Obter(int id)
        {
            UnidadesFederacao dominio = this.repositorio.Read(unifed => unifed.UFID == id);
            EstadoPoco poco = this.mapa.GetMapper.Map<EstadoPoco>(dominio);
            return poco;
        }

        public IEnumerable<EstadoPoco> ObterTodos()
        {
            List<UnidadesFederacao> lista = this.repositorio.Browsable().ToList();
            List<EstadoPoco> listaPoco = this.mapa.GetMapper.Map<List<EstadoPoco>>(lista);
            return listaPoco;
        }

        public EstadoPoco Atualizar(EstadoPoco poco)
        {
            UnidadesFederacao unifed = this.mapa.GetMapper.Map<UnidadesFederacao>(poco);
            UnidadesFederacao alterada = this.repositorio.Edit(unifed);
            EstadoPoco novoPoco = this.mapa.GetMapper.Map<EstadoPoco>(alterada);
            return novoPoco;
        }

        public EstadoPoco Excluir(int id)
        {
            UnidadesFederacao unifed = this.repositorio.Read(reg => reg.UFID == id);
            EstadoPoco poco = this.mapa.GetMapper.Map<EstadoPoco>(unifed);
            this.repositorio.Delete(unifed);
            return poco;
        }

        public EstadoPoco Incluir(EstadoPoco poco)
        {
            UnidadesFederacao unifed = this.mapa.GetMapper.Map<UnidadesFederacao>(poco);
            UnidadesFederacao nova = this.repositorio.Add(unifed);
            EstadoPoco novoPoco = this.mapa.GetMapper.Map<EstadoPoco>(nova);
            return novoPoco;
        }

        public void Dispose()
        {
            this.repositorio = null;
            this.mapa = null;
        }
    }
}