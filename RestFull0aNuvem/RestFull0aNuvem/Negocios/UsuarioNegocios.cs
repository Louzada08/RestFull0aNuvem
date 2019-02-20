using System.Collections.Generic;
using RestFull0aNuvem.Model.Context;
using System.Linq;
using RestFull0aNuvem.Repositorio;
using RestFull0aNuvem.Data.Converters;
using RestFull0aNuvem.Data.VO;

namespace RestFull0aNuvem.Negocios
{
    public class UsuarioNegocios : IUsuarioNegocios
    {
        private IRepository<Usuario> _repository;
        private readonly UsuarioConverter _converter;

        public UsuarioNegocios(IRepository<Usuario> repository)
        {
            _repository = repository;
            _converter = new UsuarioConverter();
        }

        //Metodo responsalvel para criar um novo UsuarioVO
        //e persistir no banco de dados
        public UsuarioVO Create(UsuarioVO usuarioVO)
        {
            // converte VO para Entidade
            var usuarioEntity = _converter.Parse(usuarioVO);
            // persiste a Entidade no bd
            usuarioEntity = _repository.Create(usuarioEntity);
            // retorna a entidade convertida e persistida VO
            return _converter.Parse(usuarioEntity);
        }

        public UsuarioVO Update(UsuarioVO usuarioVO)
        {

            var usuarioEntity = _converter.Parse(usuarioVO);
            usuarioEntity = _repository.Update(usuarioEntity);
            return _converter.Parse(usuarioEntity);
        }

        public UsuarioVO Delete(long id)
        {
            return _converter.Parse(_repository.Delete(id));
        }

        public List<UsuarioVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public List<UsuarioVO> FindPage(int pagina = 1, int tamanhoPagina = 10)
        {
            return _converter.ParseList(_repository.FindPage(pagina, tamanhoPagina)).ToList();
        }

        public UsuarioVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }
    }
}
