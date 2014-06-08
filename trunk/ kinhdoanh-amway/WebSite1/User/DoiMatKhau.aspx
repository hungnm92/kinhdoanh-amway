<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="DoiMatKhau.aspx.cs" Inherits="User_DoiMatKhau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <br />
    <table style="width: 100%;">
        <tr>
            <td>Mã ADA:</td>
            <td>
        <asp:TextBox ID="txtMaNPP" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Mật khẩu cũ: </td>
            <td>
        <asp:TextBox ID="txtMatKhauCu" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Mật khẩu mới: </td>
            <td>
        <asp:TextBox ID="txtMatKhauMoi" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
			runat="server" 
			ErrorMessage="Độ dài phải từ 6 đến 50 kí tự"
			ControlToValidate="txtMatKhauMoi" 
			ValidationExpression=".{6,50}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="white-space: nowrap">Mật khẩu xác nhận: </td>
            <td>
        <asp:TextBox ID="txtMatKhauXN" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
			runat="server" 
			ErrorMessage="Độ dài phải từ 6 đến 50 kí tự"
			ControlToValidate="txtMatKhauXN" 
			ValidationExpression=".{6,50}"></asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>
    <br />
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnVeTrangChu" runat="server" Font-Bold="True" PostBackUrl="~/User/TrangChu.aspx" Text="Về trang chủ" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btDoiMatKhau" runat="server" Font-Bold="True" OnClick="btDoiMatKhau_Click" Text="Đổi mật khẩu" />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblTB" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>
    </p>
</asp:Content>

