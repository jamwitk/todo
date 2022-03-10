using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Data_Model.Entity;

namespace TodoApp.Data_Model
{
    public class BoardRepository
    {
        private List<Board> _boards = new();



        public void SetDefaultBoards()
        {
            _boards.Add(new Board()
                {
                Id = 0,
                Name = "Todo"
                }
            );
            _boards.Add(new Board()
                {
                Id = 1,
                Name = "In Progress"
                }
            );
            _boards.Add(new Board()
                {
                Id = 2,
                Name = "Done"
                }
            );
        }
        public void Add(Board board)
        {
            _boards.Add(board);
        }

       
        public List<Board> GetAll()
        {
            return _boards;
        }
    }
}
