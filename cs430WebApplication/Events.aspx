<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="cs430WebApplication.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    



<head runat="server">
    <link href="Main.css" rel="stylesheet" />
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.1.1.min.js"></script>
    <title>Events</title>

    <style>

             
      table {
    border-collapse: collapse;
    width: 100%;
    font-size: 20px;
}

th, td {
    text-align: left;
    padding: 8px;
    word-wrap: break-word;
    max-width: 150px;
}

tr:nth-child(even){background-color: #f2f2f2}

th {
    background-color: blue;
    color: gold;
}
        
   

    </style>
</head>

    
<body>
    <header>

        <h1 id="loginText" style="width: auto">



            <img id="titleImg" src="http://img.scout.com/sites/default/files/west_virginia_mountaineers.png" />Events</h1>


    </header>

    <form  runat="server">
    <div>
        <asp:PlaceHolder ID = "events" runat="server" />
    </div>
    </form>
</body>
</html>
