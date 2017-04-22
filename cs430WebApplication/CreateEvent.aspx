<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="cs430WebApplication.WebForm4" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Main.css" rel="stylesheet" />
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.1.1.min.js"></script>
    <title>Create Event</title>
</head>
<body>
    <header>

        <h1 id="loginText" style="width: auto">



            <img id="titleImg" src="http://img.scout.com/sites/default/files/west_virginia_mountaineers.png" />Create an Event</h1>



    </header>


    <form runat="server">

          <div>
                
               <label for="eventName">Event Name</label>
               
               <input type="text" id="eventName" placeholder="Event Name" class="inputs" runat="server">
               

                
          </div>

          <div>
              
              
              <label for="eventDate">Event Date and Time</label>

              <input type="datetime-local" id="eventDate" runat="server">
            
          </div>


        <div>
                
               <label for="eventName">Event Location</label>
               
               <input type="text" id="eventLocation" placeholder="address, building name, or room number" class="inputs" runat="server">

                
          </div>
         

           

        <div>

             <label for="tags">Tags</label>
               
               <input type="text" id="tags" placeholder="football,basketball,pizza....." class="inputs" runat="server">
           

        </div>


        <div>
                
               <label for="eventDes">Event Description</label>
               
               
                <textarea id="eventDes" class="inputs" runat="server" ></textarea>

                
        </div>

        <div>
              <asp:Button type="submit" ID="event_sub" runat="server" OnClick="Submit_Event" Text="Create" class="buttonGold"  />

        </div>

    </form>
</body>
</html>
