<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="SanPham_GoiY.aspx.cs" Inherits="User_SanPham_ChuaDung" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


        .auto-style5 {
            width: 803px;
        }
        .auto-style15 {
            width: 751px;
            height: 30px;
        }
        .auto-style13 {
            width: 751px;
        }
        .auto-style14 {
            width: 751px;
            height: 9px;
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
    <asp:GridView ID="griMatHangChuaDung" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaMH" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="griMatHangChuaDung_SelectedIndexChanged" PageSize="5" OnPageIndexChanging="griMatHangChuaDung_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ButtonType="Button" HeaderText="Tùy chọn" SelectText="Chọn" ShowSelectButton="True">
            <HeaderStyle Wrap="False" />
            </asp:CommandField>
            <asp:BoundField DataField="MaMH" HeaderText="Mã số">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="TenMH" HeaderText="Tên sản phẩm">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Ảnh minh họa">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("AnhMH") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="35px" ImageUrl='<%# Eval("AnhMH", "~/src/product/{0}") %>' />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
                </asp:TemplateField>
            <asp:BoundField DataField="Gia" HeaderText="Giá" DataFormatString="{0:0,0.vnd}">
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
&nbsp;
    <asp:Label ID="lblTB" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>
&nbsp;<asp:Panel ID="pnlChiTietMH" runat="server" BorderStyle="Solid" Visible="False">
        <table style="width:100%;">
            <tr>
                <td colspan="2" style="text-align: center; font-size: large; font-style: inherit; color: #0000FF; font-weight: bold; background-color: #00FFFF;">CHI TIẾT THÔNG TIN SẢN PHẨM</td>
            </tr>
        </table>
        <table class="auto-style5">
            <tr>
                <td class="auto-style15">Mã sản phẩm:
                    <asp:TextBox ID="txtMaMH" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style13" rowspan="3">
                    <asp:Image ID="imgAnhMH" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style14">Tên sản phẩm:
                    <asp:TextBox ID="txtTenMH" runat="server" Enabled="False"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">Giá:
                    <asp:TextBox ID="txtGia" runat="server" Enabled="False"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="ftbGia" runat="server" Enabled="True" FilterType="Numbers" 

TargetControlID="txtGia" ></asp:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">Cách sử dụng:
                    <asp:TextBox ID="txtCachSuDung" runat="server" Width="303px" TextMode="MultiLine" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style13">&nbsp;Loại mặt hàng:
                    <asp:DropDownList ID="droLoaiMH" runat="server" DataTextField="TenLMH" DataValueField="MaLMH" Enabled="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style12" colspan="2">Chi tiết:
                    <CKEditor:CKEditorControl ID="fckChiTiet" runat="server" Enabled="False"></CKEditor:CKEditorControl>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnSuDung" runat="server" Text="Sử dụng" Visible="False" Width="7%" OnClick="btnSuDung_Click" />
                    <asp:Button ID="btnIn" runat="server" Text="In" Width="6%" />
                    <asp:Button ID="btnThoat" runat="server" Text="Thoát" Width="6%" OnClick="btnThoat_Click" />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtSoLuong" runat="server" onblur='if (this.value == "") {this.value = "Số lượng";}' onfocus='if (this.value == "Số lượng") {this.value = "";}' value ='Số lượng'></asp:TextBox>
                    <asp:CheckBox ID="chkMinhHoa" runat="server" Text="Minh họa" />
                    <asp:TextBox ID="txtNgaySD" runat="server" onblur='if (this.value == "") {this.value = "Ngày sử dụng";}' onfocus='if (this.value == "Ngày sử dụng") {this.value = "";}' value ='Ngày sử dụng'></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtNgaySD" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                    <asp:TextBox ID="txtNgayHH" runat="server" onblur='if (this.value == "") {this.value = "Ngày hết hạn";}' onfocus='if (this.value == "Ngày hết hạn") {this.value = "";}' value ='Ngày hết hạn'></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txtNgayHH" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                    <asp:TextBox ID="txtGhiChu" runat="server" onblur='if (this.value == "") {this.value = "Ghi chú";}' onfocus='if (this.value == "Ghi chú") {this.value = "";}' value ='Ghi chú'></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <div>
        Bản đồ ở đây
        &nbsp;</p>
</asp:Content>

