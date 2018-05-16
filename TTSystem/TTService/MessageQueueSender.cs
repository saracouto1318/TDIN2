using System.Messaging;
using TTService.Models;

namespace TTService
{

    public class MessageQueueSender
    {
        public MessageQueue MQueue { get; }

        public MessageQueueSender(string name)
        {
            MQueue = new MessageQueue(@".\private$\" + name)
            {
                Formatter = new BinaryMessageFormatter()
            };
        }

        public void Send(SerializedSecondaryQuestion sq)
        {
            MQueue.Send(sq, "Question");
        }
    }
}
