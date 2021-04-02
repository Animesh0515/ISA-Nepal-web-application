<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="AdminPortal.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row" style="width:1000px; height: 500px">
            <div class="card" style="width: 400px; height: 400px;">
                <div class="row" style="padding-left: 20px">
                    &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Style="padding-top: 20px" Text=""></asp:Label>
                    <br />
                    <%--<asp:Label ID="Label2" runat="server" style="padding-top:20px" Text="Head Coach" ></asp:Label>--%>
                    <div style="padding-left: 130px; padding-top: 20px">
                        <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" ImageUrl='images/profile.png' />
                    </div>

                    <%--<img src="images/profile.png"  style="height:200px; width:350px; padding-left:200px; "/>--%>
                </div>
                <div class="card-body">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Button ID="btnrmvpic" runat="server" CssClass="btn-danger" Text="Remove picture" Width="127px" />

                    &nbsp;&nbsp;
      <br />
                    <asp:Button ID="btnsave" class="btn-primary" runat="server" Text="Save" Width="127px" OnClick="btnsave_Click" />

                    &nbsp;&nbsp;

      <asp:FileUpload ID="FileImagesave" class="btn-outline-primary" runat="server" Width="212px" />
                    <asp:Literal ID="ltsave" runat="server"></asp:Literal>





                </div>
            </div>
            <div>
                <div class="card" style="width: 500px; height: 450px; left: 62px; top: 0px;">
                    <div class="card-header">
                        General Profile
                    </div>
                    <div class="card-body">
                        <asp:Label ID="Label2" runat="server" Text="First Name"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Last Name"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtfirstname" runat="server" Width="127px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtlastname" runat="server" Width="146px"></asp:TextBox>
                        &nbsp;
                        <asp:TextBox ID="txtemail" runat="server" Width="146px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Phone Number"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label6" runat="server" Text="Date of Birth"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label7" runat="server" Text="Username"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtphoneno" runat="server" Width="127px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtdob" runat="server" Width="146px"></asp:TextBox>
                        &nbsp;
                        <asp:TextBox ID="txtusername" runat="server" Width="146px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label8" runat="server" Text="Gender"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label9" runat="server" Text="Age"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Label ID="Label10" runat="server" Text="Joined Date"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtgender" runat="server" Width="127px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtage" runat="server" Width="146px"></asp:TextBox>
                        &nbsp;
                        <asp:TextBox ID="txtjoineddate" runat="server" Width="146px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label11" runat="server" Text="Address"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label12" runat="server" Text="Password"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtaddress" runat="server" Width="224px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtpassword" runat="server" Width="208px"></asp:TextBox>
                    </div>
                    <div class="card-footer text-muted">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btncancel" class="btn btn-danger" runat="server" Text="Cancel" />
                        <asp:Button ID="btnedit" class="btn btn-success" runat="server" Text="Edit" style="width: 87px" OnClick="btnedit_Click" />


                        <%--<a href="#" class="btn btn-danger" id="btncancel" >Cancel</a>--%>

                        <%--<a href="#" class="btn btn-success" style="width: 87px"  >Edit</a>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
