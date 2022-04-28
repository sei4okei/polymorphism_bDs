using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace polymorphism_bDs
{
    class Card
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }
        public string activity { get; set; }
        public string faculty { get; set; }
        public string thirdpoint { get; set; }

        public static List<Card> cards = new List<Card>();
        private static IEnumerator<int> sequence = Enumerable.Range(1, int.MaxValue).GetEnumerator();

        public static void AddNewCard(string _activity, string _name, string _surname, string _patronymic, string _faculty, string _thirdpoint)
        {
            if (cards.Count() == sequence.Current)
            {
                sequence.MoveNext();
            }
            var id = sequence.Current;
            if (_activity == "преподаватель")
            {
                var card = new Teacher
                {
                    ID = id,
                    name = _name,
                    surname = _surname,
                    patronymic = _patronymic,
                    faculty = _faculty,
                    thirdpoint = _thirdpoint,
                    activity = _activity
                };
                cards.Add(card);
            }
            else if (_activity == "студент")
            {
                var card = new Student
                {
                    ID = id,
                    name = _name,
                    surname = _surname,
                    patronymic = _patronymic,
                    faculty = _faculty,
                    thirdpoint = _thirdpoint,
                    activity = _activity
                };
                cards.Add(card);
            }
            else
            {
                WriteLine("Возникла ошибка, попробуйте снова!");
            }
        }

        public static int CalcStudents()
        {
            int amount = 0;
            foreach (var card in cards)
            {
                if (card.activity == "студент")
                {
                    amount++;
                }
            }
            return amount;
        }
    }
}
