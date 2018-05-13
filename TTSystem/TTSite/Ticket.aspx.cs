using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTSvc;
public partial class Ticket : System.Web.UI.Page
{
    TTServClient proxy;
    TTService.User user;
    TTService.Ticket ticket;
    protected void Page_Load(object sender, EventArgs e)
    {
        proxy = new TTServClient();

        String idString = Request.QueryString["id"];
        int id = Int32.Parse(idString);

        String ticketID = Request.QueryString["ticket"];
        int idTicket = Int32.Parse(ticketID);

        user = proxy.GetUser(id);
        ticket = proxy.GetTicket(idTicket);

        title.InnerText = ticket.Title;
        date.InnerText = ticket.Date.ToString();
        description.InnerText = ticket.Description;
        status.InnerText = ticket.Status.ToString();
    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        proxy.Logout(user.ID);
        Response.Redirect("Default.aspx");
    }
}