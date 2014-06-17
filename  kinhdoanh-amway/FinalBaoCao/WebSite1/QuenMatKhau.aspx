<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="QuenMatKhau.aspx.cs" Inherits="QuenMatKhau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="border-color: #000000; border-style: solid; width: 100%; text-align: center;">
        <tr>
            <td style="text-align: right">&nbsp;</td>
            <td style="text-align: left">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">Điền mã ADA của bạn và mã ADA của nhà bảo trợ, Chọn &quot;Gửi lại mật khẩu&quot;, hệ thống sẽ gửi mật khẩu về email cho bạn.<br />
                Vui lòng đổi lại mật khẩu sau khi đăng nhập.</td>
        </tr>
        <tr>
            <td style="text-align: right">&nbsp;</td>
            <td style="text-align: left">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right">Mã ADA:&nbsp;&nbsp;&nbsp; </td>
            <td style="text-align: left">
                <asp:TextBox ID="txtMaNPP" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">Mã ADA nhà bảo trợ:&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td style="text-align: left">
                <asp:TextBox ID="txtMaNBT" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">&nbsp;</td>
            <td style="text-align: left">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right"><asp:Button ID="btnVeTrangChu" runat="server" Font-Bold="True" PostBackUrl="~/DangNhap.aspx" Text="Về trang đăng nhập" />
            </td>
            <td style="text-align: left">
        <asp:Button ID="btDoiMatKhau" runat="server" Font-Bold="True" Text="Gửi lại mật khẩu" OnClick="btDoiMatKhau_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style1">
        <asp:Label ID="lblTB" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style1">
                &nbsp;</td>
        </tr>
        </table>

    </asp:Content>

