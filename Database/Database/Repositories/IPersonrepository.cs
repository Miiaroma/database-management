using System;
using System.Collections.Generic;
using System.Text;
using Database.Model;

namespace Database.Repositories
{
    public interface IPersonrepository
    {
        //CRUD
        void Create(Person person);
        List<Person> ReadByCity(string city);
        Person ReadById(long id);       
        void Update(long id, Person person);
        void Delete(long id);
    }
}
