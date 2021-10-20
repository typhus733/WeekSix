using System;
using System.IO;

namespace WeekSix
{
    public class BadInt : Exception
    {
        public BadInt()
        {
        }

        public BadInt(string message) : base(message)
        {
            Console.WriteLine(message);
        }

        public BadInt(string message, Exception inner) : base(message, inner)
        {
        }
    }
    class Program
    {


        static void NumberSeven()
        {
            try
            {
                Console.WriteLine("Enter a positive integer");
                int input = int.Parse(Console.ReadLine());
                if (input < 0)
                {
                    throw new BadInt("Number must be positive");
                }

                Console.WriteLine(Math.Sqrt(input));
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Invalid Number");
            }

            catch (BadInt bi)
            {
                
            }

            finally
            {
                Console.WriteLine("Good Bye");
            }

        }

        static void ReadNumber(int start, int end)
        {
            int currentNum = start;
            for(int x = 1; x <= 10; x++)
            {
                try
                {
                    Console.WriteLine("Enter number {2}, must be greater than {0} and less than {1}", currentNum, end, x);
                    int input = int.Parse(Console.ReadLine());
                    
                    if (input < 0)
                    {
                        throw new BadInt("Bad number, cannot be negative");
                    }
                    else if (input <= currentNum)
                    {
                        throw new BadInt("Bad number, number too low");
                    }
                    else if (input >= (end - (10 - x)))
                    {
                        throw new BadInt("Bad number, number too high and/or potentially prevents full iteration");
                    }
                    currentNum = input;

                }
                catch(FormatException fe)
                {
                    x--;
                    Console.WriteLine("Bad input! Must be an integer");
                }

                catch(BadInt bi)
                {
                    x--;
                }
            }

        }

        static string NumberNine(string fileName)
        {
            string fileRead = "";
            try 
            {
                fileRead = File.ReadAllText(fileName);
            }

            catch (IOException e)
            {
                fileRead = "Bad file!";
            }
            return fileRead;
        }

        static void Main(string[] args)
        {
            //NumberSeven();
            //ReadNumber(1, 100);
            Console.WriteLine(NumberNine(@"C:\temp\junk.txt"));
        }
    }
}
