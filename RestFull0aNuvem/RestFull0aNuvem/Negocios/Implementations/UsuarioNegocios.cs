using System.Collections.Generic;
using RestFull0aNuvem.Model.Context;
using System.Linq;
using System;
using RestFull0aNuvem.Repositorio;

namespace RestFull0aNuvem.Negocios.Implementations
{
    public class UsuarioNegocios : IUsuarioNegocios
    {
        private IUsuarioRepositorio _repository;

        public UsuarioNegocios(IUsuarioRepositorio repository)
        {
            _repository = repository;
        }

        //Metodo responsalvel para criar um novo usuario
        //e persistir no banco de dados
        public Usuario Create(Usuario usuario)
        {
            return _repository.Create(usuario);
        }

        public Usuario Update(Usuario usuario)
        {
            return _repository.Update(usuario);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Usuario> FindAll()
        {
            return _repository.FindAll();
        }

        public List<Usuario> FindPage(int pagina = 1, int tamanhoPagina = 10)
        {
            return _repository.FindPage(pagina, tamanhoPagina).ToList();
        }

        public Usuario FindById(long id)
        {
            return _repository.FindById(id);
        }
    }
}
