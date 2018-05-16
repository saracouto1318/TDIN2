using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

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

        public void Send(SecondaryQuestion sq)
        {
            MQueue.Send(sq, "Question");
        }
    }
}
