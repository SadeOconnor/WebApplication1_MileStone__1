<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="WebApplication1_MileStone__1.Products" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <head>
        <link href="https://fonts.googleapis.com/css2?family=Great+Vibes&display=swap" rel="stylesheet">
        <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;600&display=swap" rel="stylesheet">
    </head>

    <style>
        body {
            background-color: #f8d7da; /* Light background matching the theme */
            font-family: 'Poppins', sans-serif; /* Clean font for readability */
        }

        h2 {
            text-align: center;
            font-family: 'Great Vibes', cursive; /* Cursive font for main title */
            color: #e75480; /* Dark pink */
            margin: 40px 0;
            font-size: 4rem; /* Change this value to increase/decrease size */
        }

        .product-item {
            display: flex;
            align-items: center;
            margin: 20px 0;
            padding: 15px;
            background-color: #ffffff; /* White background for product info */
            border-radius: 10px; /* Rounded corners */
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1); /* Light shadow for depth */
            transition: transform 0.3s ease, box-shadow 0.3s ease; /* Smooth transition */
            position: relative; /* For positioning overlay */
            overflow: hidden; /* To clip the hover effect */
        }

        .product-item:hover {
            transform: translateY(-5px); /* Slight lift on hover */
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.2); /* Enhanced shadow on hover */
        }

        .product-image {
            max-width: 150px; /* Size for images */
            height: auto;
            border-radius: 10px; /* Rounded image corners */
            margin-right: 20px; /* Space between image and text */
            transition: transform 0.3s ease; /* Smooth image transition */
        }

        .product-item:hover .product-image {
            transform: scale(1.05); /* Zoom effect on image */
        }

        .product-title {
            color: #e75480; /* Dark pink for product titles */
            font-weight: bold;
            margin: 0 0 10px; /* Margin for spacing */
            font-size: 1rem; /* Larger title for impact */
        }

        .product-info {
            color: #333; /* Dark gray for text */
            margin: 5px 0; /* Margin for spacing */
        }

        .price-tag {
            font-size: 1rem; /* Slightly larger price */
            color: #e75480; /* Dark pink for price */
            font-weight: bold; /* Emphasize price */
            margin-top: 10px; /* Space above price */
        }

        /* Overlay effect */
        .overlay {
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background-color: rgba(231, 84, 128, 0.7); /* Semi-transparent dark pink overlay */
            opacity: 0;
            transition: opacity 0.3s ease; /* Smooth transition for overlay */
            border-radius: 10px; /* Rounded corners */
        }

        .product-item:hover .overlay {
            opacity: 1; /* Show overlay on hover */
        }

        .overlay-text {
            color: white; /* White text for overlay */
            font-size: 1.5rem; /* Larger text for emphasis */
            text-align: center;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100%;
        }
        .auto-style1 {
            width: 120px;
            height: 119px;
            margin-left: 1px;
        }
        .auto-style2 {
            width: 128px;
            height: 121px;
        }
        .auto-style3 {
            width: 118px;
            height: 72px;
            margin-left: 0px;
        }
    </style>

    <main aria-labelledby="title">
        <h2 id="title">Our Clothing Products</h2>

        <div class="container">
            <!-- Product 1 -->
            <div class="product-item">
                &nbsp;<div>
                    <h3 class="product-title">Men's T-Shirt</h3>
                    <p class="product-info"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</strong></p>
                    <p class="product-info"><strong>&nbsp;<img class="auto-style3" src="App_Start/img5.png" /> ID:</strong> 001</p>
                    <p class="product-info"><strong>&nbsp;&nbsp;&nbsp;&nbsp;</strong></p>
                    <p class="product-info"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Description:</strong> Comfortable cotton t-shirt available in multiple colors.</p>
                    <p class="product-info"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Category:</strong> Men</p>
                    <p class="price-tag"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Price:</strong> $25.00</p>
                    <div class="overlay">
                        <div class="overlay-text">Shop Now!</div>
                    </div>
                </div>
            </div>

            <!-- Product 2 -->
            <div class="product-item">
                <img class="auto-style1" src="App_Start/img6.png" />
                <div>
                    <h3 class="product-title">Women's Jacket</h3>
                    <p class="product-info"><strong>ID:</strong> 002</p>
                    <p class="product-info"><strong>Description:</strong> Stylish fur jacket perfect for cooler weather.</p>
                    <p class="product-info"><strong>Category:</strong> Women</p>
                    <p class="price-tag"><strong>Price:</strong> $120.00</p>
                    <div class="overlay">
                        <div class="overlay-text">Shop Now!</div>
                    </div>
                </div>
            </div>

            <!-- Product 3 -->
            <div class="product-item">
                <img class="auto-style2" src="App_Start/img7.png" />
                <div>
                    <h3 class="product-title">Kids' Hoodie</h3>
                    <p class="product-info"><strong>ID:</strong> 003</p>
                    <p class="product-info"><strong>Description:</strong> Warm and cozy outfit for kids, available in various sizes.</p>
                    <p class="product-info"><strong>Category:</strong> Kids</p>
                    <p class="price-tag"><strong>Price:</strong> $35.00</p>
                    <div class="overlay">
                        <div class="overlay-text">Shop Now!</div>
                    </div>
                </div>
            </div>

           
    </main>
</div>
</asp:Content>

