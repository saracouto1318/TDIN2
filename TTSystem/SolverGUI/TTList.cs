using GUI.TTSolverSvc;
using GUI.TTSvc;
using System.Collections.Generic;
using TTService;

namespace SolverGUI
{
    public class TTList
    {
        #region Delegates
        // Delegate function for trouble ticket updates
        public delegate void TTUpdate(Ticket ticket);
        // Function for notifying a new trouble ticket
        public TTUpdate OnNewTroubleTicket;
        // Function for notifying my assigned ticket
        public TTUpdate OnMyAssignedTroubleTicket;
        // Function for notifying my assigned ticket
        public TTUpdate OnOtherAssignedTroubleTicket;
        // Function for notifying a closed trouble ticket
        public TTUpdate OnClosedTroubleTicket;

        // Delegate function for secondary questions updates
        public delegate void SecondaryQuestionUpdate(Ticket ticket, SecondaryQuestion secondaryQuestion);
        // Function for notifying a new waiting trouble ticket
        public SecondaryQuestionUpdate OnWaitingSecondaryQuestion;
        // Function for notifying an answered secondary question
        public SecondaryQuestionUpdate OnAnsweredSecondaryQuestion;
        #endregion
        #region TT
        // Unassigned trouble tickets
        public List<Ticket> UnassignedTroubleTickets;
        // Assigned trouble tickets
        public List<Ticket> AssignedTroubleTickets;
        // Trouble tickets whose secondary question is waiting to be answered
        public List<Ticket> WaitingTroubleTickets;
        // Closed touble tickets
        public List<Ticket> ClosedTroubleTickets;
        #endregion
        #region SQ
        // Secondary question waiting to be answered
        public List<SecondaryQuestion> OpenSecondaryQuestion;
        // Answered secondary questions
        public List<SecondaryQuestion> ClosedSecondaryQuestion;
        #endregion

        public TTList()
        {
            OnNewTroubleTicket += OnNewTT;
            OnMyAssignedTroubleTicket += OnMyAssignedTT;
            OnOtherAssignedTroubleTicket += AssignedTT;
            OnClosedTroubleTicket += OnClosedTT;
            OnWaitingSecondaryQuestion += OnQuestionTT;
            OnAnsweredSecondaryQuestion += OnAnsweredSQ;
        }

        public List<Ticket> GetTicketsByStatus(TicketStatus status)
        {
            switch(status)
            {
                case TicketStatus.UNASSIGNED:
                    return UnassignedTroubleTickets;
                case TicketStatus.ASSIGNED:
                    return AssignedTroubleTickets;
                case TicketStatus.WAITING:
                    return WaitingTroubleTickets;
                case TicketStatus.CLOSED:
                    return ClosedTroubleTickets;
            }
            return null;
        }

        // Queries the service for the information
        public void UpdateTT(
            TTSolverSvcClient SolverProxy, 
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

            OpenSecondaryQuestion =
                new List<SecondaryQuestion>(
                    SolverProxy.MyQuestions(user.ID, false));
            ClosedSecondaryQuestion =
                new List<SecondaryQuestion>(
                    SolverProxy.MyQuestions(user.ID, true));
        }
        
        // Called when a new trouble ticket as been dispatched
        public void OnNewTT(Ticket ticket)
        {
            UnassignedTroubleTickets.Add(ticket);
        }
        
        // Called when this user's trouble ticket as been assigned
        public void OnMyAssignedTT(Ticket ticket)
        {
            AssignedTT(ticket);
            AssignedTroubleTickets.Add(ticket);
        }

        // Called when a trouble ticket as been assigned
        public void AssignedTT(Ticket ticket)
        {
            UnassignedTroubleTickets.Remove(ticket);
        }
        
        // Called when a secondary question is dispatched
        public void OnQuestionTT(
            Ticket ticket, 
            SecondaryQuestion secondaryQuestion)
        {
            AssignedTroubleTickets.Remove(ticket);
            WaitingTroubleTickets.Add(ticket);

            OpenSecondaryQuestion.Add(secondaryQuestion);
        }
        
        // Called when a secondary question is answered
        public void OnAnsweredSQ(
            Ticket ticket,
            SecondaryQuestion secondaryQuestion)
        {
            WaitingTroubleTickets.Remove(ticket);
            AssignedTroubleTickets.Add(ticket);

            OpenSecondaryQuestion.Remove(secondaryQuestion);
            ClosedSecondaryQuestion.Add(secondaryQuestion);
        }
        
        // Called when a trouble ticket is answered
        public void OnClosedTT(Ticket ticket)
        {
            AssignedTroubleTickets.Remove(ticket);
            ClosedTroubleTickets.Add(ticket);
        }
    }

}
