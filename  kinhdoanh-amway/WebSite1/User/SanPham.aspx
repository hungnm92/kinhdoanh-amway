<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="SanPham.aspx.cs" Inherits="User_SanPham" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../style/Show-popup.css" rel="stylesheet" />
    <style type="text/css">
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
        .auto-style12 {
        }
        .auto-style13 {
            
        }
        .auto-style14 {
        
        }
        .auto-style15 {
          
        }
        .auto-style16 {
            height: 24px;
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
    <asp:GridView ID="griMatHang" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaSP" ForeColor="#333333" GridLines="None" OnPageIndexChanging="griMatHang_PageIndexChanging" OnSelectedIndexChanged="griMatHang_SelectedIndexChanged" PageSize="5">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField HeaderText="Xem        " SelectText="Xem" ShowSelectButton="True">
            <HeaderStyle Wrap="False" />
            </asp:CommandField>
            <asp:BoundField DataField="MaSP" HeaderText="Mã số         ">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="TenSP" HeaderText="  Tên sản phẩm     ">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Ảnh      ">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("AnhSP") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="35px" ImageUrl='<%# Eval("AnhSP", "~/src/product/{0}") %>' />
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
    <asp:LinkButton ID="lbtThemMoi" runat="server" Font-Bold="True" OnClick="lbtThemMoi_Click">Thêm mới.</asp:LinkButton>
&nbsp;
    <asp:Label ID="lblTB" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>
&nbsp;<asp:Panel ID="pnlChiTietMH" runat="server" BorderStyle="Solid" Visible="False">
        <table style="width:100%;">
            <tr>
                <td colspan="2" style="text-align: center; font-size: large; font-style: inherit; color: #0000FF; font-weight: bold; background-color: #00FFFF;">CHI TIẾT THÔNG TIN SẢN PHẨM</td>
            </tr>
        </table>
        <table width="100%" >
            <tr>
                <td class="auto-style15" style="text-align: left">Mã sản phẩm:
                    </td>
                <td class="auto-style13" rowspan="7" style="width: 250px">
                    <asp:Image ID="imgAnhSP" runat="server" />
                    <br />
                    <asp:FileUpload ID="fileAnhSP" runat="server" />
                    <br />
                    <asp:RegularExpressionValidator 
	ID="RegularExpressionValidator1" 
	runat="server" 
	ControlToValidate="fileAnhSP" 
	ErrorMessage="Không phải file ảnh" 
	ValidationExpression= 
"^([0-9a-zA-Z_\-~ :\\])+(.jpg|.JPG|.jpeg|.JPEG|.bmp|.BMP|.gif|.GIF|.png|.PNG)$"> 
</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style15" style="text-align: left">
                    <asp:TextBox ID="txtMaSP" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style15" style="text-align: left">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15" style="text-align: left">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15" style="text-align: left">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14" style="text-align: left">Tên sản phẩm:
                    </td>
            </tr>
            <tr>
                <td class="auto-style16" style="text-align: left">
                    <asp:TextBox ID="txtTenSP" runat="server" Height="41px" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style12" style="text-align: left">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12" style="text-align: left">Giá:&nbsp; </td>
                <td class="auto-style13">&nbsp;Loại sản phẩm: </td>
            </tr>
            <tr>
                <td class="auto-style12" style="text-align: left">
                    <asp:TextBox ID="txtGia" runat="server"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="ftbGia" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtGia">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td class="auto-style13">
                    <asp:DropDownList ID="droLoaiSP" runat="server" DataTextField="TenLSP" DataValueField="MaLSP">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style12" colspan="2">Cách sử dụng:
                    <asp:TextBox ID="txtCachSuDung" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style12" colspan="2">Chi tiết:
                    <CKEditor:CKEditorControl ID="fckChiTiet" runat="server"></CKEditor:CKEditorControl>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;&nbsp;<asp:Button ID="btnThem" runat="server" OnClick="btnThem_Click" Text="Thêm" Visible="False" CssClass="style-button" Width="66px" />
                    &nbsp;<a id="show-popup" href="#">Sử dụng</a>
                    <asp:Button ID="btnXoa" runat="server" OnClick="btnXoa_Click" Text="Xóa" Visible="False" CssClass="style-button" Width="66px" />
                    &nbsp;<asp:Button ID="btnSua" runat="server" OnClick="btnSua_Click" Text="Sửa" Visible="False" CssClass="style-button" Width="66px" />
                    &nbsp;<asp:Button ID="btnThoat" runat="server" OnClick="btnThoat_Click" Text="Thoát" CssClass="style-button" Width="66px" />
                    <br />
                    
<div id="popup-bg"></div>
<div id="popup">
	<div id="popup-header">Ấn phím ESC hoặc click vào X để thoát<span id="popup-close" title="Close">x</span></div>
    <div id="popup-content">
                           <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtSoLuong" runat="server" onblur="if (this.value == &quot;&quot;) {this.value = &quot;Số lượng&quot;;}" onfocus="if (this.value == &quot;Số lượng&quot;) {this.value = &quot;&quot;;}" value="Số lượng" Visible="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkMinhHoa" runat="server" Text="Minh họa" Visible="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtNgaySD" runat="server" onblur="if (this.value == &quot;&quot;) {this.value = &quot;Ngày sử dụng&quot;;}" onfocus="if (this.value == &quot;Ngày sử dụng&quot;) {this.value = &quot;&quot;;}" value="Ngày sử dụng" Visible="true"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtNgaySD">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNgayHH" runat="server" onblur="if (this.value == &quot;&quot;) {this.value = &quot;Ngày hết hạn&quot;;}" onfocus="if (this.value == &quot;Ngày hết hạn&quot;) {this.value = &quot;&quot;;}" value="Ngày hết hạn" Visible="true"></asp:TextBox>
                                <asp:CalendarExtender ID="txtNgayHH_CalendarExtender" runat="server" Format="dd/MM/yyyy" TargetControlID="txtNgayHH">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="txtGhiChu" runat="server" onblur="if (this.value == &quot;&quot;) {this.value = &quot;Ghi chú&quot;;}" onfocus="if (this.value == &quot;Ghi chú&quot;) {this.value = &quot;&quot;;}" value="Ghi chú" Visible="true" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <asp:Button ID="btnSuDung" runat="server" CssClass="style-button" OnClick="btnSuDung_Click" Text="Xong" Visible="False" />
                            </td>
                        </tr>
                    </table>
                        
        </div>
</div>

                    <script  type='text/javascript'  src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.0/jquery.min.js"></script>
<script  type='text/javascript'  src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/jquery-ui.min.js"></script>
                    <script type='text/javascript'  src="../js/Show-popup.js"></script>
                
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <p>
        </p>
</asp:Content>

