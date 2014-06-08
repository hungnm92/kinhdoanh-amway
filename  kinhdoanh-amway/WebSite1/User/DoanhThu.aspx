<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="DoanhThu.aspx.cs" Inherits="User_DoanhThu" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">



        .auto-style5 {

        }
        .auto-style15 {

        }
        .auto-style13 {

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
    <asp:GridView ID="griDoanhThu" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ThangNam" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="griDoanhThu_SelectedIndexChanged" PageSize="5" OnPageIndexChanging="griDoanhThu_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField HeaderText="Xem     " SelectText="Xem     " ShowSelectButton="True">
            <HeaderStyle Wrap="False" />
            </asp:CommandField>
            <asp:BoundField DataField="ThangNam" HeaderText="Tháng năm     ">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Diem" HeaderText="Điểm">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
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
&nbsp;<asp:Panel ID="pnlChiTietDoanhThu" runat="server" BorderStyle="Solid" Visible="False">
        <table style="width:100%;">
            <tr>
                <td colspan="2" style="text-align: center; font-size: large; font-style: inherit; color: #0000FF; font-weight: bold; background-color: #00FFFF;">CHI TIẾT THÔNG TIN DOANH THU</td>
            </tr>
        </table>
        <table class="auto-style5" width="100%">
            <tr>
                <td class="auto-style15">Tháng năm:
                    <asp:TextBox ID="txtThangNam" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style13">Điểm:
                    <asp:TextBox ID="txtDiem" runat="server"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="ftbDiem" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtDiem" ></asp:FilteredTextBoxExtender>
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Button ID="btnTraDoanhThu" runat="server" OnClick="btnTraDoanhThu_Click" Text="Tra doanh thu" />
                    &nbsp;<asp:Button ID="btnThem" runat="server" OnClick="btnThem_Click" Text="Thêm" Visible="False" />
                    &nbsp;<asp:Button ID="btnXoa" runat="server" Text="Xóa" OnClick="btnXoa_Click" Visible="False" />
                    &nbsp;<asp:Button ID="btnSua" runat="server" OnClick="btnSua_Click" Text="Sửa" Visible="False" />
                    &nbsp;<asp:Button ID="btnIn" runat="server" Text="In" />
                    &nbsp;<asp:Button ID="btnThoat" runat="server" Text="Thoát" OnClick="btnThoat_Click" />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">Tổng số tiền mua hàng trang tháng:
                    <asp:TextBox ID="txtDoanhThu_NPP" runat="server"></asp:TextBox>
                    &nbsp;vnđ</td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">Tổng số tiền bán hành trong tháng:&nbsp;&nbsp;
                    <asp:TextBox ID="txtDoanhThu_KH" runat="server"></asp:TextBox>
                    vnđ</td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <p>
        &nbsp;</p>
</asp:Content>

