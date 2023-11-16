using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp5.DB
{
     class StudentGroupDB
    {
        Dictionary<string, string> studentGroup;
        Dictionary<string, List<string>> Groupstudent;

        public StudentGroupDB(StudentDB studentDB, GroupDB groupDB)
        {
            this.studentDB = studentDB;
            this.groupDB = groupDB;
            //load file (json)
            if (!File.Exists("studentGroup.json"))
                studentGroup = new Dictionary<string, string>();
            else
                using (FileStream fs = new FileStream("studentGroup.json", FileMode.OpenOrCreate))
                {
                    studentGroup = JsonSerializer.Deserialize<Dictionary<string, string>>(fs);
                }
        }
        private StudentDB studentDB;
        private readonly GroupDB groupDB;


        public bool AddS(string studentUID, string groupUID)
        {
            if (studentDB.GetStudentByUID(studentUID) == null)
            {
                Console.WriteLine("Такой студент не дебил и не пошёл в колледж, горжусь!");
                return false;
            }
            if (groupDB.GetGroupByUID(groupUID) == null)
            {
                Console.WriteLine("Такую группу не набрали! Меньше народу, больше кислороду)");
                return false;
            }


                studentGroup.Add(studentUID, groupUID);
            if (Groupstudent.ContainsKey(groupUID))
                Groupstudent[groupUID].Add(studentUID);
            else
                Groupstudent.Add(studentUID, new List<string>(new string[] { studentUID }));
            return true;
        }

        public Group GetGroupByStudent(string studentUID)
        {
            string uidGroup = studentGroup[studentUID];
            return groupDB.GetGroupByUID(uidGroup);
        } 

        public List<Student> GetStudentByGroup(string groupUID)
        {
            List<Student> result = new List<Student>();
            List <string> uidST = Groupstudent[groupUID];
            for (int i = 0; i < uidST.Count; i++)
            {
                string uid = uidST[i];
                result.Add(studentDB.GetStudentByUID(uid));
            }
            return result;
        }

    }
}
