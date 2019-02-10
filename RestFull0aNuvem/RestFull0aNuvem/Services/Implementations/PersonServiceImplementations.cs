using System;
using System.Collections.Generic;
using System.Threading;
using RestFull0aNuvem.Model;

namespace RestFull0aNuvem.Services.Implementations
{
    public class PersonServiceImplementations : IPersonService
    {
        private int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementaId(),
                FirstName = "Person nome" + i,
                LastName = "Person sobrenome" + i,
                Address = "Endereço" + i,
                Gender = "Genero"
            };
        }

        private long IncrementaId()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Anderson Luiz",
                LastName = "Louzada",
                Address = "110 Norte Alameda 23 Lote 50",
                Gender = "Masculino"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
