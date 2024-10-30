<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="WebApplication1_MileStone__1.checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Checkout</h2>

     <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" />

    <div>
        <h3>Order Summary</h3>
        <div id="orderSummary" runat="server"></div>
    </div>

    <div>
        <label for="txtName">Name:</label>
        <asp:TextBox ID="txtName" runat="server" />
    </div>
    <div>
        <label for="txtAddress">Address:</label>
        <asp:TextBox ID="txtAddress" runat="server" />
    </div>
    <div>
        <label for="ddlPaymentMethod">Payment Method:</label>
        <asp:DropDownList ID="ddlPaymentMethod" runat="server">
            <asp:ListItem Text="Credit Card" Value="CreditCard" />
            <asp:ListItem Text="PayPal" Value="PayPal" />
        </asp:DropDownList>
    </div>
   
    <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" OnClick="PlaceOrder_Click" />

</asp:Content>