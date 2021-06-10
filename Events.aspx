﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="AdminPortal.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 1878px;
            max-width: 1140px;
            min-width: 992px;
            margin-left: auto;
            margin-right: auto;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div class="auto-style1">
        <asp:Label ID="Label1" font-size="XX-Large" Font-name="serif" runat="server" Text="Calendar" ></asp:Label>
        <div class="row">
            <div>
        <asp:GridView ID="dgvCalendarevents" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="638px"  OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" Height="189px" AutoGenerateColumns="False" DataKeyNames="ID">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Day" HeaderText="Day" />
                <asp:BoundField DataField="Time" HeaderText="Time" />
                <asp:BoundField DataField="Venue" HeaderText="Venue" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
                </div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div class="card" style="height:250px">
                <div class="card-header">
                   
                    ADD EVENTS
                </div>
                <div class="card-body">
                    <asp:Label ID="Label2" runat="server" Text="Day">
                    </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Label ID="Label3" runat="server" Text="Time">
                    </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <br />
                    <asp:DropDownList ID="ddlday" runat="server" Width="107px">
                             <asp:ListItem Text="Sunday" Value="Sunday" />
                             <asp:ListItem Text="Monday" Value="Monday" />
                             <asp:ListItem Text="Tuesday" Value="Tuesday" />
                             <asp:ListItem Text="Wednesday" Value="Wednesday" />
                             <asp:ListItem Text="Thursday" Value="Thursday" />
                             <asp:ListItem Text="Friday" Value="Friday" />
                             <asp:ListItem Text="Saturday" Value="Saturday" />


                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtTime" runat="server" Width="123px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;<br />
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Venue"></asp:Label>
                    <br />
&nbsp;<asp:TextBox ID="txtVenue" runat="server" Width="123px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnsaved" class="btn btn-success" runat="server" Text="Save" style="width: 87px" OnClick="btnsaved_Click"   />
                    
                    <br />
                    <br />
                   </div>
            </div>
            </div>
          
        <br />
        <br />
        <asp:Label ID="Label5" font-size="XX-Large" Font-name="serif" runat="server" Text="Court Booking Time" ></asp:Label>

       <div class="row">   
    <asp:GridView ID="dgvBookingevents" runat="server" Width="566px" OnRowDataBound="OnRowDataBound1" OnRowEditing="OnRowEditing1" OnRowCancelingEdit="OnRowCancelingEdit1" OnRowUpdating="OnRowUpdating1" OnRowDeleting="OnRowDeleting1" EmptyDataText="No records has been added." AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ID">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
</asp:GridView>

         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div class="card" style="height:150px">
                <div class="card-header">
                   
                    ADD TIME
                </div>
                <div class="card-body">
                    <asp:Label ID="Label6" runat="server" Text="Time">
                    </asp:Label>
                    <br />
                    <asp:TextBox ID="txtbookingTime" runat="server" Width="123px"></asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnSaveTime" class="btn btn-success" runat="server" Text="Save" style="width: 87px" OnClick="btnSaveTime_Click"    />
                    </div>
             </div>
    </div>
        </div>
  
</asp:Content>