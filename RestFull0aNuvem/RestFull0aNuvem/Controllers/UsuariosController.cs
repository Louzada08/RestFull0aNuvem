using Microsoft.AspNetCore.Mvc;
using RestFull0aNuvem.Model.Context;
using RestFull0aNuvem.Negocios;
using System;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace RestFull0aNuvem.Controllers
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioNegocios _UsuarioNegocios;

        public UsuariosController(IUsuarioNegocios usuarioNegocios)
        {
            _UsuarioNegocios = usuarioNegocios;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_UsuarioNegocios.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var Usuario = _UsuarioNegocios.FindById(id);
            if (Usuario == null) return NotFound();

            return Ok(Usuario);
        }

        // GET api/usuarios?page=1&tampage=10
        // [Route("api/[controller]", Name = "rotaPadrao")]
        [HttpGet("{pagina}/{tamanhoPagina}", Name = "rotaPaginada")]
        public IActionResult Get(int pagina, int tamanhoPagina)
        {
            if (pagina <= 0 || tamanhoPagina <= 0)
                return BadRequest("Os parametros pagina e tamanhoPagina devem ser maiores que zero.");

            if (tamanhoPagina > 10)
                return BadRequest("O tamanho maximo de pagina permitido e 10.");

            var usrPage = _UsuarioNegocios.FindPage(pagina, tamanhoPagina);

            int totalPaginas = (int)Math.Ceiling(usrPage.Count / Convert.ToDecimal(tamanhoPagina));

            if (pagina > totalPaginas)
                return BadRequest("A pagina solicitada nao existe.");

            HttpContext.Response.Headers.Add("X-Paginacao-TotalPaginas", totalPaginas.ToString());

            if (pagina > 1)
                HttpContext.Response.Headers.Add("X-Paginacao-PaginaAnterior",
                    Url.Link("rotaPaginada", new { pagina = pagina - 1, tamanhoPagina = tamanhoPagina }));
            
            if (pagina < totalPaginas)
                HttpContext.Response.Headers.Add("X-Paginacao-ProximaPagina",
                    Url.Link("rotaPaginada", new { pagina = pagina + 1, tamanhoPagina = tamanhoPagina }));
              

            var usuarios = usrPage.OrderBy(u => u.Idpk).Skip(tamanhoPagina * (pagina - 1)).Take(tamanhoPagina).ToList();

            return Ok(usuarios);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            if (usuario == null) return BadRequest();
            return new ObjectResult(_UsuarioNegocios.Create(usuario));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Usuario value)
        {
            if (value == null) return BadRequest();
            return new ObjectResult(_UsuarioNegocios.Update(value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _UsuarioNegocios.Delete(id);
        }
    }
}
