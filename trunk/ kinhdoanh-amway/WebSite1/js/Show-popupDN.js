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

    $('a#show-popupDN').click(function () {
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