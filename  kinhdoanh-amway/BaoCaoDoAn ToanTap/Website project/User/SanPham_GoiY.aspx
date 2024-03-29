﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="SanPham_GoiY.aspx.cs" Inherits="User_SanPham_ChuaDung" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


        .auto-style5 {
         
        }
        .auto-style15 {

        }
        .auto-style13 {
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
        .auto-style14 {


        }
        </style>
       <link href="../style/Show-popup.css" rel="stylesheet" />  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id='XinChao' style="width: 600px">
          <MARQUEE BEHAVIOR=alternate scrollamount="2" scrolldelay="40"  loop="-1"><asp:Label ID="lblClick" class='label' runat="server" Text="Label" Visible="False"></asp:Label></MARQUEE>
            </div>
    <div id='TroVe'>
          <asp:LinkButton ID="lbtTroVe" runat="server" Visible="False" OnClick="lbtTroVe_Click">Trở về</asp:LinkButton>
            </div>
    <asp:GridView ID="griMatHangChuaDung" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaSP" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="griMatHangChuaDung_SelectedIndexChanged" PageSize="5" OnPageIndexChanging="griMatHangChuaDung_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField HeaderText=" Xem        " SelectText="Xem   " ShowSelectButton="True">
            <HeaderStyle Wrap="False" />
            </asp:CommandField>
            <asp:BoundField DataField="MaSP" HeaderText="  Mã số         ">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="   Tên sản phẩm">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("TenSP").ToString().Length > 30 ? Eval("TenSP").ToString().Substring(0,30) +"..." : Eval("TenSP") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:TemplateField>
            <asp:TemplateField HeaderText="  Ảnh minh họa     ">
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
&nbsp;
    <asp:Label ID="lblTB" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>
&nbsp;<asp:Panel ID="pnlChiTietMH" runat="server" BorderStyle="Solid" Visible="False">
        <table style="width:100%;">
            <tr>
                <td colspan="2" style="text-align: center; font-size: large; font-style: inherit; color: #0000FF; font-weight: bold; background-color: #00FFFF;">CHI TIẾT THÔNG TIN SẢN PHẨM</td>
            </tr>
        </table>
        <table class="auto-style5" width="100%">
            <tr>
                <td class="auto-style15">Mã sản phẩm:
                    </td>
                <td class="auto-style15">
                    &nbsp;</td>
                <td rowspan="7">
                    <asp:Image ID="imgAnhSP" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style14" style="white-space: nowrap; " colspan="2">
                    <asp:TextBox ID="txtMaSP" runat="server" Enabled="False" Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style14" style="white-space: nowrap; width: 1%;">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14" style="white-space: nowrap; width: 1%;">Tên sản phẩm: &nbsp;</td>
                <td class="auto-style14">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14" style="white-space: nowrap; " colspan="2">
                    <asp:TextBox ID="txtTenSP" runat="server" Enabled="False" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style14" style="white-space: nowrap; width: 1%;">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">Giá:
                    </td>
                <td class="auto-style12">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12" colspan="2">
                    <asp:TextBox ID="txtGia" runat="server" Enabled="False" Width="160px"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="ftbGia" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtGia">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td style="vertical-align: top">Loại sản phẩm:</td>
            </tr>
            <tr>
                <td class="auto-style12" colspan="2">Cách sử dụng: </td>
                <td style="vertical-align: top; width: 1%; white-space: nowrap;">
                    <asp:DropDownList ID="droLoaiSP" runat="server" DataTextField="TenLSP" DataValueField="MaLSP" Enabled="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style12" colspan="3">
                    <br />
                    <asp:TextBox ID="txtCachSuDung" runat="server" Enabled="False" Height="40px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    &nbsp;<br /> </td>
            </tr>
            <tr>
                <td class="auto-style12" colspan="3">Chi tiết:
                    <CKEditor:CKEditorControl ID="fckChiTiet" runat="server" Enabled="False" Width=""></CKEditor:CKEditorControl>
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;&nbsp;
                    <a id="show-popup" href="#">Sử dụng</a>
                    <asp:Button ID="btnThoat" runat="server" CssClass="auto-style13" OnClick="btnThoat_Click" Text="Thoát" Width="80px" />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtNgaySD">
                    </asp:CalendarExtender>
                    &nbsp;<asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtNgayHH">
                    </asp:CalendarExtender>
                    <br />
                     <script  type='text/javascript'  src="../js/jquery-min-1-8-0.js"></script>
<script type='text/javascript' src="../js/jquery-ui-1-8-23.js"></script>
    <script src="../js/Show-popup.js"  type='text/javascript'></script>

    <div id="popup-bg"></div>
<div id="popup">
	<div id="popup-header">Ấn phím ESC hoặc click vào X để thoát<span id="popup-close" title="Close">x</span></div>
    <div id="popup-content">
        <br />

                            <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtSoLuong" runat="server" onblur="if (this.value == &quot;&quot;) {this.value = &quot;Số lượng&quot;;}" onfocus="if (this.value == &quot;Số lượng&quot;) {this.value = &quot;&quot;;}" value="Số lượng"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkMinhHoa" runat="server" Text="Minh họa" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtNgaySD" runat="server" onblur="if (this.value == &quot;&quot;) {this.value = &quot;Ngày sử dụng&quot;;}" onfocus="if (this.value == &quot;Ngày sử dụng&quot;) {this.value = &quot;&quot;;}" value="Ngày sử dụng"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNgayHH" runat="server" onblur="if (this.value == &quot;&quot;) {this.value = &quot;Ngày hết hạn&quot;;}" onfocus="if (this.value == &quot;Ngày hết hạn&quot;) {this.value = &quot;&quot;;}" value="Ngày hết hạn"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="txtGhiChu" runat="server" onblur="if (this.value == &quot;&quot;) {this.value = &quot;Ghi chú&quot;;}" onfocus="if (this.value == &quot;Ghi chú&quot;) {this.value = &quot;&quot;;}" value="Ghi chú" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <asp:Button ID="btnSuDung" runat="server" CssClass="auto-style13" OnClick="btnSuDung_Click" style="text-align: left" Text="Xong" Visible="False" />
                            </td>
                        </tr>
                    </table>

         </div>
</div> 
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    </asp:Content>

