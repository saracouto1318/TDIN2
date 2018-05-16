using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using TTService.Database;

namespace TTService
{
    public class MessageQueueManager
    {
        #region Singleton
        private static MessageQueueManager instance;

        //Enforce singleton pattern
        public static MessageQueueManager Instance {
            get
            {
                if(instance == null)
                {
                    instance = new MessageQueueManager();
                }
                return instance;
            }
        }
        #endregion

        // Dictionary containing all active messagequeues
        private Dictionary<string, MessageQueueSender> ActiveMessageQueues;

        private MessageQueueManager()
        {
            ActiveMessageQueues = new Dictionary<string, MessageQueueSender>();
            FillActiveMessageQueues();
        }

        // On intialisation, get all stored departments and create the MessageQueues
        private void FillActiveMessageQueues()
        {
            List<string> departments = UserDao.GetDepartments();
            foreach(string department in departments)
            {
                AddMessageQueue(department);
            }
        }

        public MessageQueueSender AddMessageQueue(string name)
        {
            if (!ActiveMessageQueues.ContainsKey(name))
            {
                MessageQueueSender mqs = new MessageQueueSender(name);
                ActiveMessageQueues.Add(name, mqs);
                return mqs;
            }
            return GetMessageQueue(name);
        }

        public MessageQueueSender GetMessageQueue(string name)
        {
            bool success = ActiveMessageQueues.TryGetValue(name, out MessageQueueSender mqs);
            return success ? mqs : null;
        }
    }
}
