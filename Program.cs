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
        static void addEmployer(string _DBname) // метод добавления сотрудника
        {
            string _name, _sex, _position;
            int _year, _month, _day;
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + _DBname + ";Version=3; FailIfMissing=False");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand($"INSERT INTO Employer (Name, Age, Position) VALUES (@_name,@_age, @_position)", connection);

            Console.WriteLine("Введите имя сотрудника");
            _name = Console.ReadLine();

            do // сделали цикл ввода
            {
                Console.WriteLine("Введите пол сотрудника: M - мужчина или W - женщика");
                _sex = Console.ReadLine();
            } while (_sex.ToLower() != "m" && _sex.ToLower() != "w");


            do
            {
                Console.WriteLine("Введите год рождения сотрудника: ");
                _year = int.Parse(Console.ReadLine());
            } while (_year < 1950 || _year > 2009);

            do
            {
                Console.WriteLine("Введите месяц рождения сотрудника ( от 1 до 12 ): ");
                _month = int.Parse(Console.ReadLine());
            } while (_month < 0 || _month > 12);

            do
            {
                Console.WriteLine("Введите день рождения сотрудника ( от 1 до 31 ): ");
                _day = int.Parse(Console.ReadLine());
            } while (_day < 0 || _day > 31);

            var dateOfBirthday = new DateTime(_year, _month, _day);

            DateTime dateTime = DateTime.Now;
            int _age = dateTime.Year - dateOfBirthday.Year; // высчитали возраст ( количество лет )


            do // сделали цикл ввода
            {
                Console.WriteLine("Введите должность сотрудника: Manager или Worker");
                _position = Console.ReadLine();
            } while (_position.ToLower() != "manager" && _position.ToLower() != "worker");
            Console.WriteLine($"Мы записали сотрудника: {_name}, \nпол: {_sex}, \nвозраст: {_age}, \nдолжность: {_position} в базу данных.");

            command.Parameters.AddWithValue("@_name", _name);
            command.Parameters.AddWithValue("@_age", _age);
            command.Parameters.AddWithValue("@_position", _position);
          command.Parameters.AddWithValue("@_position", _sex);
           // command.ExecuteNonQuery();

            connection.Close();

        }
        static List<EmployerList> getDataFromDB(string _DBname)  // в этом методе считываем данные с базы данных и выводим сотрудников по условию задачи
        {
            List<EmployerList> employerList = new List<EmployerList>();
            string connectionString = $"Data Source={_DBname};Version=3;";
            string query = "SELECT * FROM Employer;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        string result = "";

                        while (reader.Read())
                        {
                            string name = reader.GetString(1);
                            int age = reader.GetInt32(2);
                            string position = reader.GetString(3);
                            string sex = reader.GetString(4);
                            result = name + " " + age + " " + position + sex;
                            EmployerList employer1 = new EmployerList(name, sex, age, position);
                            employerList.Add(employer1);

                        }
                        return employerList;
                    }
                   
                }
                
            }
        }

        static void printScedule (List <EmployerList> employers) // принимает LIST сотрудников и выводим их график
        {
            for (int i = 0; i < employers.Count; i++)
            {
                if (employers[i].Age >= 14 && employers[i].Age <= 17)
                {
                    Console.WriteLine($"Сотрудник {employers[i].Name} работает по графику:  4-х часовой рабочий день 5/2.");
                }
                else
                    if (employers[i].Age >= 18 && employers[i].Age <= 65 && employers[i].Position=="Manager")
                {
                    Console.WriteLine($"Сотрудник {employers[i].Name} работает по графику:  8-мичасовой рабочий день 5/2.");
                }
                else
                    if (employers[i].Age >= 18 && employers[i].Age <= 65 && employers[i].Position == "Worker")
                {
                    Console.WriteLine($"Сотрудник {employers[i].Name} работает по графику:   12-ти часовые смены 2/2.");
                }
                else
                    if (employers[i].Age >= 65)
                {
                    Console.WriteLine($"Сотрудник {employers[i].Name} работает по графику:   пенсионный возраст 8-мичасовой день, 4 рабочих дня в неделю.");
                }

            }
        }

        static void Main(string[] args)
        {

            SQLiteConnection connection = new SQLiteConnection(@"Data Source=Employer.db; ");
            connection.Open();

            var querry = @"CREATE TABLE IF NOT EXISTS [Employer]
                              (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE,
                              Name NVARCHAR,  
                              Age INTEGER, 
                              Position NVARCHAR)";

            var cmd = new SQLiteCommand(querry, connection);
            //command.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Table created");
            int choise;
            
            do
            {
                Console.WriteLine("Выберете действие:\n1 - добавить сотрудника.\n" +
                                                      "2 - показать список сотрудников.\n" +
                                                      "3 - показать расписание сотрудников.\n");
                choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1: addEmployer("Employer.db"); break;
                    case 2: Console.WriteLine($"Выводим список сотрудников: {getDataFromDB("Employer.db")}");break;
                    case 3: printScedule(getDataFromDB("Employer.db")); break;

                }
                addEmployer("Employer.db");
            } while (choise < 4 );
            


            Console.ReadLine();
           
        }
    }
}
