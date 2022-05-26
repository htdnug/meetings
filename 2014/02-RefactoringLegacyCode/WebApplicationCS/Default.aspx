<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplicationCS.Default1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <h2>Legacy</h2>
    
    <ul>
        <li><a href="<%= Page.ResolveClientUrl("~/Legacy/Companies.aspx") %>">Companies</a></li>
    </ul>
    
    <h2>Refactored</h2>
    
    <ul>
        <li><a href="<%= Page.ResolveClientUrl("~/Refactored/Companies.aspx") %>">Companies</a></li>
    </ul>

</asp:Content>
