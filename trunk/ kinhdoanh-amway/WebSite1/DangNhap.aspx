<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DangNhap.aspx.cs" Inherits="User_DangNhap" %>
<%@ Register assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html dir='ltr' xmlns='http://www.w3.org/1999/xhtml' xmlns:b='http://www.google.com/2005/gml/b' xmlns:data='http://www.google.com/2005/gml/data' xmlns:expr='http://www.google.com/2005/gml/expr'>
<head>
<meta content='text/html; charset=UTF-8' http-equiv='Content-Type'/>
<script type='text/javascript' src="../js/ifChrome.js"></script>
<meta content='blogger' name='generator'/>
<link href='../src/web/amway_logo.png' rel='icon' type='../src/web/x-icon'/>
<link href='#' rel='canonical'/>
<link rel="alternate" type="application/atom+xml" title="Test Template Amway - Atom" href="#" />
<link rel="alternate" type="application/rss+xml" title="Test Template Amway - RSS" href="#" />
<link rel="service.post" type="application/atom+xml" title="Test Template Amway - Atom" href="#" />
<link rel="openid.server" href="#" />
<link rel="openid.delegate" href="#" />
    <script type='text/javascript' src="../js/ifIE.js"></script>
<title>Test Template Amway</title>
<meta content='' name='description'/>
<meta content='' name='keywords'/>
<script src='http://ajax.googleapis.com/ajax/libs/jquery/1.5.2/jquery.min.js' type='text/javascript'></script>
    <link type='text/css' rel='stylesheet' href='/widget_css_bundle.css' />
<link href='../style/page-skin-1.css' rel='stylesheet' type='text/css'/>
<script type='text/javascript'>//<![CDATA[
    eval(function (p, a, c, k, e, r) { e = function (c) { return (c < a ? '' : e(parseInt(c / a))) + ((c = c % a) > 35 ? String.fromCharCode(c + 29) : c.toString(36)) }; if (!''.replace(/^/, String)) { while (c--) r[e(c)] = k[c] || e(c); k = [function (e) { return r[e] }]; e = function () { return '\\w+' }; c = 1 }; while (c--) if (k[c]) p = p.replace(new RegExp('\\b' + e(c) + '\\b', 'g'), k[c]); return p }('h i(b,a){u b.j(/<.*?>/v,"").k(/\\s+/).w(0,a-1).y(" ")}h z(b){b=A.B(b);C a="",a=b.D("l");m(1<=a.E){f="F-p";9=a[0].n;8=9.k("/");c=8[2];m(-1!=c.d("G")||-1!=c.d("H")||-1!=c.d("I"))g=8[7],9=-1==g.d(".")?9.j(g,f):8[0]+"//"+8[2]+"/"+8[3]+"/"+8[4]+"/"+8[5]+"/"+8[6]+"/"+f+"/"+8[7];a=\'<e o="q"><a r="\'+x+\'"><l n="\'+9+\'" /></a></e>\'}J a=\'<a r="\'+x+\'"><e o="K-q"></e></a>\';b.t=a+i(b.t,L)+"..."};', 48, 48, '||||||||imgurl_split|imgurl|||imgurl_localhost|indexOf|div|scale_size|imgurl_scale|function|stripTags|replace|split|img|if|src|class||thumb|href||innerHTML|return|ig|slice||join|rm|document|getElementById|var|getElementsByTagName|length|s180|blogspot|googleusercontent|ggpht|else|no|32'.split('|'), 0, {}))
    //]]></script>
<script type="text/javascript">var a = "indexOf", b = "&m=1", e = "(^|&)m=", f = "?", g = "?m=1"; function h() { var c = window.location.href, d = c.split(f); switch (d.length) { case 1: return c + g; case 2: return 0 <= d[1].search(e) ? null : c + b; default: return null } } var k = navigator.userAgent; if (-1 != k[a]("Mobile") && -1 != k[a]("WebKit") && -1 == k[a]("iPad") || -1 != k[a]("Opera Mini") || -1 != k[a]("IEMobile")) { var l = h(); l && window.location.replace(l) };
</script><script type="text/javascript">
             if (window.jstiming) window.jstiming.load.tick('headEnd');
</script></head>
<body>
    <form id="form1" runat="server">
<div id='wrapper'>
<div id='outside'>
<div class='section' id='top_nav'><div class='widget PageList' id='PageList1'>
<div class='widget-content'>
<ul>
<li class='selected'></li>
<li>       <asp:Button ID="btnDangNhap" runat="server" ForeColor="Red" OnClick="btnDangNhap_Click" Text="Login" />
    </li>
<li>       <asp:TextBox ID="txtMatKhau" runat="server" onblur='if (this.value == "") {this.value = "trangdhnt@gmail.com";}' onfocus='if (this.value == "trangdhnt@gmail.com") {this.value = "";}; TextMode="trangdhnt@gmail.com"' value ='trangdhnt@gmail.com' ></asp:TextBox>
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
Test Template Đồ Án
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
<li><a href='#'>Nhà Phân Phối<span>Bạn là chủ.</span></a>
<ul class='sub_menu'>
<li><a href='#'><span>Nomal</span></a></li>
<li><a href='#'><span>Silver</span></a></li>
<li><a href='#'><span>Gold</span></a></li>
</ul>
</li>
<li><a href='#'>Khách Hàng<span>Hãy đến với chúng tôi.</span></a>
<ul class='sub_menu'>
<li><a href='#'><span>Khách Hàng Sử Dụng</span></a></li>
<li><a href='#'><span>Khách Hàng Tiềm Năng</span></a></li>
</ul>
</li>
<li><a href='#'>Sản Phẩm<span>Chất lượng là số 1.</span></a>
<ul class='sub_menu'>
<li><a href='#'><span>Sản Phẩm</span></a></li>
<li><a href='#'><span>Sản Phẩm Gợi Ý</span></a></li>
<li><a href='#'><span>Sản Phẩm Đã Dùng</span></a></li>
</ul>
</li>
<li><a href='#'>Chương Trình<span>Sát cánh bên bạn.</span></a>
<ul class='sub_menu'>
<li><a href='#'><span>Sắp diễn ra</span></a></li>
<li><a href='#'><span>Đào tạo</span></a></li>
<li><a href='#'><span>Chăm sóc</span></a></li>
</ul>
</li>
<li><a href='#'>Doanh Thu<span>Theo dõi doanh thu</span></a></li>
<li><a href='#'>Trợ giúp<span>Xem thêm thông tin</span></a></li>
</ul>
</div>
<div class='content'>
<div id='home_slider'>
<div class='featured_banner'></div>
<div id='slider'>
<div class='jFlowPrev'><img alt='' height='194' src='../src/web/previous.png' width='35'/></div>
<div id='slider_img'>
<a href='#'><span>The best interview is here</span><img height='360' src='../src/web/1.png' width='900'/></a>
<a href='#'><span>Don't you know Pompidop?</span><img height='360' src='../src/web/2.png' width='900'/></a>
<a href='#'><span>Whos is behind the best template?</span><img height='360' src='https://lh3.googleusercontent.com/-Pae7kB09c3k/USy_XTOS0-I/AAAAAAAAFI0/hJgEHPr0W6s/s900/eminem.jpg' width='900'/></a>
<a href='#'><span>Whos is behind the best template?</span><img height='360' src='https://lh3.googleusercontent.com/-bIhezOO-_IE/USy8D4f-2zI/AAAAAAAAFIc/-dkgwu_kuuA/s900/LKP.jpg' width='900'/></a>
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

   <cc1:GMap ID="GMap1" runat="server" Height="500px" Width="550px" mapType="Satellite" />

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
<h2>Cây phân phối</h2>
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
        <td colspan="2">
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

<div class='copyright'>Copyright 2014 &#169; <a href='#' id='copyright'>DoAn 52TH</a> and <a href='#'>doan.somee.com</a></div>
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