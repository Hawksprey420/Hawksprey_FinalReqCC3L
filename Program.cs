using System;
using System.Collections.Generic;

namespace FinalReqCC3L
{
    internal class Program
    {
        static void LineGeneration()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        static void StudentInfo(List<Students> students)
        {
            int student_count = 0;

            while (true)
            {
                student_count++;

                Students student = new Students();
                Console.WriteLine($"Please enter your name, student {student_count}");
                student.student_name = Console.ReadLine();

                Console.WriteLine($"Please enter your grade in Computer Programming 1, {student.student_name}");
                student.ComProg_Grade = float.Parse(Console.ReadLine());

                Console.WriteLine($"Please enter your grade in Calculus, {student.student_name}");
                student.Calculus_Grade = float.Parse(Console.ReadLine());

                Console.WriteLine($"Please enter your grade in Trigonometry, {student.student_name}");
                student.Trigo_Grade = float.Parse(Console.ReadLine());

                students.Add(student);

                Console.WriteLine("Student added successfully!");

                if (student_count >= 3)
                {
                    Console.WriteLine("Would you like to add more students?");
                    Console.WriteLine("Y for Yes, N for No.");
                    string add_prompt = Console.ReadLine().ToUpper();

                    if (add_prompt == "N")
                    {
                        Console.WriteLine();
                        return;
                    }
                    else if (add_prompt == "Y")
                    {
                        Console.WriteLine("Please continue.");
                        continue;
                    }
                }
            }
        }

        public static float CalculateAverage(Students student)
        {
            return (student.ComProg_Grade + student.Calculus_Grade + student.Trigo_Grade) / 3;
        }

        static void DisplayDetails(List<Students> students)
        {
            foreach (Students student in students)
            {
                Console.WriteLine($"Hello {student.student_name}! ComProg1 - {student.ComProg_Grade}, Calculus - {student.Calculus_Grade}, Trigo - {student.Trigo_Grade}");
                LineGeneration();
                Console.WriteLine($"Your average in all subjects, {student.student_name} is {CalculateAverage(student)}");
                Console.WriteLine(); // For better UI, add a line break
            }
        }

        static void Main(string[] args)
        {
            List<Students> students = new List<Students>();
            Console.WriteLine("Welcome to Hawksprey's grade computation!");
            LineGeneration();

            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Input student data");
                Console.WriteLine("2. View student data.");
                Console.WriteLine("3. Exit the program.");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        StudentInfo(students);
                        break;

                    case "2":
                        if (students.Count == 0)
                        {
                            Console.WriteLine("No student data entered yet.");
                        }
                        else
                        {
                            DisplayDetails(students);
                        }
                        break;

                    case "3":
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
