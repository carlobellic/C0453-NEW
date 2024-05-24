using System;

namespace ConsoleAppProject.App02
{
    public class BMICalculator
    {
        public void Run()
        {
// The BMI Calculator Application Displays a heading which allows the user a general background of what the program does.
            Console.WriteLine("BMI Calculator Application");
            Console.WriteLine("Welcome to the BMI Calculator! This application helps you determine your Body Mass Index (BMI) and understand your weight-related health risks.");
            Console.WriteLine("For most adults, BMI provides a good estimate of weight-related health risks.");
            Console.WriteLine();

            DisplayWHOWeightStatusCategories();

            double weight = GetValidInput("Enter your weight (kg): ");
            double height = GetValidInput("Enter your height (m): ");

            double bmi = CalculateBMI(weight, height);
            string status = DetermineWeightStatus(bmi);
// Uses the entered weight and height to be able to calculate the persons BMI based on the WHO Chart, and displays the selected weight category.

            Console.WriteLine($"Your BMI is: {bmi:F2}");
            Console.WriteLine($"According to the WHO guidelines, your weight status is: {status}");
        }
                static double CalculateBMI(double weight, double height)
        {
            return weight / (height * height);
        }

        static string DetermineWeightStatus(double bmi)
        {
            if (bmi < 18.5)
            {
                return "Underweight";
            }
            else if (bmi >= 18.5 && bmi < 25.0)
            {
                return "Normal";
            }
            else if (bmi >= 25.0 && bmi < 30.0)
            {
                return "Overweight";
            }
            else if (bmi >= 30.0 && bmi < 35.0)
            {
                return "Obese Class I";
            }
            else if (bmi >= 35.0 && bmi < 40.0)
            {
                return "Obese Class II";
            }
            else
            {
                return "Obese Class III";
            }
        }
// This is just a scale of the different ranges of BMI which will determine the weight class.
        static void DisplayWHOWeightStatusCategories()
        {
            Console.WriteLine("WHO Weight Status Categories:");
            Console.WriteLine("Underweight: BMI < 18.50");
            Console.WriteLine("Normal: BMI 18.5 - 24.9");
            Console.WriteLine("Overweight: BMI 25.0 - 29.9");
            Console.WriteLine("Obese Class I: BMI 30.0 - 34.9");
            Console.WriteLine("Obese Class II: BMI 35.0 - 39.9");
            Console.WriteLine("Obese Class III: BMI >= 40.0");
            Console.WriteLine();
        }

        static double GetValidInput(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (double.TryParse(input, out value) && value > 0)
                {
                    break;
                }
                else
                {
// Pretty simple here, if you don't enter a positive number it will output that the answer is invalid, as you can't have a negative weight and height.
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                }
            }
            return value;
        }
    }
}
