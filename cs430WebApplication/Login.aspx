<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="cs430WebApplication.WebForm1" %>

<!DOCTYPE html5>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="css/bootstrap.css" rel="stylesheet" />
    <title>Log in page</title>

    <style>
        body {
            background-image: url(http://wallpapercave.com/wp/0gjtD62.jpg);
        }

        div.loginLayout {
            margin: 30px 0 30px 0;
            padding: 20px;
        }

        h1#loginText {
            color: gold;
            padding: 0px,0,0px,0;
            font-size: 70px;
            text-align: center;
        }

        img#titleImg {
            width: 120px;
            height: 120px;
        }

        header {
            width: auto;
            height: 150px;
        }

        .logingDiv {
            padding: 20px,0,20px,0;
            align-self: center;
            align-content: center;
            text-align: center;
            height: auto;
            width: auto;
        }

        .inputs {
            animation:ease-in;
            border-style:double;
            text-shadow: 2px 2px 20px #FAFA11;
            border-color:gold;
            font-size: 24px;
        }

        form {
            align-content: center;
            text-align: center;
            margin-bottom: 25px;
            margin-top: 25px;
        }

        div {
            padding: 20px,20px,20px,20px;
            margin-bottom: 25px;
            margin-top: 25px;
        }

        .buttonReg {
            width: 200px;
            height: 45px;
            font-size: medium;
            color: gold;
            background-color: blue;
            border-color: gold;
            margin: 20px,20px,20px,20px;
        }

        .buttonLog {
            width: 200px;
            height: 45px;
            font-size: medium;
            color: blue;
            background-color: gold;
            border-color: blue;
            padding: 20px,20px,20px,20px;
        }

        .label{
            color:gold;
            font-size:medium;
            align-items:center;
            margin: 20px,20px,20px,80px;

        }
    </style>


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
            
            <input placeholder="Password" type="password" id="loginPassword" runat="server" class="inputs" />
        </div>
        <div>

            <asp:Button Text="Register" runat="server" class="buttonReg" OnClick="RegisterPage" />
            &nbsp;
            <asp:Button Text="Log In" runat="server" ID="loginButton" class="buttonLog" OnClick="LoginRequest" />


        </div>


    </form>





</body>
</html>
