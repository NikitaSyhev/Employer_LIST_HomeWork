using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// мысли проработать класс, потому что мне не нравится его струкура
// НЕ ДОДЕЛАНО ! 

namespace Employer_LIST_HOMEWORK
{
    public class EmployerList
    {
        private int age;
        private string name;
        private string sex;
        private DateTime DateOfBirth;
        public  EmployerList()
        {   
            age = 0;
            name = "";
            sex = "M";
            DateTime DateOfBirth = new DateTime(1950, 1, 1); //год месяц день
        }
        public EmployerList(int _age, string _name)
        {
            if (this.SetAge(_age))
            {
                this.age = _age;
                this.name = _name;
            }
        }
        public int Age { get { return age; } }
        public string Name { get { return name; } }
        public bool SetAge(int _age)
        {
            bool flag = false;
            if (_age >= 14 & _age <= 100)
            {
                age = _age;
                flag = true;
            }
            return flag;
        }
        public void SetName(string _name)
        {
            this.name = _name;
        }
        public void addEmployer () // метод добавления сотрудника
        {
            string name, sex;
            
            DateTime DateOfBirth;
            Console.WriteLine("Введите имя сотрудника");
            name = Console.ReadLine();
            do // сделали цикл ввода
            {
                Console.WriteLine("Введите пол сотрудника: M - мужчина или W - женщика");
                sex = Console.ReadLine();
            } while (sex.ToLower() != "m" && sex.ToLower() != "w"); 
          
            try // проверка на корректность
            {
                Console.WriteLine("Введите дату рождения в формате: 1990.12.03");
                string dateInput = Console.ReadLine();
                var tmp = dateInput.Split('.');
                DateOfBirth = new DateTime(int.Parse(tmp[0]), int.Parse(tmp[1]), int.Parse(tmp[2]));
            }
            catch
            {
                Console.WriteLine("Некорректный ввод даты");
            }
            

        }
    }
}
