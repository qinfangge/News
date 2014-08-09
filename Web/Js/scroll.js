(function (jQuery) {
    jQuery.fn.extend({
        Scroll: function (opt, callback) {
            //参数初始化
            if (!opt) var opt = {};

            var _btnUp = jQuery("#" + opt.up);//Shawphy:向上按钮
            var _btnDown = jQuery("#" + opt.down);//Shawphy:向下按钮
            var _btnLeft = jQuery("#" + opt.left);//Shawphy:向上按钮
            var _btnRight = jQuery("#" + opt.right);//Shawphy:向下按钮
            var flag = opt.flag;
            var timerID;
            var _this = this.eq(0).find("ul:first");
            var lineH = _this.find("li:first").height(), //获取行高
                    lineW = this.find("li:first").width(),//获取宽度
                    line = opt.line ? parseInt(opt.line, 10) : parseInt(this.height() / lineH, 10), //每次滚动的行数，默认为一屏，即父容器高度
                    line2 = opt.line ? parseInt(opt.line, 10) : parseInt(this.width() / lineW, 10), //每次滚动的行数，默认为一屏，即父容器高度
                    speed = opt.speed ? parseInt(opt.speed, 10) : 500; //卷动速度，数值越大，速度越慢（毫秒）
            timer = opt.timer //?parseInt(opt.timer,10):3000; //滚动的时间间隔（毫秒）

            if (line == 0) line = 1;
            var upHeight = 0 - line * lineH;

            if (line2 == 0) line2 = 1;
            var leftWidth = 0 - line2 * lineW;
            //滚动函数
            var scrollUp = function () {
                flag = "up";
                _btnUp.unbind("click", scrollUp); //Shawphy:取消向上按钮的函数绑定
                _this.animate({
                    marginTop: upHeight
                }, speed, function () {
                    for (i = 1; i <= line; i++) {
                        _this.find("li:first").appendTo(_this);
                    }
                    _this.css({ marginTop: 0 });
                    _btnUp.bind("click", scrollUp); //Shawphy:绑定向上按钮的点击事件
                });
                return false;
            }
            //Shawphy:向下翻页函数
            var scrollDown = function () {
                flag = "down";
                _btnDown.unbind("click", scrollDown);
                for (i = 1; i <= line; i++) {
                    _this.find("li:last").show().prependTo(_this);
                }
                _this.css({ marginTop: upHeight });
                _this.animate({
                    marginTop: 0
                }, speed, function () {
                    _btnDown.bind("click", scrollDown);
                });
                return false;
            }

            //向左滚动函数
            var scrollLeft = function () {

                flag = "left";
                _btnLeft.unbind("click", scrollLeft); //Shawphy:取消向上按钮的函数绑定
                _this.animate({
                    marginLeft: leftWidth
                }, speed, function () {
                    for (i = 1; i <= line2; i++) {
                        _this.find("li:first").appendTo(_this);
                    }
                    _this.css({ marginLeft: 0 });
                    _btnLeft.bind("click", scrollLeft); //Shawphy:绑定向上按钮的点击事件
                });
                return false;
            }
            //向右滚动函数
            var scrollRight = function () {
                flag = "right";
                _btnRight.unbind("click", scrollRight);
                for (i = 1; i <= line2; i++) {
                    _this.find("li:last").show().prependTo(_this);
                }
                _this.css({ marginLeft: leftWidth });
                _this.animate({
                    marginLeft: 0
                }, speed, function () {
                    _btnRight.bind("click", scrollRight);
                });
                return false;
            }

            //Shawphy:自动播放
            var autoPlay = function () {
                if (timer) timerID = window.setInterval(function () {
                    if (flag == "up") {
                        scrollUp();
                    }
                    if (flag == "down") {
                        scrollDown();
                    }
                    if (flag == "left") {
                        scrollLeft();
                    }
                    if (flag == "right") {
                        scrollRight();
                    }
                }, timer);
            };
            var autoStop = function () {
                if (timer) window.clearInterval(timerID);
            };
            //鼠标事件绑定
            _this.hover(autoStop, autoPlay).mouseout();
            _btnUp.css("cursor", "pointer").click(scrollUp).hover(autoStop, autoPlay);//Shawphy:向上向下鼠标事件绑定
            _btnDown.css("cursor", "pointer").click(scrollDown).hover(autoStop, autoPlay);
            _btnLeft.css("cursor", "pointer").click(scrollLeft).hover(autoStop, autoPlay);//Shawphy:向上向下鼠标事件绑定
            _btnRight.css("cursor", "pointer").click(scrollRight).hover(autoStop, autoPlay);
        }
    })
})(jQuery);