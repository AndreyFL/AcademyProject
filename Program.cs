using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AcademyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            string errorDescription;
            Academy academy = new Academy("LevelUp :)");

            academy.AddGrp("NET14-1");
            academy.AddGrp("NET14-2");
            Console.WriteLine(academy);

            Console.Write("Введите название группы, в которую будет добавляться студент: ");
            string grpName = Console.ReadLine();
            Console.Write("Введите фамилию студента: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите имя студента: ");
            string firstName = Console.ReadLine();
            Console.Write("Введите возраст студента: ");
            byte age = Convert.ToByte(Console.ReadLine());

            if (!academy.AddStudent(grpName, lastName, firstName, age, out errorDescription))
                Console.WriteLine(errorDescription);

            Console.WriteLine(academy);

            Console.Write("Введите фамилию для поиска: ");
            lastName = Console.ReadLine();
            Student fdedStud;
            if (academy.FindStudentByLastName(lastName, out fdedStud) != null)
                Console.WriteLine("Студент \"{1}\" учится в группе: {0}", academy.FindStudentByLastName(lastName, out fdedStud).Name, fdedStud.lastName);
            else
                Console.WriteLine("По запросу \"{0}\" студентов не обнаружено!", lastName);


            Console.Write("Введите название группы в которую переводится студент: ");
            string newGroupName = Console.ReadLine();
            Console.Write("Введите фамилию переводимого студента: ");
            lastName = Console.ReadLine();
            if (!academy.MoveStudent(newGroupName, lastName, out errorDescription))
                Console.WriteLine(errorDescription);
            Console.WriteLine(academy);

            Console.Write("Введите текущее название группы: ");
            string oldGrpName = Console.ReadLine();
            Console.Write("Введите новое название группы: ");
            string newGrpName = Console.ReadLine();
            if (!academy.Rename(oldGrpName, newGrpName, out errorDescription))
                Console.WriteLine(errorDescription);
            Console.WriteLine(academy);


            Console.Write("Введите фамилию студента, данные которого нужно изменить: ");
            string needToChngStudent = Console.ReadLine();
            Console.Write("Введите фамилию студента: ");
            lastName = Console.ReadLine();
            Console.Write("Введите имя студента: ");
            firstName = Console.ReadLine();
            Console.Write("Введите возраст студента: ");
            age = Convert.ToByte(Console.ReadLine());
            Student studentNewInfo = new Student(firstName, lastName, age);
            academy.Rename(needToChngStudent, studentNewInfo);

            Console.WriteLine(academy);

            Console.Write("Введите фамилию студента, которого необходимо удалить: ");
            lastName = Console.ReadLine();
            academy.RemoveStudent(lastName, out fdedStud);

            Console.WriteLine(academy);

        }
    }
}
