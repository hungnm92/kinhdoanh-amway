﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="ChuongTrinh_DaoTao.aspx.cs" Inherits="User_ChuongTrinh_DaoTao" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">




        .auto-style5 {

        }
        .auto-style13 {            width: 186px;
        }
        .auto-style17 {

        }
        .auto-style18 {
            height: 26px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id='XinChao' style="width: 600px">
          <MARQUEE BEHAVIOR=alternate scrollamount="2" scrolldelay="40"  loop="-1"><asp:Label ID="lblClick" class='label' runat="server" Text="Label" Visible="False"></asp:Label></MARQUEE>
            </div>
    <div id='TroVe'>
          <asp:LinkButton ID="lbtTroVe" runat="server" Visible="False" OnClick="lbtTroVe_Click">Trở về</asp:LinkButton>
            </div>
    <asp:GridView ID="griChuongTrinhDaoTao" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaDT" ForeColor="#333333" GridLines="None" PageSize="5" OnPageIndexChanging="griChuongTrinhDaoTao_PageIndexChanging" OnSelectedIndexChanged="griChuongTrinhDaoTao_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField HeaderText="Xem     " SelectText="Xem     " ShowSelectButton="True">
            <HeaderStyle Wrap="False" />
            </asp:CommandField>
            <asp:BoundField DataField="MaDT" HeaderText="Mã số     ">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="NgayDT" HeaderText="Thời gian     " DataFormatString=" {0:dd/MM/yyyy}">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="SoLan" HeaderText="Số lần" />
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
    <br />
    <asp:Label ID="lblTB" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>
&nbsp;<asp:Panel ID="pnlChiTietCT" runat="server" BorderStyle="Solid" Visible="False">
        <table style="width:100%;">
            <tr>
                <td colspan="2" style="text-align: center; font-size: large; font-style: inherit; color: #0000FF; font-weight: bold; background-color: #00FFFF;" class="auto-style18">CHI TIẾT THÔNG TIN CHƯƠNG TRÌNH</td>
            </tr>
        </table>
        <table class="auto-style5" width="100%">
            <tr>
                <td class="auto-style17" style="width: 180px;">Mã đào tạo:&nbsp;
                    <asp:TextBox ID="txtMaDT" runat="server" Enabled="False" Width="30px"></asp:TextBox>
                </td>
                <td class="auto-style13">Thời gian:
                    <asp:TextBox ID="txtNgayDT" runat="server" style="height: 22px"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtNgayDT" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Số lần:
                    <asp:TextBox ID="txtSoLan" runat="server" Enabled="False" Width="30px"></asp:TextBox>
                </td>
                <td class="auto-style13">Tên chương trình:
                    <asp:DropDownList ID="droChuongTrinh" runat="server" DataTextField="TenCT" DataValueField="MaCT" Enabled="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    &nbsp;<asp:Button ID="btnXoa" runat="server" OnClick="btnXoa_Click" Text="Xóa" Visible="False" Width="50px" />
                    &nbsp;<asp:Button ID="btnSua" runat="server" OnClick="btnSua_Click" Text="Sửa" Visible="False" Width="50px" />
                    &nbsp;&nbsp;<asp:Button ID="btnThoat" runat="server" Text="Thoát" Width="50px" OnClick="btnThoat_Click" />
                    <br />
                     </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <p>
        &nbsp;</p>
</asp:Content>
