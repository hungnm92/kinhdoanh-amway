<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="NhaPhanPhoi.aspx.cs" Inherits="User_NhaPhanPhoi" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            width: 803px;
        }
        .auto-style7 {
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
        .auto-style11 {
            height: 34px;
        }
        .auto-style12 {
            height: 30px;
        }
        .auto-style13 {
            width: 401px;
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <asp:GridView ID="griNhaPhanPhoi" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaNPP" ForeColor="#333333" GridLines="None" OnPageIndexChanging="griNhaPhanPhoi_PageIndexChanging" OnSelectedIndexChanged="griNhaPhanPhoi_SelectedIndexChanged" PageSize="5">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ButtonType="Button" HeaderText="Tùy chọn" SelectText="Chọn" ShowSelectButton="True">
            <HeaderStyle Wrap="False" />
            </asp:CommandField>
            <asp:BoundField DataField="MaNPP" HeaderText="Mã ADA">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="HoTenNPP" HeaderText="Họ tên">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="SoDT" HeaderText="Số điện thoại">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="NgayKyThe" HeaderText="Ngày ký thẻ" DataFormatString="{0: HH:mm dd/MM/yyyy}">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="TenCD" HeaderText="Cấp độ">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="DiaChiLL" HeaderText="Địa chỉ liên lạc">
            <HeaderStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="DiaChiTT" HeaderText="Địa chỉ thường trú">
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
&nbsp;<asp:Panel ID="pnlChiTietNPP" runat="server" BorderStyle="Solid" Visible="False">
        <table style="width:100%;">
            <tr>
                <td colspan="2" style="text-align: center; font-size: large; font-style: inherit; color: #0000FF; font-weight: bold; background-color: #00FFFF;">CHI TIẾT THÔNG TIN NHÀ PHÂN PHỐI</td>
            </tr>
        </table>
        <table class="auto-style5">
            <tr>
                <td class="auto-style11">Mã ADA: 
                    <asp:TextBox ID="txtMaNPP" runat="server"></asp:TextBox>
                </td>
                <td rowspan="3" class="auto-style8">
                    <asp:Image ID="imgAnhNPP" runat="server" style="margin-left: 0px; margin-top: 0px;" Height="16px" />
                    <br />
                    <asp:FileUpload ID="fileAnhNPP" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Họ tên: 
                    <asp:TextBox ID="txtHoNPP" runat="server"></asp:TextBox>
                    &nbsp;<asp:TextBox ID="txtTenNPP" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Cấp độ:
                    <asp:DropDownList ID="droCapDo" runat="server" DataTextField="TenCD" DataValueField="MaCD">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">Ngày sinh: 
                     <asp:TextBox ID="txtNgaySinh" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtNgaySinh" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                </td>
                <td class="auto-style10">Giới tính: 
                    <asp:RadioButton ID="rdoNam" runat="server" Checked="True" GroupName="GioiTinh" Text="Nam" />
                    &nbsp;<asp:RadioButton ID="rdoNu" runat="server" GroupName="GioiTinh" Text="Nữ" />
                </td>
            </tr>
            <tr>
                <td class="auto-style12">Số CMND: 
                    <asp:TextBox ID="txtCMND" runat="server" Width="127px"></asp:TextBox>
                </td>
                <td class="auto-style13">Số điện thoại: 
                    <asp:TextBox ID="txtSoDT" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Email: 
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style8">Ngày ký thẻ: 
                    <asp:TextBox ID="txtNgayKyThe" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txtNgayKyThe" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="auto-style9" colspan="2">Địa chỉ thường trú:&nbsp;<asp:TextBox ID="txtSoNhaNPPTT" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="droDuongNPPTT" runat="server" DataTextField="TenDuong" DataValueField="MaDuong">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droXaNPPTT" runat="server" DataTextField="TenXa" DataValueField="MaXa">
                    </asp:DropDownList>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="droHuyenNPPTT" runat="server" DataTextField="TenHuyen" DataValueField="MaHuyen">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droTinhNPPTT" runat="server" DataTextField="TenTinh" DataValueField="MaTinh">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style7" colspan="2">Địa chỉ liên lạc:
                    <asp:TextBox ID="txtSoNhaNPPLL" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="droDuongNPPLL" runat="server" DataTextField="TenDuong" DataValueField="MaDuong">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droXaNPPLL" runat="server" DataTextField="TenXa" DataValueField="MaXa">
                    </asp:DropDownList>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="droHuyenNPPLL" runat="server" DataTextField="TenHuyen" DataValueField="MaHuyen">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droTinhNPPLL" runat="server" DataTextField="TenTinh" DataValueField="MaTinh">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnThem" runat="server" Text="Thêm" Width="8%" OnClick="btnThem_Click" />
                    <asp:Button ID="btnXoa" runat="server" Text="Xóa" Width="8%" OnClick="btnXoa_Click" />
                    <asp:Button ID="btnSua" runat="server" Text="Sửa" Width="8%" OnClick="btnSua_Click" />
                    <asp:Button ID="btnIn" runat="server" Text="In" Width="8%" />
                    <asp:Button ID="btnThoat" runat="server" Text="Thoát" Width="8%" OnClick="btnThoat_Click" />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnChuyenMacDinh" runat="server" Text="Chuyển mặc định" Visible="False" Width="14%" Height="26px" OnClick="btnChuyenMacDinh_Click" />
                    &nbsp;<asp:Button ID="btnChuyenTheoYeuCau" runat="server" Text="Chuyển theo yêu cầu" Visible="False" Width="16%" OnClick="btnChuyenTheoYeuCau_Click" />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="droNhaBaoTro" runat="server" DataTextField="HoTenNPP" DataValueField="MaNPP" Visible="False">
                    </asp:DropDownList>
                </td>
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

