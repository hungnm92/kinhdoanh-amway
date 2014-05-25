<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="SanPham_DaDung.aspx.cs" Inherits="User_SanPham_DaDung" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


        .auto-style5 {
            width: 803px;
        }
        .auto-style13 {
            width: 751px;
        }
        .auto-style14 {
            width: 751px;
            height: 9px;
        }
        .auto-style15 {
            height: 30px;
        }
        .auto-style16 {
            height: 30px;
            width: 751px;
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
    <asp:GridView ID="griMatHangNPPDaDung" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaNPPSD" ForeColor="#333333" GridLines="None" PageSize="5" OnPageIndexChanging="griMatHangDaDung_PageIndexChanging" OnSelectedIndexChanged="griMatHangDaDung_SelectedIndexChanged">
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
            <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" />
            <asp:CheckBoxField DataField="MinhHoa" HeaderText="Minh họa" >
            <HeaderStyle Wrap="False" />
            </asp:CheckBoxField>
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
            <asp:BoundField DataField="NgayNPPSD" HeaderText="Ngày sử dụng" DataFormatString=" {0:dd/MM/yyyy}">
            <HeaderStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="NgayNPPSDHH" HeaderText="Ngày hết hạn" DataFormatString=" {0:dd/MM/yyyy}" >
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
    <asp:GridView ID="griMatHangKHDaDung" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaKHSD" ForeColor="#333333" GridLines="None" PageSize="5" OnPageIndexChanging="griMatHangDaDung_PageIndexChanging" OnSelectedIndexChanged="griMatHangDaDung_SelectedIndexChanged">
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
            <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" />
            <asp:CheckBoxField DataField="MinhHoa" HeaderText="Minh họa" >
            <HeaderStyle Wrap="False" />
            </asp:CheckBoxField>
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
            <asp:BoundField DataField="NgayKHSD" HeaderText="Ngày sử dụng" DataFormatString="{0:dd/MM/yyyy}">
            <HeaderStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="NgayKHSDHH" HeaderText="Ngày hết hạn" DataFormatString="{0:dd/MM/yyyy}">
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
    <asp:Label ID="lblTB" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>
&nbsp;<asp:Panel ID="pnlChiTietMH" runat="server" BorderStyle="Solid" Visible="False">
        <table style="width:100%;">
            <tr>
                <td colspan="2" style="text-align: center; font-size: large; font-style: inherit; color: #0000FF; font-weight: bold; background-color: #00FFFF;">CHI TIẾT THÔNG TIN SẢN PHẨM</td>
            </tr>
        </table>
        <table class="auto-style5">
            <tr>
                <td class="auto-style13">Mã sản phẩm:
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
                    <asp:FilteredTextBoxExtender ID="ftbGia" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtGia" ></asp:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">Cách sử dụng:
                    <asp:TextBox ID="txtCachSuDung" runat="server" Width="359px" Enabled="False" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="auto-style13">&nbsp;Loại mặt hàng:
                    <asp:DropDownList ID="droLoaiMH" runat="server" DataTextField="TenLMH" DataValueField="MaLMH" Enabled="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style15">Số lượng:
                    <asp:TextBox ID="txtSoLuong" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style16">
                    <asp:CheckBox ID="chkMinhHoa" runat="server" Text="Minh họa" />
                </td>
            </tr>
            <tr>
                <td class="auto-style12">Chi tiết:
                    <CKEditor:CKEditorControl ID="fckChiTiet" runat="server" Enabled="False"></CKEditor:CKEditorControl>
                </td>
                <td class="auto-style12">Ngày sử dụng:
                    <asp:TextBox ID="txtThoiGian" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">Ghi chú:
                    <asp:TextBox ID="txtGhiChu" runat="server" TextMode="MultiLine" Width="387px"></asp:TextBox>
                </td>
                <td class="auto-style12">Ngày hết hạn: 
                    <asp:TextBox ID="txtNgayHH" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtNgayHH" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnXoa" runat="server" OnClick="btnXoa_Click" Text="Xóa" Width="6%" Visible="False" />
                    <asp:Button ID="btnSua" runat="server" OnClick="btnSua_Click" Text="Sửa" Width="6%" Visible="False" />
                    <asp:Button ID="btnIn" runat="server" Text="In" Width="6%" />
                    <asp:Button ID="btnThoat" runat="server" OnClick="btnThoat_Click" Text="Thoát" Width="6%" />
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

