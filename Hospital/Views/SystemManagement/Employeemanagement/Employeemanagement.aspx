<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employeemanagement.aspx.cs" Inherits="Hospital.Views.SystemManagement.Employeemanagement.Employeemanagement" %>

<!DOCTYPE html>
<html lang="en">

<head>
  <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <title>医院管理系统--系统管理员</title>
  <!-- plugins:css -->
  <link rel="stylesheet" href="../../../vendors/iconfonts/mdi/css/materialdesignicons.min.css">
  <link rel="stylesheet" href="../../../vendors/css/vendor.bundle.base.css">
  <!-- endinject -->
  <!-- inject:css -->
  <link rel="stylesheet" href="../../../css/style.css">
  <!-- endinject -->
  <link rel="shortcut icon" href="../../../images/favicon.png" />
</head>
<body>
  <div class="container-scroller">
    <!-- partial:partials/_navbar.html -->
    <nav class="navbar default-layout-navbar col-lg-12 col-12 p-0 fixed-top d-flex flex-row">
      <div class="text-center navbar-brand-wrapper d-flex align-items-center justify-content-center">
        <a class="navbar-brand brand-logo" href="PatientIndex.aspx">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="../../../images/hlogo.jpg" alt="logo"/> 医院管理系统</a>
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
                <img src="../../../images/faces/face1.jpg" alt="image">
                <span class="availability-status online"></span>             
              </div>
              <div class="nav-profile-text">
                <p runat="server" class="mb-1 text-black">系统管理员，您好！</p>
              </div>
            </a>
            <div class="dropdown-menu navbar-dropdown" aria-labelledby="profileDropdown">
              <div class="dropdown-divider"></div>
              <a class="dropdown-item" href="../LLogin/LLogin.aspx">
                <i class="mdi mdi-logout mr-2 text-primary"></i>
                退出登录
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
            <a class="nav-link" href="PatientIndex.aspx">
              <span class="menu-title">首页</span>
              <i class="mdi mdi-home menu-icon"></i>
            </a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="../PatientSearch/PatientCaseSearch/PatientCaseSearch.aspx" >
              <span class="menu-title">科室管理</span>
              <i class="mdi mdi-view-grid menu-icon "></i>
            </a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="../PatientSearch/PatientBillSearch/PatientBillSearch.aspx">
              <span class="menu-title">员工管理</span>
              <i class="mdi mdi-account-multiple menu-icon"></i>
            </a>
          </li>
             <li class="nav-item">
            <a class="nav-link" href="../PatientSearch/PatientBillSearch/PatientBillSearch.aspx">
              <span class="menu-title">仪器管理</span>
              <i class="mdi mdi-flask-empty-outline  menu-icon"></i>
            </a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="../PatientSearch/PatientBillSearch/PatientBillSearch.aspx">
              <span class="menu-title">病床管理</span>
              <i class="mdi mdi-hotel menu-icon"></i>
            </a>
          </li> 
        </ul>
      </nav>
      <!-- partial -->
        <div class="main-panel">
               <form runat="server">
                <div class="content-wrapper">
                    <div class="row">
                        <div class="col-12">
                        </div>
                    </div>
                    <div class="page-header">
                        <h3 class="page-title">
                            <span class="page-title-icon bg-gradient-primary text-white mr-2">
                                <i class="mdi mdi-home"></i>
                            </span>
                            关心病人，服务病人！
                        </h3>
                    </div>
                    <div class="col-lg-12 grid-margin stretch-card">                       
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">科室信息表</h4>
                                <p class="card-description">
                                    Employee Information Table
                                </p>
                                <label>员工编号</label>
                                <input id="eidtext"  runat="server"/>
                                 <label>员工姓名</label>
                                <input id="enametext"  runat="server"/>
                                <asp:Button ID="search" runat="server" Text="查找" CssClass="btn btn-gradient-primary mr-2" OnClick="search_Click"/>
                                <asp:Button ID="insert" runat="server" Text="添加" CssClass="btn btn-gradient-primary mr-2" OnClick="insert_Click"/>
                                <br /> <br /> <br /> <br />
                                <div class="row">
                                            <div class="col-lg-12 grid-margin stretch-card">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <table class="table">
                                                            <thead>
                                                                <tr>
                                                                    <th>员工ID</th>
                                                                    <th>姓名</th>
                                                                    <th>性别</th>
                                                                    <th>年龄</th>
                                                                    <th>部门名称</th>
                                                                    <th>职位编号</th>
                                                                    <th>手机号</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <%for (i = 0; i < employees.Count; i++)
                                                                    {%>
                                                                <tr>
                                                                    <td><p><a href="UpdateEmployee.aspx?E_ID=<%=Convert.ToString(employees[i].E_ID) %>"><%=Convert.ToString(employees[i].E_ID) %></a></p></td>
                                                                    <td><p><a href="UpdateEmployee.aspx?E_Name=<%=employees[i].E_Name %>"><%=employees[i].E_Name %></a></p></td>
                                                                    <td><p><a href="UpdateEmployee.aspx?E_Sex=<%=employees[i].E_Sex %>"><%=employees[i].E_Sex %></a></p></td>
                                                                    <td><p><a href="UpdateEmployee.aspx?E_Age=<%=Convert.ToString(employees[i].E_Age)%>"><%=Convert.ToString(employees[i].E_Age)%></a></p></td>
                                                                    <td><p><a href="UpdateEmployee.aspx?DE_ID=<%=Convert.ToString(employees[i].DE_ID) %>"><%=Convert.ToString(employees[i].DE_ID) %></a></p></td>
                                                                    <td><p><a href="UpdateEmployee.aspx?E_Position=<%=employees[i].E_Position %>"><%=employees[i].E_Position %></a></p></td>
                                                                    <td><p><a href="UpdateEmployee.aspx?E_Phone=<%=employees[i].E_Phone %>"><%=employees[i].E_Phone %></a></p></td>
                                                                </tr>
                                                                <%} %>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                            </div>
                        </div>
                    </div>
                </div>
               </form>
            </div>
      <!-- main-panel ends -->
    </div>
    <!-- page-body-wrapper ends -->
  </div>
  <!-- container-scroller -->

  <!-- plugins:js -->
  <script src="../../../vendors/js/vendor.bundle.base.js"></script>
  <script src="../../../vendors/js/vendor.bundle.addons.js"></script>
  <!-- endinject -->
  <!-- Plugin js for this page-->
  <!-- End plugin js for this page-->
  <!-- inject:js -->
  <script src="../../../js/off-canvas.js"></script>
  <script src="../../../js/misc.js"></script>
  <!-- endinject -->
  <!-- Custom js for this page-->
  <script src="../../../js/dashboard.js"></script>
  <!-- End custom js for this page-->
</body>

</html>










