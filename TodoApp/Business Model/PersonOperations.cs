using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Data_Model;
using TodoApp.Data_Model.Entity;

namespace TodoApp.Business_Model
{
    public class PersonOperations
    {
        private readonly PersonRepository _personDatamodel = new ();

        public List<Person> GetAll()
        {
            return _personDatamodel.GetAll();
        }
    }
}
