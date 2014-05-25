<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="NhaPhanPhoi.aspx.cs" Inherits="User_NhaPhanPhoi" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
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
        .auto-style10 {
           
        }
        .auto-style15 {
           
        }
             /*phần tử phủ toàn màn hình*/          
    </style>
              <link href="../style/Show-popup.css" rel="stylesheet" />              
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script  type='text/javascript'  src="../js/jquery-min-1-8-0.js"></script>
<script type='text/javascript' src="../js/jquery-ui-1-8-23.js"></script>
    <script src="../js/Show-popup.js"  type='text/javascript'></script>

    <div id="popup-bg"></div>
<div id="popup">
	<div id="popup-header">Header<span id="popup-close" title="Close">x</span></div>
    <div id="popup-content">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                       <table style="width: 100%;">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblXoa" runat="server" ForeColor="Red" Text="Bạn có chắc chắn muốn xóa Nhà phân phối này"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <asp:Button ID="btnXoa" runat="server" CssClass="style-button" OnClick="btnXoa_Click" Text="Đồng ý" Visible="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="droNhaBaoTro" runat="server" DataTextField="HoTenNPP" DataValueField="MaNPP" Visible="false">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnChuyenMacDinh" runat="server" CssClass="style-button" OnClick="btnChuyenMacDinh_Click" Text="Chuyển mặc định" Visible="false" />
                            </td>
                            <td>
                                <asp:Button ID="btnChuyenTheoYeuCau" runat="server" CssClass="style-button" OnClick="btnChuyenTheoYeuCau_Click" Text="Chuyển theo yêu cầu" Visible="false" />
                            </td>
                        </tr>
                    </table>
                    </ContentTemplate>
                </asp:UpdatePanel> 
    </div>
</div> 
    <div id='XinChao'>
          <asp:Label ID="lblClick" class='label' runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
    <asp:GridView ID="griNhaPhanPhoi" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaNPP" ForeColor="#333333" GridLines="None" OnPageIndexChanging="griNhaPhanPhoi_PageIndexChanging" OnSelectedIndexChanged="griNhaPhanPhoi_SelectedIndexChanged" PageSize="5" Width="100%">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField SelectText="Xem" ShowSelectButton="True">
            <ControlStyle Font-Underline="True" ForeColor="#009900" />
            <FooterStyle Font-Underline="False" />
            <HeaderStyle Wrap="False" />
            </asp:CommandField>
            <asp:BoundField DataField="MaNPP" HeaderText="Mã ADA">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="HoTenNPP" HeaderText="Họ tên">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="NgaySinh" HeaderText="Ngày sinh" DataFormatString=" {0:dd/MM/yyyy}">
            </asp:BoundField>
            <asp:BoundField DataField="SoDT" HeaderText="Số điện thoại">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="NgayKyThe" HeaderText="Ngày ký thẻ" DataFormatString=" {0:dd/MM/yyyy}">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Địa chỉ liên lạc">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("DiaChiLL").ToString().Length > 20 ? Eval("DiaChiLL").ToString().Substring(0,20) +"..." : Eval("DiaChiLL") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:TemplateField>
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
&nbsp;<asp:Label ID="lblTBQTCD" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>
    <asp:Panel ID="pnlChiTietNPP" runat="server" BorderStyle="Solid" Visible="False">
        <table style="width:100%;">
            <tr>
                <td style="text-align: center; font-size: large; font-style: inherit; color: #0000FF; font-weight: bold; background-color: #00FFFF;" class="auto-style15">CHI TIẾT THÔNG TIN NHÀ PHÂN PHỐI</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCanhBao" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
        <table style="width:100%;">
            <tr>
                <td colspan="2">
                    
                    </td>
                <td rowspan="4" style="vertical-align: bottom">
                    <asp:Image ID="imgAnhNPP" runat="server" Width="85px" Height="30px" />
                    <br />
                    <asp:FileUpload ID="fileAnhNPP" runat="server" />
                    <br />
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
                <td >Mã ADA: </td>
                <td>
                    <asp:TextBox ID="txtMaNPP" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="ftbMaNPP" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtMaNPP">
                    </asp:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td >Họ và đệm: &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtHoNPP" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >Tên:</td>
                <td>
                    <asp:TextBox ID="txtTenNPP" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >Ngày sinh: </td>
                <td>
                    <asp:TextBox ID="txtNgaySinh" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                </td>
                <td >Giới tính:
                    <asp:RadioButton ID="rdoNam" runat="server" Checked="True" GroupName="GioiTinh" Text="Nam" />
                    &nbsp;
                    <asp:RadioButton ID="rdoNu" runat="server" GroupName="GioiTinh" Text="Nữ" />
                </td>
            </tr>
            <tr>
                <td >Số CMND:
                    </td>
                <td>
                    <asp:TextBox ID="txtCMND" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="ftbCMND" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtCMND">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td >Số điện thoại:
                    <asp:TextBox ID="txtSoDT" runat="server"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="ftbSoDT" runat="server" Enabled="True" FilterType="Numbers" 

TargetControlID="txtSoDT" ></asp:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td >Email:
                    </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" style="width: 128px"></asp:TextBox>
                </td>
                <td >Ngày ký thẻ:
                    <asp:TextBox ID="txtNgayKyThe" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  style="white-space: nowrap">Ngày hết hạn:
                    </td>
                <td>
                    <asp:TextBox ID="txtNgayHetHan" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td style="white-space: nowrap">Địa chỉ thường trú:</td>
                <td colspan="2">
                    <asp:TextBox ID="txtSoNhaNPPTT" runat="server"></asp:TextBox>
                    &nbsp;<asp:DropDownList ID="droDuongNPPTT" runat="server" DataTextField="TenDuong" DataValueField="MaDuong">
                    </asp:DropDownList>
                    &nbsp;</td>
            </tr>
            <tr>
                <td  style="white-space: nowrap">&nbsp;</td>
                <td colspan="2"><asp:UpdatePanel ID="UpdatePanel2" runat="server">
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
                <td  style="white-space: nowrap">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td style="white-space: nowrap">Địa chỉ liên lạc:</td>
                <td colspan="2">
                    <asp:TextBox ID="txtSoNhaNPPLL" runat="server"></asp:TextBox>
                    &nbsp;<asp:DropDownList ID="droDuongNPPLL" runat="server" DataTextField="TenDuong" DataValueField="MaDuong">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="white-space: nowrap">&nbsp;</td>
                <td colspan="2">
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
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style26" colspan="1">Cấp độ:
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="droCapDo" runat="server" DataTextField="TenCD" DataValueField="MaCD">
                    </asp:DropDownList>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="1">Nhà bảo trợ:</td>
                <td colspan="2">
                    <asp:DropDownList ID="droNBT" runat="server" DataTextField="HoTenNPP" DataValueField="MaNPP">
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:LinkButton ID="lbtSP" runat="server" OnClick="lbtSP_Click" Visible="False">Sản phẩm</asp:LinkButton>
                    &nbsp;&nbsp;<asp:LinkButton ID="lbtSPSD" runat="server" OnClick="lbtSPSD_Click">Sản phẩm sử dụng</asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="lblSPGY" runat="server" OnClick="lblSPGY_Click">Sản phẩm gợi ý</asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="lbtCTSDR" runat="server" OnClick="lbtCTSDR_Click" Visible="False">Chương trình sắp diễn ra</asp:LinkButton>
                    <br />
                    &nbsp;<asp:LinkButton ID="lbtTTDT" runat="server" OnClick="lbtTTDT_Click">Thông tin đào tạo</asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="lbtTTCS" runat="server" OnClick="lbtTTCS_Click">Thông tin chăm sóc</asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="lbtTTDThu" runat="server" OnClick="lbtTTDThu_Click">Thông tin doanh thu</asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="lbtQTCD" runat="server" OnClick="lbtQTCD_Click">Quá trình cấp độ</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /> &nbsp;<asp:Button ID="btnGHT" runat="server" OnClick="btnGHT_Click" Text="Gia hạn thẻ" CssClass="style-button" />
                    &nbsp;<asp:Button ID="btnThem" runat="server" OnClick="btnThem_Click" Text="Thêm" Visible="False" CssClass="style-button" />
&nbsp;<a id="show-popup" href="#">Xóa</a>
                    <asp:Button ID="btnSua" runat="server" OnClick="btnSua_Click" Text="Sửa" Visible="False" Width="8%" CssClass="style-button" />
                    &nbsp;<asp:Button ID="btnIn" runat="server" Text="In" Width="8%" CssClass="style-button" />
                    &nbsp;<asp:Button ID="btnThoat" runat="server" OnClick="btnThoat_Click" Text="Thoát" CssClass="style-button" />
                   
                    <br />
                     
                    
                    <!-- abc -->
      

                     <!-- abc -->
                    <br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;<br />
                    
                    <br />
                    
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

