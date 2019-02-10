using RestFull0aNuvem.Model;
using System.Collections.Generic;

namespace RestFull0aNuvem.Services
{
    interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
