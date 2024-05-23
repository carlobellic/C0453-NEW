using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;
using System;

namespace ConsoleAppProject
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine();
            Console.WriteLine(" =================================================");
            Console.WriteLine("    BNU CO453 Applications Programming 2022-2023! ");
            Console.WriteLine(" =================================================");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Please select an application to run:");
                Console.WriteLine("1. Distance Converter");
                Console.WriteLine("2. BMI Calculator");
                Console.WriteLine("3. Student Grades");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DistanceConverter converter = new DistanceConverter();
                        converter.Run();
                        break;
                    case "2":
                        BMICalculator bmiCalculator = new BMICalculator();
                        bmiCalculator.Run();
                        break;
                    case "3":
                        StudentGrades studentGrades = new StudentGrades();
                        studentGrades.Run();
                        break;
                    case "0":
                        Console.WriteLine("Exiting the application...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
