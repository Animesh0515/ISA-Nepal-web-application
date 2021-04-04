<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AdminPortal.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <%--jquery--%>
    <script src="bootstrap/js/jquery-3.3.1.slim.min.js"></script>
    <%--popper js--%>
    <script src="bootstrap/js/popper.min.js"></script>
    <%--bootstrap js--%>
    <script src="bootstrap/js/bootstrap.min.js"></script>

    <%--bootstrap css--%>    
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <%--datatable css--%>
    <link href="datatables/css/jquery.dataTables.min.css" rel="stylesheet" />
    <%--fontawesome css--%>
    <link href="fontawesome/css/all.css" rel="stylesheet" />

    <%--seetalert js--%>
    <script src="sweet%20alert/sweetalert2.all.js"></script>
    <script>
        function alertmsg() {
            Swal.fire({
                icon: 'error',
                title: 'Invalid username or password',
                text: 'User Not Found',

            })
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
      <div class="row" style="padding-top:20px">
         <div class="col-md-6 mx-auto">
            <div class="card" >
               <div class="card-body" >
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="150px" src="images/adminuser.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h3>Admin Login</h3>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>Username</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtadminid" runat="server" placeholder="Admin ID"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RFVAdminID" ControlToValidate="txtadminid" ErrorMessage="Please Enter the Username" style="color: red; visibility: visible; font-size:small"/>

                        </div>
                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtpassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RFVPassword" ControlToValidate="txtpassword" ErrorMessage="Please Enter the Password" style="color: red; visibility: visible; font-size:small"/>

                        </div>
                        <div class="form-group">
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click"  />
                        </div>
                     </div>
                  </div>
               </div>
            </div>
            
         </div>
      </div>
   </div>
    </form>
</body>
</html>
