<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CMS.Web.Default" %>
<%@ Import Namespace="tk.tingyuxuan.utils" %>
<%@ Register Src="Controls/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<%@ Register src="Controls/NewsModel.ascx" tagname="NewsModel" tagprefix="uc2" %>

<%@ Register src="Controls/NewRecommendModel.ascx" tagname="NewRecommendModel" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    <link href="css/base/pager.css" rel="stylesheet"/>
    <script type="text/javascript">

        $(document).ready(function () {

            $(".loginOut").click(function () {
                var url = "/ashx/User.ashx";
                var data = { a: "out" };
                $.post(url, data, function (data) {
                    if (data == "1") {
                        window.location.reload();
                    } else {
                        window.location.reload();
                    }
                });
            });
            $(".btn-submit").click(function () {
                var url = "/ashx/User.ashx";
                var userName = $.trim($("input[name=password]").val());
                var password = $.trim($("input[name=password]").val());

                var data = { userName: userName, password: password, a: "in" };
                $.post(url, data, function (data) {
                    if (data == "1") {
                        window.location.reload();
                    } else {
                        $(".ntes-loginframe-tips").css("top","9px").text("用户名或密码错误！").show();
                       // d.content("网络繁忙，请稍后重试！").show();
                    }
                });

                return false;
            });


        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div style="top: auto;" class="rightbar">
        <div class="rightbar-caption">
            <div class="weather" id="weather">
                
                <iframe name="weather_inc" src="http://cache.xixik.com.cn/11/shanghai/" width="200" height="15" frameborder="0" marginwidth="0" marginheight="0" scrolling="no" ></iframe>
                <div class="clearfix">
                    <a href="#" class="city">上海</a>
                    <div class="weather-bg weather-1">
                        <span class="weather-name">多云</span>

                        <div class="weather-staus">
                            <span title="26~34度" class="weather-deg">26~34<label>°</label></span>
                        </div>
                    </div>
                    <div class="mode-switch mode-switch2" id="mode-switch">
                        <a href="#list" target="_self" class="mode-list" title="列表式浏览"></a>
                        <a href="#card" target="_self" class="mode-card" title="卡片式浏览"></a>
                    </div>
                </div>
                <div class="weather-citylist-wrap weather-citylist-wrap2" style="display: none;">
                    <div class="weather-cityaz"><a href="javascript:" class="weather-az-active">热门</a><a href="javascript:">A</a><a href="javascript:">B</a><a href="javascript:">C</a><a href="javascript:">D</a><a href="javascript:">E</a><a href="javascript:">F</a><a href="javascript:">G</a><a href="javascript:">H</a><a href="javascript:">J</a><a href="javascript:">K</a><a href="javascript:">L</a><a href="javascript:">M</a><a href="javascript:">N</a><a href="javascript:">P</a><a href="javascript:">Q</a><a href="javascript:">R</a><a href="javascript:">S</a><a href="javascript:">T</a><a href="javascript:">W</a><a href="javascript:">X</a><a href="javascript:">Y</a><a href="javascript:">Z</a></div>
                    <div class="weather-citylist"><a href="javascript:" code="101010100">北京</a><a href="javascript:" code="101020100">上海</a><a href="javascript:" code="101290101">昆明</a><a href="javascript:" code="101210101">杭州</a><a href="javascript:" code="101280101">广州</a><a href="javascript:" code="101270101">成都</a><a href="javascript:" code="101110101">西安</a><a href="javascript:" code="101190101">南京</a><a href="javascript:" code="101280601">深圳</a><a href="javascript:" code="101040100">重庆</a><a href="javascript:" code="101250101">长沙</a><a href="javascript:" code="101070101">沈阳</a><a href="javascript:" code="101230201">厦门</a><a href="javascript:" code="101200101">武汉</a><a href="javascript:" code="101310101">海口</a><a href="javascript:" code="101130101">乌鲁木齐</a><a href="javascript:" code="101120201">青岛</a><a href="javascript:" code="101070201">大连</a><a href="javascript:" code="101050101">哈尔滨</a><a href="javascript:" code="101310201">三亚</a><a href="javascript:" code="101060101">长春</a><a href="javascript:" code="101300101">南宁</a><a href="javascript:" code="101260101">贵阳</a><a href="javascript:" code="101230101">福州</a><a href="javascript:" code="101180101">郑州</a><a href="javascript:" code="101120101">济南</a><a href="javascript:" code="101300501">桂林</a><a href="javascript:" code="101030100">天津</a><a href="javascript:" code="101100101">太原</a><a href="javascript:" code="101240101">南昌</a><a href="javascript:" code="101140101">拉萨</a><a href="javascript:" code="101150101">西宁</a><a href="javascript:" code="101340101">台北</a></div>
                </div>
            </div>
            <div class="user-info" id="user-rightbar-login">
              <%--  <form autocomplete="off">--%><asp:Panel ID="LoginPanel" runat="server">
                    <div class="ntes-loginframe-tips">用户名密码错误！</div>
                    <div class="form-group">
                        <input value="zhongpaiwang@126.com" name="username" placeholder="封丘通行证/邮箱登陆" type="text">
                    </div>
                    <div class="form-group">
                        <input name="password" placeholder="密码" type="password">
                    </div>
                    <div class="form-group" style="display: none;">
                        <input name="autologin" class="ntes-loginframe-checkbox" type="checkbox">
                    </div>
                    <div class="form-group">
                        <button type="button" name="login" class="btn-submit">登录</button>

                        <div class="badge-group">
                            <a href="Regist.aspx" class="regist">注册</a>
                            <a href="Reset.aspx">找回密码</a>
                        </div>
                    </div>
                    <%--<div class="form-group">
                        <span class="third">第三方登录</span>
                        <a href="javascript:openWin('/oauth/login?type=SINA')" target="_self" class="weibo" title="新浪微博登录"></a>
                        <!--<a href="javascript:openWin('/oauth/login?type=SINA')" target="_self" class="qzone"></a>-->
                        <a href="javascript:openWin('/oauth/login?type=YIXIN')" target="_self" class="yixin" title="易信登录"></a>
                    </div>--%>
                  </asp:Panel>
                <%--</form>--%>
                <asp:Panel ID="LoginInPanel" runat="server">
               
                <div class="user-main" >
                    <a href="/Home/" class="avatar">

                         <asp:Image  ID="Avatar" ImageUrl="~/Images/noAvatar.jpg" runat="server" />
                    </a>
                    <div class="user-name">
                        <a href="/Home/"><%=user.userName %></a>
                    </div>
                    <div class="badge-group">
                        <a href="/Home/" class="reason">
                            <span id="recNum"><asp:Literal ID="DigCount" runat="server">20</asp:Literal></span>
                            推荐&nbsp;
                            </a> |
                         <a href="javascript:void(0)" class="reason loginOut">
                    
                            退出
                        </a>
                    </div>
                </div>

                     </asp:Panel>
            </div>
        </div>
        
        <uc2:NewsModel ID="NewsModel1" NewsModelName="今日热点" runat="server" />
        <div class="ne-login-bg"></div>
        <uc3:NewRecommendModel ID="NewRecommendModel1" runat="server" />
      
    </div>

    <div style="top: 105px;" class="commend-listwrap">
        <div style="min-height: 2110px;" class="mainarea clearfix">
            <div style="padding-top: 62px;" class="waterfall clearfix waterfall1" id="news-list">
                <asp:Repeater ID="NewsRepeater" runat="server" OnItemCommand="NewsRepeater_ItemCommand1">
                    <ItemTemplate>

                        <div style="display: inline-block;" class="card  <%#Eval("titleImage")!=""?"card-pic":"card-nopic"%> card-visible ">
                            <i class="card-flag card-flag-1"></i>
                            <div class="cardtitle pictitle">

                                <span class="bigpic" runat="server" visible='<%#Eval("titleImage")!=""%>'><a title="<%#Eval("title") %>" target="_blank" href="Detail.aspx?id=<%#Eval("id") %>">

                                    <i style="height: 200px"></i>
                                    <img alt="<%#HtmlHelper.SubStr(Eval("title").ToString(),16,false) %>" src="<%#ImageUtils.GetThumbImagePath(Eval("titleImage").ToString(),132,100,1) %>">
                                </a></span>

                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<h2>
                                    <a title="<%#Eval("title") %>" target="_blank" href="Detail.aspx?id=<%#Eval("id") %>">
                                        <div class="title-mask"></div>
                                        <span><%#Eval("title") %></span>
                                    </a>
                                </h2>
                            </div>
                            <div class="abstract">
                                <p><%#HtmlHelper.SubStr(Eval("content").ToString(),109,true) %></p>
                            </div>
                            <div class="intera" docid="A31NPSIG9001PSIH">
                                <a class="btn-close" data-hint="不感兴趣" data-action="not_like"></a>
                                <a class="btn-commend" data-action="ding" title="推荐">
                                    <i class="btn-card"></i>
                                    <span class="btn-count">1</span>
                                </a><a class="newcommend" title="跟贴评论" href="http://comment.news.163.com/comment_bbs/A31NPSIG9001PSIH.html#mainjnewscomment">
                                    <i class="btn-card"></i>
                                    <span class="tiecount">1</span>
                                </a>
                               <%-- <a data-action="share" class="btn-share">
                                    <i class="btn-card"></i>
                                    <span class="btn-over">
                                        <span class="lnk-share lnk-share-yixin" title="分享到易信" data-action="share"></span><span class="lnk-share lnk-share-sina" title="分享到新浪微博" data-action="share"></span>
                                    </span>
                                </a>--%>
                            </div>
                        </div>
                    </ItemTemplate>

                    <FooterTemplate>

                        <asp:Label ID="lblEmpty" runat="server" Visible='<%#bool.Parse((NewsRepeater.Items.Count==0).ToString())%>'>

                            <div class='emptyData'>
                                
                                <h1>暂无数据...</h1>
                                
                                <a href="#"><img width="100px" src="/images/tougao.jpg" /></a>

                            </div>

                        </asp:Label>

                    </FooterTemplate>

                </asp:Repeater>

                <uc1:Pager ID="Pager1" PageSize="2" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
