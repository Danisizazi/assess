namespace ThreadApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Factorial factorial = new Factorial();
            Thread twoFactorial = new Thread(() => factorial.PrintFactorial(2));
            Thread threeFactorial = new Thread(() => factorial.PrintFactorial(3));
            Thread fiveFactorial = new Thread(() => factorial.PrintFactorial(5));

            threeFactorial.Start();
            twoFactorial.Start();
            fiveFactorial.Start();

            Console.ReadKey();
        }
    }
}
