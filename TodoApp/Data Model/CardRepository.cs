using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Data_Model.Entity;

namespace TodoApp.Data_Model
{
    public class CardRepository
    {
        private List<Card> _cards = new();

        public void SetDefaultCards()
        {
            Add(new Card()
            {
                BoardId = 2,
                Title = "Card 1",
                Description = "Card 1 Description",
                AssociatedPersonId = 111,
                CardSize = Size.S
            });
            Add(new Card()
            {
                BoardId = 1,
                Title = "Card 1",
                Description = "Card 1 Description",
                AssociatedPersonId = 111,
                CardSize = Size.S
            });
            Add(new Card()
            {
                BoardId = 0,
                Title = "Card 2",
                Description = "Card 2 Description",
                AssociatedPersonId = 333,
                CardSize = Size.XL
            });
            var item = new Card
            {
                BoardId = 0,
                Title = "Card 5",
                Description = "Card 5 Description",
                AssociatedPersonId = 333,
                CardSize = Size.XL
            };
            Add(item);
            Add(new Card()
            {
                BoardId = 2,
                Title = "Card 3",
                Description = "Card 3 Description",
                AssociatedPersonId = 444,
                CardSize = Size.XS
            });
        } 
        public List<Card> GetAll()
        {
            return _cards;
        }

        public void Add(Card card)
        {
            _cards.Add(card);
        }

        public void Remove(IEnumerable<Card> cardToRemove)
        {
            foreach (var card in cardToRemove)
            {
                _cards.Remove(card);
            }
        }

        public void Update(Card card)
        {
            var cardToUpdate = _cards.Find(x => x.Title == card.Title);
            if (cardToUpdate is not null)
            {
                cardToUpdate.BoardId = card.BoardId;
            }
        }
    }
}
