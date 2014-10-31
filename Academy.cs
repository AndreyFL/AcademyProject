using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyProject
{

    class Academy
    {
        public string Name { private set; get; }
        List<Group> groups = new List<Group>();// Список содержащий экземпляры групп

        public Academy(string name)
        {
            this.Name = name;
        }


        // добавить группу и заполнить случайными данными по студентам.
        public void AddGrp(string grpName)
        {
            groups.Add(new Group(grpName));
            Group group = FindGrpByName(grpName);// получаю ссылку на группу
            Random r = new Random();
            byte studentsAmount = (byte)r.Next(3, 8);// случайное количество студентов в каждой группе
            for (int i = 0; i < studentsAmount; i++)
            {
                group.AddStudent(new Student("Имя" + r.Next(100), "Фамилия" + r.Next(100), (byte)r.Next(17, 31)));
                Thread.Sleep(40);
            }
        }


        public override string ToString()
        {
            string tmpString = string.Format("\nАкадемия: {0}\n", this.Name);
            for (int i = 0; i < groups.Count; i++)
                tmpString += string.Format("\nНазвание группы: {0}", groups[i].ToString());
            return tmpString;
        }


        public bool AddStudent(string grpName, string lastName, string firstName, byte age, out string errorDescription)
        {
            errorDescription = "";
            Student newStudent;
            this.FindStudentByLastName(lastName, out newStudent);
            if (newStudent != null)// проверка, числится ли в академии студент с такой же фамилией.если да, нового не добавляем, разделение студентов в данной программе только по фамилии.
            {
                errorDescription = string.Format("Ошибка: студент с фамилией \"{0}\" уже проходит обучение!", lastName);
                return false;
            }

            newStudent = new Student(firstName, lastName, age);

            Group group = FindGrpByName(grpName);


            if (group != null)
                return group.AddStudent(newStudent);
            else
            {
                errorDescription = "Ошибка: не правильно указано имя группы!";
                return false;
            }
        }


        public bool RemoveStudent(string lastName, out Student student)
        {
            Group group = this.FindStudentByLastName(lastName, out student);
            if (group != null)
                return group.RemoveStudent(student);
            else
            {
                student = null;
                return false;
            }
        }


        public Group FindStudentByLastName(string partOfLastName, out Student findedStudent)
        {
            foreach (Group grp in groups)
            {
                if (grp.FindByLastName(partOfLastName, out findedStudent))
                {
                    return grp;
                }
            }
            findedStudent = null;
            return null;
        }


        public bool MoveStudent(string newGrpName, string lastName, out string errorDescription)
        {
            errorDescription = "";
            Student tmpStudent;
            Group oldGroup = FindStudentByLastName(lastName, out tmpStudent);

            Group newGroup = FindGrpByName(newGrpName);

            if (oldGroup == null)
            {
                errorDescription = string.Format("В академии не обучается студент \"{0}\"", lastName);
                return false;
            }
            if (newGroup == null)
            {
                errorDescription = string.Format("Ошибка: не правильно указано название группы в которую переводится студент!");
                return false;
            }

            if (oldGroup.RemoveStudent(tmpStudent))
                if (newGroup.AddStudent(tmpStudent))
                    return true;
                else
                {
                    oldGroup.AddStudent(tmpStudent);
                    errorDescription = "Ошибка: не удалось переместить студента в новую группу, студент возвращен в старую!";
                    return false;
                }
            return false;
        }


        // Приватный метод для нахождения и возврата ссылки на экземпляр группы, поиск по полю Name.
        Group FindGrpByName(string grpName)
        {
            for (int i = 0; i < groups.Count; i++)
                if (groups[i].Name == grpName)
                    return groups[i];
            return null;
        }


        // Изменение данных студента. Поиск изменяемого студента производится по фамилии.
        public bool Rename(string lastName, Student newStudentInfo)
        {
            Student findedStudent;
            Group group = this.FindStudentByLastName(lastName, out findedStudent);
            if (group != null)
                return findedStudent.EditInfo(newStudentInfo);
            else
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
