using System;
using System.Collections.Generic;
using RestFull0aNuvem.Model.Context;
using System.Linq;

namespace RestFull0aNuvem.Repositorio.Implementations
{
    public class UsuarioRepositorios : IUsuarioRepositorio
    {
        private BdFoodContext _context;

        public UsuarioRepositorios(BdFoodContext context)
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

        public void Delete(long id)
        {
            var result = _context.Usuarios.SingleOrDefault(p => p.Idpk.Equals(id));
            try
            {
                if (result != null) _context.Usuarios.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> FindAll()
        {
            List<Usuario> usuarios = _context.Usuarios.OrderBy(u => u.Nome).ToList();

            return usuarios;
        }

        public List<Usuario> FindPage(int pagina = 1, int tamanhoPagina = 10)
        {
            List<Usuario> usuarios = _context.Usuarios.ToList();
            //  var usuarios = _context.Usuarios.OrderBy(u => u.Idpk).Skip(tamanhoPagina * (pagina -1)).Take(tamanhoPagina).ToList();
            return usuarios;
        }

        public Usuario FindById(long id)
        {
            return _context.Usuarios.SingleOrDefault(p => p.Idpk.Equals(id));
        }

        public Usuario Update(Usuario usuario)
        {
            if (!Exist(usuario.Idpk)) return new Usuario();
            var result = _context.Usuarios.SingleOrDefault(p => p.Idpk.Equals(usuario.Idpk));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return usuario;
        }

        public bool Exist(long? idpk)
        {
            return _context.Usuarios.Any(p => p.Idpk.Equals(idpk));
        }
    }
}
