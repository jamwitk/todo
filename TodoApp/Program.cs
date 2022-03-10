using System;
using TodoApp.Business_Model;
using TodoApp.Data_Model;
using TodoApp.Data_Model.Entity;

namespace TodoApp
{
    public class Program
    {
        static readonly PersonOperations _personBusiness = new PersonOperations();
        static readonly BoardOperations _boardBusiness = new BoardOperations();
        private static readonly CardOperations _cardBusiness = new CardOperations();
        public static void Main(string[] args)
        {
            _boardBusiness.SetDefaultBoards();
            _cardBusiness.SetDefaultCards();
            while (true)
            {
                ListFeatures();
                var response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                    {
                        ListAllBoard();
                        break;
                    }
                    case "2":
                    {
                        AddCardToBoard();
                        break;
                    }
                    case "3":
                    {
                        RemoveCardFromBoard();
                        break;
                    }
                    case "4":
                    {
                        UpdateCardFromBoard();
                        break;
                    }
                    case "5":
                    {
                        Environment.Exit(0);
                        break;
                    }
                }
            }
        }

        private static void UpdateCardFromBoard()
        {
            Console.Clear();
            Console.WriteLine("Öncelikle Taşımak istediğiniz kartı seçmeniz gerekiyor");
            Console.Write("Lütfen Kart başlığını yazınız: ");
            var cardName = Console.ReadLine();
            var cardToUpdate = _cardBusiness.GetAll().Find(x => x.Title == cardName);
            if (cardToUpdate != null)
            {
                var person = _personBusiness.GetAll().Find(x => x.Id == cardToUpdate.AssociatedPersonId);
                var cardBoard= _boardBusiness.GetAll().Find(x => x.Id == cardToUpdate.BoardId);
                Console.WriteLine("Bulunan Kart Bilgileri");
                Console.WriteLine("**********************");
                Console.WriteLine($"Başlık         : {cardToUpdate.Title}");
                Console.WriteLine($"İçerik         : {cardToUpdate.Description}");
                Console.WriteLine($"Atanan Kişi    : {person!.FirstName} {person.SecondName}");
                Console.WriteLine($"Büyüklük       : {cardToUpdate.CardSize}");
                Console.WriteLine($"Bulunan Sütün  : {cardBoard!.Name}");
                Console.WriteLine();
                Console.WriteLine("Lütfen Taşımak istediğiniz Line'ı seçiniz");
                foreach (var board in _boardBusiness.GetAll())
                {
                    Console.WriteLine($"({board.Id}) {board.Name}");
                }
                var selectedLine = int.Parse(Console.ReadLine() ?? string.Empty);
                var check = _boardBusiness.GetAll().FirstOrDefault(x => x.Id == selectedLine);
                if (check is not null)
                {
                    _cardBusiness.Update(cardToUpdate,Convert.ToInt32(selectedLine));
                    ListAllBoard();
                }

            }
            else
            {
                Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için : (2)");
                var response = Console.ReadLine();
                if (response is "2")
                {
                    UpdateCardFromBoard();
                }
            }
        }

        public static void ListFeatures()
        {
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");
            Console.WriteLine("(5) Çıkış");
        }

        public static void AddCardToBoard()
        {
            Console.Clear();
            Console.WriteLine("Board'a Kart Eklemek");
            Console.WriteLine("********************");
            Console.WriteLine("Başlık Giriniz :");
            var title = Console.ReadLine();
            Console.WriteLine("İçerik Giriniz :");
            var description = Console.ReadLine();
            Console.WriteLine("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5) ");
            var size = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Kişi ID seçiniz   :");
            foreach (var person in _personBusiness.GetAll())
            {
                Console.WriteLine($"{person.Id} {person.FirstName} {person.SecondName}");
            }
            var selectedPersonId = Convert.ToInt16(Console.ReadLine());
            if (_personBusiness.GetAll().FirstOrDefault(x => x.Id == selectedPersonId) is null)
            {
                Console.WriteLine("Hatalı içerik tekrar deneyiniz !");
                Thread.Sleep(1000);
                AddCardToBoard();
            }
            var cardModel = new Card()
            {
                BoardId = 0,
                Title = title,
                Description = description,
                CardSize = (Size)size,
                AssociatedPersonId = selectedPersonId
            };
            Console.WriteLine(cardModel.Title + " created card");
            _cardBusiness.Add(cardModel);
        }

        public static void ListAllBoard()
        {
            var boardCount = _boardBusiness!.GetAll().Count;
            var cardCount = _cardBusiness.GetAll().Count;
            for (var i = 0; i < boardCount; i++)
            {
                Console.WriteLine($"{_boardBusiness.GetAll().FirstOrDefault(x => x.Id == i)?.Name?.ToUpper()} Line");
                Console.WriteLine("*****************************");

                foreach (var card in _cardBusiness.GetAll().Where(x => x.BoardId == i))
                {
                    var associatedPerson = _personBusiness.GetAll().FirstOrDefault(x => x.Id == card.AssociatedPersonId);
                    Console.WriteLine($"Başlık      : {card.Title}");
                    Console.WriteLine($"İçerik      : {card.Description}");
                    Console.WriteLine($"Büyüklük    : {card.CardSize}");
                    Console.WriteLine($"Atakan Kişi : {associatedPerson?.FirstName} {associatedPerson?.SecondName}");
                    Console.WriteLine("----");
                }
            }
        }

        public static void RemoveCardFromBoard()
        {
            _cardBusiness.RemoveByTitle();
        }
    }
}