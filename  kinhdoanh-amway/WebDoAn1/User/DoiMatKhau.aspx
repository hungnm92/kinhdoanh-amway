<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="DoiMatKhau.aspx.cs" Inherits="User_DoiMatKhau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mã ADA:
        <asp:TextBox ID="txtMaADA" runat="server" ReadOnly="True"></asp:TextBox>
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mật khẩu cũ:
        <asp:TextBox ID="txtMatKhauCu" runat="server"></asp:TextBox>
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mật khẩu mới:
        <asp:TextBox ID="txtMatKhauMoi" runat="server"></asp:TextBox>
    </p>
    <p>
&nbsp;&nbsp; Mật khẩu xác nhận:
        <asp:TextBox ID="txtMatKhauXN" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnVeTrangChu" runat="server" Font-Bold="True" PostBackUrl="~/User/TrangChu.aspx" Text="Về trang chủ" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btDoiMatKhau" runat="server" Font-Bold="True" OnClick="btDoiMatKhau_Click" Text="Đổi mật khẩu" />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblTB" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>
    </p>
</asp:Content>

