using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyProject
{
    class Student
    {
        public String LastName { get; set; }
        public String FirstName { get; set; }
        byte age;
        public byte Age
        {
            set
            {
                if (value > 7 && value < 150)
                    age = value;
                else
                    throw new Exception();
            }
            get
            {
                return age;
            }
        }

        public Student(string firstName, string lastName, byte age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }


        public override string ToString()
        {
            return String.Format("{0}\t{1}\t{2,3} лет", this.LastName, this.FirstName, this.Age);
        }
    }

}
