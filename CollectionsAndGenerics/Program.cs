using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                Student s1 = new Student("X00100551", "Mark Lordan", Sex.Male);
                Student s2 = new Student("X00101899", "Robert Kenny", Sex.Male);
                StudentClass R1 = new StudentClass("Mask", "Gary Clynch");
                R1.addStudent(s1);
                R1.addStudent(s2);

                Student mark = R1["X00100551"];
                Console.WriteLine("Name: " + mark.Name + "\nStudent Number: " + mark.Uid);
                Student robbie = R1[1];
                Console.WriteLine("Name: " + robbie.Name + "\nStudent Number: " + robbie.Uid);
                

                foreach(Student s in R1)
                {
                    Console.WriteLine(s.ToString());
                }
                Student missing = R1[-1];


            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            Console.ReadLine();
        }
    }

    public enum Sex { Male, Female }

    class Student
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public Sex Gender { get; set; }

        public Student(string uid, string name, Sex gender )
        {
            Uid = uid;
            Name = name;
            Gender = gender;
        }
        public override string ToString()
        {
            return "Student name: " + Name + "\nStudent number: " + Uid + "\nGender: " + Gender;
        }
    }
    class StudentClass : IEnumerable
    {
        public string CRN { get; set; }
        public string LecturerName { get; set; }
        public List<Student> studentList;

        public StudentClass(string crn, string lecturerName)
        {
            CRN = crn;
            LecturerName = lecturerName;
            studentList = new List<Student>();
        }

        public bool addStudent(Student aStudent)
        {
            bool result = false;
            if (studentList == null)
            {
                result = true;
                studentList.Add(aStudent);
            }
            else
            {
                if ((studentList.Count(s => s.Uid == aStudent.Uid)) == 1)
                {
                        result = false;
                        throw new ArgumentException("This student ID already exists");
                        
                    }
                    else
                    {
                        result = true;
                        studentList.Add(aStudent);
                    }
                
            }
            return result;
        }

        public IEnumerator GetEnumerator()
        {
           foreach(Student s in studentList)
            {
                yield return s;
            }
        }

        public Student this[int i]
        {
            get {
                if(i >=0 && i < studentList.Count)
                {
                     return (Student) studentList[i];
                 
                }
                else
                {
                    throw new ArgumentException("Student " + i + " not found" );
                }
            }
        }
        public Student this[String uid]
        {
            get
            {
                Student foundStudent = null;
                int count = 0;
                foreach(Student s in studentList)
                {
                    if (s.Uid == uid)
                    {
                        foundStudent = (Student) studentList[count];
                        return foundStudent;
                    }
                    else count++;
                }
                throw new ArgumentException("No matching student found with ID of " + uid );

            }
        }
    }
}
