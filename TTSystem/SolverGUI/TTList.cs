using GUI.TTSolver;
using GUI.TTSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTService;

namespace SolverGUI
{
    public class TTList
    {
        public List<Ticket> UnassignedTroubleTickets;
        public List<Ticket> AssignedTroubleTickets;
        public List<Ticket> WaitingTroubleTickets;
        public List<Ticket> ClosedTroubleTickets;

        public void UpdateTT(
            TTSolverSvcClient SolverProxy, 
            TTServClient Proxy,
            User user)
        {
            UnassignedTroubleTickets = 
                new List<Ticket>(
                    SolverProxy.GetUnassignedTT());
            AssignedTroubleTickets =
                new List<Ticket>(
                    SolverProxy.GetSolverTTByType(user, TicketStatus.ASSIGNED));
            WaitingTroubleTickets =
                new List<Ticket>(
                    SolverProxy.GetSolverTTByType(user, TicketStatus.WAITING));
            ClosedTroubleTickets =
                new List<Ticket>(
                    SolverProxy.GetSolverTTByType(user, TicketStatus.CLOSED));
        }
        public void OnNewTT(Ticket ticket)
        {
            UnassignedTroubleTickets.Add(ticket);
        }
        public void OnAssignedTT(Ticket ticket)
        {
            UnassignedTroubleTickets.Remove(ticket);
            AssignedTroubleTickets.Add(ticket);
        }
        public void OnQuestionTT(Ticket ticket)
        {
            AssignedTroubleTickets.Remove(ticket);
            WaitingTroubleTickets.Add(ticket);
        }
        public void OnAnsweredTT(Ticket ticket)
        {
            WaitingTroubleTickets.Remove(ticket);
            AssignedTroubleTickets.Add(ticket);
        }
        public void OnClosedTT(Ticket ticket)
        {
            AssignedTroubleTickets.Remove(ticket);
            ClosedTroubleTickets.Add(ticket);
        }
    }

}
