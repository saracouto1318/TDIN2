using System;
using System.Drawing;
using System.Web.UI;
using TTSvc;

public partial class _Default : Page {
  TTServClient proxy;

  protected void Page_Load(object sender, EventArgs e) {
    proxy = new TTServClient();
  }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        string email = String.Format("{0}", Request.Form["email"]);
        string password = String.Format("{0}", Request.Form["password"]);

        /*if(proxy.CheckUser(email))
            Response.Redirect("ProfilePage.aspx");*/
    }

    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        string name = String.Format("{0}", Request.Form["name"]);
        string email = String.Format("{0}", Request.Form["emailRegister"]);
        string password = String.Format("{0}", Request.Form["passwordRegister"]);

        TTService.User user = new TTService.User
        {
            Name = name,
            Email = email,
            Password = password
        };

        /*if (proxy.AddUser(user) != 0)
            Response.Redirect("ProfilePage.aspx");*/
    }
    
}