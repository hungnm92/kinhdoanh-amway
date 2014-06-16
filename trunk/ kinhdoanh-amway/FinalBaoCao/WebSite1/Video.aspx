<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Video.aspx.cs" Inherits="Video" %>

<%@ Register assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc1" %>
service = new google.maps.places.PlacesService(map);
service.nearbySearch(request, callback);

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html dir='ltr' xmlns='http://www.w3.org/1999/xhtml' xmlns:b='http://www.google.com/2005/gml/b' xmlns:data='http://www.google.com/2005/gml/data' xmlns:expr='http://www.google.com/2005/gml/expr'>
<head runat="server">
<meta charset="utf-8">
<title>Google Maps JavaScript API v3 Example: Place Search</title>
<script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=true&libraries=places"></script>

<style type="text/css">
#map {
height: 400px;
width: 600px;
border: 1px solid #333;
margin-top: 0.6em;
}
</style>

<script type="text/javascript">
    var map;
    var infowindow;

    function initialize() {
        // Khởi tạo bản đồ
        // Vị trí trung tâm 20.9875830,105.8316770 (Định Công)
        var pyrmont = new google.maps.LatLng(20.9875830, 105.8316770);

        // khởi tạo bản đồ vào div#map
        map = new google.maps.Map(document.getElementById('map'), {
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            // ROADMAP displays the normal, default 2D tiles of Google Maps.
            // SATELLITE displays photographic tiles.
            // HYBRID displays a mix of photographic tiles and a tile layer for prominent features (roads, city names).
            // TERRAIN displays physical relief tiles for displaying elevation and water features (mountains, rivers, etc.).
            center: pyrmont,
            zoom: 15 // Zoom hiện tại
        });

        // Tạo đối tượng request
        var request = {
            location: pyrmont, // Tìm từ vị trí trung tâm
            radius: 500, // Bán kính 500m
            types: ['atm'] // Tìm tất cả nhà hàng
        };
        // Hiển thị thông tin về địa điểm
        infowindow = new google.maps.InfoWindow();
        var service = new google.maps.places.PlacesService(map);
        // Thực hiện gọi hàm nearbySearch để tìm những atm lân cận và trả về thực hiện
        // hàm callback
        service.nearbySearch(request, callback);
    }
    function customSearch() {
        // Khởi tạo bản đồ
        // Vị trí trung tâm 20.9875830,105.8316770 (Định Công)
        var pyrmont = new google.maps.LatLng(20.9875830, 105.8316770);

        // khởi tạo bản đồ vào div#map
        map = new google.maps.Map(document.getElementById('map'), {
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            center: pyrmont,
            zoom: 15
        });

        var place_type = document.getElementById('place_type');
        var selected_type = place_type.options[place_type.selectedIndex].value;
        // Tạo đối tượng request
        var request = {
            location: pyrmont, // Tìm từ vị trí trung tâm
            radius: document.getElementById('radius').value, // Bán kính 500m
            types: [selected_type] // Tìm tất cả atm
        };
        // Hiển thị thông tin về địa điểm
        infowindow = new google.maps.InfoWindow();
        var service = new google.maps.places.PlacesService(map);
        // Thực hiện gọi hàm nearbySearch để tìm những atm lân cận và trả về thực hiện
        // hàm callback
        service.nearbySearch(request, callback);

    }
    function callback(results, status) {
        if (status == google.maps.places.PlacesServiceStatus.OK) {
            for (var i = 0; i < results.length; i++) {
                // Duyệt từng địa điểm và đánh dấu lên bản đồ
                createMarker(results[i]);
            }
        }
    }
    // Hàm đánh dấu lên bản đồ từ 1 đối tượng địa điểm place
    function createMarker(place) {
        var placeLoc = place.geometry.location;
        var marker = new google.maps.Marker({
            map: map,
            position: place.geometry.location
        });

        google.maps.event.addListener(marker, 'click', function () {
            infowindow.setContent(place.name);
            infowindow.open(map, this);
        });
    }

    google.maps.event.addDomListener(window, 'load', initialize);
</script>
</head>
<body>
   Loại địa điểm:
<select id="place_type">
<option value="atm">ATM</option>
<option value="school">Trường học</option>
<option value="store">Cửa hàng</option>
<option value="hospital">Bệnh viện</option>
</select>
Bán kính:
<input type="text" id="radius" /><br/>
<input type="button" onclick="customSearch()" value="Tìm" />
<div id="map"></div>
<div id="text">
</div>
</body>
</html>
