<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfilePage.aspx.cs" Inherits="ProfilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
            <title>Profile</title>
        <link href="~/Content/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>

        <!-- Custom Fonts -->
        <link href="~/Content/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
        <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,700,300italic,400italic,700italic" rel="stylesheet" type="text/css"/>
        <link href="~/Content/vendor/simple-line-icons/css/simple-line-icons.css" rel="stylesheet"/>


        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

        <link href="~/Content/css/profile.css" rel="stylesheet"/>
    </head>
    <body>
        <div class="wrapper">
        <form method="POST" action="ProfilePage.aspx" class="form-horizontal" runat="server">
            
        <div class="modal-dialog modal-login">
            <div class="modal-content">
                <div class='profile-usertitle'>
                    <div id="divName" runat="server" class='profile-usertitle-name'>Name</div>
                    <div id="divEmail" runat="server" class='profile-usertitle-email'>Email</div>
                </div>
                <div class='profile-userbuttons'>
                    <a id="edit" class='btn btn-success btn-sm'>Edit Profile</a>
                    <a id="my" class='btn btn-primary btn-sm'>My Trouble Tickets</a>
                    <a id="new" class='btn btn-info btn-sm'>New Trouble Ticket</a>
                </div>
            </div>
        </div>
       <div id="editProfile" class="modal-dialog modal-login">
        <div class="modal-content">
            <h3>Edit Profile</h3>
            <br />
                <div style="margin-bottom: 25px" class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                    <input runat="server" id="loginUsername" type="text" class="form-control" name="name" value="" placeholder="Name" />                                        
                </div>
                <div style="margin-bottom: 25px" class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>
                    <input runat="server" id="loginEmail" type="text" class="form-control" name="email" value="" placeholder="Email" />                                        
                </div>
                <div style="margin-bottom: 25px" class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                    <input runat="server" id="loginPassword" type="password" class="form-control" name="password" placeholder="Password" />
                </div>
            <asp:Button ID="editForm" runat="server" Class="btn btn-success btn-sm" Text="Edit" OnClick="Edit_Click"/>
        </div>
     </div>
     <div id="myTickets"class="modal-dialog modal-login">
        <div class="modal-content">
            <h3>My Trouble Tickets</h3>
            <br />
            <div class='profile-userbuttons'>
                <asp:Button ID="allTicket" runat="server" Class="btn btn-success btn-sm" Text="All" OnClick="All_Click"/>
                <asp:Button ID="openTicket" runat="server" Class="btn btn-danger btn-sm" Text="Open" OnClick="Open_Click"/>
                <asp:Button ID="closeTicket" runat="server" Class="btn btn-warning btn-sm" Text="Close" OnClick="Close_Click"/>
            </div>
            <div class="table-responsive">
                <table class="table">
                    <thead>
                        <tr >
                            <th>#</th>
                            <th>Title</th>
                            <th>Description</th>
                            <th>Date</th>
                            <th>Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        <% foreach(TTService.Ticket ticket in tickets) { %>
                            <%
                                if(ticket.Status != TTService.TicketStatus.CLOSED)
                                {%><tr class="danger"><% } 
                                else {%><tr class="success"><% } 
                            %>

                            <td><%: ticket.Title %></td>
                            <td><%: ticket.Description %></td>
                            <td><%: ticket.Date.ToString() %></td>
                            <td><%: ticket.Status.ToString() %></td>
                        </tr>
                        <% } //foreach %>
                        
                    </tbody>
                </table>
            </div>
        </div>
      </div>
      <div id="newTickets" class="modal-dialog modal-login">
        <div class="modal-content">
            <h3>New Trouble Ticket</h3>
            <br />
            <div style="margin-bottom: 25px" class="input-group">
                <span class="input-group-addon"><i class="glyphicon glyphicon-pencil"></i></span>
                <input id="title" type="text" class="form-control" name="title" value="" placeholder="Title" />                                        
            </div>
            <div style="margin-bottom: 25px" class="input-group">
                <textarea id="description" class="form-control" name="description" rows="10" placeholder="Description"></textarea>                                        
            </div>
            <asp:Button ID="createTicket" runat="server" Class="btn btn-success btn-sm" Text="Create" OnClick="Create_Click"/>
        </div>
      </div>
            </form> 
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
