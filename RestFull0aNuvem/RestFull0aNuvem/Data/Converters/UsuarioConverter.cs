using RestFull0aNuvem.Data.Converter;
using RestFull0aNuvem.Data.VO;
using RestFull0aNuvem.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestFull0aNuvem.Data.Converters
{
    public class UsuarioConverter : IParser<UsuarioVO, Usuario>, IParser<Usuario, UsuarioVO>
    {
        public Usuario Parse(UsuarioVO origin)
        {
            if (origin == null) return null;
            return new Usuario
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Login = origin.Login,
                Senha = "NovaSenha"
            };
        }

        public UsuarioVO Parse(Usuario origin)
        {
            if (origin == null) return null;
            return new UsuarioVO
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Login = origin.Login,
                Senha = origin.Senha
            };
        }

        public List<Usuario> ParseList(List<UsuarioVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<UsuarioVO> ParseList(List<Usuario> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
