﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NurseIndex.aspx.cs" Inherits="Hospital.Views.Index.NurseIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
  <!-- plugins:css -->
  <link rel="stylesheet" href="../../vendors/iconfonts/mdi/css/materialdesignicons.min.css"/>
  <link rel="stylesheet" href="../../vendors/css/vendor.bundle.base.css"/>
  <!-- endinject -->
  <!-- inject:css -->
  <link rel="stylesheet" href="../../css/style.css"/>
  <!-- endinject -->
  <link rel="shortcut icon" href="../../images/favicon.png" />
    <script  type="text/javascript">
        function onDistributeSucceed(res) {
            if (res == "1")
            {
                alert("分配成功");
                location.reload();
            }
            else
                alert("分配失败，请检查输入信息是否有误！");
        }
        function AddTable(rid,dename,sid, did, sbool) {
            if (sid != "0")
            {
                var tbody = document.getElementById('tbody_info');
                var tr = document.createElement('tr');
                var td1 = document.createElement('td');
                td1.innerHTML = rid;   
                var td2= document.createElement('td');
                td2.innerHTML = dename;  
                var td3 = document.createElement('td');
                td3.innerHTML = sid;
                var td4 = document.createElement('td');
                td4.innerHTML = did;
                var la = document.createElement('label');
                la.innerHTML = "占";
                la.className = "badge badge-danger";
                la.id = sid;
                var td5 = document.createElement('td');
                td5.appendChild(la);
                if (sbool == '0') {
                    la.innerHTML = "空";
                    la.className = "badge badge-info";
                    la.addEventListener("click", function () {
                        var c = document.getElementById('Patient_ID').value;
                        if (c == "")
                        {
                            alert("请输入病人住院编号！")
                        }
                        else
                        {
                            PageMethods.Distribute(sid, c, onDistributeSucceed);
                        }                                               
                    }, false);                    
                } 
                tr.appendChild(td1);
                tr.appendChild(td2);
                tr.appendChild(td3);
                tr.appendChild(td4);
                tr.appendChild(td5);
                tbody.appendChild(tr);
            }          
        }
    </script>
    <title>医护工作站</title>
</head>
<body>
    <form runat="server">
    <div class="container-scroller">
    <!-- partial:partials/_navbar.html -->
    <nav class="navbar default-layout-navbar col-lg-12 col-12 p-0 fixed-top d-flex flex-row">
      <div class="text-center navbar-brand-wrapper d-flex align-items-center justify-content-center">
        <a class="navbar-brand brand-logo" href="NurseIndex.aspx">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="../../images/hlogo.jpg" alt="logo"/> 医护工作站</a>
      </div>
      <div class="navbar-menu-wrapper d-flex align-items-stretch">
        <div class="search-field d-none d-md-block">
                <div class="input-group">
                    <div class="input-group-prepend bg-transparent">
                        <i class="input-group-text border-0 mdi mdi-magnify"></i>
                    </div>
                    <input type="text" class="form-control bg-transparent border-0" placeholder="查询" />
                </div>
        </div>
        <ul class="navbar-nav navbar-nav-right">
          <li class="nav-item nav-profile dropdown">
            <a class="nav-link dropdown-toggle" id="profileDropdown" href="#" data-toggle="dropdown" aria-expanded="false">
              <div class="nav-profile-img">
                <img src="../../images/faces/face1.jpg" alt="image"/>
                <span class="availability-status online"></span>             
              </div>
              <div class="nav-profile-text">
                <p class="mb-1 text-black">尊敬的用户，您好！</p>
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
            <a class="nav-link" href="/Views/Index/Nurse1Index.aspx">
              <span class="menu-title">首页</span>
              <i class="mdi mdi-home menu-icon"></i>
            </a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="/Views/Index/Nurse1Index.aspx">
              <span class="menu-title">分配病床</span>
              <i class="mdi mdi-crosshairs-gps menu-icon"></i>
            </a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="/Views/Nurse/Nurse_AdviceManage.aspx">
              <span class="menu-title">医嘱管理</span>
              <i class="mdi mdi-contacts menu-icon"></i>
            </a>
          </li>
        </ul>
      </nav>
      <!-- partial -->
      <div class="main-panel">
        <div class="content-wrapper">
            <div class="row">
         <div class="col-12 grid-margin">
              <div class="card">
                <div class="card-body">
                  <h4 class="card-title">患者信息</h4>                                   
                     <div class="row">
                       <div class="col-md-6">
                        <div class="form-group row">
                          <label class="col-sm-3 col-form-label">病人编号</label>
                          <div class="col-sm-9">
                            <input type="text" class="form-control" id="Patient_ID" runat="server"/>
                          </div>
                        </div>
                      </div>
                      <div class="col-md-6">
                        <div class="form-group row">
                          <div class="col-sm-3">
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-gradient-primary mr-2" Text="查询" OnClick="search_Click"/>
                          </div>
                        </div>
                      </div> 
                    </div>
			        <div class="row">
                      <div class="col-md-6">
                        <div class="form-group row">
                          <label class="col-sm-3 col-form-label">患者姓名</label>
                          <div class="col-sm-9">
                            <input type="text" id="pname" runat="server" readonly="true"  class="form-control" />
                          </div>
                        </div>
                      </div>
                      <div class="col-md-6">
                        <div class="form-group row">
                          <label class="col-sm-3 col-form-label">年龄</label>
                          <div class="col-sm-9">
                            <input type="text" id="patientage" runat="server" readonly="true"  class="form-control" />
                          </div>
                        </div>
                      </div>
                    </div>
                    <div class="row">
                      <div class="col-md-6">
                        <div class="form-group row">
                          <label class="col-sm-3 col-form-label">性别</label>
                          <div class="col-sm-9">
                            <input class="form-control" type="text" id="patientsex" readonly="true" runat="server"/>
                          </div>
                        </div>
                      </div>
                     <div class="col-md-6">
                        <div class="form-group row">
                          <label class="col-sm-3 col-form-label">联系方式</label>
                          <div class="col-sm-9">
                            <input type="text" class="form-control" readonly="true" runat="server" id="pphone" />
                          </div>
                        </div>
                      </div>                      
                  </div>
                    <div class="row">
                      <div class="col-md-6">
                        <div class="form-group row">
                          <label class="col-sm-3 col-form-label">科室</label>
                          <div class="col-sm-9">
                            <input type="text" class="form-control" readonly="true" id="pdepart" runat="server" />
                          </div>
                        </div>
                      </div>
                      <div class="col-md-6">
                        <div class="form-group row">
                          <label class="col-sm-3 col-form-label">主治医生</label>
                          <div class="col-sm-9">
                            <input type="text" class="form-control" readonly="true" id="pdoctor" runat="server" />
                          </div>
                        </div>
                      </div>
                    </div>
                </div>
              </div>
            </div>
          </div>
            <div class="col-lg-12 grid-margin stretch-card">
              <div class="card">
                <div class="card-body" id="div_info">
                  <h4 class="card-title">床位一览</h4>
                  <table class="table">
                    <thead>
                      <tr>
                        <th>病房</th>
                        <th>科室</th>
                        <th>床位</th>
                        <th>病人</th>
                        <th>状态</th>
                      </tr>
                    </thead>
                    <tbody id="tbody_info">  
                    </tbody>
                  </table>              
                </div>
              </div>
            </div>
        <!-- content-wrapper ends -->
       </div>       
      </div>
      <!-- main-panel ends -->
    </div>
    </div>
    <!-- page-body-wrapper ends -->
  <!-- container-scroller -->
    <input id="bed" type="hidden" runat="server"/>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    </form>

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
