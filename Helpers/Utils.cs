using SchoolAPI.Globals;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolAPI.Helpers
{
    public static class Utils
    {
        public static List<Student> SetDefaultStudentList()
        {
            List<Student> list = new List<Student>();
            for (int i=0; i<5; i++)
            {
                list.Add(GenerateStudent(i));
            }
            return list;
        }

        public static List<User> SetUsersList()
        {
            var users = new List<User>();
            users.Add(new User { Id = 0, Username = "batman", Password = "batman", Role = "professor" });
            users.Add(new User { Id = 1, Username = "robin", Password = "robin", Role = "student" });
            return users;
        }

        public static User GetUser(User user)
        {
            if (AppGlobals.Users.Count>0)
            {
                return AppGlobals.Users.Where(x => x.Username.ToLower() == user.Username.ToLower() && x.Password == user.Password).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public static Student GenerateStudent(int id)
        {
            string[] subjectNames = { "Math", "Port", "Sci" };
            double avg = 0;
            Random rand = new Random();
            int num = rand.Next(0, 1);
            bool isMale = num == 0 ? false : true;
            List<Subject> subjects = new List<Subject>();
            for (int i = 0; i < subjectNames.Length; i++)
            {
                var tempAvg = rand.NextDouble() * 20;
                avg += tempAvg;
                Subject subject = new Subject()
                {
                    Name=subjectNames[i],
                    Avg= Math.Round(tempAvg, 2, MidpointRounding.ToEven)
                };
                subjects.Add(subject);
            }
            Student student = new Student()
            {
                Id=id,
                Name=GetStudentName(isMale),
                Age=rand.Next(7, 10),
                IsMale=isMale,
                Subjects=subjects,
                Avg= Math.Round((avg / subjectNames.Length), 2, MidpointRounding.ToEven)
            };
            return student;
        }

        public static string GetStudentName(bool isMale)
        {
            string[] maleNames = { "João", "Mário", "Filipe", "Tiago", "Barrigo" };
            string[] femaleNames = { "Joana", "Manuela", "Filipa", "Tatiana", "Barriga" };
            string[] surnames = { "Volvo", "BMW", "Ford", "Mazda", "Opel" };
            Random rand = new Random();
            int num1 = rand.Next(0, 4);
            int num2 = rand.Next(0, 4);
            return $"{(isMale ? maleNames[num1] : femaleNames[num1])} {surnames[num2]}";
        }

        public static bool AddStudent(Student student)
        {
            try
            {
                if (String.IsNullOrEmpty(student.Name) ||
                    student.Age < 0 ||
                    student.Subjects.Count == 0 ||
                    student.Avg <0)
                {
                    return false;
                }

                double avg = 0;
                for(int i=0; i<student.Subjects.Count; i++)
                {
                    if (String.IsNullOrEmpty(student.Subjects[i].Name) ||
                        (student.Subjects[i].Avg < 0 && student.Subjects[i].Avg > 20))
                    {
                        return false;
                    }
                    else
                    {
                        avg += student.Subjects[i].Avg;
                    }
                }

                student.Id = AppGlobals.Students.Count;
                student.Avg = avg / student.Subjects.Count;
                AppGlobals.Students.Add(student);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -> AddStudents: " +ex.Message);
                return false;
            }
        }

        public static bool UpdateStudent(Student student, int id)
        {
            try
            {
                if (String.IsNullOrEmpty(student.Name) ||
                    student.Age < 0 ||
                    student.Subjects.Count == 0 ||
                    student.Avg < 0)
                {
                    return false;
                }

                double avg = 0;
                for (int i = 0; i < student.Subjects.Count; i++)
                {
                    if (String.IsNullOrEmpty(student.Subjects[i].Name) ||
                        (student.Subjects[i].Avg < 0 && student.Subjects[i].Avg > 20))
                    {
                        return false;
                    }
                    else
                    {
                        avg += student.Subjects[i].Avg;
                    }
                }

                student.Avg = avg / student.Subjects.Count;
                AppGlobals.Students[id] = student;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -> UpdateStudent: " + ex.Message);
                return false;
            }
        }

        public static bool DeleteStudent(int id)
        {
            try
            {
                AppGlobals.Students.RemoveAt(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -> DeleteStudent: " + ex.Message);
                return false;
            }
        }
    }
}
