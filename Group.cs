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
        List<Student> students = new List<Student>();// список экземпляров объектов
        public Group(string name)
        {
            this.Name = name;
        }

        public bool FindByLastName(string partOfLastName, out Student findedStudent)
        {
            foreach (Student student in students)
            {
                if (student.lastName.ToLower().Contains(partOfLastName.ToLower()))
                {
                    findedStudent = student;
                    return true;
                }
            }
            findedStudent = null;
            return false;
        }


        public override string ToString()
        {
            string tempStr = "";
            tempStr += string.Format("{0}\n", this.Name);
            for (int i = 0; i < students.Count; i++)
            {
                tempStr += string.Format("{0}\n", students[i].ToString());
            }
            return tempStr;
        }


        public bool AddStudent(Student student)
        {
            this.students.Add(student);
            return true;
        }


        public bool RemoveStudent(Student student)
        {
            return this.students.Remove(student);
        }
    }

}
