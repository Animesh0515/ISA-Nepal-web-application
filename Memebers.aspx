﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Memebers.aspx.cs" Inherits="AdminPortal.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-15" >

                <div class="form-group">
                    &nbsp;&nbsp;&nbsp;
                    Enter First Name or Last Name or Username<br />
                    
                    <div class="row">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox CssClass="auto-style2" ID="txtsearch" runat="server" placeholder="Search" Width="257px"></asp:TextBox>

                        &nbsp;&nbsp;&nbsp;&nbsp;

                        <asp:Button ID="btnAdd" class="btn btn-lg btn-block btn-danger" runat="server" Text="Search" Style="padding-left: 20px; text-align: center; font-size: 1.15rem; line-height: 1;"  Width="100px" OnClick="btnAdd_Click" />

                        <br />
                        </div>
                        <%--<asp:RequiredFieldValidator runat="server" ID="RFVCustomerName" ControlToValidate="txtcustomername" ErrorMessage="Please Enter the Customer Name" style="color: red; visibility: visible; font-size:small"/>--%>
                                                               
                </div>
               

                 
                </div>
               
            
        </div>
        <div>
        <asp:GridView ID="dgvmemebers" runat="server"  OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" DataKeyNames="UserId" Width="1230px" Height="207px"></asp:GridView>
    </div>
        </div>
</asp:Content>
