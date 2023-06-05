using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;



namespace Employer_LIST_HOMEWORK
{
    public class EmployerList
    {
  
        private string name;
        private string sex;
        private int age;
        private string position;
        public EmployerList()
        {
            name = "";
            sex = "M";
            age = 14;
            position = "Manager";
        }

        public string Name { get { return name; } }
        public void SetName(string _name)
        {
            this.name = _name;
        }
        public string Sex { get { return sex; } }
        public void SetSex(string _sex)
        {
            this.sex = _sex;
        }
        public int Age { get { return age; } }
        public void SetAge(int _age)
        {
            this.age = _age;
        }

        public string Position { get { return position; } } 
        public void setPositoion (string _position)
        {
            this.position = _position;
        }


    }
    }

