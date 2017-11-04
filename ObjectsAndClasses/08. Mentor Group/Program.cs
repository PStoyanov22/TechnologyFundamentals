using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace _08.Mentor_Group
{
    class Program
    {
        class Student
        {

            public string Name { get; set; }

            public List<DateTime> AttendanceDate { get; set; }

            public List<string> Comments { get; set; }
        }


        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            var students = new List<Student>();

            while (command != "end of dates")
            {
                var commandArgs = command
                    .Split(new char[] {' ', ','},StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var studentName = commandArgs[0];
                var date = commandArgs.Skip(1);
                List<DateTime> dates = date
                    .Select(x => DateTime.ParseExact(x, "dd/MM/yyyy", CultureInfo.InvariantCulture)).ToList();

                bool doesExist = false;

                foreach (var student in students)
                {
                    if (student.Name == studentName)
                    {
                        doesExist = true;
                        student.AttendanceDate.AddRange(dates);
                        break;
                    }
                }
                if (doesExist == false)
                {
                    var student = new Student()
                    {
                        Name = studentName,
                        AttendanceDate = dates,
                        Comments = new List<string>()
                        
                    };
                    students.Add(student);
                }
                
                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "end of comments")
            {
                var userComments = command
                    .Split(new char[] { '-'})
                    .ToList();

                var name = userComments[0];
                var comments = userComments[1];

                foreach (var student in students)
                {
                    if (student.Name == name)
                    {
                        student.Comments.Add(comments);
                        
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var student in students.OrderBy(s => s.Name).ThenBy(d => d.AttendanceDate))
            {
                Console.WriteLine(student.Name);
                if (student.Comments.Count > 0)
                {
                    Console.WriteLine("Comments:");
                    foreach (var comment in student.Comments)
                    {
                        Console.WriteLine($"- {comment}");
                    }
                }
                else
                {
                    Console.WriteLine("Comments:");
                }
                Console.WriteLine("Dates attended:");

                foreach (var date in student.AttendanceDate.OrderBy(d => d))
                {
                    Console.WriteLine($"-- {date.ToString("dd/MM/yyyy")}");
                }                    
            }
        }
    }
}
