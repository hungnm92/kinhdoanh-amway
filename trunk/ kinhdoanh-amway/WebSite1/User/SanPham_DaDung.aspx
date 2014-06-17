<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="SanPham_DaDung.aspx.cs" Inherits="User_SanPham_DaDung" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


        .auto-style5 {
        }
        .auto-style13 {
        }
        .auto-style14 {
        }
        .auto-style15 {
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
    <asp:GridView ID="griMatHangNPPDaDung" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaNPPSD" ForeColor="#333333" GridLines="None" PageSize="5" OnPageIndexChanging="griMatHangDaDung_PageIndexChanging" OnSelectedIndexChanged="griMatHangDaDung_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField SelectText="Xem" ShowSelectButton="True" HeaderText="Xem">
            <HeaderStyle Wrap="False" />
            </asp:CommandField>
             <asp:TemplateField HeaderText="   Tên sản phẩm">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("TenSP").ToString().Length > 30 ? Eval("TenSP").ToString().Substring(0,30) +"..." : Eval("TenSP") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:TemplateField>
            <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" />
            <asp:TemplateField HeaderText="Ảnh minh họa">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("AnhSP") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="35px" ImageUrl='<%# Eval("AnhSP", "~/src/product/{0}") %>' />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
                </asp:TemplateField>
            <asp:BoundField DataField="NgayNPPSD" HeaderText="Ngày sử dụng" DataFormatString=" {0:dd/MM/yyyy}">
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
            <asp:CommandField SelectText="Xem" ShowSelectButton="True" HeaderText="Xem">
            <HeaderStyle Wrap="False" />
            </asp:CommandField>
            <asp:TemplateField HeaderText="   Tên sản phẩm">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("TenSP").ToString().Length > 30 ? Eval("TenSP").ToString().Substring(0,30) +"..." : Eval("TenSP") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:TemplateField>
            <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" />
            <asp:CheckBoxField DataField="MinhHoa" HeaderText="Minh họa" >
            <HeaderStyle Wrap="False" />
            </asp:CheckBoxField>
            <asp:BoundField DataField="NgayKHSD" HeaderText="Ngày sử dụng" DataFormatString="{0:dd/MM/yyyy}">
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
                    </td>
                <td class="auto-style13">
                    <asp:TextBox ID="txtMaSP" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style13" rowspan="6">
                    <asp:Image ID="imgAnhSP" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style14" style="white-space: nowrap; width: 1%">Tên sản phẩm: &nbsp;</td>
                <td class="auto-style14">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14" colspan="2" style="white-space: nowrap; ">
                    <asp:TextBox ID="txtTenSP" runat="server" Enabled="False" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">Giá:
                    </td>
                <td class="auto-style12" rowspan="3">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                            <table style="width: 100%;">
                                <tr>
                                    <td> <asp:TextBox ID="txtGia" AutoPostBack="true" runat="server" Enabled="False" OnTextChanged="txtGia_TextChanged"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="ftbGia" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtGia">
                    </asp:FilteredTextBoxExtender>&nbsp;vnđ</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>                    <asp:TextBox ID="txtSoLuong" AutoPostBack="true" runat="server" OnTextChanged="txtSoLuong_TextChanged"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="ftbSoLuong" runat="server" Enabled="True" FilterType="Numbers"  TargetControlID="txtSoLuong">
                    </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>                    <asp:TextBox ID="txtTongTien" AutoPostBack="false" runat="server"></asp:TextBox>
                    &nbsp;vnđ</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="auto-style15">Số lượng: </td>
            </tr>
            <tr>
                <td class="auto-style15">Tổng tiền:</td>
            </tr>
            <tr>
                <td class="auto-style12">Cách sử dụng:
                    </td>
                <td class="auto-style12" colspan="2">
                    <asp:TextBox ID="txtCachSuDung" runat="server" Enabled="False" TextMode="MultiLine" Width="99%" Height="53px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style15">
                    <asp:CheckBox ID="chkMinhHoa" runat="server" Text="Minh họa" />
                    </td>
                <td class="auto-style15" colspan="2">
                    &nbsp;Loại sản phẩm:
                    <asp:DropDownList ID="droLoaiMH" runat="server" DataTextField="TenLSP" DataValueField="MaLSP" Enabled="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style12" colspan="3">Chi tiết:<br />
                    <CKEditor:CKEditorControl ID="fckChiTiet" runat="server" Enabled="False"></CKEditor:CKEditorControl>
                </td>
            </tr>
            <tr>
                <td class="auto-style12" colspan="2">Ngày sử dụng:
                    <asp:TextBox ID="txtThoiGian" runat="server" Enabled="False"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtThoiGian">
                    </asp:CalendarExtender>
                </td>
                <td class="auto-style12">Ngày hết hạn:
                    <asp:TextBox ID="txtNgayHH" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtNgayHH">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="auto-style12" colspan="3">Ghi chú:<br />
                    <asp:TextBox ID="txtGhiChu" runat="server" TextMode="MultiLine" Width="99%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: right"><asp:Button ID="btnSua" runat="server" OnClick="btnSua_Click" Text="Cập nhật" Visible="False" Width="72px" />
                    &nbsp;<asp:Button ID="btnXoa" runat="server" OnClick="btnXoa_Click" Text="Xóa" Visible="False" Width="70px" />
&nbsp;<asp:Button ID="btnThoat" runat="server" OnClick="btnThoat_Click" Text="Thoát" Width="70px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <p>
        &nbsp;</p>
</asp:Content>

