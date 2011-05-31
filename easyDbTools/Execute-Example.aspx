<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Execute-Example.aspx.cs" Inherits="easyDbTools.Execute_Example" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Execute Example</h1>

    Sql Query <asp:TextBox runat="server" ID="txtSql" Width="400" Text="Select * from testTable" />
    <asp:Button Text="Execute" runat="server" ID="btnExecute" onclick="btnExecute_Click" />
    <br />
    <asp:Label runat="server" ID="lblstatus" />

</asp:Content>
