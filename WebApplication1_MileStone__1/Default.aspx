<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1_MileStone__1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <head>
        <link href="https://fonts.googleapis.com/css2?family=Great+Vibes&display=swap" rel="stylesheet">
        <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;600&display=swap" rel="stylesheet">
    </head>

    <style>
        /* Global Styles */
        body {
            background-color: #f8d7da; /* Light background matching the theme */
            font-family: 'Poppins', sans-serif; /* Font */
            color: #333; /* Default text color */
            line-height: 1.6; /* For readability */
        }

        /* Featured Products Section */
        .featured-products {
            padding: 60px 0; /* Increased top and bottom padding */
            border-radius: 15px; /* Rounded corners */
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1); /* Subtle shadow for elevation */
            background-color: white; /* White background for contrast */
        }

        .featured-title {
            font-family: bold; /* Cursive font for title */
            color: #e75480; /* Dark pink color */
            font-size: 2.5rem; /* Larger title size */
            margin-bottom: 40px; /* Space below title */
            text-align: center; /* Center the title */
            text-shadow: 1px 1px 2px rgba(0, 0, 0, 0.1); /* Subtle shadow */
        }

        .product-card {
            border: 1px solid #e0e0e0; /* Light gray border */
            border-radius: 15px; /* Rounded corners */
            padding: 20px;
            margin: 15px;
            text-align: center; /* Centered text */
            transition: transform 0.3s ease, box-shadow 0.3s ease; /* Smooth transition */
            background-color: #ffffff; /* White background for product card */
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1); /* Light shadow for depth */
        }

        .product-card:hover {
            transform: translateY(-8px); /* Slight lift on hover */
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.2); /* Enhanced shadow on hover */
        }

        .product-image {
            max-width: 100%; /* Responsive image */
            height: auto;
            border-radius: 10px; /* Rounded image corners */
        }

        .product-title {
            font-weight: 600; /* Bold font for titles */
            color: #e75480; /* Dark pink for product titles */
            margin: 15px 0 5px; /* Margins for spacing */
        }

        .product-price {
            color: #333; /* Dark gray for prices */
            margin: 10px 0;
            font-size: 1.5rem; /* Larger price text */
        }

        .btn-product, .btn-outline-primary {
            background-color: #e75480; /* Dark pink button */
            color: white; /* White text */
            border: none; /* No border */
            border-radius: 25px; /* Slightly rounded corners */
            padding: 12px 24px; /* Padding for larger button */
            font-size: 1rem; /* Font size */
            transition: background-color 0.3s ease; /* Smooth transition */
            text-decoration: none; /* Remove underline */
        }

        .btn-product:hover, .btn-outline-primary:hover {
            background-color: #ffc0cb; /* Light pink hover effect */
        }

        /* Hero Section */
        .store-title {
            font-family: 'Great Vibes', cursive;
            font-size: 5rem; /* Title size */
            color: #e75480; /* Dark pink */
            margin-bottom: 20px; /* Spacing */
        }

        .subtitle {
            font-weight: 300; /* Lighter weight */
            color: white;
            font-size: 1.5rem; /* Adjust size as needed */
            text-shadow: 1px 1px 2px rgba(0, 0, 0, 0.5); /* shadow for added effect */
        }
    </style>

    <main>
        <!-- Hero Section -->
        <section class="row text-center py-5" aria-labelledby="aspnetTitle">
            <div class="col-md-12">
                <h1 id="aspnetTitle" class="store-title">Bloom Clothing Store</h1>
                <p class="lead subtitle">Flourish in Fashion</p>
                <p><a href="http://www.asp.net" class="btn btn-outline-primary">Learn more &raquo;</a></p>
            </div>
        </section>

        <!-- Featured Products Section -->
        <section class="featured-products text-center">
            <div class="container">
                <h2 class="featured-title">Featured Products</h2>
                <div class="row justify-content-center">
                    <!-- Product 1 -->
                    <div class="col-md-4">
                        <div class="product-card">
                            &nbsp;<h3 class="product-title">
                                <asp:Image ID="Image1" runat="server" Height="132px" ImageUrl="~/App_Start/img1.png" Width="122px" />
                            </h3>
                            <h3 class="product-title">Lucky Charm</h3>
                            <p class="product-price">$29.99</p>
                            <a href="#" class="btn btn-product">Add to Cart</a>
                        </div>
                    </div>

                    <!-- Product 2 -->
                    <div class="col-md-4">
                        <div class="product-card">
                            &nbsp;<h3 class="product-title">
                                <asp:Image ID="Image2" runat="server" Height="144px" ImageUrl="~/App_Start/img2.png" Width="137px" />
                            </h3>
                            <h3 class="product-title">Barbie Dream</h3>
                            <p class="product-price">$39.99</p>
                            <a href="#" class="btn btn-product">Add to Cart</a>
                        </div>
                    </div>

                    <!-- Product 3 -->
                    <div class="col-md-4">
                        <div class="product-card">
                            &nbsp;<h3 class="product-title">
                                <asp:Image ID="Image3" runat="server" Height="140px" ImageUrl="~/App_Start/img3.png" Width="132px" />
                            </h3>
                            <h3 class="product-title">Fur Baby</h3>
                            <p class="product-price">$49.99</p>
                            <a href="#" class="btn btn-product">Add to Cart</a>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        
   
    </main>

</asp:Content>


