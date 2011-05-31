<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DataTableCache-Example.aspx.cs" Inherits="easyDbTools.DataTableCache_Example" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>DataTable Cache Example</h1>


<asp:GridView runat="server" ID="gv" />

<br />
<a href="CacheManager-Example.aspx">Ön Bellek</a>

</asp:Content>