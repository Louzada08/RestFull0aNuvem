using RestFull0aNuvem.Data.VO;
using System.Collections.Generic;

namespace RestFull0aNuvem.Negocios
{
    public interface IPermissoesNegocios
    {
        PermissaoVO Create(PermissaoVO PermissaoVO);
        PermissaoVO FindById(long id);
        List<PermissaoVO> FindPage(int pagina, int tamanhoPagina);
        List<PermissaoVO> FindAll();
        PermissaoVO Update(PermissaoVO PermissaoVO);
        PermissaoVO Delete(long id);
    }
}
