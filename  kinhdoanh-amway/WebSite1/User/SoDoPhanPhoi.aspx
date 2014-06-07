<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SoDoPhanPhoi.aspx.cs" Inherits="User_SoDoPhanPhoi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../style/SoDoPhanPhoi.css" rel="stylesheet" />
    <script type="text/javascript">// Lưu Session khi click vào menu.
        function setSession(value) {
            document.location.href = "TrangChu.aspx?MaADA=" + value//Điều hướng tới TrangChu và gán Id = giá trị vào
        }
    </script> 
</head>
<body>
    <form id="form1" runat="server">
    <div class="tree" style=" width: 20000px; height: auto;">
        <asp:Label ID="lblmenu" runat="server" Text="Menu"></asp:Label>
    </div>
    </form>
</body>
</html>
