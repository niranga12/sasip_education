<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sasip5.pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>SASIP EDUCATIONAL CENTER</title>
	<link rel="stylesheet" type="text/css" href="../assets/css/style.css">
	<link href="https://fonts.googleapis.com/css?family=Poppins:600&display=swap" rel="stylesheet">
	<script src="https://kit.fontawesome.com/a81368914c.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10"></script>

    <script type="text/javascript" >

        //Login Pass Alert
        function successalert() {
            Swal.fire({
                title: 'Congratulation',
                text: "You have been successfully Login",
                icon: 'success',
                showCancelButton: false,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'OK'
            }).then((result) => {
                if (result.isConfirmed) {
                    Swal.fire(
                        window.location.href = "dashboard.aspx"
                    )
                }
            })
        }

        //Login failed Alert
        function LoginFail() {
            Swal.fire({
                icon: 'error',
                title: 'Login Failed !',
                text: 'Incorrect User Name or Password !',
                footer: '<a href>Contact Us</a>'
            })
        }



    </script>
	<meta name="viewport" content="width=device-width, initial-scale=1">
</head>
<body>
	<img class="wave" src="../assets/img/login/wave.png">
	<div class="container">
		<div class="img">
			<img src="../assets/img/login/bg.svg">
		</div>
		<div class="login-content">
			<form runat="server">
                <h2 class="title">SASIP EDUCATION CENTER</h2>
				<img src="../assets/img/login/avatar.svg">
				
           		<div class="input-div one">
           		   <div class="i">
           		   		<i class="fas fa-user"></i>
           		   </div>
           		   <div class="div">
           		   		<h5>Username</h5>
           		   		<asp:TextBox runat="server" type="text" ID="txt_ID" class="input"></asp:TextBox>

           		   </div>

           		</div>
                      <asp:RequiredFieldValidator runat="server" ValidationGroup="Vali_save" id="reqName" controltovalidate="txt_ID" ForeColor="Red" CssClass="badge badge-danger" errormessage="Please enter User Name..!" />                                                                

           		<div class="input-div pass">
           		   <div class="i"> 
           		    	<i class="fas fa-lock"></i>
           		   </div>
           		   <div class="div">
           		    	<h5>Password</h5>
           		    	<asp:TextBox runat="server" TextMode="Password" ID="txt_pass" class="input"></asp:TextBox>

            	   </div>
            	</div>
                      <asp:RequiredFieldValidator runat="server" ValidationGroup="Vali_save" id="RequiredFieldValidator1" ForeColor="Red" controltovalidate="txt_pass" CssClass="badge badge-danger" errormessage="Please Enter Your Password..!" />                                                                

            	<a href="#">Forgot Password?</a>
            	<asp:Button runat="server" ID="btn_login"  type="submit" class="btn" Text="Login" ValidationGroup="Vali_save" OnClick="btn_login_Click"/>
            </form>
        </div>
    </div>
    <script type="text/javascript" src="../assets/js/main.js"></script>
</body>
</html>
