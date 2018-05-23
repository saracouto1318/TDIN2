using System;
using System.Collections.Generic;
using System.Messaging;
using TTService.Models;

namespace DepartmentGUI
{
    public delegate void NewSecondaryQuestion(SerializedSecondaryQuestion secondaryQuestion);

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

        public List<SerializedSecondaryQuestion> secondaryQuestions = new List<SerializedSecondaryQuestion>();

        public NewSecondaryQuestion OnNewSecondaryQuestion;

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
            Message msg = null;
            try
            {
                msg = MQueue.EndReceive(rcea.AsyncResult);
            }
            catch{}
            if (msg != null)
            {
                SerializedSecondaryQuestion ssq = (SerializedSecondaryQuestion)msg.Body;
                secondaryQuestions.Add(ssq);
                // Notify listeners
                OnNewSecondaryQuestion?.Invoke(ssq);
            }

            MQueue.BeginReceive();
        }
    }
}
