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
        private DateTime DateOfBirth;
        private string position;
        public EmployerList()
        {
            name = "";
            sex = "M";
          DateTime DateOfBirth = new DateTime(1950, 1, 1); //год месяц день
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
        public string Positon { get { return position; } }
        public void SetPosition(string _position)
        {
            this.position = _position;
        }


    }
    }

