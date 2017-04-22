<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="cs430WebApplication.WebForm1" %>

<!DOCTYPE html5>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="Main.css" rel="stylesheet" />
    <title>Log in page</title>

    

</head>
<body>

    <header>

        <h1 id="loginText" style="width: auto">



            <img id="titleImg" src="http://img.scout.com/sites/default/files/west_virginia_mountaineers.png" />Login </h1>



    </header>



    <form runat="server">

        <div>
         
            <input class="inputs" placeholder="Email" type="email" id="loginEmail" runat="server" />
        </div>
        <div>
            
            <input class="inputs" placeholder="Password" type="password" id="loginPassword" runat="server"  />
        </div>
        <div>

            <asp:Button Text="Register" runat="server" class="buttonGold" OnClick="RegisterPage" />
            &nbsp;
            <asp:Button Text="Log In" runat="server" ID="loginButton" class="buttonBlue" OnClick="LoginRequest" />


        </div>


    </form>





</body>
</html>
