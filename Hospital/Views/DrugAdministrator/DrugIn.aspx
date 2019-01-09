﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DrugIn.aspx.cs" Inherits="Hospital.Views.DrugAdministrator.DrugIn" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>医院管理系统--医生</title>
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
                <a class="navbar-brand brand-logo" href="index.html">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="../../images/hlogo.jpg" alt="logo" />
                    医院管理系统</a>
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
                                <p class="mb-1 text-black">医生，您好！</p>
                            </div>
                        </a>
                        <div class="dropdown-menu navbar-dropdown" aria-labelledby="profileDropdown">
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="#">
                                <i class="mdi mdi-logout mr-2 text-primary"></i>
                                退出
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
                        <a class="nav-link" href="../../Views/Index/PharmacistIndex.aspx">
                            <span class="menu-title">首页</span>
                            <i class="mdi mdi-home menu-icon"></i>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="RegisteredDrugs.aspx" aria-expanded="false" aria-controls="ui-basic">
                            <span class="menu-title">药品登记</span>
                            <i class="mdi mdi-crosshairs-gps menu-icon"></i>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="DrugIn.aspx" data-toggle="collapse">
                            <span class="menu-title">药品入库</span>
                            <i class="mdi mdi-contacts menu-icon"></i>
                        </a>
                    </li>
                     <li class="nav-item">
                        <a class="nav-link" href="DrugOut.aspx">
                            <span class="menu-title">药品出库</span>
                            <i class="mdi mdi-contacts menu-icon"></i>
                        </a>
                    </li>
                     <li class="nav-item">
                        <a class="nav-link"  href="DrugStore.aspx">
                            <span class="menu-title">查看药品库存</span>
                            <i class="mdi mdi-contacts menu-icon"></i>
                        </a>
                    </li>
                </ul>
            </nav>
            <!-- partial -->
            <div class="main-panel">
                <div class="content-wrapper">
                    <h3 class="page-title">
                        <span class="page-title-icon bg-gradient-primary text-white mr-2">
                            <i class="mdi mdi-home"></i>
                        </span>
                        关心病人，服务病人！
                    </h3>
                    <div class="col-12 grid-margin stretch-card">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">登记药品</h4>
                                <form class="forms-sample" runat="server">
                                    <div class="form-group">
                                        <label>药品ID</label>
                                        <input type="file" name="img[]" class="file-upload-default">
                                        <div class="input-group col-xs-12">
                                            <input type="text" class="form-control file-upload-info" id="drug_ID" runat="server" />
                                            <asp:Button ID="Search_Drug" runat="server" Text="查找" class="btn btn-gradient-primary mr-2" OnClick="Search_Drug_Click" />
                                        </div>
                                        <div class="form-group">
                                            <label>药品名称</label>
                                            <div class="input-group col-xs-12">
                                                <input type="text" class="form-control file-upload-info" id="drug_Name" runat="server" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label>药品规格</label>
                                            <div class="input-group col-xs-12">
                                                <input type="text" class="form-control file-upload-info" id="drug_Standard" runat="server" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label>药品进价</label>
                                            <div class="input-group col-xs-12">
                                                <input type="text" class="form-control file-upload-info" id="drug_PurchasingPrice" runat="server" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label>药品售价</label>
                                            <div class="input-group col-xs-12">
                                                <input type="text" class="form-control file-upload-info" id="drug_SellingPrice" runat="server" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label>进货量</label>
                                            <div class="input-group col-xs-12">
                                                <input type="text" class="form-control file-upload-info" id="drugin_number" runat="server" />
                                            </div>
                                        </div>
                                        <div style="text-align: center" runat="server">
                                            <asp:Button ID="DrugsIn" runat="server" Text="入库" class="btn btn-gradient-primary mr-2" OnClick="DrugIn_Click" />
                                            <asp:Button ID="Cancel" runat="server" Text="取消" class="btn btn-light mr-2" OnClick="Cancel_Click" />
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- main-panel ends -->
        </div>
        <!-- page-body-wrapper ends -->
    </div>
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
