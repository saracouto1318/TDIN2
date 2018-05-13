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
                <h1 class="mb-1">TDIN</h1>
                <h3 class="mb-5">
                    <em>Tecnologias de Distribuição e Integração</em>
                </h3>
                <button id="loginDiv" class="btn btn-primary btn-xl js-scroll-trigger">Sign In</button>
                </div>
                <div class="overlay"></div>
            </header>
      </div>

      <div id="loginBody">
        <form method="POST" action="Default.aspx" runat="server" novalidate="novalidate">
          <div id="login" class="modal-dialog modal-login">
            <div class="modal-content">
              <div class="modal-header">			
                <h4 class="modal-title">Login</h4>
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
              </div>
              <div class="modal-body">
                  <div class="form-group">
                    <i class="fa fa-user"></i>
                    <input name="email" type="email" class="form-control" placeholder="Email" required="required"/>
                  </div>
                  <div class="form-group">
                    <i class="fa fa-lock"></i>
                    <input type="password" name="password" class="form-control" placeholder="Password" required="required"/>					
                  </div>
                  <div class="form-group">
                    <asp:Button runat="server" Class="btn btn-primary btn-block btn-lg" Text="Login" OnClick="BtnLogin_Click"/>
                  </div>		
              </div>
              <p class="error" id="loginError" runat="server">This user isn't registered</p>
              <div class="modal-footer account">
                <a id="create" href="#register">Create Account</a>
              </div>
            </div>
          </div>
          <div id="register" class="modal-dialog modal-login">
            <div class="modal-content register">
              <div class="modal-header">				
                <h4 class="modal-title">Register</h4>
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
              </div>
              <div class="modal-body">
                 <div class="form-group">
                   <i class="fa fa-user"></i>
                   <input name="name" type="text" class="form-control" placeholder="Name" required="required"/>
                 </div>
                 <div class="form-group">
                   <i class="fa fa-envelope"></i>
                   <input name="emailRegister" type="email" class="form-control" placeholder="Email" required="required"/>
                 </div>
                 <div class="form-group">
                   <i class="fa fa-lock"></i>
                   <input name="passwordRegister" type="password" class="form-control" placeholder="Password" required="required"/>					
                 </div>
                 <div class="form-group">
                   <asp:Button runat="server" Class="btn btn-primary btn-block btn-lg" Text="Register" OnClick="BtnRegister_Click"/>
                 </div>			
              </div>
              <p class="error" id="registerError" runat="server">This user already exists</p>
              <div class="modal-footer">
                <a id="signin" href="#login">Login</a>
              </div>           
           </div>
         </div>        
        </form>	
          </div>
       <!-- Footer -->
        <div class="footer push">
            <span class="copyright">Copyright &copy; 2018</span>
        </div>


        <!-- Bootstrap core JavaScript -->
        <script src="Content/vendor/jquery/jquery.min.js"></script>
        <script src="Content/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <!-- Plugin JavaScript -->
        <script src="Content/vendor/jquery-easing/jquery.easing.min.js"></script>

        <script src="Content/js/authentication.js"></script>
    
  </body>

</html>