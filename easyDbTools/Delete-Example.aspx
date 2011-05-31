<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Delete-Example.aspx.cs" Inherits="easyDbTools.Delete_Example" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Delete Example</h1>

<asp:GridView runat="server" ID="gv" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="name" />
        <asp:BoundField DataField="email" />
        <asp:BoundField DataField="createDate" />
        <asp:BoundField DataField="age" />

        <asp:TemplateField>
            <ItemTemplate>
                <a href="?Id=<%#Eval("id") %>">Delete</a>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>

</asp:Content>
