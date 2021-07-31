using Atacado.POCO.Model;
using Atacado.Service.Localizacao;
using AtacadoRestApi.Ancestor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AtacadoRestApi.Controllers
{
    /// <summary>
    /// Serviços de UnidadesFederacao utilizando disegn patterns
    /// </summary>
    [RoutePrefix("atacado/localizacao/estados")]
    public class EstadoController : GenericBaseController<EstadoPoco>
    {
        private EstadoService servico;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        public EstadoController() : base()
        {
            this.servico = new EstadoService(this.contexto);
        }

        /// <summary>
        /// Obter todos os registros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<EstadoPoco>))]
        public HttpResponseMessage Get()
        {
            try
            {
                List<EstadoPoco> poco = this.servico.ObterTodos().ToList();
                return Request.CreateResponse<List<EstadoPoco>>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Obter registro por chave primaria
        /// </summary>
        /// <param name="id">Chave primaria</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(EstadoPoco))]
        public HttpResponseMessage Get([FromUri] int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "O id não pode ser zero");
            }
            try
            {
                EstadoPoco poco = this.servico.Obter(id);
                return Request.CreateResponse<EstadoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Obter municipios por sigla do estado
        /// </summary>
        /// <param name="siglauf">Sigla do estado</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{siglauf}/municipios")]
        [ResponseType(typeof(List<MunicipioPoco>))]
        public HttpResponseMessage GetMunicipiosPorSigla([FromUri] string siglauf)
        {
            if (string.IsNullOrEmpty(siglauf))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "SiglaUF deve ser informada.");
            }
            if (siglauf.Length != 2)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "SiglaUF deve conter duas letras.");
            }
            try
            {
                string sigla = siglauf.ToUpper();
                MunicipioService srv = new MunicipioService(this.contexto);
                List<MunicipioPoco> lista = srv.ObterTodos()
                    .Where(mun => mun.SiglaUF == sigla).ToList();
                return Request.CreateResponse<List<MunicipioPoco>>(HttpStatusCode.OK, lista);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Obter municipios por id do estado
        /// </summary>
        /// <param name="ufid">Chave primaria do estado</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{ufid:int}/municipio")]
        [ResponseType(typeof(List<MunicipioPoco>))]
        public HttpResponseMessage GetMunicipiosPorID([FromUri] int ufid)
        {
            if (ufid == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                MunicipioService srv = new MunicipioService(this.contexto);
                List<MunicipioPoco> lista = srv.ObterTodos()
                    .Where(mun => mun.UFID == ufid).ToList();
                return Request.CreateResponse<List<MunicipioPoco>>(HttpStatusCode.OK, lista);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Obter mesoregioes por id do estado
        /// </summary>
        /// <param name="ufid">Chave primaria do estado</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{ufid:int}/mesoregioes")]
        [ResponseType(typeof(EstadoPoco))]
        public HttpResponseMessage GetMesoregioesPorID([FromUri] int ufid)
        {
            if (ufid == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                MesoregiaoService srv = new MesoregiaoService(this.contexto);
                List<MesoregiaoPoco> lista = srv.ObterTodos()
                    .Where(mes => mes.UFID == ufid).ToList();
                return Request.CreateResponse<List<MesoregiaoPoco>>(HttpStatusCode.OK, lista);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Incluir novo registro
        /// </summary>
        /// <param name="poco">Objeto a ser incluido</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(EstadoPoco))]
        public HttpResponseMessage Post([FromBody] EstadoPoco poco)
        {
            try
            {
                EstadoPoco respPoco = this.servico.Incluir(poco);
                return Request.CreateResponse<EstadoPoco>(HttpStatusCode.OK, respPoco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Atualizar um registro
        /// </summary>
        /// <param name="poco">Objeto a ser atualizado</param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        [ResponseType(typeof(EstadoPoco))]
        public HttpResponseMessage Put([FromBody] EstadoPoco poco)
        {
            try
            {
                EstadoPoco respPoco = this.servico.Atualizar(poco);
                return Request.CreateResponse<EstadoPoco>(HttpStatusCode.OK, respPoco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Excluir um registro
        /// </summary>
        /// <param name="id">Chave primaria</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(EstadoPoco))]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                EstadoPoco poco = this.servico.Excluir(id);
                return Request.CreateResponse<EstadoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}