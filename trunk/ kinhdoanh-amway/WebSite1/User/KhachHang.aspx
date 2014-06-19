<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="KhachHang.aspx.cs" Inherits="User_KhachHang" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style5 {

        }
        .auto-style11 {

        }
        .auto-style8 {

        }
        .auto-style9 {

        }
        .auto-style10 {

        }
        .auto-style12 {

        }
        .auto-style13 {

        }
.popupControl { 
 background-color: #eeeeee; 
 border: outset 1px #c0c0c0; 
 color: #444444; 
 position: absolute; 
 visibility: visible; 
 text-align: center;
}
        .auto-style14 {
            height: 55px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id='XinChao' style="width: 600px">
          <MARQUEE BEHAVIOR=alternate scrollamount="2" scrolldelay="40"  loop="-1"><asp:Label ID="lblClick" class='label' runat="server" Text="Label" Visible="False"></asp:Label></MARQUEE>
            </div>
    <asp:GridView ID="griKhachHang" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaKH" ForeColor="#333333" GridLines="None" OnPageIndexChanging="griKhachHang_PageIndexChanging" OnSelectedIndexChanged="griKhachHang_SelectedIndexChanged" PageSize="5">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField HeaderText="Xem   " SelectText="Xem" ShowSelectButton="True">
            <HeaderStyle Wrap="False" />
            </asp:CommandField>
            <asp:BoundField DataField="MaKH" HeaderText="   Mã số  ">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="HoTenKH" HeaderText="Họ tên">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="SoDT" HeaderText="  Số điện thoại      ">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Địa chỉ liên lạc">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("DiaChiKHLL").ToString().Length > 35 ? Eval("DiaChiKHLL").ToString().Substring(0,35) +"..." : Eval("DiaChiKHLL") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="False" />
                        </asp:TemplateField>           
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
    <asp:LinkButton ID="lbtThemMoi" runat="server" Font-Bold="True" OnClick="lbtThemMoi_Click" Visible="False">Thêm mới.</asp:LinkButton>
&nbsp;
    <asp:Label ID="lblTB" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>
&nbsp;<asp:Label ID="lblTBKH" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>
    <asp:Panel ID="pnlChiTietKH" runat="server" BorderStyle="Solid" Visible="False">
        <table style="width:100%;">
            <tr>
                <td colspan="2" style="text-align: center; font-size: large; font-style: inherit; color: #0000FF; font-weight: bold; background-color: #00FFFF;">CHI TIẾT THÔNG TIN KHÁCH HÀNG</td>
            </tr>
        </table>
        <table class="auto-style5" width="100%">
            <tr>
                <td class="auto-style11">Mã số: &nbsp;&nbsp;</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtMaKH" runat="server" Enabled="False" ReadOnly="True" Width="71px"></asp:TextBox>
                </td>
                <td rowspan="5" class="auto-style8" style="vertical-align: bottom">
                    <br />
                    <asp:FileUpload ID="fileAnhNPP" runat="server" />
                    <br />
                    <asp:RegularExpressionValidator 
	ID="RegularExpressionValidator1" 
	runat="server" 
	ControlToValidate="fileAnhNPP" 
	ErrorMessage="Không phải file ảnh" 
	ValidationExpression= 
"^([0-9a-zA-Z_\-~ :\\])+(.jpg|.JPG|.jpeg|.JPEG|.bmp|.BMP|.gif|.GIF|.png|.PNG)$"> 
</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="lblMaNPP" runat="server" Text="Mã ADA:"></asp:Label>
                    &nbsp;</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtMaNPP" runat="server"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="ftbMaNPP" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtMaNPP">
                    </asp:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Họ và đệm: &nbsp;</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtHoKH" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Tên:</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtTenKH" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style12" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkLoai" runat="server" Text="Khách hàng tiềm năng" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style9">Ngày sinh: 
                    </td>
                <td class="auto-style9">
                    <asp:TextBox ID="txtNgaySinh" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtNgaySinh">
                    </asp:CalendarExtender>
                </td>
                <td class="auto-style10">Giới tính:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:RadioButton ID="rdoNam" runat="server" Checked="True" GroupName="GioiTinh" Text="Nam" />
                    &nbsp;<asp:RadioButton ID="rdoNu" runat="server" GroupName="GioiTinh" Text="Nữ" />
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Số CMND:
                    </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtCMND" runat="server"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="ftbCMND" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtCMND">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td class="auto-style8">Số điện thoại: 
                    <asp:TextBox ID="txtSoDT" runat="server"></asp:TextBox>
                     <asp:FilteredTextBoxExtender ID="ftbSoDT" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtSoDT" ></asp:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Email:
                    </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style8">Ngày ký thẻ:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtNgayKyThe" runat="server" Visible="False"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txtNgayKyThe" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9" colspan="1">Địa chỉ thường trú:&nbsp;</td>
                <td class="auto-style9" colspan="2">
                    <asp:TextBox ID="txtSoNhaKHTT" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="droDuongKHTT" runat="server" DataTextField="TenDuong" DataValueField="MaDuong">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style9" colspan="1">&nbsp;</td>
                <td class="auto-style9" colspan="2">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="droXaKHTT" runat="server" AutoPostBack="false" DataTextField="TenXa" DataValueField="MaXa">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droHuyenKHTT" runat="server" AutoPostBack="true" DataTextField="TenHuyen" DataValueField="MaHuyen" OnSelectedIndexChanged="droHuyenKHTT_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droTinhKHTT" runat="server" AutoPostBack="true" DataTextField="TenTinh" DataValueField="MaTinh" OnSelectedIndexChanged="droTinhKHTT_SelectedIndexChanged">
                    </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="auto-style9" colspan="1">&nbsp;</td>
                <td class="auto-style9" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13" colspan="1">Địa chỉ liên lạc: </td>
                <td class="auto-style13" colspan="2">
                    <asp:TextBox ID="txtSoNhaKHLL" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="droDuongKHLL" runat="server" DataTextField="TenDuong" DataValueField="MaDuong">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="1" class="auto-style13">
                    &nbsp;</td>
                <td class="auto-style13" colspan="2">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="droXaKHLL" runat="server" AutoPostBack="false" DataTextField="TenXa" DataValueField="MaXa">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droHuyenKHLL" runat="server" AutoPostBack="true" DataTextField="TenHuyen" DataValueField="MaHuyen" OnSelectedIndexChanged="droHuyenKHLL_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droTinhKHLL" runat="server" AutoPostBack="true" DataTextField="TenTinh" DataValueField="MaTinh" OnSelectedIndexChanged="droTinhKHLL_SelectedIndexChanged">
                    </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="auto-style13" colspan="1">&nbsp;</td>
                <td class="auto-style13" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" class="auto-style14">
                    <asp:LinkButton ID="lbtSP" runat="server" OnClick="lbtSP_Click" Visible="False">Sản phẩm</asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="lbtSPSD" runat="server" OnClick="lbtSPSD_Click">Sản phẩm sử dụng</asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="lbtSPGY" runat="server" OnClick="lbtSPGY_Click">Sản phẩm gợi ý</asp:LinkButton>
                    <asp:LinkButton ID="lbtCTSDR" runat="server" OnClick="lbtCTSDR_Click" Visible="False">Chương trình sắp diễn ra</asp:LinkButton>
                    <asp:LinkButton ID="lbtTTCS" runat="server" OnClick="lbtTTCS_Click">Thông tin chăm sóc</asp:LinkButton>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnThem" runat="server" OnClick="btnThem_Click" Text="Thêm" Visible="False" Width="50px" />
                    <asp:Button ID="btnXoaPnl" runat="server" Text="Xóa" />
                    <asp:PopupControlExtender ID="PopAtt" runat="server" PopupControlID="pnlXoa" TargetControlID="btnXoaPnl">
                    </asp:PopupControlExtender>
                    <asp:Button ID="btnSua" runat="server" OnClick="btnSua_Click" Text="Sửa" Visible="False" Width="50px" />
                    <asp:Button ID="btnTroThanhNPP" runat="server" OnClick="btnTroThanhNPP_Click" Text="Trở thành NPP" Visible="False" />
                    <asp:Button ID="btnThoat" runat="server" OnClick="btnThoat_Click" Text="Thoát" Width="50px" />
                    <br />
                    </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Panel ID="pnlXoa" CssClass="popupControl" runat="server" Width="50%">
                        <br />
                        Bạn chắc chắn xóa khách hàng này!<br />
                        <br />
                        <asp:Button ID="btnXoa" runat="server" OnClick="btnXoa_Click" Text="Ok" Visible="False" Width="50px" />
                        <br />
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                           <!-- <asp:LinkButton ID="lbtViewMap" runat="server" AutoPostBack="true" OnClick="lbtViewMap_Click">Xem địa chỉ trên Google Map</asp:LinkButton> -->
                            <br />
                            <cc1:GMap ID="GMap1" runat="server" AutoPostBack="false" ClientIDMode="Static" enableContinuousZoom="true" enableDoubleClickZoom="true" enableGKeyboardHandler="true" enableGoogleBar="true" enableHookMouseWheelToZoom="true" enableRotation="true" Height="500px" Width="530px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </asp:Panel>

        
    <p>
        &nbsp;</p>
</asp:Content>

