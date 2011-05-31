<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CacheManager-Example.aspx.cs" Inherits="easyDbTools.CacheManager_Example" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Cache Manager Example</h1>
       
    <asp:DropDownList runat="server" ID="ddl" />
    <asp:Button Text="Delete" runat="server" ID="btnDelete" onclick="btnDelete_Click" />
    <asp:Button Text="Delete All" runat="server" ID="btnDeleteAll" onclick="btnDeleteAll_Click" />
    <br />
    <a href="DataTableCache-Example.aspx">Ön Belleği Doldur</a>

</asp:Content>