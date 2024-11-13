<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Adminlog.aspx.cs" Inherits="WebApplication1_MileStone__1.Adminlog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <h2>Welcome to the Admin Panel</h2>
    <p>Manage your site settings here.</p>

      <div class="navbar-nav">
        <!-- Admin-specific navigation items visible only to SadeAdmin -->
        <asp:Button ID="btnManageProducts" runat="server" Text="Manage Products" OnClick="btnManageProducts_Click" CssClass="button" />
        <asp:Button ID="btnManageUsers" runat="server" Text="Manage Users" OnClick="btnManageUsers_Click" CssClass="button" />
    </div>

</asp:Content>
