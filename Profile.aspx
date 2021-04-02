<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="AdminPortal.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        
        <div class="card" style="width:400px">
            <div class="row" style="padding-left:20px">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" style="padding-top:20px" Text="Nikesh Rai" ></asp:Label>
                <br />
            <%--<asp:Label ID="Label2" runat="server" style="padding-top:20px" Text="Head Coach" ></asp:Label>--%>
                <div style="padding-left:130px; padding-top:20px">
            <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" ImageUrl='images/profile.png'  />
                    </div>
             
            <%--<img src="images/profile.png"  style="height:200px; width:350px; padding-left:200px; "/>--%>
                </div>
  <div class="card-body">
      <asp:Button ID="Button2" runat="server" Text="Upload picture" Width="175px"/>
      <asp:Button ID="Button1" runat="server" Text="Remove picture" Width="174px" />

    <div class="row">

    </div>
  </div>
</div>
    </div>
    
</asp:Content>
