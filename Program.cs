using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Employer_LIST_HOMEWORK
{
    internal class Program
    {

        static EmployerList addEmployer(EmployerList emp) // метод добавления сотрудника
        {
            string _name, _sex;
            SQLiteCommand command = null; // создали переменную для создания команд в базе данных
            SQLiteConnection connection = new SQLiteConnection(@"Data Source=employerList.db; "); //создали объект класса для БД
            connection.Open(); // открыли соединение БД

            Console.WriteLine("Введите имя сотрудника");
            _name = Console.ReadLine();
            emp.SetName(_name);
            do // сделали цикл ввода
            {
                Console.WriteLine("Введите пол сотрудника: M - мужчина или W - женщика");
                _sex = Console.ReadLine();
            } while (_sex.ToLower() != "m" && _sex.ToLower() != "w");
            emp.SetSex(_sex);
            Console.WriteLine("Введите год рождения в формате: 1990");
            int _year = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите месяц рождения в формате: 01");
            int _month = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите день рождения в формате: 01");
            int _day = int.Parse(Console.ReadLine());
            DateTime DateOfBirth = new DateTime(_year, _month, _day);

            Console.WriteLine($"Мы записали сотрудника {_name}, пол: {_sex} и датой рождения: {DateOfBirth} в базу данных.");

            command.CommandText = $"INSERT INTO People (Имя, Пол, Дата рождения) VALUES ({_name}, {_sex}, {DateOfBirth})";
            command.Parameters.AddWithValue("name", _name);
            command.Parameters.AddWithValue("sex", _sex);
            command.Parameters.AddWithValue("Birth", DateOfBirth);
            connection.Close();
            return emp;
        }

        static void Main(string[] args)
        {
            EmployerList employer1 = new EmployerList();
            addEmployer(employer1);
            Console.WriteLine($"Имя {employer1.Name}");

            // завтра записать в базу данных и освоить это дел
           
        }
    }
}
