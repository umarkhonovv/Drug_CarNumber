using System.ComponentModel.Design;

namespace DRUG__CarNumber
{
    internal class Program
    {
        public static List<string> CarNumbers = new List<string>();

        public static void DataSeed()
        {
            
        }
        public static bool CheckNumber(string carNumber)
        {
            var result = false;

            if (carNumber.Length == 6)
            {
                if (char.IsLetter(carNumber[0]) && char.IsLetter(carNumber[4]) && char.IsLetter(carNumber[5]))
                {
                    if (char.IsDigit(carNumber[1]) && char.IsDigit(carNumber[2]) && char.IsDigit(carNumber[3]))
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            RunDrug();
        }

        public static void RunDrug()
        {
            while (true)
            {
                Console.WriteLine("1.Put a car license plate up for auction");
                Console.WriteLine("2.Delete the car license plates that have been put up for auction.");
                Console.WriteLine("3.View car license plates in the auction");
                Console.Write("Select option :");
                var option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    Console.Write("Enter the number :");
                    var carNumber = Console.ReadLine();
                    PutCarOnAuction(carNumber);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter the number you want to delete from the auction");
                    var carNumber = Console.ReadLine();
                    carNumber = carNumber.ToUpper();
                    if (CheckNumber(carNumber) is true)
                    {
                        var exists = CarNumbers.Contains(carNumber);
                        if (exists is true)
                        {
                            CarNumbers.Remove(carNumber);
                            Console.WriteLine("The number succesfuly deleted");
                        }
                        else
                        {
                            Console.WriteLine("Such a number is not available in the auction");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valid Format");
                    }
                }
                else if (option == 3)
                {
                    var numbers = CarNumbers;
                    foreach (var number in numbers)
                    {
                        Console.WriteLine(number);
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static void PutCarOnAuction(string carNumber)
        {
            var exsits = CarNumbers.Contains(carNumber);
            if (CheckNumber(carNumber) is false)
            {
                Console.WriteLine("The number was not put into the auction. You entered the wrong number");
            }
            else if (exsits is true)
            {
                Console.WriteLine("This number is already in the auction");
            }
            else
            {
                Console.WriteLine("Number added successfully");
                carNumber = carNumber.ToUpper();
                CarNumbers.Add(carNumber);
            }
        }

    }
}
