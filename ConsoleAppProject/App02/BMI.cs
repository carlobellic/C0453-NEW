using System;

namespace ConsoleAppProject.App02
{
    public class BMICalculator
    {
        public void Run()
        {
            Console.WriteLine("BMI Calculator Application");
            Console.WriteLine("Welcome to the BMI Calculator! This application helps you determine your Body Mass Index (BMI) and understand your weight-related health risks.");
            Console.WriteLine("For most adults, BMI provides a good estimate of weight-related health risks.");
            Console.WriteLine();

            DisplayWHOWeightStatusCategories();

            double weight = GetValidInput("Enter your weight (kg): ");
            double height = GetValidInput("Enter your height (m): ");

            double bmi = CalculateBMI(weight, height);
            string status = DetermineWeightStatus(bmi);

            Console.WriteLine($"Your BMI is: {bmi:F2}");
            Console.WriteLine($"According to the WHO guidelines, your weight status is: {status}");
        }
