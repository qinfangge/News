<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="CMS.Web.Detail" %>
<%@ Register Src="Controls/CurrentPosition.ascx" TagName="CurrentPosition" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    <link href="css/detail.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <form id="form1" runat="server">
    
    
    <div class="commend-epwrap" style="display:block;">
        
            <div class="mainarea clearfix">
                <div class="commend-epbody" style="top: 0px;">
                    <div id="epContent" class="commend-epbody-inner" style="min-height: 1000px; visibility: visible;">
                        <div class="ep-content-bg clearfix">
                            <uc1:currentposition ID="CurrentPosition1" runat="server" ArticleTableName="Default" />
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
                            <div id="epContentLeft" class="ep-content-main">
                                
                                <h1 class="ep-h1" id="h1title"><asp:Literal ID="ArticleTitle" runat="server"></asp:Literal></h1>
                                <div class="clearfix">
                                    <div class="ep-info cDGray">
                                        <div class="left"><asp:Literal ID="AddTime" runat="server"></asp:Literal>&#12288;来源: <asp:Literal ID="Source" runat="server"></asp:Literal>&#12288;点击量：<asp:Literal ID="Hits" runat="server"></asp:Literal>
                                            <a rel="nofollow" target="_blank" href="http://ent.163.com/14/0806/01/A2U8QTTC00031H2L.html">网易娱乐</a> &#12288;<a title="点击查看跟贴" href="http://comment.ent.163.com/ent2_bbs/A2U8QTTC00031H2L.html#articlejiannewscomment" class="cDRed js-tielink" target="_blank">有<span class="js-totalcount">7758</span>人参与</a></div>
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
                                        <div id="tieAnchor" class="sharecommend-info" style="position:relative;left:100px;">
                                            <div class="bdsharebuttonbox"><a href="#" class="bds_more" data-cmd="more"></a><a title="分享到QQ空间" href="#" class="bds_qzone" data-cmd="qzone"></a><a title="分享到新浪微博" href="#" class="bds_tsina" data-cmd="tsina"></a><a title="分享到腾讯微博" href="#" class="bds_tqq" data-cmd="tqq"></a><a title="分享到人人网" href="#" class="bds_renren" data-cmd="renren"></a><a title="分享到微信" href="#" class="bds_weixin" data-cmd="weixin"></a></div>
<script>window._bd_share_config = { "common": { "bdSnsKey": {}, "bdText": "", "bdMini": "2", "bdMiniList": false, "bdPic": "", "bdStyle": "0", "bdSize": "32" }, "share": {} }; with (document) 0[(getElementsByTagName('head')[0] || body).appendChild(createElement('script')).src = 'http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion=' + ~(-new Date() / 36e5)];</script>
                                            
                                            
                                        </div>
                                    </div>
                                    <div class="qr-wrap"><span>扫一扫在手机打开当前页</span>
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
                                                    <div class="post-area-photo js-ularea-photo">
                                                        <a class="tie-sprite area-photo-nohover" title="请登录" target="_self" href="javascript:;"></a>
                                                    </div>
                                                    <div style="display: none;" class="post-area-photo js-area-photo">
                                                        <a class="tie-sprite area-photo-icon" title="请上传头像" href="http://tie.163.com/setting/avatar/?from=userPanel"></a>
                                                    </div>
                                                    <div style="display: none;" class="post-area-photo js-larea-photo">
                                                        <a href="http://tie.163.com/setting/avatar/?from=userPanel">
                                                            <img width="65" height="65">
                                                        </a>
                                                    </div>
                                                    <div class="post-area-input js-postinput">
                                                        <textarea name="body" class="tie-textarea js-postBox" cols="80" rows="8"></textarea>
                                                        <div class="area-input-tips js-tie-tips">
                                                            文明上网，登录发贴
                                                        </div>
                                                        <div class="area-input-leftline">
                                                        </div>
                                                        <div class="area-input-topline">
                                                        </div>
                                                        <input type="hidden" value="ent2_bbs" name="board">
                                                        <input type="hidden" name="username">
                                                        <input type="hidden" value="A2U8QTTC00031H2L" name="threadid">
                                                        <input type="hidden" value="http://comment.ent.163.com/ent2_bbs/A2U8QTTC00031H2L.html#articlejiannewscomment" name="url">
                                                        <input type="hidden" value="1" name="isTinyBlogSyn">
                                                    </div>
                                                </div>
                                            <div class="tie-author js-tie-author">
                                                <div class="js-unlogin" style="display: block;">
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
                                                            <div class="author-tips js-pwdtips">
                                                                密码
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="tie-author-login">
                                                        <label>
                                                            <input type="checkbox" class="js-save" checked="checked">自动登录</label>
                                                        <label class="js-syn">
                                                            <input type="checkbox" checked="checked"><em class="tie-sprite"></em></label>
                                                        <a class="tie-sprite post-btn js-loginPostBtn" target="_self" href="javascript:void(0);">登录并发表</a>
                                                    </div>
                                                </div>
                                                <div style="display: none" class="js-login">
                                                    <div class="tie-author-logon">
                                                        <a href="http://tie.163.com/reply/myaction.jsp" class="js-tie-myhome" target="_blank" rel="nofollow">
                                                            <strong class="js-tie-username"></strong></a>&nbsp; <a href="http://tie.163.com/reply/myaction.jsp" target="_blank" class="js-tie-myposts" rel="nofollow">我的跟贴</a> |
           
                                                        <a href="http://t.163.com/" target="_blank" rel="nofollow">我的微博</a> | <a target="_self" href="http://reg.163.com/Logout.jsp" class="js-tie-logout" rel="nofollow">退出</a>
                                                    </div>
                                                    <div class="tie-author-login">
                                                        <label class="js-syn">
                                                            <input type="checkbox" checked="checked"><em class="tie-sprite"></em></label>
                                                        <a class="tie-sprite post-btn js-postBtn" target="_self" href="javascript:void(0);">马上发表</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <p class="tie-reminder">网友评论仅供其表达个人看法，并不表明网易立场。</p>
                                    </div>
                                    <div class="tie-show js-tie-show" style="display: block;">
                                        <div class="tie-titlebar">
                                            <strong></strong>
                                            <a class="j-tie-header"><span>微博评论</span>(<i class="js-weiboCount">0</i>)</a>
                                            <a class="j-tie-header active"><span>跟贴</span>(<i class="js-actCount">632</i>)</a>
                                            <span class="tie-info">
                                                <a target="_blank" class="js-joinCount tie-actCount" href="http://comment.ent.163.com/ent2_bbs/A2U8QTTC00031H2L.html#articlejiannewscomment">7,758</a>人参与 </span>
                                        </div>
                                        <div class="j-tie-body js-weibo-data"></div>
                                        <div class="j-tie-body js-tie-data active">
                                            <div class="tie-hot-title">热门跟贴</div>
                                            <div id="recA2UQ5B0J" class="tie-reply js-tie-reply">
                                                <div class="tie-photo"><a href="javascript://A2UQ5B0J" class="js-digicon tie-digicon" target="_self"><span></span></a>
                                                    <div class="rec-digcount js-rec-digcount">3096</div>
                                                </div>
                                                <div class="tie-inner js-tie-inner"><span class="tie-sum-author"><span class="tie-from layerUserName"><a target="_blank" href="http://t.163.com/1935268330">村长在家</a>                                </span><span class="tie-ip">[网易湖南省永州市网友]</span>            </span><span class="tie-postTime">2014-08-06 06:47:30</span>
                                                    <div class="tie-body js-body">
                                                        <div class="tie-oneLayer layerFontColor js-body">尼玛，原来小贝一直在打假球？</div>
                                                    </div>
                                                    <ul class="tie-operations">
                                                        <li class="support"><a class="js-ding" href="javascript://A2UQ5B0J" target="_self" rel="nofollow">顶<em class="js-ding-em">[3096]</em></a></li>
                                                        <li><a nodeid="recA2UQ5B0J" href="javascript://A2UQ5B0J" class="js-reply" target="_self" rel="nofollow">回复</a></li>
                                                        <li><a class="js-copy" href="javascript://A2UQ5B0J" target="_self" rel="nofollow">复制</a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div id="recA2UM2FOS" class="tie-reply js-tie-reply">
                                                <div class="tie-photo"><a href="javascript://A2UM2FOS" class="js-digicon tie-digicon" target="_self"><span></span></a>
                                                    <div class="rec-digcount js-rec-digcount">1165</div>
                                                </div>
                                                <div class="tie-inner js-tie-inner"><span class="tie-sum-author"><span class="tie-from layerUserName">xiaogongzi6474                                </span><span class="tie-ip">[网易湖南省手机网友]</span>            </span><span class="tie-postTime">2014-08-06 05:35:57</span>
                                                    <div class="tie-body js-body">
                                                        <div class="tie-oneLayer layerFontColor js-body">维多利亚的胸不用大师说，我们一看就看出假了，半球缝隙严丝合缝</div>
                                                    </div>
                                                    <ul class="tie-operations">
                                                        <li class="support"><a class="js-ding" href="javascript://A2UM2FOS" target="_self" rel="nofollow">顶<em class="js-ding-em">[1165]</em></a></li>
                                                        <li><a nodeid="recA2UM2FOS" href="javascript://A2UM2FOS" class="js-reply" target="_self" rel="nofollow">回复</a></li>
                                                        <li><a class="js-copy" href="javascript://A2UM2FOS" target="_self" rel="nofollow">复制</a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div id="recA2UTA3J6" class="tie-reply js-tie-reply">
                                                <div class="tie-photo"><a href="javascript://A2UTA3J6" class="js-digicon tie-digicon" target="_self"><span></span></a>
                                                    <div class="rec-digcount js-rec-digcount">751</div>
                                                </div>
                                                <div class="tie-inner js-tie-inner"><span class="tie-sum-author"><span class="tie-from layerUserName"><a target="_blank" href="http://t.163.com/8131118757">西江风暴</a>                                </span><span class="tie-ip">[网易广东省深圳市网友]</span>            </span><span class="tie-postTime">2014-08-06 07:42:30</span>
                                                    <div class="tie-body js-body">
                                                        <div class="tie-oneLayer layerFontColor js-body">假又怎么了，人家孩子都三头了。</div>
                                                    </div>
                                                    <ul class="tie-operations">
                                                        <li class="support"><a class="js-ding" href="javascript://A2UTA3J6" target="_self" rel="nofollow">顶<em class="js-ding-em">[751]</em></a></li>
                                                        <li><a nodeid="recA2UTA3J6" href="javascript://A2UTA3J6" class="js-reply" target="_self" rel="nofollow">回复</a></li>
                                                        <li><a class="js-copy" href="javascript://A2UTA3J6" target="_self" rel="nofollow">复制</a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="tie-new-title">最新跟贴</div>
                                            <div id="tieA3291GAA" class="tie-reply js-tie-reply ">
                                                <div class="tie-photo">
                                                    <img width="35" height="35" alt="18351937185" src="http://timge4.126.net/image?w=35&amp;h=35&amp;url=http://mimg.126.net/p/butter/1008031648/img/face_big.gif&amp;gif=1&amp;quality=85">
                                                </div>
                                                <div class="tie-inner js-tie-inner"><span class="tie-sum-author"><span class="tie-from layerUserName">18351937185                                </span><span class="tie-ip">[网易江苏省淮安市手机网友]</span>            </span><span class="tie-postTime">2014-08-07 15:05:11</span>
                                                    <div class="tie-body js-body">
                                                        <div class="tie-frontOfFloor layerBgcolor">
                                                            <div class="tie-floorInner"><span class="tie-floor-author layerUserName">网易湖南省手机网友(106.35.*.*)的原贴：</span>                <span class="tie-floor-index">1</span>            </div>
                                                            <p class="tie-floor-content layerFontColor">维多利亚的胸不用大师说，我们一看就看出假了，半球缝隙严丝合缝</p>
                                                        </div>
                                                        <p class="tie-floor-content layerFontColor">谁能告诉我隆胸的女人喂奶怎么办</p>
                                                    </div>
                                                    <ul class="tie-operations">
                                                        <li class="support"><a class="js-ding" href="javascript://A3291GAA" target="_self" rel="nofollow">顶<em class="js-ding-em">[0]</em></a></li>
                                                        <li><a nodeid="tieA3291GAA" href="javascript://A3291GAA" class="js-reply" target="_self" rel="nofollow">回复</a></li>
                                                        <li><a class="js-copy" href="javascript://A3291GAA" target="_self" rel="nofollow">复制</a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div id="tieA3290J64" class="tie-reply js-tie-reply ">
                                                <div class="tie-photo">
                                                    <img width="35" height="35" alt="18351937185" src="http://timge4.126.net/image?w=35&amp;h=35&amp;url=http://mimg.126.net/p/butter/1008031648/img/face_big.gif&amp;gif=1&amp;quality=85">
                                                </div>
                                                <div class="tie-inner js-tie-inner"><span class="tie-sum-author"><span class="tie-from layerUserName">18351937185                                </span><span class="tie-ip">[网易江苏省淮安市手机网友]</span>            </span><span class="tie-postTime">2014-08-07 15:04:40</span>
                                                    <div class="tie-body js-body">
                                                        <div class="tie-frontOfFloor layerBgcolor">
                                                            <div class="tie-floorInner"><span class="tie-floor-author layerUserName">网易湖南省永州市网友 [村长在家] 的原贴：</span>                <span class="tie-floor-index">1</span>            </div>
                                                            <p class="tie-floor-content layerFontColor">尼玛，原来小贝一直在打假球？</p>
                                                        </div>
                                                        <p class="tie-floor-content layerFontColor">真球打腻了</p>
                                                    </div>
                                                    <ul class="tie-operations">
                                                        <li class="support"><a class="js-ding" href="javascript://A3290J64" target="_self" rel="nofollow">顶<em class="js-ding-em">[0]</em></a></li>
                                                        <li><a nodeid="tieA3290J64" href="javascript://A3290J64" class="js-reply" target="_self" rel="nofollow">回复</a></li>
                                                        <li><a class="js-copy" href="javascript://A3290J64" target="_self" rel="nofollow">复制</a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div id="tieA32906RL" class="tie-reply js-tie-reply ">
                                                <div class="tie-photo"><a target="_blank" href="http://t.163.com/4947239743">
                                                    <img width="35" height="35" title="随风40477671" alt="随风40477671" src="http://timge5.126.net/image?w=35&amp;h=35&amp;url=http://imgm.ph.126.net/iGYYhdDFcXpLnt-tPcMtAA==/2876111312129652903.jpg&amp;gif=1&amp;quality=85"></a>                    </div>
                                                <div class="tie-inner js-tie-inner"><span class="tie-sum-author"><span class="tie-from layerUserName"><a target="_blank" href="http://t.163.com/4947239743">随风40477671</a>                                </span><span class="tie-ip">[网易江苏省手机网友]</span>            </span><span class="tie-postTime">2014-08-07 15:04:33</span>
                                                    <div class="tie-body js-body">
                                                        <div class="tie-oneLayer layerFontColor">不会辜负和进口 i</div>
                                                    </div>
                                                    <ul class="tie-operations">
                                                        <li class="support"><a class="js-ding" href="javascript://A32906RL" target="_self" rel="nofollow">顶<em class="js-ding-em">[0]</em></a></li>
                                                        <li><a nodeid="tieA32906RL" href="javascript://A32906RL" class="js-reply" target="_self" rel="nofollow">回复</a></li>
                                                        <li><a class="js-copy" href="javascript://A32906RL" target="_self" rel="nofollow">复制</a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div id="tieA328QM49" class="tie-reply js-tie-reply ">
                                                <div class="tie-photo"><a target="_blank" href="http://t.163.com/5133110525">
                                                    <img width="35" height="35" title="淡淡的蛋疼" alt="淡淡的蛋疼" src="http://timge5.126.net/image?w=35&amp;h=35&amp;url=http://imgm.ph.126.net/x8ozRxjLW-P_8EcQVjRwqQ==/1377257061145486262.jpg&amp;gif=1&amp;quality=85"></a>                    </div>
                                                <div class="tie-inner js-tie-inner"><span class="tie-sum-author"><span class="tie-from layerUserName"><a target="_blank" href="http://t.163.com/5133110525">淡淡的蛋疼</a>                                </span><span class="tie-ip">[网易内蒙古手机网友]</span>            </span><span class="tie-postTime">2014-08-07 15:01:32</span>
                                                    <div class="tie-body js-body">
                                                        <div class="tie-frontOfFloor layerBgcolor">
                                                            <div class="tie-floorInner"><span class="tie-floor-author layerUserName">网易吉林省手机网友(221.9.*.*)的原贴：</span>                <span class="tie-floor-index">1</span>            </div>
                                                            <p class="tie-floor-content layerFontColor">李白太神了，他早就知道贝嫂隆胸了！不信你们看他留下的藏头诗！<br>
                                                                <br>
                                                                《隆》<br>
                                                                贝克汉姆来踢球<br>
                                                                嫂子一旁在加油<br>
                                                                假日他俩啪啪啪<br>
                                                                胸口碎大石啊呀。<br>
                                                                <br>
                                                                太神了！李白真神！</p>
                                                        </div>
                                                        <p class="tie-floor-content layerFontColor">我日，李白估计能跑出来找你</p>
                                                    </div>
                                                    <ul class="tie-operations">
                                                        <li class="support"><a class="js-ding" href="javascript://A328QM49" target="_self" rel="nofollow">顶<em class="js-ding-em">[0]</em></a></li>
                                                        <li><a nodeid="tieA328QM49" href="javascript://A328QM49" class="js-reply" target="_self" rel="nofollow">回复</a></li>
                                                        <li><a class="js-copy" href="javascript://A328QM49" target="_self" rel="nofollow">复制</a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div id="tieA328P3UU" class="tie-reply js-tie-reply ">
                                                <div class="tie-photo"><a target="_blank" href="http://t.163.com/5180853345">
                                                    <img width="35" height="35" title="b3dbbf0d6800463d8b2ae63b" alt="b3dbbf0d6800463d8b2ae63b" src="http://timge4.126.net/image?w=35&amp;h=35&amp;url=http://q.qlogo.cn/qqapp/100346651/B3DBBF0D6800463D8B2AE63BC1109161/100&amp;gif=1&amp;quality=85"></a>                    </div>
                                                <div class="tie-inner js-tie-inner"><span class="tie-sum-author"><span class="tie-from layerUserName"><a target="_blank" href="http://t.163.com/5180853345">b3dbbf0d6800463d8b2ae63b</a>                                </span><span class="tie-ip">[网易天津市手机网友]</span>            </span><span class="tie-postTime">2014-08-07 15:00:36</span>
                                                    <div class="tie-body js-body">
                                                        <div class="tie-oneLayer layerFontColor">楼上一群傻逼</div>
                                                    </div>
                                                    <ul class="tie-operations">
                                                        <li class="support"><a class="js-ding" href="javascript://A328P3UU" target="_self" rel="nofollow">顶<em class="js-ding-em">[0]</em></a></li>
                                                        <li><a nodeid="tieA328P3UU" href="javascript://A328P3UU" class="js-reply" target="_self" rel="nofollow">回复</a></li>
                                                        <li><a class="js-copy" href="javascript://A328P3UU" target="_self" rel="nofollow">复制</a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div id="tieA32839N2" class="tie-reply js-tie-reply ">
                                                <div class="tie-photo"><a target="_blank" href="http://t.163.com/9147152522">
                                                    <img width="35" height="35" title="撸无罪" alt="撸无罪" src="http://timge5.126.net/image?w=35&amp;h=35&amp;url=http://imgm.ph.126.net/EP6OP7uNp_6JtWDBnvzGnA==/6597318256284664541.jpg&amp;gif=1&amp;quality=85"></a>                    </div>
                                                <div class="tie-inner js-tie-inner"><span class="tie-sum-author"><span class="tie-from layerUserName"><a target="_blank" href="http://t.163.com/9147152522">撸无罪</a>                                </span><span class="tie-ip">[网易四川省成都市手机网友]</span>            </span><span class="tie-postTime">2014-08-07 14:48:47</span>
                                                    <div class="tie-body js-body">
                                                        <div class="tie-commentBox layerBgcolor">
                                                            <div class="tie-commentBox layerBgcolor">
                                                                <div class="tie-commentInfo"><span class="tie-sum-author layerUserName">网易广东省深圳市网友 [西江风暴] 的原贴：</span>                    <span class="tie-floorCount">1</span>                </div>
                                                                <p class="tie-content layerFontColor">假又怎么了，人家孩子都三头了。</p>
                                                            </div>
                                                            <p title="点击展开" nodeid="tieA32839N2" autoid="A32839N2" class="js-expand hideTips">已经隐藏重复盖楼 <span class="js-expand-span">[点击展开]</span></p>
                                                        </div>
                                                        <p class="tie-content layerFontColor">三带一</p>
                                                    </div>
                                                    <ul class="tie-operations">
                                                        <li class="support"><a class="js-ding" href="javascript://A32839N2" target="_self" rel="nofollow">顶<em class="js-ding-em">[0]</em></a></li>
                                                        <li><a nodeid="tieA32839N2" href="javascript://A32839N2" class="js-reply" target="_self" rel="nofollow">回复</a></li>
                                                        <li><a class="js-copy" href="javascript://A32839N2" target="_self" rel="nofollow">复制</a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div id="tieA327BQ3U" class="tie-reply js-tie-reply ">
                                                <div class="tie-photo">
                                                    <img width="35" height="35" alt="947821382" src="http://timge4.126.net/image?w=35&amp;h=35&amp;url=http://mimg.126.net/p/butter/1008031648/img/face_big.gif&amp;gif=1&amp;quality=85">
                                                </div>
                                                <div class="tie-inner js-tie-inner"><span class="tie-sum-author"><span class="tie-from layerUserName">947821382                                </span><span class="tie-ip">[网易四川省成都市手机网友]</span>            </span><span class="tie-postTime">2014-08-07 14:35:55</span>
                                                    <div class="tie-body js-body">
                                                        <div class="tie-oneLayer layerFontColor">我抢</div>
                                                    </div>
                                                    <ul class="tie-operations">
                                                        <li class="support"><a class="js-ding" href="javascript://A327BQ3U" target="_self" rel="nofollow">顶<em class="js-ding-em">[0]</em></a></li>
                                                        <li><a nodeid="tieA327BQ3U" href="javascript://A327BQ3U" class="js-reply" target="_self" rel="nofollow">回复</a></li>
                                                        <li><a class="js-copy" href="javascript://A327BQ3U" target="_self" rel="nofollow">复制</a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div id="tieA327AJ6E" class="tie-reply js-tie-reply ">
                                                <div class="tie-photo">
                                                    <img width="35" height="35" alt="1324079373" src="http://timge4.126.net/image?w=35&amp;h=35&amp;url=http://mimg.126.net/p/butter/1008031648/img/face_big.gif&amp;gif=1&amp;quality=85">
                                                </div>
                                                <div class="tie-inner js-tie-inner"><span class="tie-sum-author"><span class="tie-from layerUserName">1324079373                                </span><span class="tie-ip">[网易江西省南昌市手机网友]</span>            </span><span class="tie-postTime">2014-08-07 14:35:10</span>
                                                    <div class="tie-body js-body">
                                                        <div class="tie-commentBox layerBgcolor">
                                                            <div class="tie-commentBox layerBgcolor">
                                                                <div class="tie-commentInfo"><span class="tie-sum-author layerUserName">网易广东省深圳市网友 [西江风暴] 的原贴：</span>                    <span class="tie-floorCount">1</span>                </div>
                                                                <p class="tie-content layerFontColor">假又怎么了，人家孩子都三头了。</p>
                                                            </div>
                                                            <p title="点击展开" nodeid="tieA327AJ6E" autoid="A327AJ6E" class="js-expand hideTips">已经隐藏重复盖楼 <span class="js-expand-span">[点击展开]</span></p>
                                                        </div>
                                                        <p class="tie-content layerFontColor">春天…</p>
                                                    </div>
                                                    <ul class="tie-operations">
                                                        <li class="support"><a class="js-ding" href="javascript://A327AJ6E" target="_self" rel="nofollow">顶<em class="js-ding-em">[0]</em></a></li>
                                                        <li><a nodeid="tieA327AJ6E" href="javascript://A327AJ6E" class="js-reply" target="_self" rel="nofollow">回复</a></li>
                                                        <li><a class="js-copy" href="javascript://A327AJ6E" target="_self" rel="nofollow">复制</a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div id="tieA3276CUV" class="tie-reply js-tie-reply ">
                                                <div class="tie-photo">
                                                    <img width="35" height="35" alt="1324079373" src="http://timge4.126.net/image?w=35&amp;h=35&amp;url=http://mimg.126.net/p/butter/1008031648/img/face_big.gif&amp;gif=1&amp;quality=85">
                                                </div>
                                                <div class="tie-inner js-tie-inner"><span class="tie-sum-author"><span class="tie-from layerUserName">1324079373                                </span><span class="tie-ip">[网易江西省南昌市手机网友]</span>            </span><span class="tie-postTime">2014-08-07 14:32:53</span>
                                                    <div class="tie-body js-body">
                                                        <div class="tie-commentBox layerBgcolor">
                                                            <div class="tie-commentBox layerBgcolor">
                                                                <div class="tie-commentInfo"><span class="tie-sum-author layerUserName">网易广东省汕尾市网友(58.254.*.*)的原贴：</span>                    <span class="tie-floorCount">1</span>                </div>
                                                                <p class="tie-content layerFontColor">2015年全天下全部人80亿人都要干的事（禁止火葬 销毁火葬工具 打烂火葬工具 广修宫殿与陵园（陵墓）占领全国80%（全国10万个建筑物就一定要有8万个宫殿与陵园（陵墓）的比例）谁建设的最多的就是英雄<br>
                                                                    三大主义（三大建设）<br>
                                                                    （帝王亲笔所写 价值2亿元一本 ）每人分10本<br>
                                                                    全部人往三大主义路线去走 不往三大主义路线走的人 未来会死无全尸(价值2亿元一本的书 全天下全部人每人赠送分走10本）(按照三大主义路线走的人能平安度过一生）<br>
                                                                    三大主义（到处建设大量陵园（陵墓）和大量宫殿）<br>
                                                                    第一 向人民征收地皮钱 每人交5万地皮钱 就把地皮租卖给你们 全部人交完400万亿<br>
                                                                    <br>
                                                                    <br>
                                                                    第二 人类最后要做的事和最后的归宿（就是花8成的钱8成全部人力修建陵园和宫殿） 用来自己死后把自己的遗体放进去 谁都有死的一天要提早进行） 全天下的人都找个最好的风水宝地帮机王修建 现代版的秦始皇陵墓(重点是要找个100年以上和无限时间没人的地区和没人打搅的地区修建 避免有人搞到遗体 还要有人守陵墓不给别人进入等~~~) 鸟语花香 在山上建造6星级规模宾馆陵园 在山里建造地下宫殿 里面有房子有空调 花草树木 四面是水 中间是棺材 棺材里放着机王的遗体 到处有石头做的士兵保护（机王死后遗体就住进去 就不火葬了） 和 宫殿 宫女文武百官左右站立 保护机王的安全 招聘5亿名护法兵 穿黑色铁甲 左手拿太阳旗 右手拿武器 每2米站一个 站满一个城市<br>
                                                                    陵园 陵墓设计图（欢迎大家按照这样子去建设）到广州的山里建设这样子的陵墓 占地无限时间 无限时间无人区无人进入 无人碰到和损坏遗体<br>
                                                                    <br>
                                                                    <br>
                                                                    宫殿设计图（按照豪华皇宫的规模建造 中间修建 水池用来洗澡用的（玉露池） 在四角建造办公房和睡房） 后方椅子 椅子后面两个拿扇子的宫女<br>
                                                                    人死后还有一半知觉 火葬就是下地狱（大家跟我喊打死都不火葬）<br>
                                                                    <br>
                                                                    <br>
                                                                    第三 广告思想 全部人都是我的广告员 帮我做广告 统一了我的思想(电脑网络的统一 全部人都要先经过我的网站才能进入电脑和手机）</p>
                                                            </div>
                                                            <p title="点击展开" nodeid="tieA3276CUV" autoid="A3276CUV" class="js-expand hideTips">已经隐藏重复盖楼 <span class="js-expand-span">[点击展开]</span></p>
                                                        </div>
                                                        <p class="tie-content layerFontColor">老子看都懒得看完…</p>
                                                    </div>
                                                    <ul class="tie-operations">
                                                        <li class="support"><a class="js-ding" href="javascript://A3276CUV" target="_self" rel="nofollow">顶<em class="js-ding-em">[0]</em></a></li>
                                                        <li><a nodeid="tieA3276CUV" href="javascript://A3276CUV" class="js-reply" target="_self" rel="nofollow">回复</a></li>
                                                        <li><a class="js-copy" href="javascript://A3276CUV" target="_self" rel="nofollow">复制</a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div id="tieA326EIV0" class="tie-reply js-tie-reply tie-last">
                                                <div class="tie-photo">
                                                    <img width="35" height="35" alt="m185****2873" src="http://timge4.126.net/image?w=35&amp;h=35&amp;url=http://mimg.126.net/p/butter/1008031648/img/face_big.gif&amp;gif=1&amp;quality=85">
                                                </div>
                                                <div class="tie-inner js-tie-inner"><span class="tie-sum-author"><span class="tie-from layerUserName">m185****2873                                </span><span class="tie-ip">[网易福建省厦门市手机网友]</span>            </span><span class="tie-postTime">2014-08-07 14:19:52</span>
                                                    <div class="tie-body js-body">
                                                        <div class="tie-frontOfFloor layerBgcolor">
                                                            <div class="tie-floorInner"><span class="tie-floor-author layerUserName">网易吉林省手机网友(221.9.*.*)的原贴：</span>                <span class="tie-floor-index">1</span>            </div>
                                                            <p class="tie-floor-content layerFontColor">李白太神了，他早就知道贝嫂隆胸了！不信你们看他留下的藏头诗！<br>
                                                                <br>
                                                                《隆》<br>
                                                                贝克汉姆来踢球<br>
                                                                嫂子一旁在加油<br>
                                                                假日他俩啪啪啪<br>
                                                                胸口碎大石啊呀。<br>
                                                                <br>
                                                                太神了！李白真神！</p>
                                                        </div>
                                                        <p class="tie-floor-content layerFontColor">煞笔</p>
                                                    </div>
                                                    <ul class="tie-operations">
                                                        <li class="support"><a class="js-ding" href="javascript://A326EIV0" target="_self" rel="nofollow">顶<em class="js-ding-em">[0]</em></a></li>
                                                        <li><a nodeid="tieA326EIV0" href="javascript://A326EIV0" class="js-reply" target="_self" rel="nofollow">回复</a></li>
                                                        <li><a class="js-copy" href="javascript://A326EIV0" target="_self" rel="nofollow">复制</a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <a target="_blank" href="http://comment.ent.163.com/ent2_bbs/A2U8QTTC00031H2L.html#articlejiannewscomment" class="js-tiemore tie-more">查看全部跟贴<em>&gt;&gt;</em></a></div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <div id="epMask" class="epmask"></div>
            </div>
        </div>
    </form>
</asp:Content>
