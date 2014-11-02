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
        public byte Age { get; set; }

        public Student(string firstName, string lastName, byte age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }


        public override string ToString()
        {
            string ageMeasure;
            switch (this.Age % 10)
            {
                case 1:
                    ageMeasure = "год";
                    break;
                case 2:
                case 3:
                case 4:
                    ageMeasure = "года";
                    break;
                default:
                    ageMeasure = "лет";
                    break;

            }

            return String.Format("{0}\t{1}\t{2,3} {3}", this.LastName, this.FirstName, this.Age, ageMeasure);
        }
    }

}
