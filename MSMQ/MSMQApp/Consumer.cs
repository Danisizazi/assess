using MSMQ.Messaging;

namespace MSMQApp
{
    internal class Consumer
    {
        private MessageQueue randomNumberQueue;

        public Consumer()
        {
            randomNumberQueue = new MessageQueue(@".\Private$\randomNumberQueue");
        }

        public void RecieveFromQueue()
        {
            try
            {
                if (MessageQueue.Exists(@".\Private$\randomNumberQueue"))
                {
                    randomNumberQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(System.Int32) });

                    var messages = randomNumberQueue.GetAllMessages();
                    foreach (var msg in messages)
                    {
                        Console.WriteLine(msg.Body);
                    }
                }
            }
            catch (MessageQueueException msmqEx)
            {
                Console.WriteLine($"Error occured in consuming from queue:\n: {msmqEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:\n: {ex.Message}");
            }
        }

    }
}
