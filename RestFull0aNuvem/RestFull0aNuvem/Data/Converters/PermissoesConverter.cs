using RestFull0aNuvem.Data.Converter;
using RestFull0aNuvem.Data.VO;
using RestFull0aNuvem.Model.Context;
using System.Collections.Generic;
using System.Linq;

namespace RestFull0aNuvem.Data.Converters
{
    public class PermissoesConverter : IParser<PermissaoVO, Permissao>, IParser<Permissao, PermissaoVO>
    {
        public Permissao Parse(PermissaoVO origin)
        {
            if (origin == null) return null;
            return new Permissao
            {
                Id = origin.Id,
                Titulo = origin.Titulo,
                Permitir = origin.Permitir,
                PermissaoParentId = origin.PermissaoParentId,
              //  PermisaoParent = (ICollection<Permissao>)origin.PermisaoParentVO
            };
        }

        public PermissaoVO Parse(Permissao origin)
        {
            if (origin == null) return null;
            return new PermissaoVO
            {
                Id = origin.Id,
                Titulo = origin.Titulo,
                Permitir = origin.Permitir,
                PermissaoParentId = origin.PermissaoParentId,
              //  PermisaoParentVO = (ICollection<PermissaoVO>)origin.PermisaoParent
            };
        }

        public List<Permissao> ParseList(List<PermissaoVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PermissaoVO> ParseList(List<Permissao> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
