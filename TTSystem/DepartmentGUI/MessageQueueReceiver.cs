using System;
using System.Messaging;
using TTService.Models;

namespace DepartmentGUI
{
    public class MessageQueueReceiver
    {
        #region Singleton 
        private static MessageQueueReceiver instance;
        public static MessageQueueReceiver Instance {
            get
            {
                return instance;
            }
        }

        //Enforce singleton pattern
        public static MessageQueueReceiver InitializeInstance(string name)
        {
            if(instance != null)
            {
                instance.MQueue.Close();
            }
            instance = new MessageQueueReceiver(name);
            return instance;
        }
        #endregion

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
            Message msg = MQueue.EndReceive(rcea.AsyncResult);
            SerializedSecondaryQuestion ssq = (SerializedSecondaryQuestion)msg.Body;
            // TODO something
            // (...)
            MQueue.BeginReceive();
        }
    }
}
