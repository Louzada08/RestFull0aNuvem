using RestFull0aNuvem.Model.Context;
using System.Collections.Generic;

namespace RestFull0aNuvem.Services
{
    public interface IUsuarioService
    {
        Usuario Create(Usuario usuario);
        Usuario FindById(long id);
        List<Usuario> FindPage(int pagina, int tamanhoPagina);
        List<Usuario> FindAll();
        Usuario Update(Usuario usuario);
        List<Usuario> Delete(int id);
    }
}
