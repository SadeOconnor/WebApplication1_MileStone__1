<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication1_MileStone__1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <head>
        <link href="https://fonts.googleapis.com/css2?family=Great+Vibes&family=Poppins:wght@400;600&display=swap" rel="stylesheet">
    </head>

    <style>
        body {
            background-color: #f8d7da; /* Light background */
            font-family: 'Poppins', sans-serif; /* Clean font */
            color: #333; /* Dark text for readability */
            margin: 0; /* Remove default margins */
            padding: 0; /* Remove default padding */
        }

        .about-us-container {
            padding: 40px 20px; /* Padding for sections */
            max-width: 1200px; /* Max width for content */
            margin: auto; /* Center the content */
        }

        h2 {
            text-align: center;
            font-family: 'Great Vibes', cursive; /* Cursive font for main title */
            color: #e75480; /* Dark pink */
            margin-bottom: 30px; /* Space below title */
            font-size: 6rem; /* Larger title size */
        }

        h3 {
            color: #e75480; /* Dark pink for section titles */
            margin-top: 40px; /* Space above section titles */
            font-size: 2rem; /* Section title size */
            text-align: center; /* Center align section titles */
        }

        p {
            line-height: 1.6; /* Better line spacing for readability */
            margin: 10px 0; /* Space around paragraphs */
            text-align: center; /* Center align paragraphs */
        }

        .section {
            background-color: transparent; /* No background for sections */
            padding: 20px; /* Padding for inner sections */
            margin-bottom: 30px; /* Space between sections */
        }

        .history-section {
            display: flex; /* Flexbox for history section */
            align-items: center; /* Center align items */
            justify-content: center; /* Center content */
            flex-wrap: wrap; /* Allow wrapping for smaller screens */
            margin-top: 30px; /* Space above section */
        }

        .history-section img {
            max-width: 100%; /* Responsive image */
            border-radius: 10px; /* Rounded corners for image */
            margin: 0 20px; /* Space around image */
        }

        .team-section {
            display: flex; /* Flexbox layout for team section */
            justify-content: center; /* Center team members */
            flex-wrap: wrap; /* Allow wrapping */
            margin-top: 30px; /* Space above section */
        }

        .team-member {
            flex: 1 0 200px; /* Flex basis for responsive design */
            text-align: center; /* Center align team member info */
            margin: 10px; /* Margin around team members */
        }

        .team-member img {
            max-width: 150px; /* Fixed size for team images */
            height: auto;
            border-radius: 50%; /* Circular images (did not use) */
            margin-bottom: 10px; /* Space below images */
        }

        .cta-section {
            text-align: center; /* Center align call to action */
            margin-top: 30px; /* Space above */
        }

        .btn-primary {
            background-color: #e75480; /* Match theme color */
            border: none; /* Remove default border */
            color: white; /* White text */
            padding: 10px 20px; /* Padding for button */
            border-radius: 25px; /* Rounded button */
            text-decoration: none; /* Remove underline */
            transition: background-color 0.3s; /* Smooth transition */
        }

        .btn-primary:hover {
            background-color: #d54f76; /* Darker shade on hover */
        }
    </style>

    <main aria-labelledby="title" class="about-us-container">
        <!-- About Us Section -->
        <section class="section about-section">
            <h2>About Us</h2>
            <p>Welcome to <strong>Bloom Clothing Store</strong>, where fashion meets comfort. Established in 2022, we pride ourselves on providing stylish, high-quality apparel for men, women, and kids at affordable prices.</p>
            <p>From casual wear to special occasion outfits, our clothing is designed to help you feel confident and comfortable wherever you go. We believe that fashion should be accessible to everyone, and our mission is to make that possible.</p>
            <p>At Bloom Clothing Store, we believe that colors can express personality and style. Our founder has a special <strong>obsession with the color pink,</strong> which reflects a vibrant and joyful spirit. This passion is woven into every piece of our collection,</p>
            <p>ensuring that you not only look good but also feel confident and empowered in every shade of pink we offer. Join us in celebrating the elegance and charm that this beautiful color brings to fashion!</p>
        </section>

        <!-- Company History Section -->
        <section class="section history-section">
            <h3>Our History</h3>
            
            <div>
                <p>Founded in 2022, Bloom Clothing Store began as a small boutique inspired by a web programming class. Since then, we have grown into a trusted brand with customers around the world. Our journey started with the belief that quality fashion should be accessible to everyone..</p>
                <p>Today, Bloom Clothing Store continues to expand, offering a variety of clothing styles that reflect the latest trends while staying true to our commitment to sustainability and ethical production.</p>
            </div>
        </section>

        <!-- Mission Section -->
        <section class="section mission-section">
            <h3>Our Mission</h3>
            <p>At Bloom Clothing Store, our mission is to inspire confidence and empower people through fashion. We strive to bring the latest trends to your wardrobe, combining innovation, sustainability, and comfort.</p>
            <blockquote>
                <p>"Fashion is not just about the clothes you wear, it's about how you feel when you wear them."</p>


              
            </blockquote>
        </section>

        <!-- Meet the Team Section -->
        <section class="section team-section">
            <h3>Meet the Team</h3>
            <div class="team-member">
                
                <h4>Sade O'Connor</h4>
                <p>Founder & CEO</p>
            </div>
            <div class="team-member">
                
                <h4>Taneshia O'Connor</h4>
                <p>Head of Design</p>
            </div>
            <div class="team-member">
                <h4>Tisha Miller</h4>
                <p>Marketing Director</p>
            </div>
        </section>

        <!-- Call to Action Section -->
        <section class="section cta-section">
            <h3>Join Us on Our Journey</h3>
            <p>Stay updated on the latest fashion trends and exclusive offers by following us on social media or signing up for our newsletter.</p>
            <a href="Contact.aspx" class="btn btn-primary">Contact Us</a>
        </section>
    </main>
</asp:Content>


