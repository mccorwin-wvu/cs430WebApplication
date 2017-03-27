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
</style>
   
    
</head>
<body>

 

    <div class="container">

<div class="row" style="margin-top:20px">
    <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3">
		<form role="form" runat="server">
			<fieldset>
				<h2 class = "text-center" style="color: #ffed00">Please Sign In </h2>
				<hr class="colorgraph">
				<div class="form-group">
                    <input type="email" name="email" id="em" class="form-control input-lg" placeholder="Email Address" runat="server">
				</div>
				<div class="form-group">
                    <input type="password" name="password" id="pass" class="form-control input-lg" placeholder="Password" runat="server">
				</div>
				<span class="button-checkbox" style="color:#ffd800">
                    <input type="checkbox" name="remember_me" id="remember_me" checked="checked"> Remember Me
					<a href="" class="btn btn-link pull-right" style="color:#ffd800">Forgot Password?</a>
				</span>
				<hr class="colorgraph">
				<div class="row">
					<div class="col-xs-6 col-sm-6 col-md-6">
                        
                        <asp:Button ID="LogIn" runat="server" OnClick="Submit_Click" class="btn btn-lg btn-success btn-block" Text="Sign In" />
					</div>
					<div class="col-xs-6 col-sm-6 col-md-6">
						<a href="Register.aspx" class="btn btn-lg btn-primary btn-block">Register</a>
                        
					</div>
				</div>
			</fieldset>
		</form>
	</div>
</div>

</div>




    




</body> 
</html>
