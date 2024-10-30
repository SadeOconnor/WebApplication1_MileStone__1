
    <%@ Page Title="Shopping Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="WebApplication1_MileStone__1.cart" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        
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

    .continue-shopping-button {
    background-color: #e75480; /* Dark pink to match theme */
    color: white;
    border: none;
    padding: 10px 20px;
    border-radius: 5px;
    font-size: 1rem;
    cursor: pointer;
    margin-top: 20px;
    transition: background-color 0.3s ease;
}

.continue-shopping-button:hover {
    background-color: #d64573; /* Darker pink on hover */
}

.cart-actions {
    text-align: center;
    margin: 20px auto;
    width: 80%;
}

 .place-order-button {
            background-color: #e75480; /* Dark pink */
            color: white; /* White text */
            border: none; /* No border */
            padding: 10px 20px; /* Padding for button */
            border-radius: 5px; /* Rounded corners */
            font-size: 1rem; /* Font size */
            cursor: pointer; /* Pointer cursor */
            margin-top: 20px; /* Margin for spacing */
            transition: background-color 0.3s ease; /* Smooth background transition */
        }
 .place-order-button:hover {
  background-color: #d64573; /* Darker pink on hover */
        }

        </style>
 
    <main aria-labelledby="title">
        <h2 id="title">Your Shopping Cart</h2>
      <!--  Panel  -->
        <asp:Panel ID="cartContainer" runat="server">
            <div id="cartItems"></div>
            <div id="grandTotal"></div>
        </asp:Panel>

        <!-- Input controls for order details -->
        <div>
            <label for="txtName">Name:</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
            <label for="txtAddress">Address:</label>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" />
            <label for="ddlPaymentMethod">Payment Method:</label>
            <asp:DropDownList ID="ddlPaymentMethod" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Payment Method" Value="" />
                <asp:ListItem Text="Credit Card" Value="CreditCard" />
                <asp:ListItem Text="PayPal" Value="PayPal" />
                <asp:ListItem Text="Bank Transfer" Value="BankTransfer" />
            </asp:DropDownList>
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>

    
        <!-- Modal for updating product details -->
<div id="updateModal" class="modal">
    <div class="modal-content">
        <h3>Update Product Quantity</h3>
        <asp:HiddenField ID="hiddenProductName" runat="server" />
        <label for="txtNewQuantity">New Quantity:</label>
        <asp:TextBox ID="txtNewQuantity" runat="server" CssClass="quantity-input"></asp:TextBox>
        <asp:Label ID="lblUpdateMessage" runat="server" CssClass="update-message"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Update" OnClick="btnSubmitProductUpdate_Click" />
        <button type="button" onclick="document.getElementById('updateModal').style.display='none';">Cancel</button>
    </div>
</div>
         <!-- Message label for displaying success/error messages -->
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

        <!-- continue shopping button -->
        <div class="cart-actions">
            <asp:Button ID="btnContinueShopping" runat="server" 
                       Text="Continue Shopping" 
                       OnClick="ContinueShopping_Click" 
                       CssClass="continue-shopping-button" />

             <!-- Add New Product button -->
           <asp:Button ID="btnGoToAddProduct" runat="server" 
                 Text="Add New Product" 
                 OnClick="btnGoToAddProduct_Click"  
                 CssClass="place-order-button" />

            <!-- Update Product button -->
    <asp:Button ID="btnUpdateProduct" runat="server" 
                 Text="Update Product" 
                 OnClick="RedirectToUpdateProductPage" 
                 CssClass="place-order-button" />

                        <!-- order button here -->
           <asp:Button ID="btnPlaceOrder" runat="server" 
            Text="Place Order" 
            OnClientClick="placeOrder(); return false;" 
            CssClass="place-order-button" />

            
        </div>
        
    </main>

    <script>
        function displayCart() {
            let cart = JSON.parse(sessionStorage.getItem('cart')) || [];
            let cartItemsDiv = document.getElementById('cartItems');
            let grandTotal = 0;

            if (cart.length === 0) {
                cartItemsDiv.innerHTML = "<p class='empty-cart'>Your cart is empty.</p>";
                document.getElementById('grandTotal').innerHTML = "";
                document.getElementById('<%= btnPlaceOrder.ClientID %>').style.display = 'none';
        } else {
            let cartHTML = "<ul>";
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
                grandTotal += item.subtotal;
            });
            cartHTML += "</ul>";
            cartItemsDiv.innerHTML = cartHTML;
            document.getElementById('grandTotal').innerHTML = `Grand Total: $${grandTotal.toFixed(2)}`;
            document.getElementById('<%= btnPlaceOrder.ClientID %>').style.display = 'inline-block';
            }
        }

        function showUpdateModal(productName, currentQuantity) {
            document.getElementById('hiddenProductName').value = productName;
            document.getElementById('txtNewQuantity').value = currentQuantity;
            document.getElementById('updateModal').style.display = 'block';
        }

        // JavaScript function to remove items from the cart
        function removeFromCart(index) {
            let cart = JSON.parse(sessionStorage.getItem('cart')) || [];
            cart.splice(index, 1); // Remove the item at the given index
            sessionStorage.setItem('cart', JSON.stringify(cart)); // Update the session storage
            displayCart(); // Re-display the updated cart
        }

        function placeOrder() {
            let cart = JSON.parse(sessionStorage.getItem('cart')) || [];
            let name = document.getElementById('<%= txtName.ClientID %>').value;
        let address = document.getElementById('<%= txtAddress.ClientID %>').value;
        let paymentMethod = document.getElementById('<%= ddlPaymentMethod.ClientID %>').value;

        // Check if the cart is empty
        if (cart.length === 0) {
            alert("Your cart is empty. Add items before placing an order.");
            return;
        }

        // Validate order details
        if (!name || !address || !paymentMethod) {
            document.getElementById('<%= lblErrorMessage.ClientID %>').innerText = "Please fill in all order details.";
            return;
        }

        // Proceed with the order
        alert("Order placed successfully! Thank you for shopping.");

        // Clear the cart after placing order
        sessionStorage.removeItem('cart');
        displayCart(); // Re-display the empty cart
    }
      





        // Call displayCart function when the page loads
        window.onload = displayCart;



    </script>
   
</asp:Content>
