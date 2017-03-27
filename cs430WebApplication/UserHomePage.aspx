<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserHomePage.aspx.cs" Inherits="cs430WebApplication.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="css/bootstrap.css" rel="stylesheet" />


    <title>Home</title>



     <style>
body {
    background-image: url(http://wallpapercave.com/wp/0gjtD62.jpg);
}

label {
            color: #ffd800;
        }

btn btn-lg btn-success btn-block{

    position:center;
    margin-top: 20px;
    margin-bottom: 20px;
    

}

h1{
 color: #ffd800

}

</style>
   
</head>
<body>
    <form id="form1" runat="server">
    <h1><asp:Literal id ="name" runat="server" /></h1>

    <h1><asp:Literal id ="tag" runat="server" /></h1>
        
   



  

        <asp:Button ID="Events" style ="position:center;margin-top: 20px;margin-bottom:20px"  runat="server"  class="btn btn-lg btn-success btn-block" Text="Events" />
        <asp:Button ID="matchedEvents" style ="position:center;margin-top: 20px;margin-bottom:20px"   runat="server"  class="btn btn-lg btn-success btn-block" Text="Matched Events" />

    </form>



  

</body>
</html>
