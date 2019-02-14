﻿using RestFull0aNuvem.Model.Context;
using System.Collections.Generic;

namespace RestFull0aNuvem.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Usuario Create(Usuario usuario);
        Usuario FindById(long id);
        List<Usuario> FindPage(int pagina, int tamanhoPagina);
        List<Usuario> FindAll();
        Usuario Update(Usuario usuario);
        void Delete(long id);
    }
}