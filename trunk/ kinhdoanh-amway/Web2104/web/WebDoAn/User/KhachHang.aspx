﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="KhachHang.aspx.cs" Inherits="User_KhachHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style5 {
            width: 803px;
        }
        .auto-style11 {
            height: 34px;
        }
        .auto-style8 {
            width: 401px;
        }
        .auto-style9 {
            height: 23px;
        }
        .auto-style10 {
            width: 401px;
            height: 23px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="griKhachHang" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaKH" ForeColor="#333333" GridLines="None" OnPageIndexChanging="griKhachHang_PageIndexChanging" OnSelectedIndexChanged="griKhachHang_SelectedIndexChanged" PageSize="5">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ButtonType="Button" HeaderText="Tùy chọn" SelectText="Chọn" ShowSelectButton="True">
            <HeaderStyle Wrap="False" />
            </asp:CommandField>
            <asp:BoundField DataField="MaKH" HeaderText="Mã số">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="HoTenKH" HeaderText="Họ tên">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="SoDT" HeaderText="Số điện thoại">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="DiaChiKHLL" HeaderText="Địa chỉ liên lạc">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="DiaChiKHTT" HeaderText="Địa chỉ thường trú">
            <HeaderStyle Wrap="False" />
            </asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    <br />
    <asp:LinkButton ID="lbtThemMoi" runat="server" Font-Bold="True" OnClick="lbtThemMoi_Click">Thêm mới.</asp:LinkButton>
&nbsp;
    <asp:Label ID="lblTB" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>
&nbsp;<asp:Label ID="lblTBKH" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>
    <asp:Panel ID="pnlChiTietKH" runat="server" BorderStyle="Solid" Visible="False">
        <table style="width:100%;">
            <tr>
                <td colspan="2" style="text-align: center; font-size: large; font-style: inherit; color: #0000FF; font-weight: bold; background-color: #00FFFF;">CHI TIẾT THÔNG TIN KHÁCH HÀNG</td>
            </tr>
        </table>
        <table class="auto-style5">
            <tr>
                <td class="auto-style11">Mã số:
                    <asp:TextBox ID="txtMaKH" runat="server" Enabled="False" ReadOnly="True" Width="71px"></asp:TextBox>
                    &nbsp;<asp:Label ID="lblMaNPP" runat="server" Text="Mã ADA:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtMaNPP" runat="server"></asp:TextBox>
                </td>
                <td rowspan="3" class="auto-style8">
                    <asp:Image ID="imgAnhNPP" runat="server" style="margin-left: 0px; margin-top: 0px;" Height="16px" />
                    <br />
                    <asp:FileUpload ID="fileAnhNPP" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Họ tên: 
                    <asp:TextBox ID="txtHoKH" runat="server"></asp:TextBox>
                    &nbsp;<asp:TextBox ID="txtTenKH" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;Loại:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblCapDo" runat="server" Text="Cấp độ: "></asp:Label>
                    <asp:DropDownList ID="droCapDo" runat="server" DataTextField="TenCD" DataValueField="MaCD">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">Ngày sinh: 
                    <asp:TextBox ID="txtNgaySinh" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style10">Giới tính: 
                    <asp:RadioButton ID="rdoNam" runat="server" Checked="True" GroupName="GioiTinh" Text="Nam" />
                    &nbsp;<asp:RadioButton ID="rdoNu" runat="server" GroupName="GioiTinh" Text="Nữ" />
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Số CMND:
                    <asp:TextBox ID="txtCMND" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style8">Số điện thoại: 
                    <asp:TextBox ID="txtSoDT" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Email:
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style8">Ngày ký thẻ:
                    <asp:TextBox ID="txtNgayKyThe" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style9" colspan="2">Địa chỉ thường trú:&nbsp;<asp:TextBox ID="txtSoNhaKHTT" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="droDuongKHTT" runat="server" DataTextField="TenDuong" DataValueField="MaDuong">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droXaKHTT" runat="server" DataTextField="TenXa" DataValueField="MaXa">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droHuyenKHTT" runat="server" DataTextField="TenHuyen" DataValueField="MaHuyen">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droTinhKHTT" runat="server" DataTextField="TenTinh" DataValueField="MaTinh">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style7" colspan="2">Địa chỉ liên lạc:
                    <asp:TextBox ID="txtSoNhaKHLL" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="droDuongKHLL" runat="server" DataTextField="TenDuong" DataValueField="MaDuong">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droXaKHLL" runat="server" DataTextField="TenXa" DataValueField="MaXa">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droHuyenKHLL" runat="server" DataTextField="TenHuyen" DataValueField="MaHuyen">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droTinhKHLL" runat="server" DataTextField="TenTinh" DataValueField="MaTinh">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnThem" runat="server" Text="Thêm" Width="8%" OnClick="btnThem_Click" />
                    <asp:Button ID="btnXoa" runat="server" Text="Xóa" Width="8%" OnClick="btnXoa_Click" />
                    <asp:Button ID="btnSua" runat="server" Text="Sửa" Width="8%" OnClick="btnSua_Click" />
                    <asp:Button ID="btnTroThanhNPP" runat="server" Text="Trở thành NPP" Width="11%" OnClick="btnTroThanhNPP_Click" Visible="False" />
                    <asp:Button ID="btnIn" runat="server" Text="In" Width="8%" />
                    <asp:Button ID="btnThoat" runat="server" Text="Thoát" Width="8%" OnClick="btnThoat_Click" />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <div>
        Bản đồ ở đây</div>
    <p>
        &nbsp;</p>
</asp:Content>

