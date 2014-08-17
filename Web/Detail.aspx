<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="CMS.Web.Detail" %>

<%@ Register Src="Controls/CurrentPosition.ascx" TagName="CurrentPosition" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    <link href="css/detail.css" rel="stylesheet" />


    <link rel="stylesheet" href="Js/libs/artDialog/css/ui-dialog.css" />
    <script src="Js/libs/artDialog/dist/dialog-min.js"></script>
    <script>
        var newsId=<%=this.strid%>;
       
        $(document).ready(function () {
           
           
          
            var d = dialog({
                title: '提示',
                content: ''
            });

            //账号登录提示

            $(".tie-textbox").focus(function()
            {
                $(this).next().hide();
            }).blur(function()
            {
                if($.trim($(this).val())=="")
                {
                    $(this).next().show();
                }
            });
            $(".author-tips").click(function()
            {
                $(this).hide();
            });

            $(".js-reply").click(function()
            {
                $(this).parents(".tie-inner").append($(".tie-replyModule").show());
            });

            $(".js-tie-logout").click(function()
            {
                var url="/ashx/User.ashx";
                var data={a:"out"};
                $.post(url,data,function(data)
                {
                    if(data=="1")
                    {
                        window.location.reload();
                    }else
                    {
                        d.content("网络繁忙，请稍后重试！").show();
                    }
                });
            });

            
            $(".tie-replyModule .js-loginPostBtn").click(function()
            {
                var url="/ashx/User.ashx";
                var userName=$.trim($(this).parents(".tie-replyModule").find(".js-username").val());
                var password=$.trim($(this).parents(".tie-replyModule").find(".js-password").val());
                
                var data={userName:userName,password:password,a:"in"};
                $.post(url,data,function(data)
                {
                    if(data=="1")
                    {
                        window.location.reload();
                    }else
                    {
                        d.content("网络繁忙，请稍后重试！").show();
                    }
                });
            });


            $("#tiePostBox .js-loginPostBtn").click(function()
            {
                var url="/ashx/User.ashx";
                var userName=$.trim($(this).parents("#tiePostBox").find(".js-username").val());
                var password=$.trim($(this).parents("#tiePostBox").find(".js-password").val());
                
                var data={userName:userName,password:password,a:"in"};
                $.post(url,data,function(data)
                {
                    if(data=="1")
                    {
                        window.location.reload();
                    }else
                    {
                        d.content("用户名密码错误").show();
                    }
                });
            });

           
            $(".tie-photo a.js-digicon").bind("click",function()
            {
                var url = "/ashx/Comment.ashx";
                var type=2;
                var id=Number($(this).attr("id").replace("reply",""));
                var data={type:type,id:id};
                
                var curentDing=$(this);

                $.post(url,data,function(data)
                {
                    if(data=="1")
                    {
                       
                        curentDing.unbind('click');
                        var count=Number(curentDing.parent().find(".rec-digcount").text())+1;
                        $("#text"+id).parent().empty().html('<span class="visited">顶<em class="js-ding-em">['+count+']</em></span>');

                        curentDing.removeClass("js-digicon").addClass("tie-digicon-click").parent().find(".rec-digcount").text(count);
                    }else
                    {
                        d.content('网络繁忙，请稍后重试!').show();
                    }
                });

            });


            $(".js-ding").click(function()
            {
                var url = "/ashx/Comment.ashx";
                var type=2;
                var id=Number($(this).attr("id").replace("text",""));
                var data={type:type,id:id};
                
                var curentDing=$(this);
                $.post(url,data,function(data)
                {
                    if(data=="1")
                    {
                        var count=Number(curentDing.find(".js-ding-em").text().replace("[","").replace("]",""))+1;
                        curentDing.parent().empty().html('<span class="visited">顶<em class="js-ding-em">['+count+']</em></span>');

                        $("#reply"+id).removeClass("js-digicon").addClass("tie-digicon-click").unbind('click').parent().find(".rec-digcount").text(count);
                    }else
                    {
                        d.content('网络繁忙，请稍后重试!').show();
                    }
                });

            });


            //回复文章
            $("#tiePostBox a.js-postBtn").click(function () {

               
                var content = $.trim($("#tiePostBox .js-postBox").val());
                
                if (content == "") {
                   
                  
                    d.content('请输入评论内容!');
                    d.show();
                    return ;
                }

                var url = "/ashx/Comment.ashx";
                var pid="0";
                var type=1;
                var data={newsId:newsId,content:content,pid:pid,type:type};
                $.post(url,data,function(data)
                {
                    if(data=="1")
                    {
                        d.content('评论成功，正在审核中。。。').show();
                        $(".js-postBox").val("");
                        return;
                    }
                    if(data=="0")
                    {
                        d.content('网络繁忙，请稍后重试!').show();
                        return;
                    }

                    d.content(data).show();
                });



                return false;
            });


            //回复其它人

            $(".tie-replyModule a.js-postBtn").click(function () {

               
                var content = $.trim($(".tie-replyModule .js-postBox").val());
                
                if (content == "") {
                   
                  
                    d.content('请输入评论内容!');
                    d.show();
                    return ;
                }

                var url = "/ashx/Comment.ashx";
                var pid=$(this).parents(".tie-replyModule").prev().find(".support a").attr("id").replace("text","");
                var type=1;
                var data={newsId:newsId,content:content,pid:pid,type:type};
                $.post(url,data,function(data)
                {
                    if(data=="1")
                    {
                        d.content('评论成功，正在审核中。。。').show();
                        $(".js-postBox").val("");
                        return;
                    }
                    if(data=="0")
                    {
                        d.content('网络繁忙，请稍后重试!').show();
                        return;
                    }

                    d.content(data).show();
                });



                return false;
            });

            //信息反馈
            $(".feedback-title a").click(function()
            {
                $(".feedback-form").show();
            });

            $("input[name=reason]:last").click(function()
            {
                
                $("input[name=email]").show();
                $("textarea[name='reason_text']").show();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">



    <div class="commend-epwrap" style="display: block;">

        <div class="mainarea clearfix">
            <div class="commend-epbody" style="top: 0px;">
                <div id="epContent" class="commend-epbody-inner" style="min-height: 1000px; visibility: visible;">
                    <div class="ep-content-bg clearfix">
                        <uc1:CurrentPosition ID="CurrentPosition1" runat="server" ArticleTableName="Default" />
                        <div id="epContentRight" class="ep-content-side">
                            <div class="ep-content-side-inner" style="top: 0px;">
                                <div class="ep-title-2 clearfix">
                                    <h2 class="title">相关推荐</h2>
                                </div>
                                <div>
                                    <ul class="mod-f12list">
                                        <li><a target="_self" srctype="101" docid="A1RM4MNG90014MNH" title="娱圈还有爱情童话 盘点小贝夫妇15年情路" href="/#detail/99/A1RM4MNG90014MNH?101">娱圈还有爱情童话 盘点小贝夫妇15年情路</a></li>
                                        <li><a target="_self" srctype="101" docid="A25I08O9900108OA" title="贝克汉姆夫妇结婚15年 贝嫂收夫13枚婚戒" href="/#detail/99/A25I08O9900108OA?101">贝克汉姆夫妇结婚15年 贝嫂收夫13枚婚戒</a></li>
                                        <li><a target="_self" srctype="101" docid="A2PNEH7N9001EH7O" title="小贝大儿子脸上“超杀女”" href="/#detail/99/A2PNEH7N9001EH7O?101">小贝大儿子脸上“超杀女”</a></li>
                                        <li><a target="_self" srctype="101" docid="A2SL9C8C90019C8D" title="小贝长子情窦初开！被曝约会大两岁超杀女莫瑞兹" href="/#detail/99/A2SL9C8C90019C8D?101">小贝长子情窦初开！被曝约会大两岁超杀女莫瑞兹</a></li>
                                        <li><a target="_self" srctype="101" docid="A2NFALGI00254UF3" title="小贝15岁长子恋17岁女星 已交往三个月" href="/#detail/99/A2NFALGI00254UF3?101">小贝15岁长子恋17岁女星 已交往三个月</a></li>
                                    </ul>
                                </div>
                                <span class="blank6"></span>
                                <div class="ep-title-2 clearfix">
                                    <h2 class="title">猜你喜欢</h2>
                                </div>
                                <div>
                                    <ul class="mod-f12list">
                                        <li><a target="_self" srctype="102" docid="A31QNTR100254TI5" title="韩彩英1亿婚礼嫁豪门 曝大办过亿婚礼女星/图" href="/#detail/99/A31QNTR100254TI5?102">韩彩英1亿婚礼嫁豪门 曝大办过亿婚礼女星/图</a></li>
                                        <li><a target="_self" srctype="102" docid="A310T28F9001T28G" title="李小璐整容失败巩俐胸下垂 女星装嫩大出丑/图" href="/#detail/99/A310T28F9001T28G?102">李小璐整容失败巩俐胸下垂 女星装嫩大出丑/图</a></li>
                                        <li><a target="_self" srctype="102" docid="A31R7EQ590017EQ6" title="全智贤金秀贤未PS照曝光 求给女神男神打光" href="/#detail/99/A31R7EQ590017EQ6?102">全智贤金秀贤未PS照曝光 求给女神男神打光</a></li>
                                        <li><a target="_self" srctype="102" docid="A31IUPFR00031H2L" title="杨千嬅黑脸训儿子" href="/#detail/99/A31IUPFR00031H2L?102">杨千嬅黑脸训儿子</a></li>
                                        <li><a target="_self" srctype="102" docid="A31D8TQ900964K7C" title="8月8日爸爸节 盘点娱乐圈的绝顶好爸爸" href="/#detail/99/A31D8TQ900964K7C?102">8月8日爸爸节 盘点娱乐圈的绝顶好爸爸</a></li>
                                    </ul>
                                </div>
                                <span class="blank20"></span>
                                <div class="mod-ins">
                                    <span class="blank9"></span>
                                    <div class="ep-love">
                                        <div class="ep-love-title"><a href="http://love.163.com/?vendor=163.news.jian" class="ep-love-logo">网易花田</a></div>
                                        <ul class="love m-imglist imglist-90in300 interval clearfix" id="js_loveul">
                                            <li class="love-user"><a href="http://love.163.com/75433473?vendor=163.news.jian">
                                                <img width="90" alt="上海" src="http://s.cimg.163.com/i/img2.ph.126.net/zICIPA8JS6SsbcdASYuasg==/6608679509933846207.jpg.90x90.75.jpg"><p><span class="love-user-location">上海</span><span class="love-user-age">28岁</span></p>
                                            </a></li>
                                            <li class="love-user"><a href="http://love.163.com/5508808?vendor=163.news.jian">
                                                <img width="90" alt="上海" src="http://s.cimg.163.com/i/img2.ph.126.net/c6pQGgPcBE1z5kEeqT6DXA==/6608810351817700448.jpg.90x90.75.jpg"><p><span class="love-user-location">上海</span><span class="love-user-age">30岁</span></p>
                                            </a></li>
                                            <li class="love-user"><a href="http://love.163.com/2254500?vendor=163.news.jian">
                                                <img width="90" alt="上海" src="http://s.cimg.163.com/i/img0.ph.126.net/rRFWPGWEWbcQsj6fpEWRwA==/6597286370448716142.jpg.90x90.75.jpg"><p><span class="love-user-location">上海</span><span class="love-user-age">30岁</span></p>
                                            </a></li>
                                            <li class="love-user"><a href="http://love.163.com/4173763?vendor=163.news.jian">
                                                <img width="90" alt="上海" src="http://s.cimg.163.com/i/img0.ph.126.net/PwwPziWzOhCPV3pJKyhzrA==/6599298476727201033.jpg.90x90.75.jpg"><p><span class="love-user-location">上海</span><span class="love-user-age">21岁</span></p>
                                            </a></li>
                                            <li class="love-user"><a href="http://love.163.com/6121126?vendor=163.news.jian">
                                                <img width="90" alt="上海" src="http://s.cimg.163.com/i/img1.ph.126.net/d6VmVZJDTuXsh2D9_ocItQ==/6619529490676595086.jpg.90x90.75.jpg"><p><span class="love-user-location">上海</span><span class="love-user-age">23岁</span></p>
                                            </a></li>
                                            <li class="love-user"><a href="http://love.163.com/20260217?vendor=163.news.jian">
                                                <img width="90" alt="上海" src="http://s.cimg.163.com/i/img1.ph.126.net/QE-HGhvu91E5LAN5KuFz8A==/2966746254630563401.jpg.90x90.75.jpg"><p><span class="love-user-location">上海</span><span class="love-user-age">22岁</span></p>
                                            </a></li>
                                        </ul>
                                        <div class="tab-ft clearfix">
                                            <span class="c-fl"><a href="http://love.163.com/park/xunren/106001?vendor=163.news.jian">求河南妹子不要嫌弃我</a> <a href="http://love.163.com/park/xunren/107001" target="_blank">小学音乐老师，短发很酷</a></span>
                                        </div>
                                    </div>
                                    <span class="blank20"></span>
                                    <span class="blank9"></span>


                                </div>
                                
                                <div class="feedback-title clearfix">
                                    <a>举报与反馈</a>
                                </div>
                                <div class="feedback-form">
                                <input type="hidden" name="url">
                                <label>
                                    <input type="radio" value="文章缺失" name="reason">
                                    <span>图片，文字等缺失或错误</span>
                                </label>
                                <label>
                                    <input type="radio" value="色情暴力" name="reason">
                                    <span>色情，暴力等非法内容</span>
                                </label>
                                <label>
                                    <input type="radio" value="垃圾内容" name="reason">
                                    <span>广告，重复文章等垃圾内容</span>
                                </label>
                                <label>
                                    <input type="radio" value="" name="reason">
                                    <span>我有话要说</span>
                                </label>
                                <input type="text" placeholder="邮箱地址(选填)" name="email" class="feedback-email">
                                <textarea placeholder="详细信息" name="reason_text"></textarea>
                                <div class="feedback-footer">
                                    <a class="feedback-cancel">取消</a>
                                    <button class="feedback-confirm">确定</button>
                                </div>
                                </div>
                            </div>
                        </div>
                        <div id="epContentLeft" class="ep-content-main">

                            <h1 class="ep-h1" id="h1title">
                                <asp:Literal ID="ArticleTitle" runat="server"></asp:Literal></h1>
                            <div class="clearfix">
                                <div class="ep-info cDGray">
                                    <div class="left">
                                        <asp:Literal ID="AddTime" runat="server"></asp:Literal>&#12288;来源:
                                        <asp:Literal ID="Source" runat="server"></asp:Literal>&#12288;点击量：<asp:Literal ID="Hits" runat="server"></asp:Literal>
                                        &#12288;<a title="点击查看跟贴" href="http://comment.ent.163.com/ent2_bbs/A2U8QTTC00031H2L.html#articlejiannewscomment" class="cDRed js-tielink" target="_blank">有<span class="js-totalcount"><asp:Literal ID="CommentCount" runat="server"></asp:Literal></span>人参与</a>
                                    </div>
                                    <div class="ep-icon-tie"><a data-action="tieanchor" class="js-tieachor" target="_self" href="#tiePostBox" title="快速发贴"></a></div>
                                </div>
                            </div>
                            <div id="endText">
                                <asp:Literal ID="Content" runat="server"></asp:Literal>
                            </div>

                            <span class="blank20"></span>
                            <div class="sharecommend-wrap clearfix">
                                <div class="share-wrap">
                                    <%--  <div data-action="share" class="clearfix">
                                            <div class="ep-centerbox-outer"><a class="ep-centerbox-item yixin-bigbtn js-yixin-btn share-yixin" href="http://yixin.im/#f=www">分享到易信朋友圈</a></div>
                                        </div>--%>
                                    <div id="tieAnchor" class="sharecommend-info" style="position: relative; left: 100px;">
                                        <div class="bdsharebuttonbox"><a href="#" class="bds_more" data-cmd="more"></a><a title="分享到QQ空间" href="#" class="bds_qzone" data-cmd="qzone"></a><a title="分享到新浪微博" href="#" class="bds_tsina" data-cmd="tsina"></a><a title="分享到腾讯微博" href="#" class="bds_tqq" data-cmd="tqq"></a><a title="分享到人人网" href="#" class="bds_renren" data-cmd="renren"></a><a title="分享到微信" href="#" class="bds_weixin" data-cmd="weixin"></a></div>
                                        <script>window._bd_share_config = { "common": { "bdSnsKey": {}, "bdText": "", "bdMini": "2", "bdMiniList": false, "bdPic": "", "bdStyle": "0", "bdSize": "32" }, "share": {} }; with (document) 0[(getElementsByTagName('head')[0] || body).appendChild(createElement('script')).src = 'http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion=' + ~(-new Date() / 36e5)];</script>


                                    </div>
                                </div>
                                <div class="qr-wrap">
                                    <span>扫一扫在手机打开当前页</span>
                                    <div style="background-image: url(http://imgsize.ph.126.net/?imgurl=http://j.news.163.com/hy/qrpic/A2U8QTTC00031H2L_140x180.jpg)" class="qr-wrap-img"></div>
                                </div>
                            </div>
                            <div class="tie-area" id="tieArea">
                                <div id="tiePostBox" class="tie-post js-post-area tie-post-list">
                                    <div style="display: none" class="tie-titlebar tie-title-mend">
                                        <strong>网友跟贴</strong>
                                        <span class="tie-info"><a target="_blank" class="js-bactCount tie-actCount" href="http://comment.ent.163.com/ent2_bbs/A2U8QTTC00031H2L.html#articlejiannewscomment">632</a>人跟贴 <span class="info-line">|</span>
                                            <a target="_blank" class="js-bjoinCount tie-actCount" href="http://comment.ent.163.com/ent2_bbs/A2U8QTTC00031H2L.html#articlejiannewscomment">7,758</a>人参与 <span class="info-line">|</span>
                                            <a class="tie-byMobile" target="_blank" href="http://m.163.com/newsapp/"><em class="tie-sprite"></em>
                                                手机发跟贴</a> <span class="info-line">|</span> <a target="_blank" class="tie-reg js-reg" href="http://reg.163.com/reg0.shtml?product=tie&amp;url=http://j.news.163.com/#tie-reply">注册</a>
                                        </span>
                                    </div>
                                    <div class="tie-postform">
                                        <div class="tie-hotword">
                                            <p>跟贴热词： </p>
                                        </div>
                                        <div class="tie-post-area">

                                            <%-- <div class="post-area-photo js-ularea-photo">
                                                <a class="tie-sprite area-photo-nohover" title="请登录" target="_self" href="javascript:;"></a>
                                            </div>

                                            <div style="display: none;" class="post-area-photo js-area-photo">
                                                <a class="tie-sprite area-photo-icon" title="请上传头像" href="http://tie.163.com/setting/avatar/?from=userPanel"></a>
                                            </div>--%>

                                            <div class="post-area-photo js-larea-photo">
                                                <a href="http://tie.163.com/setting/avatar/?from=userPanel">
                                                    <%--<img width="65" height="65">--%>
                                                    <asp:Image Width="65" Height="65" ID="Avatar" ImageUrl="~/Images/noAvatar.jpg" runat="server" />
                                                </a>
                                            </div>

                                            <div class="post-area-input js-postinput">
                                                <textarea name="body" class="tie-textarea js-postBox" cols="80" rows="8"></textarea>
                                                <%-- <div class="area-input-tips js-tie-tips">
                                                    文明上网，登录发贴
                                                </div>--%>
                                                <div class="area-input-leftline">
                                                </div>
                                                <div class="area-input-topline">
                                                </div>
                                               <%-- <input type="hidden" value="ent2_bbs" name="board">
                                                <input type="hidden" name="username">
                                                <input type="hidden" value="A2U8QTTC00031H2L" name="threadid">
                                                <input type="hidden" value="http://comment.ent.163.com/ent2_bbs/A2U8QTTC00031H2L.html#articlejiannewscomment" name="url">
                                                <input type="hidden" value="1" name="isTinyBlogSyn">--%>
                                            </div>
                                        </div>
                                        <div class="tie-author js-tie-author">
                                            <asp:Panel ID="LoginPanel" runat="server">
                                                <div class="js-unlogin" style="">
                                                    <div class="js-loginInput">
                                                        <div class="author-name">
                                                            <em class="tie-sprite"></em>
                                                            <input type="text" class="tie-textbox js-username">
                                                            <div class="author-tips js-nametips" style="display: none;">
                                                                账号
                                                            </div>
                                                        </div>
                                                        <div class="author-pwd">
                                                            <em class="tie-sprite"></em>
                                                            <input type="password" class="tie-textbox js-password">
                                                            <div class="author-tips js-pwdtips" style="display: none;">
                                                                密码
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="tie-author-login">
                                                        <label>
                                                            <input type="checkbox" class="js-save" checked="checked">自动登录</label>
                                                        <%--<label class="js-syn">
                                                            <input type="checkbox" checked="checked"><em class="tie-sprite"></em></label>--%>
                                                        <a class="tie-sprite post-btn js-loginPostBtn" target="_self" href="javascript:void(0);">登录并发表</a>
                                                    </div>
                                                </div>

                                            </asp:Panel>
                                            <asp:Panel ID="LoginInPanel" runat="server">
                                                <div style="display: block;" class="js-login">
                                                    <div class="tie-author-logon">
                                                        <a href="http://tie.163.com/reply/myaction.jsp?action=reply2me&amp;username=&lt;#=userId#&gt;" class="js-tie-myhome" target="_blank" rel="nofollow">
                                                            <strong class="js-tie-username">
                                                                <%=this.user.userName %></strong></a>&nbsp; <a href="#" target="_blank" class="js-tie-myposts" rel="nofollow">我的跟贴</a> |
           
                                                        <%--<a href="http://t.163.com/" target="_blank" rel="nofollow">我的微博</a> |--%> <a target="_self" href="javascript:void(0)" class="js-tie-logout" rel="nofollow">退出</a>
                                                    </div>
                                                    <div class="tie-author-login">
                                                        <%-- <label class="js-syn">
                                                            <input type="checkbox" checked="checked"><em class="tie-sprite"></em></label>--%>
                                                        <a class="tie-sprite post-btn js-postBtn" target="_self" href="javascript:void(0);">马上发表</a>
                                                    </div>
                                                </div>

                                            </asp:Panel>
                                        </div>
                                    </div>
                                    <p class="tie-reminder">网友评论仅供其表达个人看法，并不表明网易立场。</p>
                                </div>
                                <div class="tie-show js-tie-show" style="display: block;">
                                    <div class="tie-titlebar">
                                        <%--<strong></strong>
                                        <a class="j-tie-header"><span>微博评论</span>(<i class="js-weiboCount">0</i>)</a>--%>
                                        <a class="j-tie-header active"><span>跟贴</span><%--(<i class="js-actCount">
                                        </i>)--%></a>
                                        <span class="tie-info">
                                            <a target="_blank" class="js-joinCount tie-actCount" href="http://comment.ent.163.com/ent2_bbs/A2U8QTTC00031H2L.html#articlejiannewscomment">
                                                <asp:Literal ID="CommentCount2" runat="server"></asp:Literal></a>人参与 </span>
                                    </div>
                                    <div class="j-tie-body js-weibo-data"></div>
                                    <div class="j-tie-body js-tie-data active">
                                        <div class="tie-hot-title">热门跟贴</div>
                                        <asp:Repeater ID="HotReplayRepeater" runat="server">
                                            <ItemTemplate>
                                                <div class="tie-reply js-tie-reply">
                                                    <div class="tie-photo">

                                                        <a href="javascript:void(0)" id="reply<%#Eval("id") %>" class="js-digicon tie-digicon" target="_self"><span></span></a>
                                                        <div class="rec-digcount js-rec-digcount"><%#Eval("dig") %></div>
                                                    </div>
                                                    <div class="tie-inner js-tie-inner">
                                                        <span class="tie-sum-author"><span class="tie-from layerUserName"><a target="_blank" href="http://t.163.com/1935268330"><%#GetUserName(int.Parse(Eval("userID").ToString())) %></a>                                </span><span class="tie-ip">[<%#GetAddress(Eval("ip").ToString()) %>]</span>            </span><span class="tie-postTime"><%#Eval("addTime") %></span>
                                                        <div class="tie-body js-body">
                                                            <div class="tie-oneLayer layerFontColor js-body"><%#Eval("content") %></div>
                                                        </div>
                                                        <ul class="tie-operations">
                                                            <li class="support"><a class="js-ding" id="text<%#Eval("id") %>" href="javascript:void(0)" target="_self" rel="nofollow">顶<em class="js-ding-em">[<%#Eval("dig") %>]</em></a></li>
                                                            <li><a nodeid="recA2UQ5B0J" href="javascript:void(0)" class="js-reply" target="_self" rel="nofollow">回复</a></li>
                                                            <%--<li><a class="js-copy" href="javascript://A2UQ5B0J" target="_self" rel="nofollow">复制</a></li>--%>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </ItemTemplate>

                                        </asp:Repeater>

                                        <div class="tie-new-title">最新跟贴</div>

                                        <asp:Repeater ID="NewReplayRepeater" runat="server">
                                            <ItemTemplate>
                                                <div id="tieA3291GAA" class="tie-reply js-tie-reply ">
                                                    <div class="tie-photo">
                                                        <img width="35" height="35" alt="" src="<%#GetAvatar(int.Parse(Eval("userID").ToString())) %>">
                                                    </div>

                                                    <div class="tie-inner js-tie-inner">
                                                        <span class="tie-sum-author"><span class="tie-from layerUserName"><%#GetUserName(int.Parse(Eval("userID").ToString())) %>                                </span><span class="tie-ip">[<%#GetAddress(Eval("ip").ToString()) %>]</span>            </span><span class="tie-postTime"><%#Eval("addTime") %></span>
                                                        <div class="tie-body js-body">
                                                            <%#GetParentCommentHtml(int.Parse(Eval("pid").ToString())) %>
                                                            <%-- <div class="tie-frontOfFloor layerBgcolor">
                                                                <div class="tie-floorInner"><span class="tie-floor-author layerUserName">网易湖南省手机网友(106.35.*.*)的原贴：</span>                <span class="tie-floor-index">1</span>            </div>
                                                                <p class="tie-floor-content layerFontColor">维多利亚的胸不用大师说，我们一看就看出假了，半球缝隙严丝合缝</p>
                                                            </div>--%>
                                                            <p class="tie-floor-content layerFontColor"><%#Eval("content") %></p>
                                                        </div>
                                                        <ul class="tie-operations">
                                                            <li class="support"><a class="js-ding" id="text<%#Eval("id") %>" href="javascript:void(0)" target="_self" rel="nofollow">顶<em class="js-ding-em">[<%#Eval("dig") %>]</em></a></li>
                                                            <li><a href="javascript:void(0)" class="js-reply" target="_self" rel="nofollow">回复</a></li>
                                                            <%--<li><a class="js-copy" href="javascript://A3291GAA" target="_self" rel="nofollow">复制</a></li>--%>
                                                        </ul>


                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <a target="_blank" href="http://comment.ent.163.com/ent2_bbs/A2U8QTTC00031H2L.html#articlejiannewscomment" class="js-tiemore tie-more">查看全部跟贴<em>&gt;&gt;</em></a>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <div class="tie-replyModule" style="display: none;">
                <div class="tie-postform">
                    <form accept-charset="gbk" class="js-postForm" method="post" target="_blank" action="http://comment.news.163.com/reply/dopost.jsp">
                        <div class="module-wraper js-postinput">
                            <div class="moduleInput-wraper">
                                <textarea name="body" rows="8" cols="80" class="tie-textarea js-postBox"></textarea>
                            </div>
                            <%-- <div class="area-input-tips js-tie-tips" style="display: block;">文明上网，登录发贴</div>--%>
                            <div class="area-input-leftline"></div>
                            <div class="area-input-topline"></div>
                            <span class="tie-sprite replyModule-arrow js-arrow" style="left: 494px;"></span>
                        </div>
                        <%--<input type="hidden" name="username">
                        <input type="hidden" name="board" value="comment_bbs">
                        <input type="hidden" name="threadid" value="A3O8P2869001P287">
                        <input type="hidden" name="url" value="http://comment.news.163.com/comment_bbs/A3O8P2869001P287.html#articlejiannewscomment">
                        <input type="hidden" name="quote" value="A3O8P2869001P287_A3P9K3BA">
                        <input type="hidden" value="1" name="isTinyBlogSyn">--%>
                    </form>
                    <asp:Panel ID="ReplyModuleLogin" runat="server">
                        <div  class="js-unlogin">
                            <div class="tie-author-logno js-loginInput">
                                <div class="author-name">
                                    <em class="tie-sprite"></em>
                                    <input type="text" class="tie-textbox js-username">
                                    <div class="author-tips js-nametips">账号</div>
                                </div>
                                <div class="author-pwd">
                                    <em class="tie-sprite"></em>
                                    <input type="password" class="tie-textbox js-password">
                                    <div class="author-tips js-pwdtips">密码</div>
                                </div>
                            </div>

                            <div class="tie-author-login">
                                <%--<label class="js-syn">
                                    <input type="checkbox" checked="checked"><em class="tie-sprite"></em></label>--%>
                                <a class="tie-sprite post-btn js-loginPostBtn" target="_self" href="javascript:void(0);">登录并发表</a>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="ReplyModuleLoginIn" runat="server">

                        <div style="display: block;" class="js-login">
                            <div class="tie-author-logon"><a class="tie-myposts js-tie-myhome" target="_blank" rel="nofollow" href="#"><strong class="tie-username js-tie-username"><%=this.user.userName %></strong></a>&nbsp;                 <a target="_blank" class="tie-myposts js-tie-myposts" rel="nofollow" href="#">我的跟贴</a> |              <a target="_self" class="tie-logout js-tie-logout" rel="nofollow" href="javascript:void(0)">退出</a>          </div>
                            <div class="tie-author-login">
                                <%--<label class="js-syn">
                                                                            <input type="checkbox" checked="checked"><em class="tie-sprite"></em></label>--%>
                                <a class="tie-sprite post-btn js-postBtn" target="_self" href="javascript:void(0);">马上发表</a>
                            </div>
                        </div>
                    </asp:Panel>


                </div>
            </div>

            <div id="epMask" class="epmask"></div>
        </div>
    </div>

</asp:Content>
