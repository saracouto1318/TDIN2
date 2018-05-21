using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TTService
{
    [ServiceContract(CallbackContract = typeof(ITTUpdateCallback))]
    public interface ITTSolverSvc
    {
        #region SolverGUI
        [OperationContract]
        String Hello();

        [OperationContract]
        void Subscribe();

        [OperationContract]
        void Unsubscribe();

        [OperationContract]
        bool RegisterSolver(string name, string email, string password);

        [OperationContract]
        bool LoginSolver(string email, string password);

        [OperationContract]
        User GetSolver(int id);
        
        [OperationContract]
        List<Ticket> GetUnassignedTT();

        [OperationContract]
        List<Ticket> GetSolverTT(User solver);

        [OperationContract]
        List<Ticket> GetSolverTTByType(User solver, TicketStatus status);

        [OperationContract]
        bool AssignTicket(int idTicket, int idSolver);

        [OperationContract]
        bool AnswerTicket(int solver, int senderTicket, int ticket, string email);

        [OperationContract]
        bool RedirectTicket(int ticket, int solver, string redirectMessage, string department);

        [OperationContract]
        List<SecondaryQuestion> MyQuestions(int idSolver, bool type);
        #endregion
    }
    public interface ITTUpdateCallback
    {
        [OperationContract(IsOneWay = true)]
        void NewTT(Ticket ticket);

        [OperationContract(IsOneWay = true)]
        void AssignedTT(Ticket ticket);
    }
}
