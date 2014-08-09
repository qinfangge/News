<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CMS.Web.Default" %>
<%@ Import Namespace="tk.tingyuxuan.utils" %>
<%@ Register Src="Controls/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    <link href="css/base/pager.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div style="top: auto;" class="rightbar">
        <div class="rightbar-caption">
            <div class="weather" id="weather">
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
                <form autocomplete="off">
                    <div class="ntes-loginframe-tips"></div>
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
                    <div class="form-group">
                        <span class="third">第三方登录</span>
                        <a href="javascript:openWin('/oauth/login?type=SINA')" target="_self" class="weibo" title="新浪微博登录"></a>
                        <!--<a href="javascript:openWin('/oauth/login?type=SINA')" target="_self" class="qzone"></a>-->
                        <a href="javascript:openWin('/oauth/login?type=YIXIN')" target="_self" class="yixin" title="易信登录"></a>
                    </div>
                </form>
                <div class="user-main" style="display: none;">
                    <a href="" class="avatar"></a>
                    <div class="user-name">
                        <a href="">--</a>
                    </div>
                    <div class="badge-group">
                        <a href="" class="reason">
                            <span id="recNum">0</span>
                            推荐&nbsp;
                    <span id="shareNum">0</span>
                            分享
                        </a>
                    </div>
                </div>
            </div>
        </div>
        <div class="ranking-list">
            <ul class="nav-list">
                <li>
                    <a class="item">今日热点新闻</a>
                </li>
            </ul>
            <div>
                <div class="item-wrapper active">
                    <ul id="ranking-wrapper">
                        <li class="item-top3">
                            <span class="num num-red">1</span>
                            <div class="name">
                                <a docid="A30RVQ4L00014SEH" href="http://j.news.163.com/docs/99/2014080701/A30RVQ4L00014SEH.html" srctype="106">房价下跌银行“被房东” 苏杭惊现“弃房断供”</a>
                            </div>
                        </li>
                        <li class="item-top3">
                            <span class="num num-red">2</span>
                            <div class="name">
                                <a docid="A2VORD6N9001RD6O" href="http://j.news.163.com/docs/10/2014080614/A2VORD6N9001RD6O.html" srctype="106">北影校花景甜后台到底有多硬？一起来扒女明星背景</a>
                            </div>
                        </li>
                        <li class="item-top3">
                            <span class="num num-red">3</span>
                            <div class="name">
                                <a docid="A300RQQ39001RQQ4" href="http://j.news.163.com/docs/10/2014080617/A300RQQ39001RQQ4.html" srctype="106">致命！饿的时候千万别吃10种食品</a>
                            </div>
                        </li>
                        <li class="">
                            <span class="num ">4</span>
                            <div class="name">
                                <a docid="A31D4J9500014AED" href="http://j.news.163.com/docs/1/2014080706/A31D4J9500014AED.html" srctype="106">东莞女模特半夜回家小巷内被施暴 警方调查(图)</a>
                            </div>
                        </li>
                        <li class="">
                            <span class="num ">5</span>
                            <div class="name">
                                <a docid="A30R5VOQ90015VOR" href="http://j.news.163.com/docs/99/2014080702/A30R5VOQ90015VOR.html" srctype="106">61岁钟镇涛再当新郎 婚前验精证实力在</a>
                            </div>
                        </li>
                        <li class="">
                            <span class="num ">6</span>
                            <div class="name">
                                <a docid="A2VBGPE100031H2L" href="http://j.news.163.com/docs/2/2014080611/A2VBGPE100031H2L.html" srctype="106">疑似比伯女友赛琳娜裸照流出 露胸半裸</a>
                            </div>
                        </li>
                        <li class="">
                            <span class="num ">7</span>
                            <div class="name">
                                <a docid="A2VVNAC59001NAC6" href="http://j.news.163.com/docs/2/2014080617/A2VVNAC59001NAC6.html" srctype="106">王珞丹晒自拍裙子拉链没拉  网友犀利调侃不忍直视</a>
                            </div>
                        </li>
                        <li class="">
                            <span class="num ">8</span>
                            <div class="name">
                                <a docid="A31EKNOO9001KNOP" href="http://j.news.163.com/docs/10/2014080707/A31EKNOO9001KNOP.html" srctype="106">网曝郑州小三被扒光衣服</a>
                            </div>
                        </li>
                        <li class="">
                            <span class="num ">9</span>
                            <div class="name">
                                <a docid="A30G85IM00031H2L" href="http://j.news.163.com/docs/2/2014080622/A30G85IM00031H2L.html" srctype="106">《色戒》王佳芝原型照片曝光 汤唯果真神还原</a>
                            </div>
                        </li>
                        <li class="">
                            <span class="num ">10</span>
                            <div class="name">
                                <a docid="A30QFHME00032KMI" href="http://j.news.163.com/docs/99/2014080701/A30QFHME00032KMI.html" srctype="106">林建名女儿爆父拥二百名性伴 不知父吃壮阳药</a>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="ne-login-bg"></div>
        <div class="recent-hd">
            大家刚刚推荐
        </div>
        <div class="recent-item-list">
            <div style="top: -186px;" class="recent-item-list-wrapper">
                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a href="http://j.news.163.com/#detail/99/A300RTAB9001RTAC" data-url="/docs/8/2014080617/A300RTAB9001RTAC.html" docid="A300RTAB9001RTAC" srctype="107" class="recent-title">从小训练孩子攀岩</a>
                        <label>[<a class="nickname" href="http://j.news.163.com/profile/zouxm1984/">天戟沧雄</a>]推荐</label>
                    </div>
                </div>

                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a href="http://j.news.163.com/#detail/99/A2VS980K9001980L" data-url="/docs/99/2014080616/A2VS980K9001980L.html" docid="A2VS980K9001980L" srctype="107" class="recent-title">iPhone 6真机组图现身Twitter：这次真不是机模</a>
                        <label>[<a class="nickname" href="http://j.news.163.com/profile/chinnoaaron/">chinnoaaron</a>]推荐</label>
                    </div>
                </div>

                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a href="http://j.news.163.com/#detail/99/A31MLBMP9001LBMQ" data-url="/docs/8/2014080700/A31MLBMP9001LBMQ.html" docid="A31MLBMP9001LBMQ" srctype="107" class="recent-title">我去，从罚球线起跳啊！</a>
                        <label>[<a class="nickname" href="http://j.news.163.com/profile/t_macs@126.com/">流浪的球鞋</a>]推荐</label>
                    </div>
                </div>

                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a href="http://j.news.163.com/#detail/99/A31I2I2R90012I2S" data-url="/docs/8/2014080708/A31I2I2R90012I2S.html" docid="A31I2I2R90012I2S" srctype="107" class="recent-title">照着这发型剪</a>
                        <label>[<a class="nickname" href="http://j.news.163.com/profile/rfwlli/">rfwlli</a>]推荐</label>
                    </div>
                </div>

                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a href="http://j.news.163.com/#detail/99/A31EKNOO9001KNOP" data-url="/docs/10/2014080707/A31EKNOO9001KNOP.html" docid="A31EKNOO9001KNOP" srctype="107" class="recent-title">网曝郑州小三被扒光衣服</a>
                        <label>[<a class="nickname" href="http://j.news.163.com/profile/zjflbx/">乃们的丰兄</a>]推荐</label>
                    </div>
                </div>

                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a href="http://j.news.163.com/#detail/99/A30MVQ7Q0011179O" data-url="http://mobile.163.com/14/0807/00/A30MVQ7Q0011179O.html" docid="A30MVQ7Q0011179O" srctype="107" class="recent-title">Note 4亮点全解析：三面屏幕配竹制后盖</a>
                        <label>[<a class="nickname" href="http://j.news.163.com/profile/me0mj/">就是我me0mj</a>]推荐</label>
                    </div>
                </div>

                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a href="http://j.news.163.com/#detail/99/A31Q36M0900136M1" data-url="/docs/6/2014080710/A31Q36M0900136M1.html" docid="A31Q36M0900136M1" srctype="107" class="recent-title">奔驰全新防弹车型S Guard 可抗机枪子弹!</a>
                        <label>[<a class="nickname" href="http://j.news.163.com/profile/linyanri/">216587773</a>]推荐</label>
                    </div>
                </div>

                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a href="http://j.news.163.com/#detail/99/A324CDNJ9001CDNK" data-url="/docs/2/2014080712/A324CDNJ9001CDNK.html" docid="A324CDNJ9001CDNK" srctype="107" class="recent-title">《爸爸去哪儿》杨阳洋是不合群？还是更有独立性？</a>
                        <label>[<a class="nickname" href="http://j.news.163.com/profile/yrx333/">Kiki16110193</a>]推荐</label>
                    </div>
                </div>

                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a href="http://j.news.163.com/#detail/99/A31KBVU49001BVU5" data-url="/docs/1/2014080708/A31KBVU49001BVU5.html" docid="A31KBVU49001BVU5" srctype="107" class="recent-title">男孩烈日下摆茶摊为救灾人员送水解渴</a>
                        <label>[<a class="nickname" href="http://j.news.163.com/profile/lfj888@126.com/">lfj888126</a>]推荐</label>
                    </div>
                </div>

                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a href="http://j.news.163.com/#detail/99/A30A0N9E90010N9F" data-url="/docs/99/2014080619/A30A0N9E90010N9F.html" docid="A30A0N9E90010N9F" srctype="107" class="recent-title">十分罕见：17张有些诡异的老照片</a>
                        <label>[<a class="nickname" href="http://j.news.163.com/profile/yangm516/">yangm516</a>]推荐</label>
                    </div>
                </div>

                <!--
            <div class="recent-item ">
		        <i></i>
		        <div class="recent-detail">
		            <a href="http://news.163.com/14/0318/11/9NK78O4300011229.html" docid="6597268778261368654">起底东莞"丐帮"：帮主为利润砸断幼童腿喂安眠药</a>
		            <label>[绡罗]推荐</label>
		        </div>
		    </div>
			-->
            </div>
        </div>
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

                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<h2>
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
                                </a><a data-action="share" class="btn-share">
                                    <i class="btn-card"></i>
                                    <span class="btn-over">
                                        <span class="lnk-share lnk-share-yixin" title="分享到易信" data-action="share"></span><span class="lnk-share lnk-share-sina" title="分享到新浪微博" data-action="share"></span>
                                    </span>
                                </a>
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
