<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Authentication.aspx.cs" Inherits="Authentication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Authentication</title>
            <link href="~/Content/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

        <!-- Custom Fonts -->
            <link href="~/Content/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
            <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,700,300italic,400italic,700italic" rel="stylesheet" type="text/css" />
            <link href="~/Content/vendor/simple-line-icons/css/simple-line-icons.css" rel="stylesheet" />

        <!-- Custom CSS -->
            <link href="~/Content/css/home.css" rel="stylesheet" />
            <link href="~/Content/css/authentication.css" rel="stylesheet" />
    </head>
    <body id="page-top">
         <form runat="server" novalidate="novalidate">
            <div id="loginBody">
                <div id="login" class="modal-dialog modal-login">
                    <div class="modal-content login">
                        <div class="modal-header">
                            <h4 class="modal-title">Login</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <i class="fa fa-user"></i>
                                <input class="form-control" name="email" placeholder="Email" required="required" type="email" />
                            </div>
                            <div class="form-group">
                                <i class="fa fa-lock"></i>
                                <input class="form-control" name="password" placeholder="Password" required="required" type="password" />
                            </div>
                            <div class="form-group">
                                <asp:Button ID="Button1" runat="server" Class="btn btn-primary btn-block btn-lg" OnClick="BtnLogin_Click" Text="Login" />
                            </div>
                        </div>
                        <p id="loginError" runat="server" class="error">
                            This user isn&#39;t registered</p>
                    </div>
                </div>
                <div id="register" class="modal-dialog modal-login">
                    <div class="modal-content register">
                        <div class="modal-header">
                            <h4 class="modal-title">Register</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <i class="fa fa-user"></i>
                                <input class="form-control" name="name" placeholder="Name" required="required" type="text" />
                            </div>
                            <div class="form-group">
                                <i class="fa fa-envelope"></i>
                                <input class="form-control" name="emailRegister" placeholder="Email" required="required" type="email" />
                            </div>
                            <div class="form-group">
                                <i class="fa fa-lock"></i>
                                <input class="form-control" name="passwordRegister" placeholder="Password" required="required" type="password" />
                            </div>
                            <div class="form-group">
                                <asp:Button ID="Button2" runat="server" Class="btn btn-primary btn-block btn-lg" OnClick="BtnRegister_Click" Text="Register" />
                            </div>
                        </div>
                        <p id="registerError" runat="server" class="error">
                            This user already exists</p>
                    </div>
                </div>
            </div>
       <!-- Footer -->
            <div class="footer push">
                <span class="copyright">Copyright © 2018</span>
            </div>
    </form>
</body>
</html>
