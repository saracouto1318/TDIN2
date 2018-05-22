<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfilePage.aspx.cs" Inherits="_ProfilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
            <title>Profile</title>
        <link rel="shortcut icon" href="~/Content/img/ticket-icon.png" />
        <link href="~/Content/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>

        <!-- Custom Fonts -->
        <link href="~/Content/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
        <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,700,300italic,400italic,700italic" rel="stylesheet" type="text/css"/>
        <link href="~/Content/vendor/simple-line-icons/css/simple-line-icons.css" rel="stylesheet"/>


        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

        <link href="~/Content/css/profile.css" rel="stylesheet"/>
        <link href="~/Content/css/table.css" rel="stylesheet"/>
        <script type="text/javascript">
       function Redirect(id, ticket)
       {
        location.href="Ticket.aspx?id=" + id + "&ticket=" + ticket;
       }
    </script>
    </head>
    <body>

        <div class="wrapper">
        <form class="form-horizontal" runat="server" novalidate="novalidate">  
        <div class="modal-dialog modal-login">
            <div class="modal-content">
                <div class='profile-usertitle'>
                    <div id="divName" runat="server" class='profile-usertitle-name'>
                        <label>Name:</label>Name</div>
                    <div id="divEmail" runat="server" class='profile-usertitle-email'>Email</div>
                </div>
                <div class='profile-userbuttons'>
                    <a id="edit" class='btn btn-success btn-sm'>Edit Profile</a>
                    <a id="my" class='btn btn-primary btn-sm'>My Trouble Tickets</a>
                    <a id="new" class='btn btn-info btn-sm'>New Trouble Ticket</a>
                    <asp:Button ID="Logout" runat="server" Class="btn btn-danger btn-sm" Text="Logout" OnClick="Logout_Click"/>
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
            <div class="form-group">
             <asp:Button runat="server" ID="createTicket" Class="btn btn-success btn-sm" Text="Create" OnClick="Create_Click"/>
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
            <div class="form-group">
            <asp:Button runat="server" ID="editForm" Class="btn btn-success btn-sm" Text="Edit" OnClick="Edit_Click"/>
 </div>
            </div>
     </div>
     <div id="myTickets"class="modal-dialog modal-login">
        <div class="modal-content">
            <h3>My Trouble Tickets</h3>
            <br />
            <div class='profile-userbuttons'>
                <asp:Button ID="allTicket" runat="server" Class="btn btn-success btn-sm" Text="All" OnClick="All_Click"/>
                <asp:Button ID="openTicket" runat="server" Class="btn btn-danger btn-sm" Text="Open" OnClick="Open_Click"/>
                <asp:Button ID="closeTicket" runat="server" Class="btn btn-warning btn-sm" Text="Closed" OnClick="Close_Click"/>
            </div>
            <div class="table-responsive">
                <% if(tickets.Length > 0) { %>
                <table id="example" class="table table-striped table-bordered" style="width:100%">
                    <thead>
                        <tr >
                            <th>#</th>
                            <th>Title</th>
                            <th>Date</th>
                            <th>Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        <% foreach(TTService.Ticket ticket in tickets) { %>
                            <%
                                if(ticket.Status == TTService.TicketStatus.CLOSED)
                                {%><tr class="success" onclick="Redirect(<%: user.ID %>,<%: ticket.ID %>);"><% }
                                else if(ticket.Status == TTService.TicketStatus.ASSIGNED)
                                {%><tr class="warning" onclick="Redirect(<%: user.ID %>,<%: ticket.ID %>);"><% } 
                                else {%><tr class="danger" onclick="Redirect(<%: user.ID %>,<%: ticket.ID %>);"><% }
                            %>
                            <td><%: ticket.ID %></td>
                            <td><%: ticket.Title %></td>
                            <td><%: ticket.Date.ToString() %></td>
                            <td style="font-weight: bold"><%: ticket.Status.ToString() %></td>
                        </tr>
                        <% } %>
                        
                    </tbody>
                </table>
                <% } else { %>
                <p class="noTicket">You don't have any tickets</p>
                <% } %>
            </div>
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
         <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
        <script src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js"></script>
        <script src="https://cdn.datatables.net/1.10.16/js/dataTables.bootstrap.min.js"></script>
    </body>
</html>
