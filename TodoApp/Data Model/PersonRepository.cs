using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Data_Model.Entity;

namespace TodoApp.Data_Model
{
    public class PersonRepository
    {
        private List<Person> persons = new List<Person>();

        public PersonRepository()
        {
            persons.Add(new Person
            {
                Id = 111,
                FirstName = "Obama",
                SecondName = "Barack"
            });
            persons.Add(new Person
            {
                Id = 222,
                FirstName = "Vladimir",
                SecondName = "Putin"
            });
            persons.Add(new Person
            {
                Id = 333,
                FirstName = "Mark",
                SecondName = "Zackerberg"
            });
            persons.Add(new Person
            {
                Id = 444,
                FirstName = "Elon",
                SecondName = "Musk"
            });

        }
        public void Add(Person person)
        {
            persons.Add(person);
        }
        public List<Person> GetAll()
        {
            return persons;
        }
    }
}
