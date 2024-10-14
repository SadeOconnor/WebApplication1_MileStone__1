// JavaScript source code
// Initialize an empty cart array


// Cookie management functions
// Function to set a cookie
function setCookie(name, value, days) {
    let expires = "";
    if (days) {
        const date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}

// Function to get a cookie
function getCookie(name) {
    const nameEQ = name + "=";
    const ca = document.cookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

// Function to save cart to cookies
function saveCartToCookies() {
    setCookie("cart", JSON.stringify(cart), 7); // Expires in 7 days
}

// Function to load cart from cookies
function loadCartFromCookies() {
    const storedCart = getCookie("cart");
    if (storedCart) {
        cart = JSON.parse(storedCart);
        updateCartDisplay();
    }
}

// Call this function on page load
loadCartFromCookies();

// Existing cart functionality
let cart = [];

// Function to add items to the cart
function addToCart(productName, productPrice, quantity) {
    const item = {
        name: productName,
        price: parseFloat(productPrice),
        quantity: parseInt(quantity),
        subtotal: parseFloat(productPrice) * parseInt(quantity) // calculation
    };

    // Add item to cart
    cart.push(item);

    // Update the cart display
    updateCartDisplay();

    // Save the updated cart to cookies
    saveCartToCookies();
}

// Function to remove items from the cart based on index
function removeFromCart(index) {
    if (cart.length === 0) {
        alert("No items in the cart to remove.");
        return;
    }

    // Remove the item from the cart array at the specified index
    cart.splice(index, 1);

    // Update the cart display after removing the item
    updateCartDisplay();

    // Save the updated cart to cookies
    saveCartToCookies();
}

// Function to display the cart and update total
function updateCartDisplay() {
    const cartItemsContainer = document.getElementById('cart-items');
    const cartTotal = document.getElementById('cart-total');

    // Clear the current cart display
    cartItemsContainer.innerHTML = '';

    let grandTotal = 0;

    // Check if cart is empty
    if (cart.length === 0) {
        cartItemsContainer.innerHTML = '<p>No items in the cart</p>';
        cartTotal.innerText = 'Grand Total: $0.00';
        return;
    }

    // Display each cart item with a "Remove" button
    cart.forEach((item, index) => {
        grandTotal += item.subtotal;   // Calculation for cart

        const cartItemHTML = `
            <div class="cart-item">
                <p><strong>${item.name}</strong></p>
                <p>${item.quantity} x $${item.price.toFixed(2)} = $${item.subtotal.toFixed(2)}</p> 
                <button class="remove-btn" onclick="removeFromCart(${index})">Remove</button>
            </div>
        `;

        // Append the item to the cart-items container
        cartItemsContainer.innerHTML += cartItemHTML;
    });

    // Update the total cost
    cartTotal.innerText = `Grand Total: $${grandTotal.toFixed(2)}`;
}

// Function to toggle cart dropdown display
function toggleCartDropdown() {
    const cartDropdown = document.getElementById('cart-dropdown');
    cartDropdown.style.display = cartDropdown.style.display === 'none' ? 'block' : 'none';
}