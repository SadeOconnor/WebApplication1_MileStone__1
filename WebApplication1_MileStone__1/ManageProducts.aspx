<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="WebApplication1_MileStone__1.ManageProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h2 class="my-4">Manage Products</h2>

        <!-- Add New Product Button -->
        <div class="row mb-3">
            <div class="col">
                <a href="AddProduct.aspx" class="btn btn-pink">Add New Product</a>
            </div>
        </div>

        <!-- Product Table -->
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>Product Name</th>
                    <th>Description</th>
                    <th>Price</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                <!-- Data binding for products list -->
                <asp:Repeater ID="ProductRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Name") %></td>
                            <td><%# Eval("Description") %></td>
                            <td><%# Eval("Price", "{0:C}") %></td>
                            <td>
                                <!-- Edit Product Link -->
                                <a href="EditProduct.aspx?productId=<%# Eval("ProductID") %>" class="btn btn-warning btn-sm">Edit</a>
                                <!-- Delete Product Link -->
                                <a href="DeleteProduct.aspx?productId=<%# Eval("ProductID") %>" class="btn btn-danger btn-sm">Delete</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>

