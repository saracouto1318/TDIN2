using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTSvc;

public partial class ProfilePage : System.Web.UI.Page
{
    TTServClient proxy;
    TTService.User user;
    public TTService.Ticket[] tickets;
    protected void Page_Load(object sender, EventArgs e)
    {
        proxy = new TTServClient();

       /*String idString = Request.QueryString["id"];
       int id = Int32.Parse(idString);

        user = proxy.GetUser(id);
        /*divName.InnerHtml = user.name;
        divEmail.InnerHtml = user.email;

        loginUsername.Value = user.name;
        loginEmail.Value = user.email;
        loginPassword.Value = user.password;

        tickets = proxy.GetTickets(id);*/
    }

    protected void Edit_Click(object sender, EventArgs e) {
        string name = String.Format("{0}", Request.Form["loginUsername"]);
        string email = String.Format("{0}", Request.Form["loginEmail"]);
        string password = String.Format("{0}", Request.Form["loginPassword"]);

        user.Name = name;
        user.Email = email;
        user.Password = password;

        //proxy.UpdateUser(user);
    }

    protected void Create_Click(object sender, EventArgs e)
    {
        string title = String.Format("{0}", Request.Form["title"]);
        string description = String.Format("{0}", Request.Form["description"]);

        TTService.Ticket ticket = new TTService.Ticket
        {
            Title = title,
            Description = description,
            Author = user,
            Status = TTService.TicketStatus.UNASSIGNED
        };

        //proxy.AddTicket(ticket);
    }

    protected void All_Click(object sender, EventArgs e)
    {
        //tickets = proxy.GetTicketsByType(user.ID, "all");
    }

    protected void Open_Click(object sender, EventArgs e)
    {
        //tickets = proxy.GetTicketsByType(user.ID, "open");
    }

    protected void Close_Click(object sender, EventArgs e)
    {
        //tickets = proxy.GetTicketsByType(user.ID, "close");
    }
    
}