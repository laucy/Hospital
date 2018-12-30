<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LLogin.aspx.cs" Inherits="Hospital.Views.LLogin.LLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <!-- Required meta tags -->
  <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
  <title>登录</title>
  <!-- plugins:css -->
  <link rel="stylesheet" href="../../vendors/iconfonts/mdi/css/materialdesignicons.min.css"/>
  <link rel="stylesheet" href="../../vendors/css/vendor.bundle.base.css"/>
  <!-- endinject -->
  <!-- plugin css for this page -->
  <!-- End plugin css for this page -->
  <!-- inject:css -->
  <link rel="stylesheet" href="../../css/style.css"/>
  <!-- endinject -->
  <link rel="shortcut icon" href="../../images/favicon.png" />
</head>
<body>
    <div class="container-scroller">
    <div class="container-fluid page-body-wrapper full-page-wrapper">
      <div class="content-wrapper d-flex align-items-center auth">
        <div class="row w-100">
          <div class="col-lg-4 mx-auto">
            <div class="auth-form-light text-left p-5">
              <div class="brand-logo">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<img src="../../images/hlogo.jpg"></div>
              <h4> &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 欢迎来到双口医院！</h4>
              <h6 class="font-weight-light"> &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 用户登录</h6>
              <form class="pt-3" runat="server">
                <div class="form-group">
                  <input type="text" class="form-control form-control-lg" id="UserID" runat="server" placeholder="用户名"/>
                </div>
                <div class="form-group">
                  <input type="password" class="form-control form-control-lg" id="Password" runat="server" placeholder="密码"/>
                </div>
                <div class="mt-3">
                  <asp:Button class="btn btn-block btn-gradient-primary btn-lg font-weight-medium auth-form-btn" ID="but_login" OnClick="but_login_Click" runat="server" Text="登录"></asp:Button>
                </div>
                <div class="my-2 d-flex justify-content-between align-items-center">
                  <div class="form-check">
                    <label class="form-check-label text-muted">
                      <input type="checkbox" class="form-check-input"/>
                      记住密码
                    </label>
                  </div>
                  <a href="#" class="auth-link text-black">忘记密码?</a>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
      <!-- content-wrapper ends -->
    </div>
    <!-- page-body-wrapper ends -->
  </div>
  <!-- container-scroller -->
  <!-- plugins:js -->
  <script src="../../vendors/js/vendor.bundle.base.js"></script>
  <script src="../../vendors/js/vendor.bundle.addons.js"></script>
  <!-- endinject -->
  <!-- inject:js -->
  <script src="../../js/off-canvas.js"></script>
  <script src="../../js/misc.js"></script>
  <!-- endinject -->



</body>
</html>
