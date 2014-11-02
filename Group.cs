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
        public List<Student> Students { get; set; }

        public Group(string name)
        {
            Students = new List<Student>();
            this.Name = name;
        }

        public override string ToString()
        {
            string tempStr = "";
            tempStr += string.Format("{0}\n", this.Name);
            for (int i = 0; i < Students.Count; i++)
                tempStr += string.Format("{0} - {1}\n",i+1, Students[i].ToString());
            return tempStr;
        }
    }
}