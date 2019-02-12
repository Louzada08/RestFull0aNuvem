using System;
using System.Collections.Generic;
using System.Threading;
using RestFull0aNuvem.Model.Context;
using System.Linq;

namespace RestFull0aNuvem.Services.Implementations
{
    public class UsuarioServiceImplementations : IUsuarioService
    {
        private int count;
        private BdFoodContext _context;

        public UsuarioServiceImplementations(BdFoodContext context)
        {
            _context = context;
        }

        //Metodo responsalvel para criar um novo usuario
        //e persistir no banco de dados
        public Usuario Create(Usuario usuario)
        {
           // if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                _context.Add(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usuario;
        }

        public List<Usuario> Delete(int id)
        {
            List<Usuario> usuarios = new List<Usuario>();
            for (int i = 0; i < 8; i++)
            {
                Usuario usuario = MockUsuario(i);
                usuarios.Add(usuario);
            }
            if (id > -1 && id < 8) usuarios.RemoveAt(id);
            return usuarios;
        }

        public List<Usuario> FindAll()
        {
            List<Usuario> usuarios = _context.Usuarios.OrderBy(u => u.Nome).ToList();

            return usuarios;
        }

        public List<Usuario> FindPage(int pagina = 1, int tamanhoPagina = 10)
        {
            List<Usuario> usuarios =  _context.Usuarios.ToList();
          //  var usuarios = _context.Usuarios.OrderBy(u => u.Idpk).Skip(tamanhoPagina * (pagina -1)).Take(tamanhoPagina).ToList();

            return usuarios;
        }

        private Usuario MockUsuario(int i)
        {
            return null;
        }

        private long IncrementaId()
        {
            return Interlocked.Increment(ref count);
        }

        public Usuario FindById(long id)
        {
            return new Usuario
            {

            };
        }

        public Usuario Update(Usuario usuario)
        {
            return usuario;
        }
    }
}
