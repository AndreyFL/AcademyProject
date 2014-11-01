using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyProject
{
    class Group
    {
        public string Name { get; set; }
        List<Student> students   = new List<Student>();// список экземпляров класса студент
        public List<Student> Students {
            get
            {
                return students;
            }
            set
            {
                students = value;
            }
        }
        public Group(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            string tempStr = "";
            tempStr += string.Format("{0}\n", this.Name);
            for (int i = 0; i < Students.Count; i++)
            {
                tempStr += string.Format("{0}\n", Students[i].ToString());
            }
            return tempStr;
        }


        public bool AddStudent(Student student)
        {
            this.Students.Add(student);
            return true;
        }


        public bool RemoveStudent(Student student)
        {
            return this.Students.Remove(student);
        }
    }

}
