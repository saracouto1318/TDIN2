using System;
using System.Drawing;
using System.Web.UI;
using TTService;
using TTSvc;

public partial class _Default : Page {

  protected void Page_Load(object sender, EventArgs e) {
  }

    
    protected void BtnRedirect_Click(object sender, EventArgs e)
    {
        Response.Redirect("Authentication.aspx");
    }

}