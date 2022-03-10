using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Data_Model;
using TodoApp.Data_Model.Entity;

namespace TodoApp.Business_Model
{
    public class BoardOperations
    {
        private readonly BoardRepository _boardDataModel=new BoardRepository();

        public void SetDefaultBoards()
        {
            _boardDataModel.SetDefaultBoards();
        }
       

        public List<Board> GetAll()
        {
            return _boardDataModel.GetAll();
        }
    }
}
