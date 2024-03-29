﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DangNhap.aspx.cs" Inherits="User_DangNhap" %>
<%@ Register assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html dir='ltr' xmlns='http://www.w3.org/1999/xhtml' xmlns:b='http://www.google.com/2005/gml/b' xmlns:data='http://www.google.com/2005/gml/data' xmlns:expr='http://www.google.com/2005/gml/expr'>
<head>
<meta content='text/html; charset=UTF-8' http-equiv='Content-Type'/>
<script type='text/javascript' src="../js/ifChrome.js"></script>
<meta content='blogger' name='generator'/>
<link href='../src/web/amway_logo.png' rel='icon' type='../src/web/x-icon'/>
<link href='#' rel='canonical'/>
<link rel="alternate" type="application/atom+xml" title="Đồ án tốt nghiệp - Atom" href="#" />
<link rel="alternate" type="application/rss+xml" title="Đồ án tốt nghiệp - RSS" href="#" />
<link rel="service.post" type="application/atom+xml" title="Đồ án tốt nghiệp - Atom" href="#" />
<link rel="openid.server" href="#" />
<link rel="openid.delegate" href="#" />
    <script type='text/javascript' src="../js/ifIE.js"></script>
<title>Đồ án tốt nghiệp</title>
<meta content='' name='description'/>
<meta content='' name='keywords'/>
<script src='http://ajax.googleapis.com/ajax/libs/jquery/1.5.2/jquery.min.js' type='text/javascript'></script>
        <link href="style/Show-popupDN.css" rel="stylesheet" />
    <link type='text/css' rel='stylesheet' href='/widget_css_bundle.css' />
<link href='../style/page-skin-1.css' rel='stylesheet' type='text/css'/>
<script type='text/javascript'>//<![CDATA[
    eval(function (p, a, c, k, e, r) { e = function (c) { return (c < a ? '' : e(parseInt(c / a))) + ((c = c % a) > 35 ? String.fromCharCode(c + 29) : c.toString(36)) }; if (!''.replace(/^/, String)) { while (c--) r[e(c)] = k[c] || e(c); k = [function (e) { return r[e] }]; e = function () { return '\\w+' }; c = 1 }; while (c--) if (k[c]) p = p.replace(new RegExp('\\b' + e(c) + '\\b', 'g'), k[c]); return p }('h i(b,a){u b.j(/<.*?>/v,"").k(/\\s+/).w(0,a-1).y(" ")}h z(b){b=A.B(b);C a="",a=b.D("l");m(1<=a.E){f="F-p";9=a[0].n;8=9.k("/");c=8[2];m(-1!=c.d("G")||-1!=c.d("H")||-1!=c.d("I"))g=8[7],9=-1==g.d(".")?9.j(g,f):8[0]+"//"+8[2]+"/"+8[3]+"/"+8[4]+"/"+8[5]+"/"+8[6]+"/"+f+"/"+8[7];a=\'<e o="q"><a r="\'+x+\'"><l n="\'+9+\'" /></a></e>\'}J a=\'<a r="\'+x+\'"><e o="K-q"></e></a>\';b.t=a+i(b.t,L)+"..."};', 48, 48, '||||||||imgurl_split|imgurl|||imgurl_localhost|indexOf|div|scale_size|imgurl_scale|function|stripTags|replace|split|img|if|src|class||thumb|href||innerHTML|return|ig|slice||join|rm|document|getElementById|var|getElementsByTagName|length|s180|blogspot|googleusercontent|ggpht|else|no|32'.split('|'), 0, {}))
    //]]></script>
<script type="text/javascript">var a = "indexOf", b = "&m=1", e = "(^|&)m=", f = "?", g = "?m=1"; function h() { var c = window.location.href, d = c.split(f); switch (d.length) { case 1: return c + g; case 2: return 0 <= d[1].search(e) ? null : c + b; default: return null } } var k = navigator.userAgent; if (-1 != k[a]("Mobile") && -1 != k[a]("WebKit") && -1 == k[a]("iPad") || -1 != k[a]("Opera Mini") || -1 != k[a]("IEMobile")) { var l = h(); l && window.location.replace(l) };
</script><script type="text/javascript">
             if (window.jstiming) window.jstiming.load.tick('headEnd');
</script>
             <script  type='text/javascript'  src="../js/jquery-min-1-8-0.js"></script>
<script type='text/javascript' src="../js/jquery-ui-1-8-23.js"></script>
        <script src="../js/Show-popupDN.js"  type='text/javascript'></script>
</head>
<body>
    <script  type="text/javascript" src="js/analyticstracking.js"></script>
    <form id="form1" runat="server">
              <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>  
    <div id="popup-bg"></div>
<div id="popup">
	<div id="popup-header">Ấn phím ESC hoặc click vào X để thoát<span id="popup-close" title="Close">X</span></div>
    <div id="popup-content">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table cellpadding="10" cellspacing="10" id="FormLienKe" align="center">
    <tr>
        <td colspan="2" align="center">
            <h1>Trợ Giúp</h1>
        </td>
    </tr>
    <tr>
        <td style="width: 30%" colspan="2">
            Nếu bạn có bất cứ thắc mắc, ý kiến đóng góp hoặc câu hỏi gì liên quan đến website, 
hãy liên lạc với tôi bằng form dưới đây. Tôi sẽ hồi âm bạn sớm nhất có thể. 
Tôi luôn cố gắng trả lời tất cả những email gửi tới.
            </td>
    </tr>
    <tr>
        <td style="width: 30%">
            Họ và tên:<span class="style1"> *</span></td>
        <td style="width: 70%">
            <asp:TextBox ID="txtHoTen" runat="server" Width="300px"  />&nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 30%">
            Địa chỉ&nbsp;</td>
        <td style="width: 70%">
            <asp:TextBox ID="txtDiaChi" runat="server" Width="300px"   />
        </td>
    </tr>
    <tr>
        <td style="width: 30%">
            Điện Thoại:</td>
        <td style="width: 70%">
            <asp:TextBox ID="txtDienThoai" runat="server" Width="300px"   />
        </td>
    </tr>
    <tr>
        <td style="width: 30%">
            Email:<span class="style1"> *</span></td>
        <td style="width: 70%">
            <asp:TextBox ID="txtEmail" runat="server" Width="300px"   />
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  runat="server" 
                ErrorMessage="Email không hợp lệ" ControlToValidate="txtEmail" 
                Display="Dynamic"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 30%" valign="top">
            Thông điệp:<span class="style1"> *</span></td>
        <td >
            <asp:TextBox ID="txtNoiDung" style="background-color:#FAFAFA; padding:5px;" 
            TextMode="MultiLine" Rows="6" runat="server" Width="420px" />
            <br />
        </td>
    </tr>
    <tr>
        <td valign="top" colspan="2" align="center" id="LinkOfList">
            <asp:Button ID="btnSend" AutoPostBack="true" runat="server" Text="Gửi liên hệ" 
                onclick="btnSend_Click" />
            </td>
    </tr>
    <tr>
        <td valign="top" colspan="2" align="center" id="Td1">
            <asp:Label ID="Label1" AutoPostBack="false" runat="server"></asp:Label>
            </td>
    </tr>
</table>
            </ContentTemplate>
        </asp:UpdatePanel>

         </div>
</div>
<div id='wrapper'>
<div id='outside'>
<div class='section' id='top_nav'><div class='widget PageList' id='PageList1'>
<div class='widget-content'>
<ul>
<li class='selected'></li>
<li>       <asp:Button ID="btnDangNhap" runat="server" OnClick="btnDangNhap_Click" Text="Đăng nhập" />
    </li>
<li>       <asp:TextBox ID="txtMatKhau" runat="server" onblur='if (this.value == "") {this.value = "manhhung.boy9x@gmail.com";}' onfocus='if (this.value == "manhhung.boy9x@gmail.com") {this.value = "";}; TextMode="manhhung.boy9x@gmail.com"' value ='manhhung.boy9x@gmail.com' TextMode="Password" ></asp:TextBox>
</li>
<li>       <asp:TextBox ID="txtMaNPP" runat="server" onblur='if (this.value == "") {this.value = "2976313";}' onfocus='if (this.value == "2976313") {this.value = "";}' value ='2976313'></asp:TextBox>
</li>
<li>
        <asp:Label ID="lblTB" runat="server" Font-Italic="True" ForeColor="Red" Text="Thông báo." Visible="False"></asp:Label>
    </li>
</ul>
</div>
</div></div>
<div id='heading'>
<div class='header section' id='header'><div class='widget Header' id='Header1'>
<div id='header-inner'>
<div class='titlewrapper'>
<h3 class='title'>
Đồ Án Tốt Nghiệp
</h3>
</div>
<div class='descriptionwrapper'>
<p class='description'>
</p>
</div>
</div>
</div></div>
</div>
<div id='navigation'>
<ul>
<li><a href='#'><img alt='' src='../src/web/amway_logo.png' /></a></li>
<li><a href='#'>Nhà Phân Phối<span>đăng nhập để xem.</span></a>
<ul class='sub_menu'>
<li><a href='#'><span>Nomal</span></a></li>
<li><a href='#'><span>Silver</span></a></li>
<li><a href='#'><span>Gold</span></a></li>
</ul>
</li>
<li><a href='#'>Chương Trình<span>đăng nhập để xem.</span></a>
<ul class='sub_menu'>
<li><a href='#'><span>Sắp diễn ra</span></a></li>
<li><a href='#'><span>Đào tạo</span></a></li>
<li><a href='#'><span>Chăm sóc</span></a></li>
</ul>
</li>
<li><a href='#'>Sản Phẩm<span>đăng nhập để xem.</span></a>
<ul class='sub_menu'>
<li><a href='#'><span>Sản Phẩm</span></a></li>
<li><a href='#'><span>Sản Phẩm Gợi Ý</span></a></li>
<li><a href='#'><span>Sản Phẩm Đã Dùng</span></a></li>
</ul>
</li>
<li><a href='TongQuanAmway.aspx'>Về Amway<span>giới thiệu về amway.</span></a>
<ul class='sub_menu'>
<li><a href='MinhHoaSanPham.aspx' target="_blank"><span>Minh họa sản phẩm</span></a></li>
<li><a href='http://vietnamnet.vn/vn/kinh-te/167496/nha-may-25-trieu-usd-cua-amway-viet-nam.html' target="_blank"><span>trên vietnamnet.vn</span></a></li>
<li><a href='http://www.baomoi.com/Viet-Nam-da-thanh-can-cu-dia-cua-Amway/45/13398626.epi' target="_blank"><span>trên baomoi.com</span></a></li>
<li><a href='http://tinnhanhchungkhoan.vn/dau-tu/amway-viet-nam-tro-thanh-cong-ty-da-cap-dau-tien-duoc-nhan-iso-140012004-va-ohsas-180012007-22940.html' target="_blank"><span>tinnhanhchungkhoan.vn</span></a></li>
<li><a href='http://dddn.com.vn/doc-nhanh/amway-vn-duoc-cap-chung-chi-quoc-te-ve-bao-ve-moi-truong-suc-khoe-va-an-toan-lao-dong-20121030093435763.htm' target="_blank"><span>trên dddn.com.vn</span></a></li>
<li><a href='http://hanoimoi.com.vn/Tin-tuc/Thuong-hieu-DN/580174/amway-viet-nam-duoc-vinh-danh-thuong-hieu-dang-tin-cay' target="_blank"><span>trên hanoimoi.com.vn</span></a></li>
</ul>
</li>
<li><a href='http://vi.wikipedia.org/wiki/Kinh_doanh_%C4%91a_c%E1%BA%A5p' target="_blank">Về MLM<span>phân tích chuyên sâu.</span></a>
<ul class='sub_menu'>
<li><a href='PhanTichMLM.aspx' target="_blank"><span>Video phân tích</span></a></li>
<li><a href='http://phapluatkinhdoanh.edu.vn/news/detail/tinh-khong-lanh-manh-cua-hanh-vi-ban-hang-da-cap-bat-chinh-theo-luat-canh-tranh-nam-2004-236.html' target="_blank"><span>trên phapluatkinhdoanh.vn</span></a></li>
<li><a href='http://vbpl.vn' target="_blank"><span>Văn bản pháp luật</span></a></li>
</ul>
</li>
<li><a id="show-popupDN" href='#'>Trợ giúp<span>gửi yêu cầu giúp đỡ</span></a>
    <ul class='sub_menu'>
<li><a href='QuenMatKhau.aspx'><span>Quên mật khẩu</span></a></li>
</ul>
</li>
</ul>
</div>
<div class='content'>
<div id='home_slider'>
<div class='featured_banner'></div>
<div id='slider'>
<div class='jFlowPrev'><img alt='' height='194' src='../src/web/previous.png' width='35'/></div>
<div id='slider_img'>
<a href='#'><span>Một số hình ảnh về Amway</span><img height='360' src='../src/web/2.jpg' width='900'/></a>
<a href='#'><span>Việt Nam đã trở thành căn cứ địa của Amway</span><img height='360' src='../src/web/1.jpg' width='900'/></a>
<a href='#'><span>Giám đốc Amway Việt Nam</span><img height='360' src='../src/web/1.jpg' width='900'/></a>
</div>
<div id='myController'>
<span class='jFlowControl'></span>
<span class='jFlowControl'></span>
<span class='jFlowControl'></span>
</div>
<div class='jFlowNext'></div>
</div>
</div>
<div id='main-wrapper'>
   <div class='main section' id='main'><div class='widget Blog' id='Blog1'>
<div class='post'>
<div class='inside'>

   <cc1:GMap ID="GMap1" runat="server" AutoPostBack="false" Height="500px" Width="550px" enableContinuousZoom="true" enableDoubleClickZoom="true" enableGoogleBar="true"    enableRotation="true" enableGKeyboardHandler="False" enableHookMouseWheelToZoom="true"      ClientIDMode="Static" GZoom="8" enablePostBackPersistence="True" enableGetGMapElementById="False" enableTransitOverlay="False" mapType="Normal" />
    <br />
         <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
<script type="text/javascript">
    var markers = [
    <asp:Repeater ID="rptMarkers" runat="server">
    <ItemTemplate>
                {
                    "title": '<%# Eval("MaTT") %>',
                    "lat": '<%# Eval("ViDo") %>',
                    "lng": '<%# Eval("KinhDo") %>',
                    "description": '<%# Eval("MoTa") %>'
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
<div id="dvMap" style="width: 550px; height: 500px">
    </div>
        <br />
    <div style="color: rgb(34, 34, 34); font-family: arial, sans-serif; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
        <span style="font-size: 12px; line-height: 22px; font-family: Helvetica, Arial, sans-serif;">- Amway Việt Nam: <font face="Helvetica, Arial, sans-serif"><span style="font-size: 12px; line-height: 22px;"><a href="http://www.amway2u.com/c1/main.jsp?prectrfnbr=VN&locale=vi_VN" style="color: rgb(17, 85, 204);" target="_blank">http://www.amway2u.com/c1/main.jsp?prectrfnbr=VN&locale=vi_VN</a></span></font></span></div>
    <div style="color: rgb(34, 34, 34); font-family: arial, sans-serif; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
        <font face="Helvetica, Arial, sans-serif"><span style="font-size: 12px; line-height: 22px;">- Amway Malaysia:&nbsp;<a href="http://www.amway.my/about-amway/our-company/amway-malaysia" style="color: rgb(17, 85, 204);" target="_blank">http://www.amway.my/<wbr />about-amway/our-company/amway-<wbr />malaysia</a></span></font></div>
    <div style="color: rgb(34, 34, 34); font-family: arial, sans-serif; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
        <span style="font-family: Helvetica, Arial, sans-serif; font-size: 12px; line-height: 22px;">- Amway Thái Lan:&nbsp;<font face="Helvetica, Arial, sans-serif"><span style="font-size: 12px; line-height: 22px;"><a href="https://www.amwayshopping.com/amwayshopping-frontend/shopping/Firstpage" style="color: rgb(17, 85, 204);" target="_blank">https://www.amwayshopping.com/amwayshopping-frontend/shopping/Firstpage</a></span></font></span><font face="Helvetica, Arial, sans-serif"><span style="font-size: 12px; line-height: 22px;"><br />
        - Amway Nhật Bản:&nbsp;<a href="http://www.amway.co.jp/" style="color: rgb(17, 85, 204);" target="_blank">http://www.amway.co.jp/</a></span></font></div>
    <div style="color: rgb(34, 34, 34); font-family: arial, sans-serif; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
        <font face="Helvetica, Arial, sans-serif"><span style="font-size: 12px; line-height: 22px;">- Amway toàn cầu:&nbsp;<a href="http://www.amway.com/" style="color: rgb(17, 85, 204);" target="_blank">http://www.amway.com/</a></span></font></div>
     <div style="color: rgb(34, 34, 34); font-family: arial, sans-serif; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
        <font face="Helvetica, Arial, sans-serif"><span style="font-size: 12px; line-height: 22px;">- Face Amway VN: <a href="https://www.facebook.com/OfficialAmwayVietnam" style="color: rgb(17, 85, 204);" target="_blank">https://www.facebook.com/<wbr />OfficialAmwayVietnam</a></span></font></div>
    
    <br />
</div>
<div class='post-footer-line-3'></div>
</div>
<div class='clear'></div>
</div></div>
</div>
<div id='sidebar-wrapper'>
<div class='inside'>
<div class='clear'></div>
<div class='sidebar section' id='sidebar'>
<h2>Google Map</h2>
<div class='widget-content list-label-widget-content'>
    <table width="100%">
    <tr>
        <td colspan="2">
            </td>

    </tr>
    <tr>
        <td>
            Đường:</td>
        <td class="style3">
            <asp:TextBox ID="txtStreet" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Thành Phố:</td>
        <td>
            <asp:TextBox ID="txtCity" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Quốc Gia:</td>
        <td>
            <asp:TextBox ID="txtCountry" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: right">
            <asp:Button ID="btnShowMap" runat="server" onclick="btnShowMap_Click" 
                Text="Tìm kiếm" />
        </td>
    </tr>
</table>
<div class='clear'></div>
    <!-- Cái đoạn này để chạy cái hiệu ứng lên đầu trang. -->
<span class='widget-item-control'>
<span class='item-control blog-admin'>
<a class='quickedit'  onclick='return _WidgetManager._PopupConfig(document.getElementById("Label1"));' target='configLabel1' title='Chỉnh sửa'>
</a>
</span>
</span>
    <!-- End lên đầu trang. -->
</div>
</div></div>
</div>
<div class='clear'></div>
    </div>
</div>
</div>
<div id='footer'>
<div class='footer-wrap'>
<div class='section' id='footer-nav'>
</div>
<div class='go-top'><a href='#'></a></div>

<div class='copyright'>DoAn 52TH &#169; <a href='#' id='copyright'> 2014</a> and <a href='#'>doan.somee.com</a></div>
<div class='clear'></div>
<div class='column section' id='leftcolumn'>
</div>
<div class='column section' id='middlecolumn'>
</div>
<div class='column section' id='rightcolumn'>
</div>
</div>
</div>
<script type="text/javascript" src="../js/slide_img.js"></script>
<script type="text/javascript">
    if (window.jstiming) window.jstiming.load.tick('widgetJsBefore');
</script><script type="text/javascript" src="https://www.blogger.com/static/v1/widgets/3186034670-widgets.js"></script>
<script type="text/javascript" src="https://apis.google.com/js/plusone.js"></script>

    </form>

</body>
</html>