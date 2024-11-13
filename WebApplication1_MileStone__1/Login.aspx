<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="WebApplication1_MileStone__1.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <script type="text/javascript">
    function checkAdminPassword() {
        var password = prompt("Please enter admin password:", "");
        if (password == "Adminbloom123#") { 
            return true;
        } else {
            alert("Incorrect password!");
            return false;
        }
    }
</script>

    <style>
        body {
            background-color: #ff66b2; /* Pink background */
            font-family: Arial, sans-serif;
            color: #333;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }
        h2 {
            font-family: "Brush Script MT", cursive; /* Cursive font for heading */
            font-size: 2em;
            color: #ff66b2; /* Pink heading color */
            text-align: center;
        }
        .form-container {
            background-color: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            width: 100%;
            max-width: 400px;
            margin-bottom: 20px;
        }
        .form-wrapper {
            display: flex;
            justify-content: space-between;
            gap: 30px;
            width: 80%;
            margin: 0 auto;
        }
        .input-field, .dropdown {
            width: 100%;
            padding: 8px;
            border-radius: 5px;
            border: 1px solid #ccc;
            margin-bottom: 15px;
            box-sizing: border-box;
        }
        .button {
            background-color: #ff66b2; /* Pink button color */
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            display: inline-block;
        }
        .button:hover {
            background-color: #ff3385; /* Slightly darker pink */
        }
        .message {
            font-size: 0.9em;
        }
        .left-form, .right-form {
            flex: 1;
            display: block;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <asp:HiddenField ID="hfUserID" runat="server" />
            <asp:Button Text="Logout" ID="btnLogout" CssClass="button" runat="server" OnClick="btnLogout_Click" />

            <h2>User Registration</h2>
            <table>
                <!-- Column 1 -->
                <tr>
                    <td><asp:Label Text="First Name" runat="server" /></td>
                    <td colspan="2"><asp:TextBox ID="txtFirstName" CssClass="input-field" runat="server" /></td>
                </tr>
                <!-- Column 2 -->
                <tr>
                    <td><asp:Label Text="Last Name" runat="server" /></td>
                    <td colspan="2"><asp:TextBox ID="txtLastName" CssClass="input-field" runat="server" /></td>
                </tr>
                <!-- Column 3 -->
                <tr>
                    <td><asp:Label Text="Contact" runat="server" /></td>
                    <td colspan="2"><asp:TextBox ID="txtContact" CssClass="input-field" runat="server" /></td>
                </tr>
                <!-- Column 4 -->
                <tr>
                    <td><asp:Label Text="Gender" runat="server" /></td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlGender" CssClass="dropdown" runat="server">
                            <asp:ListItem>MALE</asp:ListItem>
                            <asp:ListItem>FEMALE</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <!-- Column 5 -->
                <tr>
                    <td><asp:Label Text="Address" runat="server" /></td>
                    <td colspan="2"><asp:TextBox ID="txtAddress" CssClass="input-field" TextMode="MultiLine" runat="server" /></td>
                </tr>
                <!-- Column 6 -->
                <tr>
                    <td><asp:Label Text="Username" runat="server" /></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtUsername" CssClass="input-field" runat="server" />
                        <asp:Label Text="*" ForeColor="Red" runat="server" />
                    </td>
                </tr>
                <!-- Column 7 -->
                <tr>
                    <td><asp:Label Text="Password" runat="server" /></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtPassword" CssClass="input-field" TextMode="Password" runat="server" />
                        <asp:Label Text="*" ForeColor="Red" runat="server" />
                    </td>
                </tr>
                <!-- Column 8 -->
                <tr>
                    <td><asp:Label Text="Confirm Password" runat="server" /></td>
                    <td colspan="2"><asp:TextBox ID="txtConfirmPassword" CssClass="input-field" TextMode="Password" runat="server" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button Text="Submit" ID="btnSubmit" CssClass="button" runat="server" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                       <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="button" />
                    </td>
                </tr>
                 <!-- Admin -->
                      <tr>
             <td></td>
                 <td colspan="2">
                            <asp:Button ID="Button1" runat="server" Text="Admin" OnClientClick="return checkAdminPassword();" 
            OnClick="btnAdmin_Click" CssClass="button" />
                    </td>
            </tr>
                      <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="lblSuccessMessage" CssClass="message" ForeColor="Green" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="lblErrorMessage" CssClass="message" ForeColor="Red" runat="server" />
                    </td>
                </tr>

            </table>
        </div>



        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UserResgistrationDBConnectionString %>" SelectCommand="SELECT * FROM [UserReg]"></asp:SqlDataSource>
    </form>
</body>
</html>
