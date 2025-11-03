using MSMQ.Messaging;

namespace MSMQApp
{
    internal class Producer
    {
        private Random random;
        private MessageQueue randomNumberQueue;
        private Message message;
        public Producer()
        {
            random = new Random();
            message = new Message();
            message.Formatter = new XmlMessageFormatter();
        }

        public void GenerateNumbers()
        {
            try
            {
                if (MessageQueue.Exists(@".\Private$\randomNumberQueue"))
                {
                    randomNumberQueue = new MessageQueue(@".\Private$\randomNumberQueue");
                }
                else
                {
                    randomNumberQueue = MessageQueue.Create(@".\Private$\randomNumberQueue");
                }

                SendRandomNumbers();
            }
            catch(MessageQueueException msmqEx) 
            {
                Console.WriteLine($"Error occured in adding to queue\n: {msmqEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:\n: {ex.Message}");
            }

        }


        private void SendRandomNumbers()
        {
            for (int i = 0; i < 5; i++)
            {
                message.Body = random.Next(1, 7);
                message.Label = $"Message number {i}";
                randomNumberQueue.Send(message);
            }
        }
    }
}
