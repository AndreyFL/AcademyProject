using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyProject
{
    class Student
    {
        public String lastName { get; private set; }
        String firstName;
        byte age;
        byte Age
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
            this.firstName = firstName;
            this.lastName = lastName;
            this.Age = age;
        }


        public override string ToString()
        {
            return String.Format("{0}\t{1}\t{2,3} лет", this.lastName, this.firstName, this.Age);
        }

        public bool EditInfo(Student student)
        {
            this.firstName = student.firstName;
            this.lastName = student.lastName;
            this.Age = student.age;
            return true;
        }
    }

}
