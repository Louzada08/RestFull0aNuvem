using RestFull0aNuvem.Data.VO;
using System.Collections.Generic;

namespace RestFull0aNuvem.Negocios

{
    public interface IUsuarioNegocios
    {
        UsuarioVO Create(UsuarioVO UsuarioVO);
        UsuarioVO FindById(long id);
        List<UsuarioVO> FindPage(int pagina, int tamanhoPagina);
        List<UsuarioVO> FindAll();
        UsuarioVO Update(UsuarioVO UsuarioVO);
        UsuarioVO Delete(long id);
    }
}
