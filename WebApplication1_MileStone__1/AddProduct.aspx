<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="WebApplication1_MileStone__1.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<style>
    body {
        background-color: #f8d7da; /* Pink background */
        font-family: Arial, sans-serif;
        color: #333;
    }
    h2 {
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
        background-color: #e75480;/* Pink button */
        color: white;
        padding: 10px 20px;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        margin-top: 10px;
    }
    .button:hover {
        background-color: #ff3385; /* Darker pink on hover */
    }
</style>

<div class="form-container">
    <h2>Add New Product</h2>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
    <br />

    <label for="txtProductName">Product Name:</label>
    <asp:TextBox ID="txtProductName" runat="server" CssClass="input-field" Required="true"></asp:TextBox>

    <label for="txtDescription">Description:</label>
    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="4" CssClass="input-field" Required="true"></asp:TextBox>

    <label for="txtCategory">Category:</label>
    <asp:TextBox ID="txtCategory" runat="server" CssClass="input-field" Required="true"></asp:TextBox>

    <label for="txtPrice">Price:</label>
    <asp:TextBox ID="txtPrice" runat="server" CssClass="input-field" Required="true"></asp:TextBox>

    <label for="txtImageUrl">Image URL:</label>
    <asp:TextBox ID="txtImageUrl" runat="server" CssClass="input-field" Required="true"></asp:TextBox>

    <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" CssClass="button" OnClick="AddNewProduct_Click" />
</div>

</asp:Content>