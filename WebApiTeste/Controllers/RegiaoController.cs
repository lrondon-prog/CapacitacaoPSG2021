using Atacado.DAL.Model;
using Atacado.POCO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTeste.Controllers
{
    public class RegiaoController : ApiController
    {
        public List<RegiaoPoco> Get()
        {
            AtacadoModel contexto = new AtacadoModel();
            List<Regiao> regioes = contexto.Regioes.ToList();

            List<RegiaoPoco> regioesPoco = new List<RegiaoPoco>();

            foreach (var item in regioes)
            {
                regioesPoco.Add(new RegiaoPoco() 
                { 
                    RegiaoID = item.RegiaoID, 
                    Descricao = item.Descricao,
                    SiglaRegiao = item.SiglaRegiao,
                    DataInclusao = item.datainsert
                });
            }

            return regioesPoco;
        }
    }
}
