using RestFull0aNuvem.Model.Base;
using System.Collections.Generic;

namespace RestFull0aNuvem.Repositorio
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T objT);
        T FindById(long id);
        List<T> FindPage(int pagina, int tamanhoPagina);
        List<T> FindAll();
        T Update(T objT);
        T Delete(long id);

        bool Existe(long? id);
    }
}
