<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication1_MileStone__1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
        <link href="https://fonts.googleapis.com/css2?family=Great+Vibes&family=Poppins:wght@400;600&display=swap" rel="stylesheet">
   

    <style>
        body {
            background-color: #f8d7da; /* Light background */
            font-family: 'Poppins', sans-serif; /* Clean font */
            color: #333; /* Dark text for readability */
            margin: 0; /* Remove default margins */
            padding: 0; /* Remove default padding */
        }

        main {
            padding: 40px 20px; /* Padding for the main content */
            max-width: 1200px; /* Max width for content */
            margin: auto; /* Center the content */
            text-align: center; /* Center text */
        }

        h2 {
            font-family: 'Great Vibes', cursive; /* Cursive font for title */
            color: #e75480; /* Dark pink */
            font-size: 5rem; /* Title size */
            margin-bottom: 30px; /* Space below title */
        }

        h3 {
            color: #e75480; /* Dark pink for section titles */
            margin-top: 50px; /* Increased space above h3 */
            font-size: 2rem; /* Size for h3 */
        }

        h4 {
            color: #e75480; /* Dark pink for section titles */
            margin-top: 40px; /* Increased space above h4 */
            font-size: 1.5rem; /* Size for h4 */
        }

        address {
            font-style: normal; /* Normal style for address */
            margin: 20px 0; /* Space around address */
        }

        ul {
            list-style-type: none; /* Remove bullet points */
            padding: 0; /* Remove padding */
        }

        li {
            margin: 10px 0; /* Space between list items */
        }

        a {
            color: #e75480; /* Theme color for links */
            text-decoration: none; /* Remove underline */
            transition: color 0.3s; /* Smooth transition for hover */
        }

        a:hover {
            color: #d54f76; /* Darker shade on hover */
        }
    </style>

    <main aria-labelledby="title">
        <h2 id="title">Contact Us</h2>
        <h3>We'd Love to Hear from You!</h3>

        <!-- Company Contact Information -->
        <section>
            <h4>Our Location</h4>
            <address>
                23 Dominica Drive<br />
                Kingstion<br />
                <abbr title="Phone"></abbr> (876) 981-7890
            </address>
        </section>

        <!-- Email Contact Information -->
        <section>
            <h4>Email Us</h4>
            <p><strong>Support:</strong> <a href="mailto:info@bloomclothingstore.com">info@bloomclothingstore.com</a></p>
            <p><strong>Marketing:</strong> <a href="mailto:marketing@bloomclothingstore.com">marketing@bloomclothingstore.com</a></p>
        </section>

        <!-- Social Media Links -->
        <section>
            <h4>Follow Us on Social Media</h4>
            <ul>
                <li><strong>TikTok:</strong> <a href="https://www.tiktok.com/@bloomclothingstore" target="_blank">@bloomclothingstore</a></li>
                <li><strong>Instagram:</strong> <a href="https://www.instagram.com/bloomclothingstore" target="_blank">@bloomclothingstore</a></li>
                <li><strong>Twitter:</strong> <a href="https://twitter.com/bloomclothingstore" target="_blank">@bloomclothingstore</a></li>
            </ul>
        </section>
    </main>

</asp:Content>




