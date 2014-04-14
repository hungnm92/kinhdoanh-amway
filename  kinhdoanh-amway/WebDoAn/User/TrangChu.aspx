<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="TrangChu.aspx.cs" Inherits="User_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
        }
        .auto-style6 {
            height: 23px;
        }
        .auto-style7 {
            height: 30px;
        }
        .auto-style9 {
            width: 239px;
        }
        .auto-style10 {
            height: 30px;
            width: 239px;
        }
        .auto-style11 {
            height: 23px;
            width: 239px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="pnlChiTiet" runat="server" BorderStyle="Solid">
        <table style="width:100%;">
            <tr>
                <td class="auto-style5">Mã ADA:
                    <asp:TextBox ID="txtMaNPP" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="auto-style9" rowspan="2">
                    <asp:Image ID="imgAnhNPP" runat="server" Width="85px" Height="30px" />
                    <br />
                    <asp:FileUpload ID="fileAnhNPP" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Họ tên:
                    <asp:TextBox ID="txtHoNPP" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:TextBox ID="txtTenNPP" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Ngày sinh:
                    <asp:TextBox ID="txtNgaySinh" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style10">Giới tính:
                    <asp:RadioButton ID="rdoNam" runat="server" Checked="True" GroupName="GioiTinh" Text="Nam" />
                    &nbsp;
                    <asp:RadioButton ID="rdoNu" runat="server" GroupName="GioiTinh" Text="Nữ" />
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Số CMND:
                    <asp:TextBox ID="txtCMND" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="auto-style11">Số điện thoại:
                    <asp:TextBox ID="txtSoDT" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Email:
                    <asp:TextBox ID="txtEmail" runat="server" style="width: 128px"></asp:TextBox>
                </td>
                <td class="auto-style10">Ngày ký thẻ:
                    <asp:TextBox ID="txtNgayKyThe" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2">Địa chỉ thường trú:
                    <asp:TextBox ID="txtSoNhaNPPTT" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="droDuongNPPTT" runat="server" DataTextField="TenDuong" DataValueField="MaDuong">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droXaNPPTT" runat="server" DataTextField="TenXa" DataValueField="MaXa">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droHuyenNPPTT" runat="server" DataValueField="MaHuyen">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droTinhNPPTT" runat="server" DataTextField="TenTinh" DataValueField="MaTinh">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2">Địa chỉ liên lạc:
                    <asp:TextBox ID="txtSoNhaNPPLL" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="droDuongNPPLL" runat="server" DataTextField="TenDuong" DataValueField="MaDuong">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droXaNPPLL" runat="server" DataTextField="TenXa" DataValueField="MaXa">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droHuyenNPPLL" runat="server" DataTextField="TenHuyen" DataValueField="MaHuyen">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droTinhNPPLL" runat="server" DataTextField="TenTinh" DataValueField="MaTinh">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Cấp độ:
                    <asp:DropDownList ID="droCapDo" runat="server" DataTextField="TenCD" DataValueField="MaCD">
                    </asp:DropDownList>
                </td>
                <td class="auto-style11">Nhà bảo trợ:
                    <asp:DropDownList ID="droNBT" runat="server" DataTextField="HoTenNPP" DataValueField="MaNPP">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style6" colspan="2">
                    <asp:Label ID="lblTB" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnSua" runat="server" Font-Bold="True" Text="Cập nhật" OnClick="btnSua_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        Bản đồ.<br />
    </p>
</asp:Content>

