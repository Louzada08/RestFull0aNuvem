using Microsoft.AspNetCore.Mvc;
using RestFull0aNuvem.Negocios;
using System;
using Microsoft.AspNetCore.Http;
using System.Linq;
using RestFull0aNuvem.Data.VO;
using RestFull0aNuvem.Model.Context;
using System.Collections.Generic;

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
        [HttpGet("{pagina}/{tamanhoPagina}", Name = "rotaPaginadaUsuario")]
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

            var usrPage = _UsuarioNegocios.FindPage(pagina, tamanhoPagina);

            int totalPaginas = (int)Math.Ceiling(usrPage.Count / Convert.ToDecimal(tamanhoPagina));

            if (pagina > totalPaginas)
                return BadRequest("A pagina solicitada nao existe.");

            HttpContext.Response.Headers.Add("X-Paginacao-TotalPaginas", totalPaginas.ToString());

            if (pagina > 1)
                HttpContext.Response.Headers.Add("X-Paginacao-PaginaAnterior",
                    Url.Link("rotaPaginadaUsuario", new { pagina = pagina - 1, tamanhoPagina = tamanhoPagina }));
            
            if (pagina < totalPaginas)
                HttpContext.Response.Headers.Add("X-Paginacao-ProximaPagina",
                    Url.Link("rotaPaginadaUsuario", new { pagina = pagina + 1, tamanhoPagina = tamanhoPagina }));
              
            var usuarios = usrPage.OrderBy(u => u.Id).Skip(tamanhoPagina * (pagina - 1)).Take(tamanhoPagina).ToList();

            return Ok(usuarios);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] UsuarioVO usuarioVO)
        {
            if (usuarioVO == null) return BadRequest();
            return new ObjectResult(_UsuarioNegocios.Create(usuarioVO));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] UsuarioVO usuarioVO)
        {
            if (usuarioVO == null) return BadRequest();
            return new ObjectResult(_UsuarioNegocios.Update(usuarioVO));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var usuario = _UsuarioNegocios.FindById(id);
            if (usuario == null) return NotFound();
            _UsuarioNegocios.Delete(id);
            return NoContent();
        }
    }
}
