<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Nurse.aspx.cs" Inherits="Hospital.Views.Index.Nurse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Menu ID="Menu1" runat="server">
            <Items>
                <asp:MenuItem Text="医嘱管理" Value="医嘱管理"></asp:MenuItem>
                <asp:MenuItem Text="病床管理" Value="病床管理"></asp:MenuItem>
            </Items>
        </asp:Menu>
    </form>
</body>
</html>
