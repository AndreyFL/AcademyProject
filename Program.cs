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
            char key;
            Academy academy = new Academy("LevelUp :)");

            academy.AddGrp("NET14-1");
            academy.AddGrp("NET14-2");

            do
            {
                Console.Clear();
                Console.WriteLine(academy);

                Console.WriteLine("1. Добавить студента.");
                Console.WriteLine("2. Поиск студента.");
                Console.WriteLine("3. Перевод студента.");
                Console.WriteLine("4. Удалить студента.");
                Console.WriteLine("5. Изменение данных студента.");
                Console.WriteLine("6. Переименование группы.");
                Console.WriteLine("\nq. Выход");

                try
                {
                    key = Convert.ToChar(Console.ReadLine());
                }
                catch
                {
                    key = 'q';
                }
                switch (key)
                {
                    case '1':
                        AddStudentChoice(academy);
                        break;
                    case '2':
                        FindStudentChoice(academy);
                        break;
                    case '3':
                        MoveStudentChoice(academy);
                        break;
                    case '4':
                        RemoveStudentChoice(academy);
                        break;
                    case '5':
                        StudentRenameChoice(academy);
                        break;
                    case '6':
                        GroupRenameChioce(academy);
                        break;
                    default:
                        key = 'q';
                        break;
                }
            } while (key != 'q');
        }

        // Вспомагательный метод для вывода передаваемого сообщения на консоль и ожидания нажатия Enter.
        static void WriteMessageWithDelay(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("нажмите 'Enter' для продолжения...");
            Console.ReadKey();
        }

        // Пункт меню добавить студента.
        static void AddStudentChoice(Academy academy)
        {
            string errorDescription;
            Console.Write("Введите название группы, в которую будет добавляться студент: ");
            string grpName = Console.ReadLine();
            Console.Write("Введите фамилию студента: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите имя студента: ");
            string firstName = Console.ReadLine();
            Console.Write("Введите возраст студента: ");
            byte age = Convert.ToByte(Console.ReadLine());
            if (!academy.AddStudent(grpName, lastName, firstName, age, out errorDescription))
                WriteMessageWithDelay(errorDescription);

        }

        // Пункт меню найти студента.
        static void FindStudentChoice(Academy academy)
        {
            Console.Write("Введите фамилию для поиска: ");
            string lastName = Console.ReadLine();
            Student findedStudent;
            if (academy.FindStudentByLastName(lastName, out findedStudent) != null)
                WriteMessageWithDelay(string.Format("Студент \"{1}\" учится в группе: {0}", academy.FindStudentByLastName(lastName, out findedStudent).Name, findedStudent.LastName));
            else
                WriteMessageWithDelay(string.Format("По запросу \"{0}\" студентов не обнаружено!", lastName));
        }

        // Пункт меню перевести студента.
        static void MoveStudentChoice(Academy academy)
        {
            string errorDescription;
            Console.Write("Введите название группы в которую переводится студент: ");
            string newGroupName = Console.ReadLine();
            Console.Write("Введите фамилию переводимого студента: ");
            string lastName = Console.ReadLine();
            if (!academy.MoveStudent(newGroupName, lastName, out errorDescription))
                WriteMessageWithDelay(errorDescription);


        }

        // Пункт меню удалить данные о студенте.
        static void RemoveStudentChoice(Academy academy)
        {
            Student findedStudent;
            Console.Write("Введите фамилию студента, которого необходимо удалить: ");
            string lastName = Console.ReadLine();
            academy.RemoveStudent(lastName, out findedStudent);
        }

        // Пункт меню изменить данные о студенте.
        static void StudentRenameChoice(Academy academy)
        {
            Console.Write("Введите фамилию студента, данные которого нужно изменить: ");
            string needToChngStudent = Console.ReadLine();
            Console.Write("Введите фамилию студента: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите имя студента: ");
            string firstName = Console.ReadLine();
            Console.Write("Введите возраст студента: ");
            byte age = Convert.ToByte(Console.ReadLine());
            Student studentNewInfo = new Student(firstName, lastName, age);
            academy.Rename(needToChngStudent, studentNewInfo);
        }

        // Пункт меню переименовать группу.
        static void GroupRenameChioce(Academy academy)
        {
            string errorDescription;
            Console.Write("Введите текущее название группы: ");
            string oldGrpName = Console.ReadLine();
            Console.Write("Введите новое название группы: ");
            string newGrpName = Console.ReadLine();
            if (!academy.Rename(oldGrpName, newGrpName, out errorDescription))
                WriteMessageWithDelay(errorDescription);
        }
    }
}
