<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateProductHandler.aspx.cs" Inherits="WebApplication1_MileStone__1.UpdateProductHandler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body {
            background-color: #f8d7da; /* Set the background color to pink */
            font-family: Arial, sans-serif;
            color: #e75480;
        }
        h2, h3 {
            font-family: "Brush Script MT", cursive; /* Cursive font */
            font-size: 3em;
            color: #e75480; 
            text-align: center;
        }
        .form-container {
            max-width: 500px;
            margin: 0 auto;
            padding: 20px;
        }
        label {
            display: block;
            margin: 10px 0 5px;
            color: #e75480;
        }
        .input-field {
            width: 100%;
            padding: 8px;
            border-radius: 5px;
            border: 1px solid #ccc;
            margin-bottom: 15px;
        }
        .button {
            background-color: #e75480;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            margin-top: 10px;
        }
        .button:hover {
            background-color: #e75480; /* Slightly darker pink */
        }
    </style>

    <h2 class="cursive-heading">Update Product</h2>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
    <br />

    <table class="form-table">
        <tr>
            <td><label for="txtOldProductName">Old Product Name:</label></td>
            <td><asp:TextBox ID="txtOldProductName" runat="server" placeholder="Enter Old Product Name"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label for="txtProductName">Product Name:</label></td>
            <td><asp:TextBox ID="txtProductName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label for="txtDescription">Description:</label></td>
            <td><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label for="txtCategory">Category:</label></td>
            <td><asp:TextBox ID="txtCategory" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label for="txtPrice">Price:</label></td>
            <td><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></td>
        </tr>
    </table>

    <br />
    <asp:Button ID="btnUpdateProduct" runat="server" Text="Update Product" OnClick="btnUpdateProduct_Click" />
    <br /><br /> <!-- Space between update and delete sections -->

    <h3 class="cursive-heading">Delete Product</h3>
    <table class="form-table">
        <tr>
            <td><label for="txtDeleteProductName">Product Name to Delete:</label></td>
            <td><asp:TextBox ID="txtDeleteProductName" runat="server" Placeholder="Enter product name to delete"></asp:TextBox></td>
        </tr>
    </table>
    <asp:Label ID="lblDeleteMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
    <asp:Button ID="btnDeleteProduct" runat="server" Text="Delete Product" OnClick="btnDeleteProduct_Click" />

</asp:Content>