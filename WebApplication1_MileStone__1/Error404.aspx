<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error404.aspx.cs" Inherits="WebApplication1_MileStone__1.Error404" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <title>Page Not Found</title>
    <style>
        body {
            background-color: #f8d7da; /* Light background matching the theme */
            font-family: 'Poppins', sans-serif;
            text-align: center;
            padding: 100px;
        }
        h1 {
            color: #e75480; /* Pink color matching the site theme */
            font-size: 3rem;
        }
        p {
            color: #333;
            font-size: 1.5rem;
        }
        a {
            color: #e75480;
            text-decoration: none;
            font-weight: bold;
        }
        a:hover {
            color: #c0396b;
        }
    </style>
</head>
<body>
    <h1>Oops! Page Not Found (404)</h1>
    <p>Sorry, the page you're looking for doesn't exist.</p>
    <p>COME BACK AND SHOP WITH US</p>
    <p><a href="Products.aspx">Go Back</a></p>
</body>
</html>

</asp:Content>
