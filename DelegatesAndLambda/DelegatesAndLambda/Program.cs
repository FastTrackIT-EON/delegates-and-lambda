using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndLambda
{
    public delegate int SumOfThreeNumbers(int a, int b, int c);

    public delegate int OtherSumOfThreeNumbers(int a, int b, int c);

    internal class Program
    {
        static void Main(string[] args)
        {
            //SumOfThreeNumbers varFunction = SumProgram;
            //int result = varFunction(1, 2, 3);

            //Math math = new Math();
            //SumOfThreeNumbers varFunction = math.Sum;
            //int result = varFunction.Invoke(1, 2, 3);

            SumOfThreeNumbers varFunction = delegate (int x, int y, int z)
            {
                return x + y + z;
            };

            int result = varFunction.Invoke(1, 2, 3);

            int[] array = new[] { 1, 2, 3 };

            Action<int> actOnElement = delegate (int element)
            {
                Console.WriteLine(element);
            };

            array.ForEach(actOnElement);

            Func<int, bool> isEvenNumber = CheckNumberIsEven;
            Func<int, bool> anyDivisorOf3 = delegate (int number)
            {
                return AnyDivisorOf(number, 3);
            };

            bool areAnyEvenNumbers = array.HasMatch(isEvenNumber);
            bool areAnyDivisorsOf3 = array.HasMatch(anyDivisorOf3);
            Console.WriteLine($"Are there any even numbers: {areAnyEvenNumbers}");


            List<Product> products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "iPhone",
                    Category = "Smartphones"
                },
                new Product
                {
                    Id = 2,
                    Name = "Samsung Galaxy S24",
                    Category = "Smartphones"
                },
                new Product
                {
                    Id = 3,
                    Name = "Dell",
                    Category = "Laptops"
                },
                new Product
                {
                    Id = 4,
                    Name = "HP",
                    Category = "Laptops"
                },
                new Product
                {
                    Id = 5,
                    Name = "Samsung",
                    Category = "TVs"
                }
            };

            Func<Product, bool> keepOnlyLaptops = delegate (Product p)
            {
                return string.Equals(p.Category, "Laptops", StringComparison.OrdinalIgnoreCase);
            };

            foreach(Product laptops in products.Filter(keepOnlyLaptops))
            {
                Console.WriteLine($"#{laptops.Id} - {laptops.Name}, Category: {laptops.Category}");
            }

            Console.ReadKey();
        }

        private static int SumProgram(int x, int y, int z)
        {
            return x + y + z;
        }

        private static bool CheckNumberIsEven(int number)
        {
            return number % 2 == 0;
        }

        private static bool AnyDivisorOf(int number, int x)
        {
            return number % x == 0;
        }
    }
}
