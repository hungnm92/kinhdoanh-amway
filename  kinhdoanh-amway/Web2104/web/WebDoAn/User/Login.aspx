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
    <span id="lblMenu">        <ul id='nav'>            <li><img src='Nomal.jpg'><span>Nguyễn  C</span></li>            <li><img src='Nomal.jpg'><span>Trần Thị  A</span></li>            <li><img src='Nomal.jpg'><span>Bùi Ngọc Ty</span></li>            <li><img src='Nomal.jpg'><span>Nguyễn Thị Lệ</span></li>            <li><img src='Nomal.jpg'><span>Bùi Ngọc Hưng</span></li>            <li><img src='Nomal.jpg'><span>Trần Văn Tuấn</span></li>            <li><img src='Nomal.jpg'><span>Bùi Văn Ty</span><ul></ul></li>            <li><img src='Nomal.jpg'><span>Nguyễn Thị Lãnh</span></li>            <li><img src='Nomal.jpg'><span>Đào Đức Linh</span></li>            <li><img src='Nomal.jpg'><span>Trần Văn Ái</span><ul></ul></li>            <li><img src='Nomal.jpg'><span>Mai Thị Hi?n</span></li>            <li><img src='Nomal.jpg'><span>Mai Ánh Tuy?t</span></li>            <li><img src='Nomal.jpg'><span>Mai Ánh Tuy?t</span></li>

        </ul></span>    <ul id='Ul1'><li><img src='../images/emp/GoldProducer.jpg'><span>Bùi Ngọc Hưng</span></li>
        <li><img src='../images/emp/GoldProducer.jpg'><span>Bùi Văn Ty</span>
            <ul><li><img src='../images/emp/Nomal.jpg'><span>Trần Văn Ái</span></li>
                <li><img src='../images/emp/Nomal.jpg'><span>Mai Thị Hi?n</span></li>
                <li><img src='../images/emp/Nomal.jpg'><span>Mai Ánh Tuy?t</span></li>

            </ul></li>
        <li><img src='../images/emp/Nomal.jpg'><span>Nguyễn Thị Lãnh</span></li>
        <li><img src='../images/emp/Nomal.jpg'><span>Đào Đức Linh</span></li>
        <li><img src='../images/emp/GoldProducer.jpg'><span>Trần Văn Ái</span></li>
        <li><img src='../images/emp/GoldProducer.jpg'><span>Mai Thị Hi?n</span></li>
        <li><img src='../images/emp/GoldProducer.jpg'><span>Mai Ánh Tuy?t</span></li>

    </ul>
</asp:Content>

