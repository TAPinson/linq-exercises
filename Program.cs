using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Restriction/Filtering Operations");
            Console.WriteLine("--------------------------------");
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            IEnumerable<string> LFruits = fruits.Where<string>(fruit =>
            {
                return fruit.StartsWith("L");
            });

            foreach (string fruit in LFruits)
            {
                Console.WriteLine(fruit);
            }

            Console.WriteLine(" ");
            ///////////////////////////////////////////////////////////////////////////////

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable<int> fourSixMultiples = numbers.Where<int>(number =>
            {
                return number % 6 == 0 || number % 4 == 0;
            });

            foreach (int number in fourSixMultiples)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine(" ");
            ///////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Ordering Operations");
            Console.WriteLine("-------------------");
            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre"
            };

            IEnumerable<string> descend = names.OrderByDescending(name => name);

            foreach (string name in descend)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine(" ");
            ///////////////////////////////////////////////////////////////////////////////

            // Build a collection of these numbers sorted in ascending order
            List<int> garbledNumbers = new List<int>()
            {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable<int> ascendingNumbers = garbledNumbers.OrderBy(n => n);

            foreach (int number in ascendingNumbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine(" ");
            ///////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Aggregate Operations");
            Console.WriteLine("--------------------");
            // Output how many numbers are in this list
            List<int> numbers3 = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            Console.WriteLine(numbers3.Count);
            Console.WriteLine(" ");
            ///////////////////////////////////////////////////////////////////////////////

            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };

            double totalMade = purchases.Sum();
            Console.WriteLine(totalMade);
            Console.WriteLine(" ");
            ///////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Partitioning Operations");
            Console.WriteLine("-----------------------");
            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };

            double expensiveProduct = prices.Max();
            Console.WriteLine(expensiveProduct);
            Console.WriteLine(" ");
            ///////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Partitioning Operations");
            Console.WriteLine("-----------------------");
            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };

            /*
                Store each number in the following List until a perfect square
                is detected.

                Expected output is { 66, 12, 8, 27, 82, 34, 7, 50, 19, 46 } 

                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */

            IEnumerable<int> heresSquaredo = wheresSquaredo.TakeWhile(n =>
            {
                double result = Math.Sqrt(n);
                bool isSquare = result % 1 == 0;

                if (isSquare == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            });

            foreach (int squaredo in heresSquaredo)
            {
                Console.WriteLine(squaredo);
            }

            Console.WriteLine(" ");
            ///////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Using Custom Types");
            Console.WriteLine("------------------");

            List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };



            List<Customer> millionaires = customers.Where(customer =>
            {
                return customer.Balance >= 1_000_000;
            }).ToList();

            millionaires.GroupBy(customer => customer.Bank)
                .ToList()
                .ForEach(group =>
                {
                    Console.WriteLine($"{group.Key} {group.Count()}");
                });

            // foreach (Customer customer in millionaires)
            // {
            //     Console.WriteLine(customer.Bank);
            // }

        }
    }
}
