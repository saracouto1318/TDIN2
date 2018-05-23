using System;
using System.Windows.Forms;
using System.Drawing;
using TTService;
using GUI.Forms;

namespace SolverGUI
{

    public interface IPanelRow
    {
        void AddPanelRow(TableLayoutPanel panel, float value, object obj, Action action);
    }

    public class TicketPanelRowImpl : IPanelRow
    {
        public void AddPanelRow(TableLayoutPanel panel, float value, object obj, Action action)
        {
            if (!(obj is Ticket))
                return;

            Ticket ticket = (Ticket)obj;
            int count = panel.Controls.Count;

            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, value));
            Label labelTmp = new Label()
            {
                Text = ticket.ID.ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            };

            labelTmp.Click += (object sender, EventArgs e) =>
            {
                action();
            };

            panel.Controls.Add(labelTmp, 0, count);

            labelTmp = new Label()
            {
                Text = ticket.Title,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            };

            labelTmp.Click += (object sender, EventArgs e) =>
            {
                action();
            };

            panel.Controls.Add(labelTmp, 1, count);

            labelTmp = new Label()
            {
                Text = ticket.Date.ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            };

            labelTmp.Click += (object sender, EventArgs e) =>
            {
                action();
            };

            panel.Controls.Add(labelTmp, 2, count);
        }
    }

    public class TitleTicketPanelRowImpl : IPanelRow
    {
        public void AddPanelRow(TableLayoutPanel panel, float value, object obj, Action action)
        {
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, value));
            Label labelTmp = new Label()
            {
                Text = "Ticket ID",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            };
            labelTmp.Click += (object sender, EventArgs e) =>
            {
                action();
            };
            panel.Controls.Add(labelTmp, 0, 0);

            labelTmp = new Label()
            {
                Text = "Title",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            };
            labelTmp.Click += (object sender, EventArgs e) =>
            {
                action();
            };
            panel.Controls.Add(labelTmp, 1, 0);

            labelTmp = new Label()
            {
                Text = "Date",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            };
            labelTmp.Click += (object sender, EventArgs e) =>
            {
                action();
            };
            panel.Controls.Add(labelTmp, 2, 0);
        }
    }

    public class TitleQuestionPanelRowImpl : IPanelRow
    {
        public void AddPanelRow(TableLayoutPanel panel, float value, object obj, Action action)
        {
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, value));
            Label labelTmp = new Label()
            {
                Text = "Ticket ID",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            };
            labelTmp.Click += (object sender, EventArgs e) =>
            {
                action();
            };
            panel.Controls.Add(labelTmp, 0, 0);

            labelTmp = new Label()
            {
                Text = "Title",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            };
            labelTmp.Click += (object sender, EventArgs e) =>
            {
                action();
            };
            panel.Controls.Add(labelTmp, 1, 0);

            labelTmp = new Label()
            {
                Text = "Date",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            };
            labelTmp.Click += (object sender, EventArgs e) =>
            {
                action();
            };
            panel.Controls.Add(labelTmp, 2, 0);
        }
    }

    public class QuestionPanelRowImpl : IPanelRow
    {
        public void AddPanelRow(TableLayoutPanel panel, float value, object obj, Action action)
        {
            if (!(obj is SecondaryQuestion))
                return;

            SecondaryQuestion q = (SecondaryQuestion)obj;
            int count = panel.Controls.Count;

            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, value));
            Label labelTmp = new Label()
            {
                Text = q.ID.ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            };

            labelTmp.Click += (object sender, EventArgs e) =>
            {
                action();
            };

            panel.Controls.Add(labelTmp, 0, count);

            labelTmp = new Label()
            {
                Text = q.TicketID.ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            };

            labelTmp.Click += (object sender, EventArgs e) =>
            {
                action();
            };

            panel.Controls.Add(labelTmp, 1, count);

            labelTmp = new Label()
            {
                Text = Client.Instance.Proxy.GetDepartment(q.Department),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            };

            labelTmp.Click += (object sender, EventArgs e) =>
            {
                action();
            };

            panel.Controls.Add(labelTmp, 2, count);

            labelTmp = new Label()
            {
                Text = q.Date.ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            };

            labelTmp.Click += (object sender, EventArgs e) =>
            {
                action();
            };

            panel.Controls.Add(labelTmp, 3, count);
        }
    }


    public interface IStatusPanel
    {
        void AssignedMyTT(Tickets form, Ticket ticket);
        void AssignedOthTT(Tickets form, Ticket ticket);
        void NewTT(Tickets form, Ticket ticket);
    }

    public class StatusPanelFactory
    {
        public static IStatusPanel GetStatusPanelController(TicketStatus status)
        {
            switch (status)
            {
                case TicketStatus.UNASSIGNED:
                    return new UnassignedStautsPanel();
                case TicketStatus.ASSIGNED:
                case TicketStatus.WAITING:
                case TicketStatus.CLOSED:
                    return new DoNothingStatusPanel();
            }
            return null;
        }
    }

    public class UnassignedStautsPanel : IStatusPanel
    {
        // Reload current panel
        public void AssignedMyTT(Tickets form, Ticket ticket)
        {
            form.CreateTable(TicketStatus.UNASSIGNED);
        }

        // Reload current panel
        public void AssignedOthTT(Tickets form, Ticket ticket)
        {
            form.CreateTable(TicketStatus.UNASSIGNED);
        }

        // Add new ticket to current panel or load new panel
        public void NewTT(Tickets form, Ticket ticket)
        {
            if (form.Panel == null || form.Panel.RowCount == 0)
            {
                form.CreateTable(TicketStatus.UNASSIGNED);
            }
            else
            {
                IPanelRow panelRow = new TicketPanelRowImpl();
                float value = 100 / (form.ClientInstance.TroubleTickets.UnassignedTroubleTickets.Count + 1);
                panelRow.AddPanelRow(form.Panel, value, ticket, () => { form.TicketClickAction(ticket); });
            }
        }
    }

    public class DoNothingStatusPanel : IStatusPanel
    {
        // Do nothing
        public void AssignedMyTT(Tickets form, Ticket ticket)
        { }

        // Do nothing
        public void AssignedOthTT(Tickets form, Ticket ticket)
        { }

        // Do nothing
        public void NewTT(Tickets form, Ticket ticket)
        { }
    }


    public interface IQuestionStatusPanel
    {
        void AnsweredQuestion(Questions form, SecondaryQuestion secondaryQuestion, Ticket ticket);
    }


    public class QuestionStatusPanelFactory
    {
        public static IQuestionStatusPanel GetStatusPanelController(bool isOpen)
        {
            if (isOpen)
            {
                return new DoNothingQuestionStatusPanel();
            }
            else
            {
                return new ClosedQuestionStatusPanel();
            }
        }
    }
    public class ClosedQuestionStatusPanel : IQuestionStatusPanel
    {
        // Add new closed question or create new panel
        public void AnsweredQuestion(Questions form, SecondaryQuestion secondaryQuestion, Ticket ticket)
        {
            if (form.Panel == null || form.Panel.RowCount == 0)
            {
                form.CreateTable(false);
            }
            else
            {
                IPanelRow panelRow = new QuestionPanelRowImpl();
                float value = 100 / (form.ClientInstance.TroubleTickets.UnassignedTroubleTickets.Count + 1);
                panelRow.AddPanelRow(form.Panel, value, secondaryQuestion, () => { form.QuestionClickAction(secondaryQuestion); });
            }
        }
    }

    public class DoNothingQuestionStatusPanel : IQuestionStatusPanel
    {
        // Do nothing
        public void AnsweredQuestion(Questions form, SecondaryQuestion secondaryQuestion, Ticket ticket)
        {}
    }
}