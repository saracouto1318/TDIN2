<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ticket.aspx.cs" Inherits="Ticket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
            <title>Ticket</title>
        <link href="~/Content/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

        <!-- Custom Fonts -->
        <link href="~/Content/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
        <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,700,300italic,400italic,700italic" rel="stylesheet" type="text/css" />
        <link href="~/Content/vendor/simple-line-icons/css/simple-line-icons.css" rel="stylesheet" />


        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

        <link href="~/Content/css/profile.css" rel="stylesheet" />
    </head>
    <body>
    <div class="wrapper">
        <div class="modal-dialog modal-login">
            <div class="modal-content col-md-18">
                <div class='profile-sidebar'>
                    <div class='profile-usertitle'>
                        <form method="POST" action="Ticket.aspx" role="form" runat="server">
                        <div runat="server" id="title" class='profile-usertitle-name'>Ticket Title</div>
                            <br />
                        <div runat="server" id="date" class='profile-usertitle-email'>Date</div>
                        <div runat="server" id="status"  class='profile-usertitle-email'>Status</div>
                        <br />
                        <div runat="server" id="description" class='profile-usertitle-email'>Ticket Description</div>
                            <a id="logout" class='btn btn-danger btn-sm'>Logout</a>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
        <div class="footer push">
            <span class="copyright">Copyright &copy; 2018</span>
        </div>

   
        <script src="Content/vendor/jquery/jquery.min.js"></script>
        <script src="Content/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <!-- Plugin JavaScript -->
        <script src="Content/vendor/jquery-easing/jquery.easing.min.js"></script>

        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

        <script src="Content/js/profile.js"></script>
    </body>
</html>                            