<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>TDIN</title>
        <link href="~/Content/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>

        <!-- Custom Fonts -->
        <link href="~/Content/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
        <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,700,300italic,400italic,700italic" rel="stylesheet" type="text/css"/>
        <link href="~/Content/vendor/simple-line-icons/css/simple-line-icons.css" rel="stylesheet"/>

        <!-- Custom CSS -->
        <link href="~/Content/css/home.css" rel="stylesheet"/>
        <link href="~/Content/css/authentication.css" rel="stylesheet"/>
    </head>
    <body id="page-top">
        <div id="page">
        <!-- Header -->
            <header class="masthead d-flex">
                <div class="container text-center my-auto">
                <h1 class="mb-1">IT Trouble Tickets</h1>
                <h3 class="mb-5">
                    <em>Submit here your trouble tickets</em>
                </h3>
                    <form runat="server" novalidate="novalidate">
                <asp:Button ID="loginDiv" runat="server" Class="btn btn-primary btn-xl js-scroll-trigger" Text="Sign In" OnClick="BtnRedirect_Click"/>
                        </form>
                </div>
                <div class="overlay"></div>
            </header>
      </div>
       <!-- Footer -->
        <div class="footer push">
            <span class="copyright">Copyright &copy; 2018</span>
        </div>
    
  </body>

</html>