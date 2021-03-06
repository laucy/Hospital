﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Case.aspx.cs" Inherits="Hospital.Views.Doctor.Case" %>

<!DOCTYPE html>


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
                            <a class="dropdown-item" href="../LLogin/LLogin.aspx">
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
            <nav class="sidebar sidebar-offcanvas" id="sidebar">
                <ul class="nav">
                    <li class="nav-item">
                        <a class="nav-link" href="../../Views/Index/DoctorIndex.aspx">
                            <span class="menu-title">首页</span>
                            <i class="mdi mdi-home menu-icon"></i>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" data-toggle="collapse" href="../../Views/Doctor/Case.aspx" aria-expanded="false" aria-controls="ui-basic">
                            <span class="menu-title">填写病历</span>
                            <i class="mdi mdi-crosshairs-gps menu-icon"></i>
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
                    <div class="page-header">
                        <div class="col-12 grid-margin stretch-card">
                            <div class="card">
                                <div class="card-body">
                                    <h4 class="card-title">病历表</h4>
                                    <p class="card-description">
                                        病人信息
                                    </p>
                                    <form class="forms-sample" runat="server">
                                        <div class="form-group">
                                            <label>病人ID</label>
                                            <input type="file" name="img[]" class="file-upload-default">
                                            <div class="input-group col-xs-12">
                                                <input type="text" class="form-control file-upload-info" id="patient_ID" runat="server" />
                                                <asp:Button ID="Button2" runat="server" Text="查找" OnClick="Button2_Click1" class="file-upload-browse btn btn-gradient-primary"/>
                                            </div>
                                        </div>
                                        <div class="input-group col-xs-12">
                                            <input type="text" class="form-control file-upload-info" id="name1" runat="server" visible="false" />
                                            <input type="text" class="form-control file-upload-info" id="sex1" runat="server" visible="false" />
                                            <input type="text" class="form-control file-upload-info" id="phone1" runat="server" visible="false" />
                                            <input type="text" class="form-control file-upload-info" id="age1" runat="server" visible="false" />
                                        </div>
                                        <p class="card-description">药方</p>
                                        <div class="input-group col-xs-12">
                                            <input type="text" class="form-control file-upload-info" id="drug_name" runat="server" placeholder="药品名称" />
                                            <asp:Button ID="search_drug" class="file-upload-browse btn btn-gradient-primary" runat="server" Text="查找" OnClick="search_drug_Click" />
                                            <input type="text" class="form-control file-upload-info" id="drug_ID" runat="server" placeholder="药品ID" />
                                            <input type="text" class="form-control file-upload-info" id="drug_number" runat="server" placeholder="药品数量" />
                                            <input type="text" class="form-control file-upload-info" id="drug_note" runat="server" placeholder="注意事项" />
                                            <asp:Button ID="add_drug" runat="server" Text="添加" class="file-upload-browse btn btn-gradient-primary" OnClick="add_drug_Click" />
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-12 grid-margin stretch-card">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <p class="card-description">药品清单</p>
                                                        <table class="table">
                                                            <thead>
                                                                <tr>
                                                                    <th>药品ID</th>
                                                                    <th>药品名称</th>
                                                                    <th>药品规格</th>
                                                                    <th>单价</th>
                                                                    <th>库存</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <%for (i = 0; i < drugs.Count; i++)
                                                                    {%>
                                                                <tr>
                                                                    <td><%=drugs[i].D_ID %></td>
                                                                    <td><%=drugs[i].D_Name %></td>
                                                                    <td><%=drugs[i].D_Standard %></td>
                                                                    <td><%=Convert.ToString(drugs[i].D_SellingPrice)%></td>
                                                                    <td><%=Convert.ToString(drugs[i].D_Store) %></td>
                                                                </tr>
                                                                <%} %>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-12 grid-margin stretch-card">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <p class="card-description">药方</p>
                                                        <table class="table table-hover">
                                                            <thead>
                                                                <tr>
                                                                    <th>药品ID</th>
                                                                    <th>药品名称</th>
                                                                    <th>数量</th>
                                                                    <th>总价</th>
                                                                    <th>注意事项</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <%for (j = 0; j < prescripts.Count; j++)
                                                                    {%>
                                                                <tr>
                                                                    <td><%=prescripts[j].D_ID %></td>
                                                                    <td><%=prescripts[j].D_Name %></td>
                                                                    <td><%=prescripts[j].D_Number %></td>
                                                                    <td><%=prescripts[j].D_Totalprice %></td>
                                                                    <td><%=prescripts[j].P_Notes %></td>
                                                                </tr>
                                                                <%} %>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <p class="card-description">检查单</p>
                                        <div class="input-group col-xs-12">
                                            <input type="text" class="form-control file-upload-info" id="Text_Name" runat="server" placeholder="检查项名称" />
                                            <asp:Button ID="Button_search_text" class="file-upload-browse btn btn-gradient-primary" runat="server" Text="查找" OnClick="Button_search_text_Click" />
                                            <input type="text" class="form-control file-upload-info" id="Text_ID" runat="server" placeholder="检查项目ID" />
                                            <asp:Button ID="Button_add_text" runat="server" Text="添加" class="file-upload-browse btn btn-gradient-primary" OnClick="Button_add_text_Click" />
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-12 grid-margin stretch-card">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <p class="card-description">检查项列表</p>
                                                        <table class="table">
                                                            <thead>
                                                                <tr>
                                                                    <th>检查项ID</th>
                                                                    <th>检查项名称</th>
                                                                    <th>检查项目仪器ID</th>
                                                                    <th>检查项目单价</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <%for (k = 0; k < assessmentItems.Count; k++)
                                                                    {%>
                                                                <tr>
                                                                    <td><%=assessmentItems[k].IT_ID %></td>
                                                                    <td><%=assessmentItems[k].IT_Name %></td>
                                                                    <td><%=assessmentItems[k].I_ID %></td>
                                                                    <td><%=assessmentItems[k].IT_Price%></td>
                                                                </tr>
                                                                <%} %>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-12 grid-margin stretch-card">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <p class="card-description">检查单</p>
                                                        <table class="table table-hover">
                                                            <thead>
                                                                <tr>
                                                                    <th>检查项ID</th>
                                                                    <th>检查项名称</th>
                                                                    <th>检查项价格</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <%for (l = 0; l < tests.Count; l++)
                                                                    {%>
                                                                <tr>
                                                                    <td><%=tests[l].IT_ID %></td>
                                                                    <td><%=tests[l].IT_Name %></td>
                                                                    <td><%=tests[l].IT_Price %></td>
                                                                </tr>
                                                                <%} %>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="exampleTextarea1">病情主诉</label>
                                            <textarea class="form-control" id="Case_Complain" rows="4" runat="server"></textarea>
                                        </div>
                                        <div class="form-group">
                                            <label for="exampleTextarea1">诊断结果</label>
                                            <textarea class="form-control" id="Case_Diagnose" rows="4" runat="server"></textarea>
                                        </div>
                                        <div class="form-group">
                                            <label for="exampleTextarea1">医嘱</label>
                                            <textarea class="form-control" id="Case_Advice" rows="4" runat="server"></textarea>
                                        </div>
                                        <div style="text-align: center">
                                            <asp:RadioButton ID="hospitalization" runat="server" Text="是否住院" class="input-group col-xs-6" gravity="center_vertical" />
                                            <asp:Button ID="submit" runat="server" Text="提交" class="file-upload-browse btn btn-gradient-primary" OnClick="submit_Click" />
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>


                    </div>

                    <!-- content-wrapper ends -->
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