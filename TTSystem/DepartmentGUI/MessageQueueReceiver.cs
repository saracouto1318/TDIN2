using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace DepartmentGUI
{
    public class MessageQueueReceiver
    {
        public MessageQueue MQueue { get; }

        public MessageQueueReceiver(string departmentName)
        {
            MQueue = new MessageQueue(@".\private$\"+departmentName)
            {
                Formatter = new BinaryMessageFormatter()
            };
            MQueue.ReceiveCompleted += QueueReceiver;
            MQueue.BeginReceive();
        }

        private void QueueReceiver(object src, ReceiveCompletedEventArgs rcea)
        {
            System.Messaging.Message msg = MQueue.EndReceive(rcea.AsyncResult);
            // TODO something
            // (...)
            MQueue.BeginReceive();
        }
    }
}
