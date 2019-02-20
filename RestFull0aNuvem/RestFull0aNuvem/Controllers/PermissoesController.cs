using Microsoft.AspNetCore.Mvc;
using RestFull0aNuvem.Negocios;
using System;
using Microsoft.AspNetCore.Http;
using System.Linq;
using RestFull0aNuvem.Data.VO;
using RestFull0aNuvem.Model.Context;

namespace RestFull0aNuvem.Controllers
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    public class PermissoesController : ControllerBase
    {
        private IPermissoesNegocios _PermissoesNegocios;

        public PermissoesController(IPermissoesNegocios permissoesNegocios)
        {
            _PermissoesNegocios = permissoesNegocios;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_PermissoesNegocios.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var Usuario = _PermissoesNegocios.FindById(id);
            if (Usuario == null) return NotFound();

            return Ok(Usuario);
        }

        // GET api/usuarios?page=1&tampage=10
        // [Route("api/[controller]", Name = "rotaPadrao")]
        [HttpGet("{pagina}/{tamanhoPagina}", Name = "rotaPaginadaPemissao")]
        public IActionResult Get(int pagina, int tamanhoPagina)
        {


            if (pagina <= 0 || tamanhoPagina <= 0)
                return BadRequest((new MessagesEspecifica
                {
                    MsgeEpecifica = new[] { "Mensagem 01: nº pagina invalida!", "Mensagem 02: tamanho pagina invalido!" },
                    messages = new Messages
                    {
                        StatusCodigo = "400",
                        StatusDescricao = "Os parametros pagina e tamanhoPagina devem ser maiores que zero."
                    }
                })
                );

            if (tamanhoPagina > 10)
                return BadRequest("O tamanho maximo de pagina permitido e 10.");

            var usrPage = _PermissoesNegocios.FindPage(pagina, tamanhoPagina);

            int totalPaginas = (int)Math.Ceiling(usrPage.Count / Convert.ToDecimal(tamanhoPagina));

            if (pagina > totalPaginas)
                return BadRequest("A pagina solicitada nao existe.");

            HttpContext.Response.Headers.Add("X-Paginacao-TotalPaginas", totalPaginas.ToString());

            if (pagina > 1)
                HttpContext.Response.Headers.Add("X-Paginacao-PaginaAnterior",
                    Url.Link("rotaPaginadaPermissao", new { pagina = pagina - 1, tamanhoPagina = tamanhoPagina }));

            if (pagina < totalPaginas)
                HttpContext.Response.Headers.Add("X-Paginacao-ProximaPagina",
                    Url.Link("rotaPaginadaPermissao", new { pagina = pagina + 1, tamanhoPagina = tamanhoPagina }));

            var usuarios = usrPage.OrderBy(u => u.Id).Skip(tamanhoPagina * (pagina - 1)).Take(tamanhoPagina).ToList();

            return Ok(usuarios);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] PermissaoVO permissaoVO)
        {
            if (permissaoVO == null) return BadRequest();
            return new ObjectResult(_PermissoesNegocios.Create(permissaoVO));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] PermissaoVO permissaoVO)
        {
            if (permissaoVO == null) return BadRequest();
            return new ObjectResult(_PermissoesNegocios.Update(permissaoVO));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var usuario = _PermissoesNegocios.FindById(id);
            if (usuario == null) return NotFound();
            _PermissoesNegocios.Delete(id);
            return NoContent();
        }
    }
}
