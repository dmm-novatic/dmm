
        <!DOCTYPE html>
        <html>
        
        <head>
            <title>Novatic Login</title>
        
            <meta charset="utf-8">
            <meta name="viewport" content="width=device-width, initial-scale=1">
            <link href="files/css/loginStyle.css" rel="stylesheet" type="text/css" media="all" />
            <meta name="keywords" content="novatic" />
            <meta name="author" content="Harry Nguyen" />
            <!-- Favicon icon -->
            <link rel="icon" href="files/assets/images/favicon.ico" type="image/x-icon">
        
            <!-- Latest compiled and minified CSS & JS -->
            <link rel="stylesheet" media="screen" href="https://netdna.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css">
            <script src="https://code.jquery.com/jquery.js"></script>
            <script src="https://netdna.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
            <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
        
            <!-- Sweet alert -->
            <script src="https://cdnjs.cloudflare.com/ajax/libs/limonte-sweetalert2/8.11.8/sweetalert2.all.min.js"></script>
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/limonte-sweetalert2/8.11.8/sweetalert2.min.css">
        
        
            <style>
                *,
                ::after,
                ::before {
                    box-sizing: unset !important;
                }
        
                body {
                    height: 100vh;
                    overflow: hidden;
                }
                .checkbox input + i:after {
                    content: url(files/images/tick.png) !important;
                    top: -1px;
                    left: 2px;
                    width: 15px;
                    height: 15px;
                }
            </style>
        </head>
        
        <body>
            <!-- main -->
            <div class="w3layouts-main">
                <div class="bg-layer">
                    <div class="header-main">
                        <div class="main-icon">
                            <!-- <span class="fa fa-eercast"></span> -->
                            <img src="files/css/ml-logo.png" style="padding: 15px;width:280px">
                        </div>
                        <div class="header-left-bottom">
                            <div method="post">
                                <div class="icon1">
                                    <span class="fa fa-user"></span>
                                    <input type="text" placeholder="Username" id="UserName" />
                                </div>
                                <div class="icon1">
                                    <span class="fa fa-lock"></span>
                                    <input type="password" id="Pass" placeholder="Password">
                                </div>
                                <div class="login-check">
                                    <label class="checkbox">
                                        <input type="checkbox" name="checkbox" checked=""><i> </i>Keep me logged in</label>
                                </div>
                                <div class="bottom">
                                    <button class="btn" id="submitVisible" style="box-sizing: border-box !important;">Log In</button>
                                </div>
                                <div class="links">
                                    <p><a>Forgot Password?</a></p>
                                    <p class="right"><a>Register</a></p>
                                    <div class="clear"></div>
                                </div>
                            </div>
                        </div>
                        <div class="social">
                            <ul>
                                <li>or login using : </li>
                                <li><a href="#" class="facebook"><span class="fa fa-facebook"></span></a></li>
                                <li><a href="#" class="twitter"><span class="fa fa-twitter"></span></a></li>
                                <li><a href="#" class="google"><span class="fa fa-google-plus"></span></a></li>
                            </ul>
                        </div>
                    </div>
        
                    <!-- copyright -->
                    <div class="copyright">
                        <p>© 2019 Novatic Technology Solution</p>
                    </div>
                    <!-- //copyright -->
                </div>
            </div>
            <!-- //main -->
        
        
            <script>
                function submit() {
                    if ($("#UserName").val().length < 1 || $("#Pass").val().length < 1) {
        
                        Swal.fire(
                            'Error',
                            'Your username or password is invalid',
                            'error'
                        );
                    } else {
                        login($("#UserName").val(), $("#Pass").val());
                    }
                }
        
        
                function login(username, password) {
        
                    $.ajax({
                        url: "http://localhost/masterlaw/config/security.php",
                        type: "POST",
                        contentType: "application/json",
                        data: JSON.stringify({
                            action: "login",
                            username: username,
                            password: password
                        }),
                        success: function(responseData) {
                            // debugger;
                            responseData = JSON.parse(responseData)
                            if (responseData.status === 200 && responseData.message === "SUCCESS") {
                                // Swal.fire(
                                //     'Login success!',
                                //     'Welcome back, ' + responseData.data[0].name + '!',
                                //     'success',
                                //     function() {
                                //         var account = responseData.data;
                                //         console.log(account);
                                //     }
                                // );
                                localStorage.setItem("currentLoggedInUser", JSON.stringify(responseData.data[0]));
                                Swal.fire({
                                    title: 'Login success!',
                                    text: 'Welcome back, ' + responseData.data[0].name + '!',
                                    type: 'success',
                                    showCancelButton: false, 
                                    confirmButtonText: 'OK'
                                }).then((result) => {
                                    if (result.value) {
                                        window.location.href = "index.php";
                                    }
                                })
                            }
                        },
                        error: function(e) {
                            //console.log(e.message);
                            Swal.fire(
                                'Login failed',
                                'Please kindly check your account information',
                                'error'
                            );
                        }
                    });
                }
        
                document.getElementById("submitVisible").addEventListener("click", submit);
            </script>
        </body>
        
        </html>
    