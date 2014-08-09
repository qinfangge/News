<%@ Page Title="" Language="C#" MasterPageFile="Home.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CMS.Web.Home.Default" %>

<%@ Import Namespace="tk.tingyuxuan.utils" %>
<%@ Register Src="/Controls/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    <link href="/css/base/pager.css" rel="stylesheet" />
    <link href="http://img1.cache.netease.com/f2e/news/commend/collect/head~yzRBYNNdHlGv.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="rightbar">
        <div class="rightbar-caption">
            <div id="weather" class="weather">
                <div class="clearfix">
                    <a class="city" href="#">上海</a>
                    <div class="weather-bg weather-3">
                        <span class="weather-name">阵雨</span>

                        <div class="weather-staus">
                            <span class="weather-deg" title="25~28度">25~28<label>°</label></span>
                        </div>
                    </div>
                    <div id="mode-switch" class="mode-switch">
                        <a title="列表式浏览" class="mode-list" target="_self" href="#list"></a>
                        <a title="卡片式浏览" class="mode-card" target="_self" href="#card"></a>
                    </div>
                </div>
                <div style="display: none;" class="weather-citylist-wrap weather-citylist-wrap2">
                    <div class="weather-cityaz"><a class="weather-az-active" href="javascript:">热门</a><a href="javascript:">A</a><a href="javascript:">B</a><a href="javascript:">C</a><a href="javascript:">D</a><a href="javascript:">E</a><a href="javascript:">F</a><a href="javascript:">G</a><a href="javascript:">H</a><a href="javascript:">J</a><a href="javascript:">K</a><a href="javascript:">L</a><a href="javascript:">M</a><a href="javascript:">N</a><a href="javascript:">P</a><a href="javascript:">Q</a><a href="javascript:">R</a><a href="javascript:">S</a><a href="javascript:">T</a><a href="javascript:">W</a><a href="javascript:">X</a><a href="javascript:">Y</a><a href="javascript:">Z</a></div>
                    <div class="weather-citylist"><a code="101010100" href="javascript:">北京</a><a code="101020100" href="javascript:">上海</a><a code="101290101" href="javascript:">昆明</a><a code="101210101" href="javascript:">杭州</a><a code="101280101" href="javascript:">广州</a><a code="101270101" href="javascript:">成都</a><a code="101110101" href="javascript:">西安</a><a code="101190101" href="javascript:">南京</a><a code="101280601" href="javascript:">深圳</a><a code="101040100" href="javascript:">重庆</a><a code="101250101" href="javascript:">长沙</a><a code="101070101" href="javascript:">沈阳</a><a code="101230201" href="javascript:">厦门</a><a code="101200101" href="javascript:">武汉</a><a code="101310101" href="javascript:">海口</a><a code="101130101" href="javascript:">乌鲁木齐</a><a code="101120201" href="javascript:">青岛</a><a code="101070201" href="javascript:">大连</a><a code="101050101" href="javascript:">哈尔滨</a><a code="101310201" href="javascript:">三亚</a><a code="101060101" href="javascript:">长春</a><a code="101300101" href="javascript:">南宁</a><a code="101260101" href="javascript:">贵阳</a><a code="101230101" href="javascript:">福州</a><a code="101180101" href="javascript:">郑州</a><a code="101120101" href="javascript:">济南</a><a code="101300501" href="javascript:">桂林</a><a code="101030100" href="javascript:">天津</a><a code="101100101" href="javascript:">太原</a><a code="101240101" href="javascript:">南昌</a><a code="101140101" href="javascript:">拉萨</a><a code="101150101" href="javascript:">西宁</a><a code="101340101" href="javascript:">台北</a></div>
                </div>
            </div>
            <div id="user-rightbar-profile" class="user-info">
                <div class="user-main">
                    <a class="avatar" href="/profile/fqmhw@qq.com/">
                        <img width="132" src="http://s.cimg.163.com/i/126.fm%2F4Daxkj.132x1000.auto.jpg">
                    </a>
                    <div class="user-name">
                        <a href="/profile/fqmhw@qq.com/">封丘门户网</a>
                    </div>
                    <div class="badge-group">
                        <a class="reason" href="/profile/fqmhw@qq.com/#loginshare">
                            <span id="recNum">4</span>
                            推荐&nbsp;
                   
                            <span id="shareNum">2</span>
                            分享</a>
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
                                <a srctype="106" href="http://j.news.163.com/docs/10/2014080816/A34VOB0S0001124J.html" docid="A34VOB0S0001124J">武汉一辆满载乘客长途汽车遭劫持 司机浑身血</a>
                            </div>
                        </li>
                        <li class="item-top3">
                            <span class="num num-red">2</span>
                            <div class="name">
                                <a srctype="106" href="http://j.news.163.com/docs/10/2014080815/A34UPJKR9001PJKS.html" docid="A34UPJKR9001PJKS">千万注意：厨师下馆子不点的3样菜 都可能致癌！</a>
                            </div>
                        </li>
                        <li class="item-top3">
                            <span class="num num-red">3</span>
                            <div class="name">
                                <a srctype="106" href="http://j.news.163.com/docs/99/2014080900/A35V0HAO90010HAP.html" docid="A35V0HAO90010HAP">穿帮镜头大集合 搞笑趣图让你哭笑不得【图】</a>
                            </div>
                        </li>
                        <li class="">
                            <span class="num ">4</span>
                            <div class="name">
                                <a srctype="106" href="http://j.news.163.com/docs/99/2014080900/A35SNCAK9001NCAL.html" docid="A35SNCAK9001NCAL">李小璐整容失败巩俐胸部下垂 女星装嫩大出丑</a>
                            </div>
                        </li>
                        <li class="">
                            <span class="num ">5</span>
                            <div class="name">
                                <a srctype="106" href="http://j.news.163.com/docs/10/2014080909/A36N1HOD90011HOE.html" docid="A36N1HOD90011HOE">揭秘朝鲜卖妻 处女600万人民币一个[组图]</a>
                            </div>
                        </li>
                        <li class="">
                            <span class="num ">6</span>
                            <div class="name">
                                <a srctype="106" href="http://j.news.163.com/docs/1/2014080909/A36QFRM69001FRM7.html" docid="A36QFRM69001FRM7">男子误点黄色网页激情视频 主角竟是自己和老婆</a>
                            </div>
                        </li>
                        <li class="">
                            <span class="num ">7</span>
                            <div class="name">
                                <a srctype="106" href="http://j.news.163.com/docs/99/2014080905/A36DSK5P9001SK5Q.html" docid="A36DSK5P9001SK5Q">童星长大后长相让人震惊了！有的变美有的长残</a>
                            </div>
                        </li>
                        <li class="">
                            <span class="num ">8</span>
                            <div class="name">
                                <a srctype="106" href="http://j.news.163.com/docs/99/2014080905/A36DSK879001SK88.html" docid="A36DSK879001SK88">明星飞机上真面目：范冰冰公主病 张柏芝傲慢无礼</a>
                            </div>
                        </li>
                        <li class="">
                            <span class="num ">9</span>
                            <div class="name">
                                <a srctype="106" href="http://j.news.163.com/docs/8/2014080900/A35SNAVG9001NAVH.html" docid="A35SNAVG9001NAVH">妹子要是热，咱就脱了，这样子我很热！</a>
                            </div>
                        </li>
                        <li class="">
                            <span class="num ">10</span>
                            <div class="name">
                                <a srctype="106" href="http://j.news.163.com/docs/2/2014080818/A355OUSJ00031H2L.html" docid="A355OUSJ00031H2L">重庆女主播遇害抛尸溪沟 咽喉被挖窟窿</a>
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
            <div class="recent-item-list-wrapper" style="top: 0px;">
                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a class="recent-title" srctype="107" docid="A2VTDS8D9001DS8E" data-url="/docs/66/2014080615/A2VTDS8D9001DS8E.html" href="/#detail/99/A2VTDS8D9001DS8E">12岁学生夺日本国民美少女冠军 网友毒舌：太瘦</a>
                        <label>[<a href="/profile/iamwudy@qq.com/" class="nickname">iamwudy</a>]推荐</label>
                    </div>
                </div>
                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a class="recent-title" srctype="107" docid="A37AG2IN9001G2IO" data-url="/docs/10/2014080914/A37AG2IN9001G2IO.html" href="/#detail/99/A37AG2IN9001G2IO">韩国学者称《西游记》起源韩国 花果山也在韩国</a>
                        <label>[<a href="/profile/rxzwww/" class="nickname">快乐的小老鼠</a>]推荐</label>
                    </div>
                </div>
                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a class="recent-title" srctype="107" docid="A33TJHDJ9001JHDK" data-url="/docs/2/2014080805/A33TJHDJ9001JHDK.html" href="/#detail/99/A33TJHDJ9001JHDK">赵本山女儿豪放奢侈 明星家庭背景有权有钱</a>
                        <label>[<a href="/profile/zx1132729295/" class="nickname">zx1132729295</a>]推荐</label>
                    </div>
                </div>
                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a class="recent-title" srctype="107" docid="A364BNBM0001124J" data-url="http://news.163.com/14/0809/03/A364BNBM0001124J.html" href="/#detail/99/A364BNBM0001124J">专家：习近平反腐思路与地方任职时思考一脉相承</a>
                        <label>[<a href="/profile/yszheng@126.com/" class="nickname">yszheng40126</a>]推荐</label>
                    </div>
                </div>
                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a class="recent-title" srctype="107" docid="A37DU0TH9001U0TI" data-url="/docs/8/2014080914/A37DU0TH9001U0TI.html" href="/#detail/99/A37DU0TH9001U0TI">菇凉，我有强迫症能不这么逼我么</a>
                        <label>[<a href="/profile/fqmhw@qq.com/" class="nickname">封丘门户网</a>]推荐</label>
                    </div>
                </div>
                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a class="recent-title" srctype="107" docid="A34RBJU29001BJU3" data-url="/docs/10/2014080813/A34RBJU29001BJU3.html" href="/#detail/99/A34RBJU29001BJU3">加拿大：这是中国对加拿大一个狠狠的报复</a>
                        <label>[<a href="/profile/realcomman/" class="nickname">realcomman</a>]推荐</label>
                    </div>
                </div>
                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a class="recent-title" srctype="107" docid="A34KFRK39001FRK4" data-url="/docs/66/2014080810/A34KFRK39001FRK4.html" href="/#detail/99/A34KFRK39001FRK4">印度土豪130万 制8斤重纯金上衣 庆祝生日</a>
                        <label>[<a href="/profile/m18263905608_1/" class="nickname">m182639056081</a>]推荐</label>
                    </div>
                </div>
                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a class="recent-title" srctype="107" docid="A371B3039001B304" data-url="/docs/2/2014080910/A371B3039001B304.html" href="/#detail/99/A371B3039001B304">佟丽娅童年萌照曝光 被赞美人胚子</a>
                        <label>[<a href="/profile/wdd752750272/" class="nickname">wdd752750272</a>]推荐</label>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="commend-listwrap">
        <div class="mainarea clearfix" style="min-height: 2144px;">
            <div class="commend-mycommend">
                <div id="sync-commend-all" class="item-wrapper">
                    <ul class="my-commend-list">

                        <asp:Repeater ID="NewsRepeater" runat="server" OnItemCommand="NewsRepeater_ItemCommand1">
                            <ItemTemplate>


                                <li>
                                    <div docid="A37DTUHL9001TUHM" data-id="166182" class="my-commend-item">
                                        <span data-hint="不感兴趣" action="not_like" class="btn-close"></span>
                                        <div class="my-commend-header">
                                            <p>推荐于：<span class="time">16:17</span></p>
                                        </div>
                                        <div class="my-commend-body">
                                            <div class="figure">
                                                <span runat="server" visible='<%#Eval("titleImage")!=""%>'>
                                                      <a  title="<%#Eval("title") %>" target="_blank" href="Detail.aspx?id=<%#Eval("id") %>">
                                                    
                                                   <img class="figure-img"  alt="<%#HtmlHelper.SubStr(Eval("title").ToString(),16,false) %>" src="<%#ImageUtils.GetThumbImagePath(Eval("titleImage").ToString(),132,100,1) %>">

                                                </a>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><div class="figcaption">
                                                    <h2>
                                                        <a title="<%#Eval("title") %>" target="_blank" href="Detail.aspx?id=<%#Eval("id") %>"><%#Eval("title") %></a>
                                                    </h2>
                                                    <p class="caption">
                                                        我说你一个大老爷们欺负人家一个女孩子好意思的么？！
                                                    </p>
                                                    <div class="intera">
                                                        <a title="推荐" data-action="ding" class="btn-commend btn-disable">
                                                            <i class="btn-card btn-label"></i>
                                                            <span class="btn-count">1</span>
                                                        </a>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                                
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
                        <uc1:Pager ID="Pager1" PageSize="1" runat="server" />

                    </ul>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
