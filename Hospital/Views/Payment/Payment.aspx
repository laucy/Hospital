<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Hospital.Views.Payment.Payment" %>

<!DOCTYPE html>
<html lang="en">

<head>
  <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <title>医院管理系统--收费处</title>
  <!-- plugins:css -->
  <link rel="stylesheet" href="../../vendors/iconfonts/mdi/css/materialdesignicons.min.css">
  <link rel="stylesheet" href="../../vendors/css/vendor.bundle.base.css">
  <!-- endinject -->
  <!-- inject:css -->
  <link rel="stylesheet" href="../../css/style.css">
  <!-- endinject -->
  <link rel="shortcut icon" href="../../images/favicon.png" />
</head>
<body>
  <div class="container-scroller">
    <!-- partial:partials/_navbar.html -->
    <nav class="navbar default-layout-navbar col-lg-12 col-12 p-0 fixed-top d-flex flex-row">
      <div class="text-center navbar-brand-wrapper d-flex align-items-center justify-content-center">
        <a class="navbar-brand brand-logo" href="index.html">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="../../images/hlogo.jpg" alt="logo"/> 医院管理系统</a>
      </div>
      <div class="navbar-menu-wrapper d-flex align-items-stretch">
        <div class="search-field d-none d-md-block">
          <form class="d-flex align-items-center h-100" action="#">
            <div class="input-group">
              <div class="input-group-prepend bg-transparent">
                  <i class="input-group-text border-0 mdi mdi-magnify"></i>                
              </div>
              <input type="text" class="form-control bg-transparent border-0" placeholder="查询">
            </div>
          </form>
        </div>
        <ul class="navbar-nav navbar-nav-right">
          <li class="nav-item nav-profile dropdown">
            <a class="nav-link dropdown-toggle" id="profileDropdown" href="#" data-toggle="dropdown" aria-expanded="false">
              <div class="nav-profile-img">
                <img src="../../images/faces/face1.jpg" alt="image">
                <span class="availability-status online"></span>             
              </div>
              <div class="nav-profile-text">
                <p class="mb-1 text-black">财务人员，您好！</p>
              </div>
            </a>
            <div class="dropdown-menu navbar-dropdown" aria-labelledby="profileDropdown">
              <div class="dropdown-divider"></div>
              <a class="dropdown-item" href="#">
                <i class="mdi mdi-logout mr-2 text-primary"></i>
                Signout
              </a>
            </div>
          </li>
          <li class="nav-item d-none d-lg-block full-screen-link">
            <a class="nav-link">
              <i class="mdi mdi-fullscreen" id="fullscreen-button"></i>
            </a>
          </li>
          <li class="nav-item dropdown">
            <a class="nav-link count-indicator dropdown-toggle" id="messageDropdown" href="#" data-toggle="dropdown" aria-expanded="false">
              <i class="mdi mdi-email-outline"></i>
              <span class="count-symbol bg-warning"></span>
            </a>
          </li>
          <li class="nav-item dropdown">
            <a class="nav-link count-indicator dropdown-toggle" id="notificationDropdown" href="#" data-toggle="dropdown">
              <i class="mdi mdi-bell-outline"></i>
              <span class="count-symbol bg-danger"></span>
            </a>    
          </li>
          <li class="nav-item nav-logout d-none d-lg-block">
            <a class="nav-link" href="#">
              <i class="mdi mdi-power"></i>
            </a>
          </li>
          <li class="nav-item nav-settings d-none d-lg-block">
            <a class="nav-link" href="#">
              <i class="mdi mdi-format-line-spacing"></i>
            </a>
          </li>
        </ul>
        <button class="navbar-toggler navbar-toggler-right d-lg-none align-self-center" type="button" data-toggle="offcanvas">
          <span class="mdi mdi-menu"></span>
        </button>
      </div>
    </nav>
    <!-- partial -->
    <div class="container-fluid page-body-wrapper">
      <!-- partial:partials/_sidebar.html -->
      <nav class="sidebar sidebar-offcanvas" id="sidebar">
        <ul class="nav">      
          <li class="nav-item">
            <a class="nav-link" href="../Index/CashierIndex.aspx">
              <span class="menu-title">首页</span>
              <i class="mdi mdi-home menu-icon"></i>
            </a>
          </li>
          <li class="nav-item">
            <a class="nav-link"  href="../CashierRegister/CashierRegister.aspx">
              <span class="menu-title">挂号</span>
              <i class="mdi mdi-crosshairs-gps menu-icon"></i>
            </a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="Payment.aspx"
              <span class="menu-title">缴费</span>
              <i class="mdi mdi-contacts menu-icon"></i>
            </a>
          </li>
        </ul>
      </nav>
      <!-- partial -->
      <div class="main-panel">
        <div class="content-wrapper">
          <div class="page-header">
            <h3 class="page-title">
              <span class="page-title-icon bg-gradient-primary text-white mr-2">
                <i class="mdi mdi-contacts"></i>                 
              </span>
              关心病人，服务病人！
            </h3>
          </div>
            <form runat="server">
            <div class="row">          
            <div class="col-lg-12 grid-margin stretch-card">
              <div class="card">
                <div class="card-body"> 
                  <h4 class="card-title">缴费清单</h4>
                  <p class="card-description">                    
                     Payment list                
                  </p>
                  <asp:Label ID="patientid" runat="server" Text="病人编号"></asp:Label>
                  <asp:TextBox ID="pid" runat="server"></asp:TextBox>
                  <asp:Label ID="patientname" runat="server" Text="病人姓名"></asp:Label>
                  <asp:TextBox ID="pname" runat="server"></asp:TextBox>&nbsp&nbsp&nbsp  
                  <asp:Button ID="search" CssClass="btn btn-gradient-primary mr-2" runat="server" Text="查询" />
                </div>
              </div>
            </div>            
          </div>
            <div class="row">          
            <div class="col-lg-12 grid-margin stretch-card">
              <div class="card">
                <div class="card-body">
                  <h4 class="card-title">医药费</h4>
                  <p class="card-description">Medical expenses
                  </p>
                  <table class="table table-striped">
                    <thead>
                      <tr>
                        <th>
                          药品名称
                        </th>
                        <th>
                          单价
                        </th>
                        <th>
                          数量
                        </th>
                        <th>
                          规格
                        </th>
                        <th>
                          金额
                        </th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr>
                        <td class="py-1">
                          <img src="../../images/faces-clipart/pic-1.png" alt="image"/>
                        </td>
                        <td>
                          Herman Beck
                        </td>
                        <td>
                          <div class="progress">
                            <div class="progress-bar bg-success" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                          </div>
                        </td>
                        <td>
                          $ 77.99
                        </td>
                        <td>
                          May 15, 2015
                        </td>
                      </tr>
                      <tr>
                        <td class="py-1">
                          <img src="../../images/faces-clipart/pic-2.png" alt="image"/>
                        </td>
                        <td>
                          Messsy Adam
                        </td>
                        <td>
                          <div class="progress">
                            <div class="progress-bar bg-danger" role="progressbar" style="width: 75%" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100"></div>
                          </div>
                        </td>
                        <td>
                          $245.30
                        </td>
                        <td>
                          July 1, 2015
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </div>
              </div>
            </div>            
          </div>
            <div class="row">          
            <div class="col-lg-12 grid-margin stretch-card">
              <div class="card">
                <div class="card-body"> 
                  <h4 class="card-title">检查费</h4>
                  <p class="card-description">
                      Inspection fee 
                  </p>
                  <table class="table table-striped">
                    <thead>
                      <tr>
                        <th>
                          检查项目
                        </th>
                        <th>
                          单价
                        </th>
                        <th>
                          数量
                        </th>
                        <th>
                          金额
                        </th>                       
                      </tr>
                    </thead>
                    <tbody>
                      <tr>
                        <td class="py-1">
                          <img src="../../images/faces-clipart/pic-1.png" alt="image"/>
                        </td>
                        <td>
                          Herman Beck
                        </td>
                        <td>
                          <div class="progress">
                            <div class="progress-bar bg-success" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                          </div>
                        </td>
                        <td>
                          $ 77.99
                        </td>
                       
                      </tr>
                      <tr>
                        <td class="py-1">
                          <img src="../../images/faces-clipart/pic-2.png" alt="image"/>
                        </td>
                        <td>
                          Messsy Adam
                        </td>
                        <td>
                          <div class="progress">
                            <div class="progress-bar bg-danger" role="progressbar" style="width: 75%" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100"></div>
                          </div>
                        </td>
                        <td>
                          $245.30
                        </td>
                        
                      </tr>
                    </tbody>
                  </table>
                </div>
              </div>
            </div>            
          </div>
            <div class="row">          
            <div class="col-lg-12 grid-margin stretch-card">
              <div class="card">
                <div class="card-body">
                 <h4 class="card-title">住院费</h4>
                  <p class="card-description">                   
                     hospitalization expenses 
                  </p>
                  <table class="table table-striped">
                    <thead>
                      <tr>
                        <th>
                          入院时间
                        </th>
                        <th>
                          出院时间
                        </th>
                        <th>
                          天数
                        </th>
                        <th>
                          单价
                        </th>
                        <th>
                          金额
                        </th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr>
                        <td class="py-1">
                          <img src="../../images/faces-clipart/pic-1.png" alt="image"/>
                        </td>
                        <td>
                          Herman Beck
                        </td>
                        <td>
                          <div class="progress">
                            <div class="progress-bar bg-success" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                          </div>
                        </td>
                        <td>
                          $ 77.99
                        </td>
                        <td>
                          May 15, 2015
                        </td>
                      </tr>
                      <tr>
                        <td class="py-1">
                          <img src="../../images/faces-clipart/pic-2.png" alt="image"/>
                        </td>
                        <td>
                          Messsy Adam
                        </td>
                        <td>
                          <div class="progress">
                            <div class="progress-bar bg-danger" role="progressbar" style="width: 75%" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100"></div>
                          </div>
                        </td>
                        <td>
                          $245.30
                        </td>
                        <td>
                          July 1, 2015
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </div>
              </div>
            </div>            
          </div>
            </form>
          </div>
        </div>
        <!-- content-wrapper ends -->       
      </div>
      <!-- main-panel ends -->
    </div>
    <!-- page-body-wrapper ends -->

  <!-- container-scroller -->

  <!-- plugins:js -->
  <script src="../../vendors/js/vendor.bundle.base.js"></script>
  <script src="../../vendors/js/vendor.bundle.addons.js"></script>
  <!-- endinject -->
  <!-- Plugin js for this page-->
  <!-- End plugin js for this page-->
  <!-- inject:js -->
  <script src="../../js/off-canvas.js"></script>
  <script src="../../js/misc.js"></script>
  <!-- endinject -->
  <!-- Custom js for this page-->
  <script src="../../js/dashboard.js"></script>
  <!-- End custom js for this page-->
</body>

</html>


