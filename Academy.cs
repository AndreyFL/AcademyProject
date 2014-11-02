using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AcademyProject
{

    class Academy
    {
        public string Name { private set; get; }
        public List<Group> groups { get; set; } // Список содержащий экземпляры групп

        // Конструктор академии
        public Academy(string name)
        {
            this.Name = name;
            groups = new List<Group>();
        }


        // добавить группу и заполнить случайными данными по студентам.
        public void AddGrp(string grpName)
        {
            groups.Add(new Group(grpName));
            Group group = groups[groups.Count - 1];// получаю ссылку на вновь созданную группу
            Random r = new Random();
            byte studentsAmount = (byte)r.Next(3, 8);// случайное количество студентов в каждой группе
            for (int i = 0; i < studentsAmount; i++)
            {
                group.Students.Add(new Student("Имя" + r.Next(100), "Фамилия" + r.Next(100), (byte)r.Next(17, 31)));
                Thread.Sleep(40);
            }
        }

        public override string ToString()
        {
            string tmpString = string.Format("\nАкадемия: {0}\n", this.Name);
            for (int i = 0; i < groups.Count; i++)
                tmpString += string.Format("{0}", groups[i].ToString());
            return tmpString;
        }

        public bool AddStudent(string grpName, string lastName, string firstName, byte age, out string errorDescription)
        {
            errorDescription = "";
            List<Student> findedStudent;

            FindStudentByLastName(lastName, out findedStudent);
            if (findedStudent.Count != 0)// проверка, числится ли в академии студент с такой же фамилией.если да, нового не добавляем, разделение студентов в данной программе только по фамилии.
            {
                errorDescription = string.Format("Ошибка: студент с фамилией \"{0}\" уже проходит обучение!", lastName);
                return false;
            }

            Student newStudent = new Student(firstName, lastName, age);

            Group group = FindGrpByName(grpName);// Нахожу экземпляр группы в которую хотим добавить студента.

            if (group != null)
            {
                group.Students.Add(newStudent);
                return true;
            }
            else
            {
                errorDescription = "Ошибка: не правильно указано имя группы!";
                return false;
            }
        }

        // Удалить данные о студенте.
        public bool RemoveStudent(string lastName, out string errorDescription)
        {
            errorDescription = "";
            List<Student> student;
            List<Group> group = FindStudentByLastName(lastName, out student);
            if (student.Count == 1)
                return group[0].Students.Remove(student[0]);
            else if (student.Count == 0)
                errorDescription = "Ошибка: заданным критериям поиска не соответствует ни один студент!\n";
            else
            {
                errorDescription = "Ошибка: указанным критериям поиска соответствуют более чем один студент!\n";
                for (int i = 0; i < student.Count; i++)
                    errorDescription += string.Format("{0} обучается в => {1}\n", student[i], group[i].Name);
            }
            return false;
        }

        // Нахожу экземпляры класса студент, фамилии которых подходит под условие поиска.
        // Возвращаю экземпляры студента через out и экземпляр группы через метод.
        public List<Group> FindStudentByLastName(string partOfLastName, out List<Student> findedStudents)
        {
            List<Group> groupsList = new List<Group>();
            findedStudents = new List<Student>();
            foreach (Group grp in this.groups)
            {
                for (int i = 0; i < grp.Students.Count; i++)
                {
                    if (grp.Students[i].LastName.ToLower().Contains(partOfLastName.ToLower()))
                    {
                        findedStudents.Add(grp.Students[i]);
                        groupsList.Add(grp);
                    }
                }
            }
            return groupsList;
        }


        public bool MoveStudent(string newGrpName, string lastName, out string errorDescription)
        {
            errorDescription = "";
            List<Student> movedStudent;
            List<Group> oldGroup = FindStudentByLastName(lastName, out movedStudent);
            if (movedStudent.Count > 1)
            {
                errorDescription = "Ошибка: указанным критериям поиска соответствуют более чем один студент!\n";
                for (int i = 0; i < movedStudent.Count; i++)
                    errorDescription += string.Format("{0} обучается в => {1}\n", movedStudent[i], oldGroup[i].Name);
                return false;
            }

            Group newGroup = FindGrpByName(newGrpName);

            if (oldGroup.Count == 0)
            {
                errorDescription = string.Format("Ошибка: в академии не обучается студент \"{0}\"!", lastName);
                return false;
            }
            if (newGroup == null)
            {
                errorDescription = string.Format("Ошибка: не правильно указано название группы в которую переводится студент!");
                return false;
            }

            oldGroup[0].Students.Remove(movedStudent[0]);
            newGroup.Students.Add(movedStudent[0]);
            return true;
        }


        // Приватный метод для нахождения и возврата ссылки на экземпляр группы, поиск по полю Name.
        public Group FindGrpByName(string grpName)
        {
            for (int i = 0; i < groups.Count; i++)
                if (groups[i].Name == grpName)
                    return groups[i];
            return null;
        }


        // Изменение данных студента. Поиск изменяемого студента производится по фамилии.
        public bool Rename(string lastName, Student newStudentInfo, out string errorDescription)
        {
            errorDescription = "";
            List<Student> findedStudent;
            List<Group> group = FindStudentByLastName(lastName, out findedStudent);
            if (findedStudent.Count == 1)
            {
                findedStudent[0].FirstName = newStudentInfo.FirstName;
                findedStudent[0].LastName = newStudentInfo.LastName;
                findedStudent[0].Age = newStudentInfo.Age;
                return true;
            }
            else if (findedStudent.Count == 0)
            {
                errorDescription = "Ошибка: заданным критериям поиска не соответствует ни один студент!";
            }
            else
            {
                errorDescription = "Ошибка: указанным критериям поиска соответствуют более чем один студент!";
                for (int i = 0; i < findedStudent.Count; i++)
                    errorDescription += string.Format("{0} обучается в => {1}", findedStudent[i], group[i]);
            }
            return false;
        }

        // Переименование группы. Поиск исходной группы выполняется по имени группы.
        public bool Rename(string oldGrpName, string newGrpName, out string errorDescription)
        {
            errorDescription = "";
            Group group = FindGrpByName(oldGrpName);
            if (group == null)
            {
                errorDescription = "Ошибка: не правильно введено название искомой группы!";
                return false;
            }
            else
            {
                group.Name = newGrpName;
                return true;
            }
        }
    }
}