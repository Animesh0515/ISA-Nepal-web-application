<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bookings.aspx.cs" Inherits="AdminPortal.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container">
        <div class="row align-items-start">
            <div class="col">
                <asp:GridView ID="dgvcourtbooking" runat="server"></asp:GridView>

            </div>
            <div class="col">
                <asp:GridView ID="dgvtrainingbooking" runat="server"></asp:GridView>

            </div>




        </div>
</asp:Content>
