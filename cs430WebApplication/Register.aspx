<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="cs430WebApplication.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="Main.css" rel="stylesheet" />

    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.1.1.min.js"></script>

    <title></title>


   
</head>

    
<body>

    <header>

        <h1 id="loginText" style="width: auto">
            


            <img id="titleImg" src="http://img.scout.com/sites/default/files/west_virginia_mountaineers.png" />Register </h1>



    
   </header>

    <script>



        var noErrfn = true;
        var noErrln = true;
        var noErrem = true;
        var noErrps = true;

        function checkFilledFn() {
            var inputVal = document.getElementById("firstName");
            if (inputVal.value == "") {
                inputVal.style.border = "thick solid red";

                noErrfn = false;

            }
            else {
                inputVal.style.border = "thick solid green";

                noErrfn = true;

            }
        }

        function checkFilledLn() {
            var inputVal = document.getElementById("lastName");
            if (inputVal.value == "") {
                inputVal.style.border = "thick solid red";

                noErrln = false;
            }
            else {
                inputVal.style.border = "thick solid green";

                noErrln = true;
            }
        }


        function checkFilledEmail() {
            var inputVal = document.getElementById("email");
            if (inputVal.value.match(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/g) == null) {
                inputVal.style.border = "thick solid red";

                noErrem = false;
            }
            else {
                inputVal.style.border = "thick solid green";


                noErrem = true;
            }
        }


        function checkFilledPass() {
            var inputVal1 = document.getElementById("password");
            var inputVal2 = document.getElementById("confirmPassword");


            if (inputVal1.value.localeCompare(inputVal2.value) != 0 || inputVal1.value.length < 6) {

                inputVal1.style.border = "thick solid red";
                inputVal2.style.border = "thick solid red";

                noErrps = false;
            }
            else {
                inputVal1.style.border = "thick solid green";
                inputVal2.style.border = "thick solid green";

                noErrps = true;
            }
        }

        function buttonRdy() {
            if (noErrfn == true && noErrln == true && noErrem == true && noErrps == true) {
                document.getElementById("Button1").disabled = false;

            }
            else {
                document.getElementById("Button1").disabled = true;
            }



        }




    </script>

    <form runat="server">

            <div>
                
               <label for="firstName">First Name</label>
               
               <input type="text" id="firstName" placeholder="First Name" onchange="checkFilledFn();" class="inputs" runat="server" autofocus>
                
            </div>

            <div class="form-group">
                <label for="lastName">Last Name</label>
                
                    <input type="text" id="lastName" placeholder="Last Name" onchange="checkFilledLn(); buttonRdy();" class="inputs"  runat="server" autofocus>
                
            </div>

            <div>
                <label for="email" >Email</label>
                
                <input type="email" id="email" placeholder="Email" onchange="checkFilledEmail(); buttonRdy();" runat="server" class="inputs">
                
            </div>

            <div>
                    <label for="password">Password</label>
               
                    <input type="password" id="password" placeholder="Password" onchange="checkFilledPass(); buttonRdy();" runat="server" class="inputs">
                    
                
                
            </div>

            <div>
                <label for="confirmPassword">Confirm Password</label>
               
                    <input type="password" id="confirmPassword" placeholder="Confirm Password" onchange="checkFilledPass(); buttonRdy();" runat="server" class="inputs">
                
            </div>

            


            <div>
                <label for="School">School</label>
                
                    <select id="School" class="inputs" runat="server">
                        <option class="inputs">West Virginia University</option>

                    </select>
                
            </div>





             <div>

                <label for="tagBox">Tags</label>
               
                 
                    <input type="text" id="tagBox" class="live-search-box" runat="server" placeholder="search here" />
                    <span class="help-block" style="color: blue">Enter Tags That interest you separated by commas, eg. Basketball,football,pizza</span>
                
                 


            </div>

            <div>

                 <asp:Button type="submit" ID="Button1" runat="server" OnClick="Submit_Click" Text="Register" class="buttonGold"  />

            </div>



   


        </form>


            

           

       




    <footer>

    </footer>






</body>

    
<script>
    checkFilledFn();
    checkFilledLn();
    checkFilledEmail();
    checkFilledPass();
    buttonRdy();

</script>


</html>
