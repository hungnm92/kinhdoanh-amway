<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="ThongKe.aspx.cs" Inherits="User_NhaPhanPhoi" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style10 {
           
        }
        .auto-style15 {
           
        }
             /*phần tử phủ toàn màn hình*/
             * {
	padding:0;
	font-family:Arial, Helvetica, sans-serif;
            margin-left: 0;
            margin-right: 0;
            margin-bottom: 0;
        }
a#show-popup {
	margin:20px 0 0 20px;
	float:left;
	text-decoration:none;
}
div#popup-bg {
	position:absolute;
	top:0;
	bottom:0;
	left:0;
	right:0;
	z-index:99;
	background:#000;
	display:none;
}
div#popup {
	width:680px;
	height:480px;
	border:solid 4px #000000;
	z-index:999;
	display:none;
	background:#FFF;
}
div#popup-header {
	position:relative;
	float:left;
	width:680px;
	line-height:30px;
	font-size:20px;
	background:#000;
	color:#FF0;
	cursor:move;
}
span#popup-close {
	cursor:pointer;
	color:#FFF;
	font-size:12px;
	position:absolute;
	top:-2px;
	right:10px;
	z-index:9999;
}
div#popup-content {
	width:670px;
	float:left;
	padding:5px;
}

        .auto-style16 {
            height: 26px;
        }

        .auto-style17 {
            height: 24px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div id='XinChao'>
          <asp:Label ID="lblClick" class='label' runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
    <asp:Panel ID="pnlThongKe" runat="server" BorderStyle="Solid">
        <table style="width:100%;">
            <tr>
                <td style="text-align: center; font-size: large; font-style: inherit; color: #0000FF; font-weight: bold; background-color: #00FFFF;" class="auto-style15">THỐNG KÊ</td>
            </tr>
        </table>
        <table style="width:100%;">
            <tr>
                <td class="auto-style16">
                    
                    Từ ngày:</td>
                <td class="auto-style16">
                    <asp:TextBox ID="txtTuNgay" runat="server" style="width: 128px"></asp:TextBox>
                     <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtTuNgay" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                </td>
                <td class="auto-style16">Đến ngày:&nbsp;
                    <asp:TextBox ID="txtDenNgay" runat="server"></asp:TextBox>
                     <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txtDenNgay" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="white-space: nowrap" >
                    <asp:Button ID="btnNPP_Moi" runat="server" Text="Thống kê NNP mới" Width="22%" OnClick="btnNPP_Moi_Click" />
                    <asp:Button ID="btnNPP_ThanhTichMoi" runat="server" Text="Thống kê NPP đạt thành tích mới" Width="38%" OnClick="btnNPP_ThanhTichMoi_Click" />
                    <asp:Button ID="btnNPP_SapHetHan" runat="server" Text="Thống kê NPP sắp hết hạn" Width="30%" OnClick="btnNPP_SapHetHan_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:GridView ID="griNPP_Moi" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaNPP" ForeColor="#333333" GridLines="None" OnPageIndexChanging="griNPP_Moi_PageIndexChanging" OnSelectedIndexChanged="griNPP_Moi_SelectedIndexChanged" PageSize="5">
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
    <asp:GridView ID="griNPP_ThanhTichMoi" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaNPP" ForeColor="#333333" GridLines="None" OnPageIndexChanging="griNPP_ThanhTichMoi_PageIndexChanging" OnSelectedIndexChanged="griNPP_ThanhTichMoi_SelectedIndexChanged" PageSize="5">
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
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("DiaChiLL").ToString().Length > 20 ? Eval("DiaChiLL").ToString().Substring(0,20) +"..." : Eval("DiaChiLL") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:TemplateField>
            <asp:BoundField DataField="TenCD" HeaderText="Cấp độ" />
            <asp:BoundField DataField="ThoiGian" DataFormatString=" {0:dd/MM/yyyy}" HeaderText="Thời gian" />
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
    <asp:GridView ID="griNPP_SapHetHan" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaNPP" ForeColor="#333333" GridLines="None" OnPageIndexChanging="griNPP_ThanhTichMoi_PageIndexChanging" OnSelectedIndexChanged="griNPP_SapHetHan_SelectedIndexChanged" PageSize="5">
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
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("DiaChiLL").ToString().Length > 20 ? Eval("DiaChiLL").ToString().Substring(0,20) +"..." : Eval("DiaChiLL") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:TemplateField>
            <asp:BoundField DataField="TenCD" HeaderText="Cấp độ" />
            <asp:BoundField DataField="ThoiGian" DataFormatString=" {0:dd/MM/yyyy}" HeaderText="Thời gian" />
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
    <asp:Panel ID="pnlChiTietNPP" runat="server" BorderStyle="Solid" Visible="False">
        <table style="width:100%;">
            <tr>
                <td style="text-align: center; font-size: large; font-style: inherit; color: #0000FF; font-weight: bold; background-color: #00FFFF;" class="auto-style15">CHI TIẾT THÔNG TIN NHÀ PHÂN PHỐI</td>
            </tr>
        </table>
        <table style="width:100%;">
            <tr>
                <td colspan="2">
                    
                    </td>
                <td rowspan="4" style="vertical-align: bottom">
                    <asp:Image ID="imgAnhNPP" runat="server" Width="85px" Height="30px" />
                    <br />
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
                    <asp:TextBox ID="txtHoNPP" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style17" >Tên:</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txtTenNPP" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >Ngày sinh: </td>
                <td>
                    <asp:TextBox ID="txtNgaySinh" runat="server" Enabled="False" ReadOnly="True" style="height: 20px"></asp:TextBox>
                </td>
                <td >Giới tính:
                    <asp:RadioButton ID="rdoNam" runat="server" Checked="True" GroupName="GioiTinh" Text="Nam" Enabled="False" />
                    &nbsp;
                    <asp:RadioButton ID="rdoNu" runat="server" GroupName="GioiTinh" Text="Nữ" Enabled="False" />
                </td>
            </tr>
            <tr>
                <td >Số CMND:
                    </td>
                <td>
                    <asp:TextBox ID="txtCMND" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="ftbCMND" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtCMND">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td >Số điện thoại:
                    <asp:TextBox ID="txtSoDT" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="ftbSoDT" runat="server" Enabled="True" FilterType="Numbers" 

TargetControlID="txtSoDT" ></asp:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td >Email:
                    </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" style="width: 128px; height: 20px;" Enabled="False" ReadOnly="True"></asp:TextBox>
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
                    <asp:TextBox ID="txtSoNhaNPPTT" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                    &nbsp;<asp:DropDownList ID="droDuongNPPTT" runat="server" DataTextField="TenDuong" DataValueField="MaDuong" Enabled="False">
                    </asp:DropDownList>
                    &nbsp;</td>
            </tr>
            <tr>
                <td  style="white-space: nowrap">&nbsp;</td>
                <td colspan="2"><asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="droXaNPPTT" runat="server" AutoPostBack="false" DataTextField="TenXa" DataValueField="MaXa" Enabled="False">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droHuyenNPPTT" runat="server" AutoPostBack="true" DataValueField="MaHuyen" DataTextField="TenHuyen" Enabled="False">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droTinhNPPTT" runat="server" AutoPostBack="true" DataTextField="TenTinh" DataValueField="MaTinh" Enabled="False">
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
                    <asp:TextBox ID="txtSoNhaNPPLL" runat="server" Enabled="False"></asp:TextBox>
                    &nbsp;<asp:DropDownList ID="droDuongNPPLL" runat="server" DataTextField="TenDuong" DataValueField="MaDuong" Enabled="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="white-space: nowrap">&nbsp;</td>
                <td colspan="2">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="droXaNPPLL" runat="server" AutoPostBack="false" DataTextField="TenXa" DataValueField="MaXa" Enabled="False">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droHuyenNPPLL" runat="server" AutoPostBack="true" DataTextField="TenHuyen" DataValueField="MaHuyen" Enabled="False">
                    </asp:DropDownList>
                    <asp:DropDownList ID="droTinhNPPLL" runat="server" AutoPostBack="true" DataTextField="TenTinh" DataValueField="MaTinh" Enabled="False">
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
                    <asp:DropDownList ID="droCapDo" runat="server" DataTextField="TenCD" DataValueField="MaCD" Enabled="False">
                    </asp:DropDownList>
                    &nbsp;<asp:Button ID="Button1" runat="server" Text="Xem quá trình" />
                </td>
            </tr>
            <tr>
                <td colspan="1">Nhà bảo trợ:</td>
                <td colspan="2">
                    <asp:DropDownList ID="droNBT" runat="server" DataTextField="HoTenNPP" DataValueField="MaNPP" Enabled="False">
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td colspan="3">                   
                    <asp:Button ID="btnIn" runat="server" Text="In" Width="8%" />
                    <asp:Button ID="btnThoat" runat="server" OnClick="btnThoat_Click" Text="Thoát" Width="8%" />
                     <asp:LinkButton ID="show_popup" href ='#' runat="server" >Thông tin</asp:LinkButton>
                    <br />
                     
                    
                    <!-- abc -->
                   
<div id="popup-bg"></div>
<div id="popup">
	<div id="popup-header">Header<span id="popup-close" title="Close">x</span></div>
    <div id="popup-content">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="droNhaBaoTro" runat="server" DataTextField="HoTenNPP" DataValueField="MaNPP" Visible="true">
                    </asp:DropDownList>
                    <br />
                    </ContentTemplate>
                </asp:UpdatePanel> 
    </div>
</div>
                    <script type='text/javascript' src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.0/jquery.min.js"></script>
<script type='text/javascript' src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/jquery-ui.min.js"></script>
<script type='text/javascript'>
    $(document).ready(function () {
        (function ($) {
            //Căn giữa phần tử thuộc tính là absolute so với phần hiển thị của trình duyệt, chỉ dùng cho phần tử absolute đối với body
            $.fn.absoluteCenter = function () {
                this.each(function () {
                    var top = -($(this).outerHeight() / 2) + 'px';
                    var left = -($(this).outerWidth() / 2) + 'px';
                    $(this).css({ 'position': 'absolute', 'position': 'fixed', 'margin-top': top, 'margin-left': left, 'top': '50%', 'left': '50%' });
                    return this;
                });
            }
        })(jQuery);

        $('LinkButton#show_popup').click(function () {
            //Đặt biến cho các đối tượng để gọi dễ dàng
            var bg = $('div#popup-bg');
            var obj = $('div#popup');
            var btnClose = obj.find('#popup-close');
            //Hiện các đối tượng
            bg.animate({ opacity: 0.2 }, 0).fadeIn(1000); //cho nền trong suốt
            obj.fadeIn(1000).draggable({ cursor: 'move', handle: '#popup-header' }).absoluteCenter(); //căn giữa popup và thêm draggable của jquery UI cho phần header của popup
            //Đóng popup khi nhấn nút
            btnClose.click(function () {
                bg.fadeOut(1000);
                obj.fadeOut(1000);
            });
            //Đóng popup khi nhấn background
            bg.click(function () {
                btnClose.click(); //Kế thừa nút đóng ở trên
            });
            //Đóng popup khi nhấn nút Esc trên bàn phím
            $(document).keydown(function (e) {
                if (e.keyCode == 27) {
                    btnClose.click(); //Kế thừa nút đóng ở trên
                }
            });
            return false;
        });
    });
</script>
               

                     <!-- abc -->
                    <br />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />

    <br />

         <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
<script type="text/javascript">
    var markers = [
    <asp:Repeater ID="rptMarkers" runat="server">
    <ItemTemplate>
                {
                    "title": '<%# Eval("MaNPP") %>',
                    "lat": '<%# Eval("ViDo") %>',
                    "lng": '<%# Eval("KinhDo") %>',
                    "description": '<%# Eval("HoTen") %>'
                }
</ItemTemplate>
<SeparatorTemplate>
    ,
</SeparatorTemplate>
</asp:Repeater>
    ];
</script>
<script type="text/javascript">
    window.onload = function () {
        var mapOptions = {
            center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
            zoom: 8,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var infoWindow = new google.maps.InfoWindow();
        var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
        for (i = 0; i < markers.length; i++) {
            var data = markers[i]
            var myLatlng = new google.maps.LatLng(data.lat, data.lng);
            var marker = new google.maps.Marker({
                position: myLatlng,
                map: map,
                title: data.title
            });
            (function (marker, data) {
                google.maps.event.addListener(marker, "click", function (e) {
                    infoWindow.setContent(data.description);
                    infoWindow.open(map, marker);
                });
            })(marker, data);
        }
    }
</script>
<div id="dvMap" style="width: 545px; height: 500px">

    <p>
        &nbsp;</p>
    </div>
</asp:Content>

