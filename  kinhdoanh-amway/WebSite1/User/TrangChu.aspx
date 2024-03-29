﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="TrangChu.aspx.cs" Inherits="User_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style9 {
            width: 239px;
        }
        .auto-style10 {
            width: 239px;
        }
        .auto-style11 {
            width: 239px;
        }
         .style-button {
            display: inline-block  !important;
    min-width: 26px;
    text-align: center;
    color: #444;
    font-size: 14px;
    font-weight: 700;
    height: 34px;
    padding: 0px 5px;
    line-height: 34px;
    border-radius: 4px;
    transition: all 0.218s ease 0s;
    border: 1px solid #DCDCDC;
    background-color: #F5F5F5;
    background-image: -moz-linear-gradient(center top , #F5F5F5, #F1F1F1);
    cursor: pointer;
        }
        * {
	margin:0;
	padding:0;
	font-family:Arial, Helvetica, sans-serif;
}
        .auto-style12 {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id='XinChao' style="width: 600px">
          <MARQUEE BEHAVIOR=alternate scrollamount="2" scrolldelay="40"  loop="-1"><asp:Label ID="lblClick" class='label' runat="server" Text="Label" Visible="False"></asp:Label></MARQUEE>
            </div>
    <div id='NPP_New'><!-- Ảnh NEW khi có NPP đạt thành tích mới -->
         <a href='ThongKe.aspx?ThanhTichMoi=Dung'><asp:Image ID="imgNew" runat="server" ImageUrl="~/src/web/npp_new.gif" Visible="False" /></a>
</div>
    <asp:Panel ID="pnlChiTiet" runat="server" BorderStyle="Solid" style="margin-left: 5px; margin-right: 0px" Width="553px">
        <table style="width:100%;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblCanhBao" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style27" colspan="3">
                    
                    </td>
                <td class="auto-style9" rowspan="5" style="vertical-align: bottom">
                    <asp:Image ID="imgAnhNPP" runat="server" Height="100px" />
                    <br />
                    <asp:FileUpload ID="fileAnhNPP" runat="server" />
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
                <td class="auto-style27">Mã ADA: </td>
                <td colspan="2">
                    <asp:TextBox ID="txtMaNPP" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="ftbMaNPP" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtMaNPP">
                    </asp:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td class="auto-style27">Họ và đệm: &nbsp;
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtHoNPP" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style27">Tên:</td>
                <td colspan="2">
                    <asp:TextBox ID="txtTenNPP" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style27">Ngày sinh: </td>
                <td colspan="2">
                    <asp:TextBox ID="txtNgaySinh" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style27">Số CMND:
                    </td>
                <td colspan="2">
                    <asp:TextBox ID="txtCMND" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="ftbCMND" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtCMND">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td class="auto-style11">Giới tính:
                    <asp:RadioButton ID="rdoNam" runat="server" Checked="True" GroupName="GioiTinh" Text="Nam" />
                    &nbsp;
                    <asp:RadioButton ID="rdoNu" runat="server" GroupName="GioiTinh" Text="Nữ" />
                </td>
            </tr>
            <tr>
                <td class="auto-style27">Email:
                    </td>
                <td colspan="2">
                    <asp:TextBox ID="txtEmail" runat="server" ></asp:TextBox>
                </td>
                <td class="auto-style11">Số điện thoại:
                    <asp:TextBox ID="txtSoDT" runat="server" Width="100px"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="txtSoDT_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtSoDT">
                    </asp:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td class="auto-style27" style="white-space: nowrap">Ngày hết hạn:
                    </td>
                <td colspan="2">
                    <asp:TextBox ID="txtNgayHetHan" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="auto-style10">Ngày ký thẻ:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtNgayKyThe" runat="server" Enabled="False" ReadOnly="True" Width="100px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style27" style="white-space: nowrap">Địa chỉ thường trú:</td>
                <td colspan="3">
                    <asp:TextBox ID="txtSoNhaNPPTT" runat="server"></asp:TextBox>
                    &nbsp;<asp:DropDownList ID="droDuongNPPTT" runat="server" DataTextField="TenDuong" DataValueField="MaDuong">
                    </asp:DropDownList>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style27" style="white-space: nowrap">&nbsp;</td>
                <td colspan="3"><asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="droXaNPPTT" runat="server" AutoPostBack="false" DataTextField="TenXa" DataValueField="MaXa">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droHuyenNPPTT" runat="server" AutoPostBack="true" DataValueField="MaHuyen" DataTextField="TenHuyen" OnSelectedIndexChanged="droHuyenNPPTT_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droTinhNPPTT" runat="server" AutoPostBack="true" DataTextField="TenTinh" DataValueField="MaTinh" OnSelectedIndexChanged="droTinhNPPTT_SelectedIndexChanged">
                    </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="auto-style27" style="white-space: nowrap">&nbsp;</td>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style27" style="white-space: nowrap">Địa chỉ liên lạc:</td>
                <td colspan="3">
                    <asp:TextBox ID="txtSoNhaNPPLL" runat="server"></asp:TextBox>
                    &nbsp;<asp:DropDownList ID="droDuongNPPLL" runat="server" DataTextField="TenDuong" DataValueField="MaDuong">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style27" style="white-space: nowrap">&nbsp;</td>
                <td colspan="3">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="droXaNPPLL" runat="server" AutoPostBack="false" DataTextField="TenXa" DataValueField="MaXa">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droHuyenNPPLL" runat="server" AutoPostBack="true" DataTextField="TenHuyen" DataValueField="MaHuyen" OnSelectedIndexChanged="droHuyenNPPLL_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droTinhNPPLL" runat="server" AutoPostBack="true" DataTextField="TenTinh" DataValueField="MaTinh" OnSelectedIndexChanged="droTinhNPPLL_SelectedIndexChanged">
                    </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12" colspan="1">Cấp độ:
                </td>
                <td colspan="3" class="auto-style12">
                    <asp:DropDownList ID="droCapDo" runat="server" DataTextField="TenCD" DataValueField="MaCD">
                    </asp:DropDownList>
                    &nbsp;<asp:TextBox ID="txtNgayKyThe0" runat="server" Enabled="False" ReadOnly="True" Visible="False"></asp:TextBox>
                    <asp:CalendarExtender ID="txtNgayKyThe0_CalendarExtender" runat="server" Format="dd/MM/yyyy"  TargetControlID="txtNgayKyThe0">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td colspan="1">Nhà bảo trợ:</td>
                <td colspan="3">
                    <asp:DropDownList ID="droNBT" runat="server" DataTextField="HoTenNPP" DataValueField="MaNPP" Width="200px" Enabled="False">
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblTB" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>

                </td>
                <td colspan="2" style="text-align: right">&nbsp;<asp:Button ID="btnGHT" runat="server" CssClass="style-button" OnClick="btnGHT_Click" Text="Gia hạn thẻ" Visible="False" />
                    &nbsp;<asp:Button ID="btnSua" runat="server" Font-Bold="True"  CssClass="style-button" OnClick="btnSua_Click" Text="Cập nhật" Visible="False" /></td>
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
        
    </p>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
             <asp:LinkButton ID="lbtViewMap" AutoPostBack="true" runat="server" OnClick="lbtViewMap_Click">Xem địa chỉ trên Google Map</asp:LinkButton>
            <br />
            <cc1:GMap ID="GMap1" runat="server" AutoPostBack="false" Height="500px" Width="560px" enableContinuousZoom="true" enableDoubleClickZoom="true" enableGoogleBar="true"    enableRotation="true" enableGKeyboardHandler="true" enableHookMouseWheelToZoom="true"      ClientIDMode="Static"/>
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
        <br />
    </p>
</asp:Content>

