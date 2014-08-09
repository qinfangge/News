(function (jQuery) {
    jQuery.fn.extend({
        Scroll: function (opt, callback) {
            //������ʼ��
            if (!opt) var opt = {};

            var _btnUp = jQuery("#" + opt.up);//Shawphy:���ϰ�ť
            var _btnDown = jQuery("#" + opt.down);//Shawphy:���°�ť
            var _btnLeft = jQuery("#" + opt.left);//Shawphy:���ϰ�ť
            var _btnRight = jQuery("#" + opt.right);//Shawphy:���°�ť
            var flag = opt.flag;
            var timerID;
            var _this = this.eq(0).find("ul:first");
            var lineH = _this.find("li:first").height(), //��ȡ�и�
                    lineW = this.find("li:first").width(),//��ȡ���
                    line = opt.line ? parseInt(opt.line, 10) : parseInt(this.height() / lineH, 10), //ÿ�ι�����������Ĭ��Ϊһ�������������߶�
                    line2 = opt.line ? parseInt(opt.line, 10) : parseInt(this.width() / lineW, 10), //ÿ�ι�����������Ĭ��Ϊһ�������������߶�
                    speed = opt.speed ? parseInt(opt.speed, 10) : 500; //���ٶȣ���ֵԽ���ٶ�Խ�������룩
            timer = opt.timer //?parseInt(opt.timer,10):3000; //������ʱ���������룩

            if (line == 0) line = 1;
            var upHeight = 0 - line * lineH;

            if (line2 == 0) line2 = 1;
            var leftWidth = 0 - line2 * lineW;
            //��������
            var scrollUp = function () {
                flag = "up";
                _btnUp.unbind("click", scrollUp); //Shawphy:ȡ�����ϰ�ť�ĺ�����
                _this.animate({
                    marginTop: upHeight
                }, speed, function () {
                    for (i = 1; i <= line; i++) {
                        _this.find("li:first").appendTo(_this);
                    }
                    _this.css({ marginTop: 0 });
                    _btnUp.bind("click", scrollUp); //Shawphy:�����ϰ�ť�ĵ���¼�
                });
                return false;
            }
            //Shawphy:���·�ҳ����
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

            //�����������
            var scrollLeft = function () {

                flag = "left";
                _btnLeft.unbind("click", scrollLeft); //Shawphy:ȡ�����ϰ�ť�ĺ�����
                _this.animate({
                    marginLeft: leftWidth
                }, speed, function () {
                    for (i = 1; i <= line2; i++) {
                        _this.find("li:first").appendTo(_this);
                    }
                    _this.css({ marginLeft: 0 });
                    _btnLeft.bind("click", scrollLeft); //Shawphy:�����ϰ�ť�ĵ���¼�
                });
                return false;
            }
            //���ҹ�������
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

            //Shawphy:�Զ�����
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
            //����¼���
            _this.hover(autoStop, autoPlay).mouseout();
            _btnUp.css("cursor", "pointer").click(scrollUp).hover(autoStop, autoPlay);//Shawphy:������������¼���
            _btnDown.css("cursor", "pointer").click(scrollDown).hover(autoStop, autoPlay);
            _btnLeft.css("cursor", "pointer").click(scrollLeft).hover(autoStop, autoPlay);//Shawphy:������������¼���
            _btnRight.css("cursor", "pointer").click(scrollRight).hover(autoStop, autoPlay);
        }
    })
})(jQuery);