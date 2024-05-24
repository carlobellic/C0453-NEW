using ConsoleAppProject.App04;
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
// Allows the user to select between the 4 different programs available.
            while (true)
            {
                Console.WriteLine("Please select an application to run:");
                Console.WriteLine("1. Distance Converter");
                Console.WriteLine("2. BMI Calculator");
                Console.WriteLine("3. Student Grades");
                Console.WriteLine("4. Social Network");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
// Connects to the name of the class, and then directs to the code which is inside the different classes, allowing the programs to be ran from the program class.
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
                    case "4":
                        SocialNetworkApp();
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
// This is here because I couldn't figure out how to return the social network code to the main menu without having it inside the program class.
        private static void SocialNetworkApp()
        {
            NewsFeed newsFeed = new NewsFeed();

            while (true)
            {
                Console.WriteLine("Social Network:");
                Console.WriteLine("1. Add Message Post");
                Console.WriteLine("2. Add Photo Post");
                Console.WriteLine("3. Display All Posts");
                Console.WriteLine("0. Return to Main Menu");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter author: ");
                        string messageAuthor = Console.ReadLine();
                        Console.Write("Enter message: ");
                        string message = Console.ReadLine();
                        MessagePost messagePost = new MessagePost(messageAuthor, message);
                        newsFeed.AddPost(messagePost);
                        break;
                    case "2":
                        Console.Write("Enter author: ");
                        string photoAuthor = Console.ReadLine();
                        Console.Write("Enter photo filename: ");
                        string photoFilename = Console.ReadLine();
                        Console.Write("Enter caption: ");
                        string caption = Console.ReadLine();
                        PhotoPost photoPost = new PhotoPost(photoAuthor, photoFilename, caption);
                        newsFeed.AddPost(photoPost);
                        break;
                    case "3":
                        newsFeed.Display();
                        break;
                    case "0":
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
