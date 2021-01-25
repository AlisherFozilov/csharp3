using System;
using System.Collections.Generic;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // DZ 1
                // ===========================================================
                Console.WriteLine("task 1");
                
                Console.WriteLine("Enter number");
                var a = inputNumber();
                Console.WriteLine("Enter number");
                var b = inputNumber();
                var sum = task1(a, b); // or task11
                Console.WriteLine($"sum = {sum}");

                Console.WriteLine("odd numbers:");
                task1_2(a, b);

                Console.WriteLine("===========================================================");
                Console.WriteLine("task 2");
                Console.WriteLine();
                printSquare(5, "* ", "  ");
                Console.WriteLine();
                printRightTriangle(5, "* ");
                Console.WriteLine();
                printEquilateralTriangle(5, "* ");
                Console.WriteLine();
                printRhombus(5, "* ");
                Console.WriteLine();

                Console.WriteLine("===========================================================");
                Console.WriteLine("task 3");
                Console.WriteLine("Enter number");
                Double.TryParse(Console.ReadLine(), out double percent);
                var depositAmount = 1000.0; // rub
                var months = 0;
                while (depositAmount <= 1100)
                {
                    Console.WriteLine(depositAmount);
                    depositAmount += depositAmount * percent / 100;
                    months++;
                }
                Console.WriteLine($"total deposit is {depositAmount}");
                Console.WriteLine($"number of months is {months}");

                // DZ 2
                Console.WriteLine("===========================================================");
                Console.WriteLine("task 4");
                Console.WriteLine("Enter number");

                var size = inputNumber();
                if (size < 1)
                {
                    Console.WriteLine("size can not be less than 1");
                    return;
                }

                int[] numbers = new int[size];
                var random = new Random();

                for (int i = 0; i < size; i++)
                    numbers[i] = random.Next(100);
                

                Console.WriteLine("array is:");
                print(numbers);

                var largest = findLargestNumberIn(numbers);
                var min = findMinNumberIn(numbers);
                sum = sumAll(numbers);
                var average = sum / Convert.ToDouble(numbers.Length);
                var oddNumbers = findOdds(numbers);
                
                Console.WriteLine($"largest is {largest}");
                Console.WriteLine($"min is {min}");
                Console.WriteLine($"sum is {sum}");
                Console.WriteLine($"average is {average}");
                Console.WriteLine($"odd numbers are:");
                print(oddNumbers);

                Console.WriteLine("===========================================================");
                Console.WriteLine("task5");
                Console.WriteLine("Enter array size:");
                size = inputNumber();
                int[] ordered = new int[size];
                
                Console.WriteLine("Enter numbers");
                for (int i = 0; i < size; i++)
                {
                    ordered[i] = inputNumber();
                }

                int[] reversed = new int[size];

                var lastIndex = size - 1;
                for (int i = lastIndex; i >= 0 ; i--)
                {
                    reversed[lastIndex - i] = ordered[i];
                }

                Console.WriteLine("ordered and reversed:");
                print(ordered);
                print(reversed);

                Console.WriteLine("===========================================================");
                Console.WriteLine("task 6");
                Console.WriteLine("Enter array size:");
                size = inputNumber();
                int[] array = new int[size];
                
                var rnd = new Random();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next(100);
                }

                print(array);
                
                Console.WriteLine("Enter index:");
                var index = inputNumber();
                Console.WriteLine("Enter count:");
                var count = inputNumber();
                
                int[] resultArray = new int[count];
                
                if (count + index <= array.Length)
                {
                    var j = index;
                    for (int i = 0; i < resultArray.Length; i++, j++)
                    {
                        resultArray[i] = array[j];
                    }
                }
                else
                {
                    var j = 0;
                    for (int i = index; i < array.Length; i++, j++)
                    {
                        resultArray[j] = array[i];
                    }
                    for (; j < resultArray.Length; j++)
                    {
                        resultArray[j] = 1;
                    }
                }

                print(resultArray);
            }
            catch (BadInputException)
            {
                Console.WriteLine("Bad input. Program terminated. Try again.");
                return;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Unknown program error");
                return;
            }
            
        }

        static T findLargestNumberIn<T>(T[] numbers) where T: IComparable<T>
        {
            var max = numbers[0];
            foreach (var number in numbers)
                if (max.CompareTo(number) < 0)
                    max = number;
            
            return max;
        }

        static T findMinNumberIn<T>(T[] numbers) where T: IComparable<T>
        {
            var min = numbers[0];
            foreach (var number in numbers)
                if (min.CompareTo(number) > 0)
                    min = number;
            
            return min;
        }

        static int sumAll(int[] numbers)
        {
            var sum = 0;
            foreach (var number in numbers)
                sum += number;
            
            return sum;
        }

        static int[] findOdds(int[] numbers)
        {
            var oddNumbers = new List<int>();
            foreach (var number in numbers)
            {
                if (number % 2 != 0)
                    oddNumbers.Add(number);
            }
            return oddNumbers.ToArray();
        }

        static void print<T>(T[] collection)
        {
            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void printSquare(int side, string symbol, string emptySymbol)
        {
            printLine(side, symbol);
            // body
            for (int i = 1; i < side - 1; i++)
            {
                Console.Write(symbol);
                for (int j = 0; j < side-2; j++)
                {
                    Console.Write(emptySymbol);
                }
                Console.WriteLine(symbol);
            }
            printLine(side, symbol);
        }

        static void printRightTriangle(int leg, string symbol) // leg = катет
        {
            for (int i = 1; i <= leg; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
        }

        static void printEquilateralTriangle(int side, string symbol) // leg = катет
        {
            var spaces = side;
            var symbols = 0;
            for (int i = 0; i <= side; i++)
            {
                for (int j = 0; j < spaces; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < symbols; j++)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine();
                spaces--;
                symbols++;
            }
        }

        static void printEquilateralTriangleUpsideDown(int side, string symbol)
        {
            var spaces = 0;
            var symbols = side;
            for (int i = 0; i <= side; i++)
            {
                Console.Write(" ");
                for (int j = 0; j < spaces; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < symbols; j++)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine();
                spaces++;
                symbols--;
            }
        }

        static void printRhombus(int side, string symbol)
        {
            var half = side / 2 + 1;
            printEquilateralTriangle(half, symbol);
            printEquilateralTriangleUpsideDown(half - 1, symbol);
        }

        static void printLine(int side, string symbol)
        {
            for (int i = 0; i < side; i++)
            {
                Console.Write(symbol);
            }
            Console.Write("\n");
        }

        static int inputNumber()
        {
            var input = Console.ReadLine();
            var ok = Int32.TryParse(input, out var number);
            if (!ok)
            {
                throw new BadInputException("not a number");
            }
            return number;
        }

        static int task1(int a, int b)
        {
            var sum = 0;
            for (int i = a + 1; i < b; i++)
            {
                sum += i;
            }
            return sum;
        }
        static double task11(int a, int b)
        {
            var sum = (b + a) / 2.0 * (b-a-1);
            return sum;
        }

        static void task1_2(int a, int b)
        {
            var anyOddExists = false;
            for (int i = a + 1; i < b; i++)
            {
                if (i % 2 != 0)
                {
                    anyOddExists = true;
                    Console.WriteLine(i);
                }
            }
            if (!anyOddExists)
            {
                Console.WriteLine("no odds");
            }
        }
    }
}

[System.Serializable]
public class BadInputException : System.Exception
{
    public BadInputException() { }
    public BadInputException(string message) : base(message) {}
    public BadInputException(string message, System.Exception inner) : base(message, inner) { }
    protected BadInputException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
