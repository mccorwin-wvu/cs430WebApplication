<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserHomePage.aspx.cs" Inherits="cs430WebApplication.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link href="Main.css" rel="stylesheet" />
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.1.1.min.js"></script>




    <title>Home</title>

  
</head>
<body>
    <header>

        <h1 id="loginText" style="width: auto">



            <img id="titleImg" src="http://img.scout.com/sites/default/files/west_virginia_mountaineers.png" />Home </h1>



    </header>

    <form id="form1" runat="server">
    
        <div>
            <asp:Button ID="Events" runat="server"  class="buttonGold" Text="Events" OnClick="ViewEvents" />
        </div>
        <div>
            <asp:Button ID="matchedEvents" runat="server"  class="buttonGold" Text="Matched Events" OnClick="MatchedEventPage" />
        </div>

        <div>
            <asp:Button ID="CreateEvent" runat="server"  class="buttonGold" Text="Create Event" OnClick="CreateEventPage"/>
        </div>
        
        <div>
            <asp:Button ID="ChangePass" runat="server"  class="buttonGold" Text="Change Password"/>
        </div>

        <div>
            <asp:Button ID="SubmitTags" runat="server"  class="buttonGold" Text="Submit New Tags" OnClick="SubmitNewTags"/>
        </div>
        
        <div>

                <label for="tagBox">Tags</label>
               
                 
                    <input type="text" id="tagBox" class="live-search-box" runat="server"/>
                    <span class="help-block" id="helpTagBox" style="color: gold" runat="server">Enter New Tags </span>
              
                 
              



            </div>

   


        
        
        

    </form>


    <footer>

    </footer>
  

</body>
</html>
