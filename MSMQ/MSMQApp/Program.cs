namespace MSMQApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Producer producer = new Producer();

            producer.GenerateNumbers();

            Console.WriteLine("Generated numbers are:");
            Consumer consumer = new Consumer();
            consumer.RecieveFromQueue();
            Console.ReadKey();
        }
    }
}
