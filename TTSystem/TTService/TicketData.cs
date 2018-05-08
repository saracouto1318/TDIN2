using System;
using System.Collections.Generic;

namespace TTService
{
    class TicketData
    {
        private static TicketData _instance;

        private Dictionary<int, Ticket> _tickets;
        private Dictionary<int, User> _users;

        public TicketData()
        {
            _tickets = new Dictionary<int, Ticket>();
            _users = new Dictionary<int, User>();

            // TODO extract information from db SARA FAZ
        }

        public static TicketData GetInstance()
        {
            if(_instance == null)
            {
                _instance = new TicketData();
            }

            return _instance;
        }

    }
}
