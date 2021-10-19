using System;

namespace WeekSix
{
    public class BadInt : Exception
    {
        public BadInt()
        {
        }

        public BadInt(string message) : base(message)
        {
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
                    throw new BadInt();
                }

                Console.WriteLine(Math.Sqrt(input));
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Invalid Number");
            }

            catch (BadInt bi)
            {
                Console.WriteLine("Invalid Number");
            }

            finally
            {
                Console.WriteLine("Good Bye");
            }

        }


        static void Main(string[] args)
        {
            NumberSeven();
        }
    }
}
