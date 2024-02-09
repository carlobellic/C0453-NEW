using System;

namespace ConsoleAppProject.App01
{
    public class DistanceConverter
    {
        public const int FEET_IN_MILES = 5280;
        public const int MILES_IN_FEET = 1;
        private double miles;
        private double feet;

        public void Run()
        {
            bool continueExecution = true;

            while (continueExecution)
            {
                OutPutHeading();
                Console.WriteLine("1. Convert Miles to Feet");
                Console.WriteLine("2. Convert Feet to Miles");
                Console.WriteLine("3. Quit");
                Console.Write("Please choose an option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ConvertMilesToFeet();
                        break;
                    case "2":
                        ConvertFeetToMiles();
                        break;
                    case "3":
                        continueExecution = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
        }

        private void OutPutHeading()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("    Distance Converter Menu     ");
            Console.WriteLine("       by Carl O'Brien            ");
            Console.WriteLine("--------------------------------");
        }

        private void ConvertMilesToFeet()
        {
            Console.Write("Please enter the number of miles: ");
            string value = Console.ReadLine();
            miles = Convert.ToDouble(value);
            feet = miles * FEET_IN_MILES;
            Console.WriteLine($"{miles} miles is equal to {feet} feet.");
        }

        private void ConvertFeetToMiles()
        {
            Console.Write("Please enter the number of feet: ");
            string value = Console.ReadLine();
            feet = Convert.ToDouble(value);
            miles = feet / FEET_IN_MILES;
            Console.WriteLine($"{feet} feet is equal to {miles} miles.");
        }
    }
}
