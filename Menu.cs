using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace polymorphism_bDs
{
    class Menu
    {
        static void Main(string[] args)
        {
            while (true)
            {
                WriteLine("Введите команду:\n0. Выйти\n1. Добавить запись\n2. Вывести информаци\n3. Вывести студентов\n4. Кол-во аннулир. пропусков.");
                switch (Convert.ToInt32(CheckInput()))
                {
                    case 0:
                        Environment.Exit(0);
                        break;

                    case 1:
                        AddNewRecord();
                        break;

                    case 2:
                        ReadAllRecords();
                        break;

                    case 3:
                        ReadStudentRecords();
                        break;

                    case 4:
                        ReadAmountStudents();
                        break;

                    default:
                        break;
                }

            }
        }

        static double CheckInput()
        {
            double UserInput;

            while (true)
            {
                try
                {
                    return UserInput = Convert.ToDouble(ReadLine());
                }
                catch (Exception)
                {
                    WriteLine("Что-то пошло не так, попробуйте снова!");
                }
            }
        }

        static void AddNewRecord()
        {
            var activity = "";
            var thirdpoint = "";
            Write("Введите имя: "); var name = ReadLine();
            Write("Введите фамилию: "); var surname = ReadLine();
            Write("Введите отчество: "); var patronymic = ReadLine();
            Write("Введите факультет: "); var faculty = ReadLine();

            while (true)
            {
                Write("Введите должность: "); activity = ReadLine().ToLower();
                if (activity == "преподаватель")
                {
                    Write("Введите кафедру: "); thirdpoint = ReadLine();
                    break;
                }
                else if (activity == "студент")
                {
                    Write("Введите год поступления:  "); thirdpoint = ReadLine();
                    break;
                }
                else
                {
                    WriteLine("Что-то не так, попробуйте снва!");
                }
            }
            Card.AddNewCard(activity, name, surname, patronymic, faculty, thirdpoint);

        }

        static void ReadAllRecords()
        {
            WriteLine("№\tИмя   \tФамилия \tОтчество\tФакультет\tГод \tДолжность");
            foreach (var card  in Card.cards)
            {
                if (card.activity == "студент")
                {
                    WriteLine($"{card.ID}\t {card.name} \t{card.surname} \t{card.patronymic} \t{card.faculty} \t{card.thirdpoint} \t{card.activity} \t");
                }
            }
            WriteLine("Имя   \tФамилия \tОтчество\tФакультет\tКафедра\tДолжность");
            foreach (var card in Card.cards)
            {
                if (card.activity == "преподаватель")
                {
                    WriteLine($"{card.ID}\t {card.name} \t{card.surname} \t{card.patronymic} \t{card.faculty} \t{card.thirdpoint} \t{card.activity} \t");
                }
            }
        }

        static void ReadStudentRecords()
        {
            WriteLine("Имя   \tФамилия \tОтчество\tФакультет\tГод \tДолжность");
            foreach (var card in Card.cards)
            {
                if (card.activity == "студент")
                {
                    WriteLine($"{card.name} \t{card.surname} \t{card.patronymic} \t{card.faculty} \t{card.thirdpoint} \t{card.activity} \t");
                }
            }
        }

        static void ReadAmountStudents()
        {
            WriteLine("Количество карточек подлежащий аннулированию: " + Card.CalcStudents());
        }
    }
}
