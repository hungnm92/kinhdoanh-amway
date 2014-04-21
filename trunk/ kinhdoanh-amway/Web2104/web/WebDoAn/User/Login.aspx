<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="User_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
&nbsp;&nbsp;
        <asp:TextBox ID="txtMaNPP" runat="server" ></asp:TextBox>
&nbsp;
        <asp:TextBox ID="txtMatKhau" runat="server" ></asp:TextBox>
        &nbsp;
        <asp:Button ID="btnDangNhap" runat="server" ForeColor="Red" OnClick="btnDangNhap_Click" Text="Login" />
    </p>
    <p>
        <asp:Label ID="lblTB" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>

