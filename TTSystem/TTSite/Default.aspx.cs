using System;
using System.Drawing;
using System.Web.UI;
using TTService;
using TTSvc;

public partial class _Default : Page {
    TTServClient proxy;
    public User user;

  protected void Page_Load(object sender, EventArgs e) {
    proxy = new TTServClient();
    user = new User();
  }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        string email = String.Format("{0}", Request.Form["email"]);
        string password = String.Format("{0}", Request.Form["password"]);

        if(proxy.CheckUser(email, password))
        {
            this.user = proxy.GetUserByEmail(email);
            proxy.Login(this.user.ID);
            Response.Redirect("ProfilePage.aspx?id=" + this.user.ID.ToString());
        }
            
    }

    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        string name = String.Format("{0}", Request.Form["name"]);
        string email = String.Format("{0}", Request.Form["emailRegister"]);
        string password = String.Format("{0}", Request.Form["passwordRegister"]);

        if (proxy.AddUser(name, email, password))
        {
            this.user = proxy.GetUserByEmail(email);
            if(proxy.Login(this.user.ID))
                Response.Redirect("ProfilePage.aspx?id="+this.user.ID.ToString());
        }
    }
    
}