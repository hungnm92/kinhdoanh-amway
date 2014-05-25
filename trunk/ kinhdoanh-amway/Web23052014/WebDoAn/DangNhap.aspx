<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DangNhap.aspx.cs" Inherits="User_DangNhap" %>
<%@ Register assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html dir='ltr' xmlns='http://www.w3.org/1999/xhtml' xmlns:b='http://www.google.com/2005/gml/b' xmlns:data='http://www.google.com/2005/gml/data' xmlns:expr='http://www.google.com/2005/gml/expr'>
<head>
<meta content='text/html; charset=UTF-8' http-equiv='Content-Type'/>
<script type="text/javascript">(function () {
var b = window, f = "chrome", g = "jstiming", k = "tick"; (function () {
function d(a) { this.t = {}; this.tick = function (a, d, c) { var e = void 0 != c ? c : (new Date).getTime(); this.t[a] = [e, d]; if (void 0 == c) try { b.console.timeStamp("CSI/" + a) } catch (h) { } }; this[k]("start", null, a) } var a; b.performance && (a = b.performance.timing); var n = a ? new d(a.responseStart) : new d; b.jstiming = { Timer: d, load: n }; if (a) { var c = a.navigationStart, h = a.responseStart; 0 < c && h >= c && (b[g].srt = h - c) } if (a) { var e = b[g].load; 0 < c && h >= c && (e[k]("_wtsrt", void 0, c), e[k]("wtsrt_", "_wtsrt", h), e[k]("tbsd_", "wtsrt_")) } try {
a = null,
b[f] && b[f].csi && (a = Math.floor(b[f].csi().pageT), e && 0 < c && (e[k]("_tbnd", void 0, b[f].csi().startE), e[k]("tbnd_", "_tbnd", c))), null == a && b.gtbExternal && (a = b.gtbExternal.pageT()), null == a && b.external && (a = b.external.pageT, e && 0 < c && (e[k]("_tbnd", void 0, b.external.startE), e[k]("tbnd_", "_tbnd", c))), a && (b[g].pt = a)
} catch (p) { }
})(); b.tickAboveFold = function (d) { var a = 0; if (d.offsetParent) { do a += d.offsetTop; while (d = d.offsetParent) } d = a; 750 >= d && b[g].load[k]("aft") }; var l = !1; function m() { l || (l = !0, b[g].load[k]("firstScrollTime")) } b.addEventListener ? b.addEventListener("scroll", m, !1) : b.attachEvent("onscroll", m);
})();</script>
<meta content='blogger' name='generator'/>
<link href='../src/web/amway_logo.png' rel='icon' type='../src/web/x-icon'/>
<link href='#' rel='canonical'/>
<link rel="alternate" type="application/atom+xml" title="Test Template Amway - Atom" href="#" />
<link rel="alternate" type="application/rss+xml" title="Test Template Amway - RSS" href="#" />
<link rel="openid.server" href="#" />
<link rel="openid.delegate" href="#" />
<!--[if IE]> <script> (function() { var html5 = ("abbr,article,aside,audio,canvas,datalist,details," + "figure,footer,header,hgroup,mark,menu,meter,nav,output," + "progress,section,time,video").split(','); for (var i = 0; i < html5.length; i++) { document.createElement(html5[i]); } try { document.execCommand('BackgroundImageCache', false, true); } catch(e) {} })(); </script> <![endif]-->
<title>Test Template Amway</title>
<meta content='' name='description'/>
<meta content='' name='keywords'/>
<link href='http://fonts.googleapis.com/css?family=Roboto' rel='stylesheet' type='text/css'/>
<script src='http://ajax.googleapis.com/ajax/libs/jquery/1.5.2/jquery.min.js' type='text/javascript'></script>
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
<li>       <asp:TextBox ID="txtMatKhau" runat="server" onblur='if (this.value == "") {this.value = "Mật khẩu";}' onfocus='if (this.value == "Mật khẩu") {this.value = "";}; TextMode="Password"' value ='Mật khẩu' ></asp:TextBox>
</li>
<li>       <asp:TextBox ID="txtMaNPP" runat="server" onblur='if (this.value == "") {this.value = "Mã ADA";}' onfocus='if (this.value == "Mã ADA") {this.value = "";}' value ='Mã ADA'></asp:TextBox>
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
<script type='text/javascript'>
    function initialize() {
        var mapProp = {
            center: new google.maps.LatLng(12.24876,109.156723, 0.194594,0.338173),
            zoom: 12,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
    }

    function loadScript() {
        var script = document.createElement("script");
        script.type = "text/javascript";
        script.src = "http://maps.googleapis.com/maps/api/js?key=AIzaSyDY0kkJiTPVd2U7aTOAwhc9ySH6oHxOIYM&sensor=false&callback=initialize";
        document.body.appendChild(script);
    }

    window.onload = loadScript;
</script>


   
<div class='post-footer'>
     <div id="googleMap" style="width:500px;height:380px;"></div>
</div>
</div>
<div id='sidebar-wrapper'>
<div class='inside'>
<div class='clear'></div>
<div class='sidebar section' id='sidebar'>
<h2>Cây phân phối</h2>
<div class='widget-content list-label-widget-content'>
<ul>
<li>
<a dir='ltr' href='#'>Họ và tên</a>
<span dir='ltr'>(10)</span>
</li>
</ul>
     <table>
    <tr>
        <td colspan="2">
            </td>
        <td rowspan="5">
            <cc1:GMap ID="GMap1" runat="server" Height="500px" Width="600px" enableGoogleBar="true" enableContinuousZoom="true" />
        </td>
    </tr>
    <tr>
        <td>
            Street</td>
        <td class="style3">
            <asp:TextBox ID="txtStreet" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            City</td>
        <td>
            <asp:TextBox ID="txtCity" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Country</td>
        <td>
            <asp:TextBox ID="txtCountry" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnShowMap" runat="server" onclick="btnShowMap_Click" 
                Text="ShowMap" />
        </td>
    </tr>
</table>
<div class='clear'></div>
<span class='widget-item-control'>
<span class='item-control blog-admin'>
<a class='quickedit'  onclick='return _WidgetManager._PopupConfig(document.getElementById("Label1"));' target='configLabel1' title='Chỉnh sửa'>
<img alt='' height='18' src='../src/web/icon18_wrench_allbkg.png' width='18'/>
</a>
</span>
</span>
<div class='clear'></div>
</div>
</div></div>
</div>
</div>
<div class='clear'></div>
</div>
</div>
<div id='footer'>
<div class='footer-wrap'>
<div class='section' id='footer-nav'>
</div>
<div class='go-top'><a href='#'></a></div>
<div id='credit'><a href='#'>Template Blogspot</a></div>
<div class='copyright'>Copyright 2013 &#169; <a href='#' id='copyright'>Test Template Blogger</a> and <a href='#'>Blogger Templates</a></div>
<div class='clear'></div>
<div class='column section' id='leftcolumn'>
    
</div>
<div class='column section' id='middlecolumn'>
  <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
<script type="text/javascript">
    var markers = [
    <asp:Repeater ID="rptMarkers" runat="server">
    <ItemTemplate>
                {
                    "title": '<%# Eval("Ten") %>',
                "lat": '<%# Eval("ViDo") %>',
                "lng": '<%# Eval("KinhDo") %>',
                "description": '<%# Eval("MieuTa") %>'
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
<div id="dvMap" style="width: 500px; height: 500px">
</div> 
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