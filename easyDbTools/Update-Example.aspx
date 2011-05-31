<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Update-Example.aspx.cs" Inherits="easyDbTools.Update_Example" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Update Example</h1>

<div runat="server" id="divForm">

    name <asp:TextBox runat="server" ID="txtname" /> <br />

    email <asp:TextBox runat="server" ID="txtemail" /> <br />

    <asp:Button Text="Update" runat="server" ID="Update" onclick="Update_Click" />

</div>

</asp:Content>
