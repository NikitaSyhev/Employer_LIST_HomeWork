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
        static SQLiteConnection connection;
        static SQLiteCommand command;

        static public void DBConnect(string _DBname)
        {
            try
            {
                connection = new SQLiteConnection("Data Source=" + _DBname + ";Version=3; FailIfMissing=False");
                connection.Open();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка доступа к базе данных. Исключение: {ex.Message}");
            }
        }

        static void addEmployer(string _DBname) // метод добавления сотрудника
        {
           
            string _name, _sex, _position;
            int _age;
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + _DBname + ";Version=3; FailIfMissing=False");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand( $"INSERT INTO Employer (Name, Age, Position) VALUES (@_name,@_age, @_position)", connection);

            Console.WriteLine("Введите имя сотрудника");
            _name = Console.ReadLine();
            
            do // сделали цикл ввода
            {
                Console.WriteLine("Введите пол сотрудника: M - мужчина или W - женщика");
                _sex = Console.ReadLine();
            } while (_sex.ToLower() != "m" && _sex.ToLower() != "w");

            do
            {
                Console.WriteLine("Введите возраст сотрудника ( от 14 до 65 ): ");
                _age = int.Parse(Console.ReadLine());
            } while (_age < 14 || _age >65);

            do // сделали цикл ввода
            {
                Console.WriteLine("Введите должность сотрудника: Manager или Worker");
                _position = Console.ReadLine();
            } while (_position.ToLower() != "manager" && _position.ToLower() != "worker");


            Console.WriteLine($"Мы записали сотрудника: {_name}, \nпол: {_sex}, \nвозраст: {_age}, \nдолжность: {_position} в базу данных.");

            command.Parameters.AddWithValue("@_name", _name);
            command.Parameters.AddWithValue("@_age", _age);
            command.Parameters.AddWithValue("@_position", _position);

            
            connection.Close();
            
        }

        static void Main(string[] args)
        {
            EmployerList employer1 = new EmployerList();
            DBConnect("Employer.db");
            command = new SQLiteCommand(connection)
            {
                CommandText = "CREATE TABLE IF NOT EXISTS [Employer]([id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE," + // создали БД
                   " [Name], [Age] INTEGER, [Position] TEXT);"
            };
            command.ExecuteNonQuery();
            Console.WriteLine("Таблица создана");
            addEmployer("Employer.db");
            
            Console.ReadLine();
           
        }
    }
}
