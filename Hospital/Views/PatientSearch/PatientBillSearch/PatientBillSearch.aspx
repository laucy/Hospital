﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientBillSearch.aspx.cs" Inherits="Hospital.Views.PatientSearch.PatientBillSearch.PatientBillSearch" %>

<!DOCTYPE html>
<html lang="en">

<head>
  <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <title>医院管理系统--用户账单查询</title>
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
        <a class="navbar-brand brand-logo" href="index.html">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="../../../images/hlogo.jpg" alt="logo"/> 医院管理系统</a>
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
                <p runat="server" class="mb-1 text-black">尊敬的<%=patients[0].P_Name%><%=sex%>，您好！</p>
              </div>
            </a>
            <div class="dropdown-menu navbar-dropdown" aria-labelledby="profileDropdown">
              <div class="dropdown-divider"></div>
              <a class="dropdown-item" href="../LLogin/LLogin.aspx">
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
            <a class="nav-link" href="../../Index/PatientIndex.aspx">
              <span class="menu-title">首页</span>
              <i class="mdi mdi-home menu-icon"></i>
            </a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="../PatientCaseSearch/PatientCaseSearch.aspx" >
              <span class="menu-title">病历查询</span>
              <i class="mdi mdi-crosshairs-gps menu-icon"></i>
            </a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="PatientBillSearch.aspx">
              <span class="menu-title">账单查询</span>
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
                <i class="mdi mdi-home"></i>                 
              </span>
              祝您早日康复！
            </h3>
          </div>
          <form runat="server">
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
                          单价/元
                        </th>
                        <th>
                          数量
                        </th>                    
                        <th>
                          金额/元
                        </th>
                      </tr>
                    </thead>
                    <tbody>
                    <%if (prescripts != null)
                        { %>
                      <%for (int i = 0; i < prescripts.Count; i++)
                          { %>
                        <tr>
                         <td><%=prescripts[i].D_Name %></td>
                         <td><%=sellingprice[i] %></td>
                         <td><%=prescripts[i].D_Number %></td>   
                         <td><%=prescripts[i].D_Totalprice %></td> 
                       </tr> 
                      <%} %>
                    <%} %>
                    </tbody>
                  </table>
                   <asp:TextBox BorderStyle="None" runat="server" Text=""></asp:TextBox>
                  <asp:TextBox BorderStyle="None" runat="server" Text=""></asp:TextBox>
                  <asp:TextBox BorderStyle="None" runat="server" Text=""></asp:TextBox>
                  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                  <label>总计：</label> 
                  <asp:Label ID="sum1" runat="server"></asp:Label>
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
                          单价/元
                        </th>
                        <th>
                          数量
                        </th>
                         <th>
                          时间
                        </th>
                        <th>
                          金额/元
                        </th>                       
                      </tr>
                    </thead>
                    <tbody>
                    <%if (tests != null)
                        { %>
                      <%for (int i = 0; i < tests.Count; i++)
                          { %>
                        <tr>
                         <td><%=tests[i].IT_Name %>                  </td>
                         <td><%=tests[i].IT_Price %></td>
                         <td> 1 </td>
                         <td><%=tests[i].T_Date.ToShortDateString() %></td>    
                         <td><%=tests[i].IT_Price %></td>                      
                       </tr> 
                      <%} %>
                    <%} %>
                    </tbody>
                  </table>
                  <asp:TextBox BorderStyle="None" runat="server" Text=""></asp:TextBox>
                  <asp:TextBox BorderStyle="None" runat="server" Text=""></asp:TextBox>
                  <asp:TextBox BorderStyle="None" runat="server" Text=""></asp:TextBox>
                  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                  <label>总计：</label> 
                  <asp:Label ID="sum2" runat="server"></asp:Label>
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
                          天数/天
                        </th>
                        <th>
                          单价/元
                        </th>
                        <th>
                          金额/元
                        </th>
                      </tr>
                    </thead>
                    <tbody>
                    <%if (hospitalizations != null)
                        { %>
                      <%for (int i = 0; i < hospitalizations.Count; i++)
                          { %>
                        <tr>
                         <td><%=hospitalizations[i].H_In.ToShortDateString() %></td>
                         <td><%=hospitalizations[i].H_Out.ToShortDateString() %></td>
                         <td><%=(hospitalizations[i].H_Out-hospitalizations[i].H_In).Days %></td>
                         <td>50</td>    
                         <td><%=hospitalizations[i].H_Sum %></td>                      
                       </tr> 
                      <%} %>
                    <%} %>
                    </tbody>
                  </table>
                  <asp:TextBox BorderStyle="None" runat="server" Text=""></asp:TextBox>
                  <asp:TextBox BorderStyle="None" runat="server" Text=""></asp:TextBox>
                  <asp:TextBox BorderStyle="None" runat="server" Text=""></asp:TextBox>
                  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                  <label>总计：</label> 
                  <asp:Label ID="sum3" runat="server"></asp:Label>
                  <br />
                  <asp:TextBox BorderStyle="None" runat="server" Text=""></asp:TextBox>
                  <asp:TextBox BorderStyle="None" runat="server" Text=""></asp:TextBox>
                  <asp:TextBox BorderStyle="None" runat="server" Text=""></asp:TextBox>
                  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                  <label>共计：</label> 
                  <asp:Label ID="sum" runat="server"></asp:Label>
                </div>
              </div>
            </div>            
          </div> 
              &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
             <asp:Button runat="server" ID="back" CssClass="btn btn-gradient-primary mr-2" OnClick="back_Click" Text="返回" />
            </form>       
        </div>
        <!-- content-wrapper ends -->       
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


