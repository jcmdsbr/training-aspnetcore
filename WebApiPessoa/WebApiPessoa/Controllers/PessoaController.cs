using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPessoa.Filtros;
using WebApiPessoa.Models;
using WebApiPessoa.Repositorio;

namespace WebApiPessoa.Controllers
{
    [RoutePrefix("api/pessoa")]
    [ValidadorRequisicao]
    public class PessoaController : ApiController
    {
        [Route("consultarPorNome/{nome}")]
        [HttpGet]
        public HttpResponseMessage ConsultarPorNome(string nome)
        {
            var pessoa = PessoaContexto.ConsultarPor(x => x.Nome.Equals(nome));

            return Request.CreateResponse(HttpStatusCode.OK, pessoa);
        }

        //api/Pessoa/
        public HttpResponseMessage Get()
        {
            var pessoas = PessoaContexto.ConsultarTodos();

            return Request.CreateResponse(HttpStatusCode.OK, pessoas);
        }

        //api/Pessoa/1
        public HttpResponseMessage Get(int id)
        {
            var pessoa = PessoaContexto.ConsultarPor(x => x.Id.Equals(id));

            return Request.CreateResponse(HttpStatusCode.OK, pessoa);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] Pessoa pessoa)
        {
            PessoaContexto.Add(pessoa);

            return Request.CreateResponse(HttpStatusCode.Created, PessoaContexto.ConsultarTodos());
        }

        [Route("{codigo}")]
        [HttpPut]
        public HttpResponseMessage Put(int codigo, [FromBody] Pessoa pessoa)
        {
            var updValido = PessoaContexto.Update(x => x.Id == codigo, pessoa);
            var status = updValido ? HttpStatusCode.Accepted : HttpStatusCode.NoContent;

            return Request.CreateResponse(status, PessoaContexto.ConsultarTodos());
        }

        //api/Pessoa?codigo=
        [Route("{codigo}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int codigo)
        {
            var pessoa = PessoaContexto.ConsultarPor(x => x.Id == codigo);

            if (pessoa != null)
            {
                PessoaContexto.Remove(pessoa);

                return Request
                    .CreateResponse(HttpStatusCode.OK, PessoaContexto.ConsultarTodos());
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}