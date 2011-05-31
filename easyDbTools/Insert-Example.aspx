<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Insert-Example.aspx.cs" Inherits="easyDbTools.Insert_Example" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Insert Example</h1>

<asp:Button runat="server" ID="btnInsert" Text="Add Random Record" onclick="btnInsert_Click" />

<hr />

<div runat="server" id="divForm">

    name <asp:TextBox runat="server" ID="txtname" /> <br />

    email <asp:TextBox runat="server" ID="txtemail" /> <br />

    age <asp:TextBox runat="server" ID="txtage" /> <br />

    <asp:Button Text="Add" runat="server" ID="add" onclick="add_Click" />

</div>



</asp:Content>
