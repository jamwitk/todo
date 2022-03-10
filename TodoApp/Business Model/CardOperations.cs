using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Data_Model;
using TodoApp.Data_Model.Entity;

namespace TodoApp.Business_Model
{
    public class CardOperations
    {
        private readonly CardRepository _cardDataModel = new();
        
        public void SetDefaultCards()
        {
            _cardDataModel.SetDefaultCards();
        }

        public void Add(Card card)
        {
            _cardDataModel.Add(card);
        }

        public bool RemoveByTitle()
        {
            Console.Clear();
            Console.WriteLine("Öncelikle Silmek istediğiniz kartı seçmeniz gerekiyor");
            Console.Write("Lütfen Kart Başlığını yazınız: ");
            var titleToRemove = Console.ReadLine();
            var cardToRemove = GetAll().Where(x => x.Title!.ToLower().Equals(titleToRemove!.ToLower())).ToList();
            if(cardToRemove.Count!= 0)
            {
                _cardDataModel.Remove(cardToRemove);
                Console.WriteLine("Kart silindi. ");
                return true;
            }
            Console.WriteLine("Aradığını kriterlere uygun kart board'da bulunamadı. Lütfen seçim yapınız.");
            Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
            Console.WriteLine("* Yeniden denemek için : (2)");
            var response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    return true;
                case "2":
                    RemoveByTitle();
                    break;
            }
            return false;
        }
        public List<Card> GetAll()
        {
           return _cardDataModel.GetAll();
        }

        public void Update(Card cardToUpdate,int newBoardId)
        {
            cardToUpdate.BoardId = newBoardId;
            _cardDataModel.Update(cardToUpdate);
        }
    }
}
