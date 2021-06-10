<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberProfile.aspx.cs" Inherits="AdminPortal.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row" style="width:1000px; height: 500px">
            <div class="card" style="width: 400px; height: 400px;">
                <div class="row" style="padding-left: 20px">
                    &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Style="padding-top: 20px" Text="" Font-Bold="True" Size="40" ></asp:Label>
                    <div style="padding-left: 110px; padding-top: 20px">
                        <asp:Image ID="imgadm" runat="server" Height="200px" Width="200px" />
                    </div>

                    <%--<img src="images/profile.png"  style="height:200px; width:350px; padding-left:200px; "/>--%>
                </div>
                <div class="card-body">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      
                    &nbsp;&nbsp;
      <br />

                    &nbsp;&nbsp;

      



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
                        <br />
                        <asp:TextBox ID="addresstxt" runat="server" Width="224px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        </div>
                    <div class="card-footer text-muted">
                        <asp:Button ID="btnedit" class="btn btn-warning" runat="server" Text="Edit" style="width: 87px" OnClick="btnedit_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btncancel" class="btn btn-danger" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                        <asp:Button ID="btnsaved" class="btn btn-success" runat="server" Text="Save" style="width: 87px" OnClick="btnsaved_Click"  />



                        <%--<a href="#" class="btn btn-danger" id="btncancel" >Cancel</a>--%>

                        <%--<a href="#" class="btn btn-success" style="width: 87px"  >Edit</a>--%>
                    </div>
                </div>
            </div>
            </div>
    </div>
</asp:Content>
