using System;
using System.Collections.Generic;
using System.Text;
using PersonDB.Models;

namespace PersonDB.Repositories
{
    public interface IPersonRepository
    {
        //CRUD
        void Create(Person person);

        List<Person> Read();
        Person Read(long id);

        void Update(long id, Person person);
        void Delete(long id);
    }
}
