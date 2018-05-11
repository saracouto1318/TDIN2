using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using TTService;
using TTSvc;

public partial class _ProfilePage : Page
{
    TTServClient proxy;
    User user;
    public TTService.Ticket[] tickets;
    protected void Page_Load(object sender, EventArgs e)
    {
        proxy = new TTServClient();

       String idString = Request.QueryString["id"];
       int id = Int32.Parse(idString);

        user = proxy.GetUser(id);
        divName.InnerHtml = user.Name;
        divEmail.InnerHtml = user.Email;

        loginUsername.Value = user.Name;
        loginEmail.Value = user.Email;
        loginPassword.Value = user.Password;

        tickets = proxy.GetTickets(user);
    }

    protected void Edit_Click(object sender, EventArgs e) {
        string name = String.Format("{0}", Request.Form["loginUsername"]);
        string email = String.Format("{0}", Request.Form["loginEmail"]);
        string password = String.Format("{0}", Request.Form["loginPassword"]);

        user.Name = name;
        user.Email = email;
        user.Password = password;

        if(proxy.UpdateUser(name, email, password, user.ID))
            Response.Redirect("ProfilePage.aspx?id=" + user.ID.ToString());
    }

    protected void Create_Click(object sender, EventArgs e)
    {
        string title = String.Format("{0}", Request.Form["title"]);
        string description = String.Format("{0}", Request.Form["description"]);

        if(proxy.AddTicket(user.ID, title, description))
            Response.Redirect("ProfilePage.aspx?id=" + user.ID.ToString());
    }

    protected void All_Click(object sender, EventArgs e)
    {
        tickets = proxy.GetTickets(user);
    }

    protected void Open_Click(object sender, EventArgs e)
    {
        TTService.Ticket[] assign = proxy.GetTicketsByType(user, TicketStatus.ASSIGNED);
        TTService.Ticket[] unassigned = proxy.GetTicketsByType(user, TicketStatus.UNASSIGNED);

        List<TTService.Ticket> list = assign.ToList();
        foreach (TTService.Ticket t in unassigned)
            list.Add(t);

        tickets = list.ToArray();
    }

    protected void Close_Click(object sender, EventArgs e)
    {
        tickets = proxy.GetTicketsByType(user, TicketStatus.CLOSED);
    }
    
}