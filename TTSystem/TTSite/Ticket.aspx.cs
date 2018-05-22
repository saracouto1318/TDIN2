using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTService;
using TTSvc;

public partial class _Ticket : Page
{
    private TTServClient proxy;
    private User user;
    private Ticket ticket;
    protected void Page_Load(object sender, EventArgs e)
    {
        proxy = new TTServClient();

        String idString = Request.QueryString["id"];
        int id = Int32.Parse(idString);

        String ticketID = Request.QueryString["ticket"];
        int idTicket = Int32.Parse(ticketID);

        user = proxy.GetUser(id);
        ticket = proxy.GetTicket(idTicket);

        title.InnerHtml = "<label class='labelProfile'>Ticket Title: </label>" + ticket.Title;
        date.InnerHtml = "<label class='labelProfile'>Ticket Date: </label>" + ticket.Date.ToString();
        description.InnerHtml = "<label class='labelProfile'>Ticket Description: </label>" + ticket.Description;
        status.InnerHtml = "<label class='labelProfile'>Ticket Status: </label>" + ticket.Status.ToString();
    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        proxy.Logout(user.ID);
        Response.Redirect("Default.aspx");
    }
    protected void Profile_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProfilePage.aspx?id=" + user.ID);
    }
}