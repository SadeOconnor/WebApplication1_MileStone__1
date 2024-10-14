
    <%@ Page Title="Shopping Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="WebApplication1_MileStone__1.cart" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <head>
        <link href="https://fonts.googleapis.com/css2?family=Great+Vibes&display=swap" rel="stylesheet">
        <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;600&display=swap" rel="stylesheet">
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
            #cartItems {
                margin: 20px auto;
                width: 80%; /* Set width for cart items */
                background-color: #ffffff; /* White background for cart */
                border-radius: 10px; /* Rounded corners */
                padding: 20px; /* Padding for cart content */
                box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1); /* Light shadow for depth */
            }
            #cartItems ul {
                list-style-type: none; /* Remove default list styles */
                padding: 0; /* Remove default padding */
            }
            #cartItems li {
                margin-bottom: 20px; /* Space between each item */
                padding: 10px; /* Padding for items */
                border-bottom: 1px solid #e1e1e1; /* Add a bottom border for separation */
                display: flex; /* Use flexbox for layout */
                justify-content: space-between; /* Space out the details and remove button */
                align-items: center; /* Center align items */
            }
            .item-details {
                display: flex; /* Use flexbox for item details layout */
                justify-content: space-between; /* Space between item name and quantity/price */
                font-size: 1.2rem; /* Slightly larger font for item list */
                flex-grow: 1; /* Allow item details to grow and fill space */
            }
            .remove-btn {
                background-color: #e75480; /* Dark pink */
                color: white; /* White text */
                border: none; /* No border */
                padding: 5px 10px; /* Padding for button */
                cursor: pointer; /* Pointer cursor on hover */
                border-radius: 5px; /* Rounded corners */
            }
            .remove-btn:hover {
                background-color: #d64573; /* Darker pink on hover */
            }
            #grandTotal {
                text-align: right; /* Align grand total to the right */
                margin-top: 20px;
                font-size: 1.5rem; /* Larger font for emphasis */
                font-weight: bold; /* Bold font for emphasis */
            }
            .empty-cart {
                text-align: center;
                font-size: 1.2rem; /* Slightly larger font for empty cart message */
                color: #e75480; /* Dark pink for the message */
            }

            .view-cart-button {
                display: inline-block; /* Make it behave like a button */
                background-color: #e75480; /* Dark pink background */
                color: white; /* White text color */
                padding: 10px 20px; /* Padding for button */
                border-radius: 5px; /* Slightly rounded corners */
                font-size: 1rem; /* Font size */
                text-decoration: none; /* Remove underline */
                transition: background-color 0.3s ease; /* Smooth background transition */
                box-shadow: 0 2px 5px rgba(0, 0, 0, 0.2); /* Shadow for depth */
            }

    .view-cart-button:hover {
        background-color: #c0396b; /* Darker pink on hover */
    }
        </style>
    </head>

    <main aria-labelledby="title">
        <h2 id="title">Your Shopping Cart</h2>
        <div id="cartItems"></div> <!-- Container for cart items -->
        <div id="grandTotal"></div> <!-- Section for grand total -->
    </main>

    <script>
        function displayCart() {
            let cart = JSON.parse(sessionStorage.getItem('cart')) || [];
            let cartItemsDiv = document.getElementById('cartItems');
            let grandTotal = 0; // Initialize grand total

            if (cart.length === 0) {
                cartItemsDiv.innerHTML = "<p class='empty-cart'>Your cart is empty.</p>"; // Message when cart is empty
                document.getElementById('grandTotal').innerHTML = ""; // Clear grand total
            } else {
                let cartHTML = "<ul>"; // Start an unordered list
                cart.forEach((item, index) => {
                    cartHTML += `
                        <li>
                            <div class="item-details">
                                <span>${item.name}</span>
                                <span>Quantity: ${item.quantity}</span>
                                <span>Subtotal: $${item.subtotal.toFixed(2)}</span>
                            </div>
                            <button class="remove-btn" onclick="removeFromCart(${index})">Remove</button>
                        </li>
                    `;
                    grandTotal += item.subtotal; // Update grand total
                });
                cartHTML += "</ul>";
                cartItemsDiv.innerHTML = cartHTML; // Display cart items

                // Display the grand total
                document.getElementById('grandTotal').innerHTML = `Grand Total: $${grandTotal.toFixed(2)}`;
            }
        }

        function removeFromCart(index) {
            let cart = JSON.parse(sessionStorage.getItem('cart')) || [];
            cart.splice(index, 1); // Remove item at the specified index
            sessionStorage.setItem('cart', JSON.stringify(cart)); // Update session storage
            displayCart(); // Refresh the cart display
        }

        // Call displayCart function when the page loads
        window.onload = displayCart;
    </script>

</asp:Content>
