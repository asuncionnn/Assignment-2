using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "students.txt";

        List<Student> students = new List<Student>
        {
            new Student(101, "John", "BSIT", 89),
            new Student(102, "Maria", "BSCS", 92),
            new Student(103, "Paul", "BSIT", 75),
            new Student(104, "Ana", "BSCS", 85),
            new Student(105, "Mark", "BSIT", 90)
        };

        // WRITE TO FILE
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var s in students)
            {
                writer.WriteLine($"{s.studentID},{s.name},{s.course},{s.grade}");
            }
        }

        Console.WriteLine("students.txt file created and data written.\n");

        // READ FILE
        var studentList = File.ReadAllLines(filePath)
            .Select(line =>
            {
                var data = line.Split(',');
                return new Student(
                    int.Parse(data[0]),
                    data[1],
                    data[2],
                    int.Parse(data[3])
                );
            })
            .ToList();

        // LINQ: Grade > 85
        Console.WriteLine("Students with Grade > 85");
        studentList
            .Where(s => s.grade > 85)
            .ToList()
            .ForEach(s => Console.WriteLine($"{s.name} - {s.grade}"));

        // LINQ: Sorted Descending
        Console.WriteLine("\nSorted by Grade (Descending)");
        studentList
            .OrderByDescending(s => s.grade)
            .ToList()
            .ForEach(s => Console.WriteLine($"{s.name} - {s.grade}"));

        // LINQ: Names only
        Console.WriteLine("\nStudent Names");
        studentList
            .Select(s => s.name)
            .ToList()
            .ForEach(name => Console.WriteLine(name));

        // LINQ: Average
        Console.WriteLine($"\nAverage Grade: {studentList.Average(s => s.grade):F2}");
    }
}   