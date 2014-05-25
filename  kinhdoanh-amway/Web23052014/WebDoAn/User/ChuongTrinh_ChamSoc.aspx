﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="ChuongTrinh_ChamSoc.aspx.cs" Inherits="User_ChuongTrinh_ChamSoc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">



        .auto-style5 {
            width: 803px;
        }
        .auto-style15 {
            width: 684px;
            height: 30px;
        }
        .auto-style13 {
            width: 751px;
        }
        .auto-style16 {
            width: 751px;
            height: 30px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div id='XinChao'>
          <asp:Label ID="lblClick" class='label' runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
    <div id='TroVe'>
          <asp:LinkButton ID="lbtTroVe" runat="server" Visible="False" OnClick="lbtTroVe_Click">Trở về</asp:LinkButton>
            </div>
    <asp:GridView ID="griChuongTrinhChamSoc" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaCS" ForeColor="#333333" GridLines="None" PageSize="5" OnPageIndexChanging="griChuongTrinhChamSoc_PageIndexChanging" OnSelectedIndexChanged="griChuongTrinhChamSoc_SelectedIndexChanged" Visible="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ButtonType="Button" HeaderText="Tùy chọn" SelectText="Chọn" ShowSelectButton="True">
            <HeaderStyle Wrap="False" />
            </asp:CommandField>
            <asp:BoundField DataField="MaCS" HeaderText="Mã số">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="NgayCS" HeaderText="Thời gian" DataFormatString="{0:dd/MM/yyyy}">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="SoLan" HeaderText="Số lần" />
            <asp:CheckBoxField DataField="ThamDu" HeaderText="Tham dự" />
            <asp:BoundField DataField="TenCT" HeaderText="Tên chương trình" />
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
   
    <asp:GridView ID="griChuongTrinhChamSocNPP" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaCS" ForeColor="#333333" GridLines="None" PageSize="5" OnPageIndexChanging="griChuongTrinhChamSoc_PageIndexChanging" OnSelectedIndexChanged="griChuongTrinhChamSoc_SelectedIndexChanged" Visible="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ButtonType="Button" HeaderText="Tùy chọn" SelectText="Chọn" ShowSelectButton="True">
            <HeaderStyle Wrap="False" />
            </asp:CommandField>
            <asp:BoundField DataField="MaCS" HeaderText="Mã số">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="NgayCS" HeaderText="Thời gian" DataFormatString="{0:dd/MM/yyyy}">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="SoLan" HeaderText="Số lần" />
            <asp:CheckBoxField DataField="ThamDu" HeaderText="Tham dự" />
            <asp:BoundField DataField="TenCT" HeaderText="Tên chương trình" />
            <asp:BoundField DataField="HoTenKH" HeaderText="Khách hàng" />
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
    <asp:Label ID="lblTB" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>
&nbsp;<asp:Panel ID="pnlChiTietCT" runat="server" BorderStyle="Solid" Visible="False">
        <table style="width:100%;">
            <tr>
                <td colspan="2" style="text-align: center; font-size: large; font-style: inherit; color: #0000FF; font-weight: bold; background-color: #00FFFF;">CHI TIẾT THÔNG TIN CHƯƠNG TRÌNH</td>
            </tr>
        </table>
        <table class="auto-style5">
            <tr>
                <td class="auto-style15">Mã chăm sóc:
                    <asp:TextBox ID="txtMaCS" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style13">Thời gian:
                    <asp:TextBox ID="txtNgayCS" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtNgayCS" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="auto-style15">Số lần:
                    <asp:TextBox ID="txtSoLan" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style13">
                    <asp:CheckBox ID="chkThamDu" runat="server" Text="Tham dự" />
                </td>
            </tr>
            <tr>
                <td class="auto-style15">Tên chương trình:
                    <asp:DropDownList ID="droChuongTrinh" runat="server" DataTextField="TenCT" DataValueField="MaCT" Enabled="False">
                    </asp:DropDownList>
                </td>
                <td class="auto-style16"></td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnXoa" runat="server" Text="Xóa" Visible="False" Width="7%" OnClick="btnXoa_Click" />
                    <asp:Button ID="btnSua" runat="server" Text="Sửa" Visible="False" Width="7%" OnClick="btnSua_Click" />
                    <asp:Button ID="btnIn" runat="server" Text="In" Width="6%" />
                    <asp:Button ID="btnThoat" runat="server" Text="Thoát" Width="6%" OnClick="btnThoat_Click" />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
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

