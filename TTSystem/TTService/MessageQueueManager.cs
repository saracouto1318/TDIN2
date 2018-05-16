using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TTService
{
    public class MessageQueueManager
    {
        private static MessageQueueManager instance;

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

        private Dictionary<string, MessageQueueSender> ActiveMessageQueues;

        private MessageQueueManager()
        {
            ActiveMessageQueues = new Dictionary<string, MessageQueueSender>();
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
