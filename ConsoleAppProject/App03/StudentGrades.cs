using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App03
{
    public class StudentGrades
    {
// This is an integer that represents the amount of students in the list.
        private const int NumberOfStudents = 10;
        private List<int> marks;
        private string[] students;
// Uses a string to be able to enter the different exam results for the students, by using an int list.
        public StudentGrades()
        {
            marks = new List<int>();
            students = new string[NumberOfStudents]
            {
                "Student1", "Student2", "Student3", "Student4", "Student5",
                "Student6", "Student7", "Student8", "Student9", "Student10"
            };
        }

        public void Run()
        {
            OutputHeading();
            InputMarks();
            DisplayMarksAndGrades();
            DisplayStatistics();
            DisplayGradeProfile();
        }
// Displays a heading of the name of the application.
        private void OutputHeading()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("    Student Grades Application  ");
            Console.WriteLine("       by Carl O'Brien          ");
            Console.WriteLine("--------------------------------");
        }
// Allows the user to enter the mark the student has received.
        private void InputMarks()
        {
            for (int i = 0; i < NumberOfStudents; i++)
            {
                Console.Write($"Enter mark for {students[i]}: ");
                int mark = Convert.ToInt32(Console.ReadLine());
                marks.Add(mark);
            }
        }
// Converts the marks which are inputted into the program into a grade.
        private void DisplayMarksAndGrades()
        {
            Console.WriteLine("\nStudent Marks and Grades:");
            for (int i = 0; i < NumberOfStudents; i++)
            {
                string grade = ConvertMarkToGrade(marks[i]);
                Console.WriteLine($"{students[i]}: {marks[i]} - {grade}");
            }
        }
// Uses if and else if statements and determines that if a mark is below a certain grade boundary, it will display the correct grade for the student.
        private string ConvertMarkToGrade(int mark)
        {
            if (mark >= 70) return "A (First Class)";
            else if (mark >= 60) return "B (Upper Second Class)";
            else if (mark >= 50) return "C (Lower Second Class)";
            else if (mark >= 40) return "D (Third Class)";
            else return "F (Fail)";
        }

        private void DisplayStatistics()
        {
            int minMark = int.MaxValue;
            int maxMark = int.MinValue;
            int totalMarks = 0;

            foreach (int mark in marks)
            {
                if (mark < minMark) minMark = mark;
                if (mark > maxMark) maxMark = mark;
                totalMarks += mark;
            }

            double meanMark = totalMarks / (double)NumberOfStudents;

            Console.WriteLine("\nStatistics:");
            Console.WriteLine($"Mean Mark: {meanMark:F2}");
            Console.WriteLine($"Minimum Mark: {minMark}");
            Console.WriteLine($"Maximum Mark: {maxMark}");
        }

        private void DisplayGradeProfile()
        {
            int[] gradeCounts = new int[5];

            foreach (int mark in marks)
            {
                if (mark >= 70) gradeCounts[0]++;
                else if (mark >= 60) gradeCounts[1]++;
                else if (mark >= 50) gradeCounts[2]++;
                else if (mark >= 40) gradeCounts[3]++;
                else gradeCounts[4]++;
            }
// Displays the percentage of distributed students and what mark they had got, for example it could be 40% of students got a B, or 60% students got a C, etc.
            Console.WriteLine("\nGrade Profile:");
            Console.WriteLine($"A (First Class): {GetPercentage(gradeCounts[0])}%");
            Console.WriteLine($"B (Upper Second Class): {GetPercentage(gradeCounts[1])}%");
            Console.WriteLine($"C (Lower Second Class): {GetPercentage(gradeCounts[2])}%");
            Console.WriteLine($"D (Third Class): {GetPercentage(gradeCounts[3])}%");
            Console.WriteLine($"F (Fail): {GetPercentage(gradeCounts[4])}%");
        }

        private double GetPercentage(int count)
        {
            return (count / (double)NumberOfStudents) * 100;
        }
    }
}
