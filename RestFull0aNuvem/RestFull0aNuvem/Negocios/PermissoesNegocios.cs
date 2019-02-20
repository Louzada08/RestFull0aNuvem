using RestFull0aNuvem.Model.Context;
using RestFull0aNuvem.Repositorio;
using RestFull0aNuvem.Data.Converters;
using System.Collections.Generic;
using System.Linq;
using RestFull0aNuvem.Data.VO;

namespace RestFull0aNuvem.Negocios
{
    public class PermissoesNegocios : IPermissoesNegocios
    {
        private IRepository<Permissao> _repository;
        private readonly PermissoesConverter _converter;

        public PermissoesNegocios(IRepository<Permissao> repository)
        {
            _repository = repository;
            _converter = new PermissoesConverter();
        }

        //Metodo responsalvel para criar um novo PermissaoVO
        //e persistir no banco de dados
        public PermissaoVO Create(PermissaoVO PermissaoVO)
        {
            // converte VO para Entidade
            var PermissaoEntity = _converter.Parse(PermissaoVO);
            // persiste a Entidade no bd
            PermissaoEntity = _repository.Create(PermissaoEntity);
            // retorna a entidade convertida e persistida VO
            return _converter.Parse(PermissaoEntity);
        }

        public PermissaoVO Update(PermissaoVO PermissaoVO)
        {

            var PermissaoEntity = _converter.Parse(PermissaoVO);
            PermissaoEntity = _repository.Update(PermissaoEntity);
            return _converter.Parse(PermissaoEntity);
        }

        public PermissaoVO Delete(long id)
        {
            return _converter.Parse(_repository.Delete(id));
        }

        public List<PermissaoVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public List<PermissaoVO> FindPage(int pagina = 1, int tamanhoPagina = 10)
        {
            return _converter.ParseList(_repository.FindPage(pagina, tamanhoPagina)).ToList();
        }

        public PermissaoVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }
    }
}
