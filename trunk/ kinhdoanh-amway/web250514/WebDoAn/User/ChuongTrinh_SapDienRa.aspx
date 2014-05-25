<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="ChuongTrinh_SapDienRa.aspx.cs" Inherits="User_ChuongTrinh_SapDienRa" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .popupControl { 
 background-color: #eeeeee; 
 border: outset 1px #c0c0c0; 
 color: #444444; 
 position: absolute; 
 visibility: visible; 
}

        .auto-style5 {

        }
        .auto-style15 {

        }
        .auto-style13 {

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
    <asp:GridView ID="griChuongTrinhSapDienRa" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaCT" ForeColor="#333333" GridLines="None" PageSize="5" OnPageIndexChanging="griChuongTrinhSapDienRa_PageIndexChanging" OnSelectedIndexChanged="griChuongTrinhSapDienRa_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ButtonType="Button" HeaderText="Tùy chọn" SelectText="Chọn" ShowSelectButton="True">
            <HeaderStyle Wrap="False" />
            </asp:CommandField>
            <asp:BoundField DataField="MaCT" HeaderText="Mã số">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="TenCT" HeaderText="Tên chương trình">
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
&nbsp;<asp:Panel ID="pnlChiTietCT" runat="server" BorderStyle="Solid" Visible="False">
        <table style="width:100%;">
            <tr>
                <td colspan="2" style="text-align: center; font-size: large; font-style: inherit; color: #0000FF; font-weight: bold; background-color: #00FFFF;">CHI TIẾT THÔNG TIN CHƯƠNG TRÌNH</td>
            </tr>
        </table>
        <table class="auto-style5">
            <tr>
                <td class="auto-style15">Mã chương trình:
                    <asp:TextBox ID="txtMaCT" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style13">Tên chương trình:
                    <asp:TextBox ID="txtTenCT" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;&nbsp;
                    <asp:Button ID="btnThem" runat="server" Text="Thêm" Visible="False" OnClick="btnThem_Click" />
                    <asp:Button ID="btnXoa" runat="server" Text="Xóa" Visible="False" OnClick="btnXoa_Click" />
                    <asp:Button ID="btnSua" runat="server" Text="Sửa" Visible="False" OnClick="btnSua_Click" />
                    <asp:Button ID="btnChamSoc" runat="server" Text="Chăm sóc" Visible="False" OnClick="btnChamSoc_Click" />
                    
                        <asp:Button ID="btnShowPopup" runat="server" Text="Đào tạo" />
                  <asp:PopupControlExtender ID="PopAtt" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlThemDT" > </asp:PopupControlExtender>
                    <asp:Button ID="btnIn" runat="server" Text="In" />
                    <asp:Button ID="btnThoat" runat="server" Text="Thoát" OnClick="btnThoat_Click" />
                    <br />
                    <asp:Panel ID="pnlThemDT" CssClass="popupControl" runat="server">
                        <table style="width: 100%;">
                            <tr>
                                <td>Thời gian:&nbsp;&nbsp;<asp:TextBox ID="txtThoiGian" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtThoiGian">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkThamDu" runat="server" Enabled="False" Text="Tham dự" />
                                </td>
                               
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center">
                                    <asp:Button ID="btnDaoTao" runat="server" OnClick="btnDaoTao_Click" Text="Xong" Visible="False" />
                                </td>
                               
                            </tr>
                        </table>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <br />
                          </asp:Panel>
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

