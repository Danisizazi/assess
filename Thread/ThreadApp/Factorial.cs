namespace ThreadApp
{
    public class Factorial
    {
        static readonly object lockOject = new object();

        public void PrintFactorial(int factorial)
        {
            lock (lockOject)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Factorial of {factorial} is {GetFactorial(factorial)}");
                    Thread.Sleep(1000);
                }
            }
        }

        public long GetFactorial(int input)
        {
            if(input == 0 || input == 1)
            {
                return 1;
            }
            if (input< 0)
            {
                throw new ArgumentOutOfRangeException("The factorial is only defined for integers zero and greater");
            }
            else
            {
                return input * GetFactorial(input - 1);
            }
        }
    }
}
