<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CMS.Web.Home.Default" %>

<%@ Import Namespace="tk.tingyuxuan.utils" %>
<%@ Register Src="/Controls/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    <link href="/css/base/pager.css" rel="stylesheet" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    

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
                                            <p>推荐于：<span class="time"><%#Eval("addTime") %></span></p>
                                        </div>
                                        <div class="my-commend-body">
                                            <div class="figure">
                                                <span runat="server" visible='<%#Eval("titleImage")!=""%>'>
                                                      <a  title="<%#Eval("title") %>" target="_blank" href="/Detail.aspx?id=<%#Eval("id") %>">
                                                    
                                                   <img class="figure-img"  alt="<%#HtmlHelper.SubStr(Eval("title").ToString(),16,false) %>" src="<%#ImageUtils.GetThumbImagePath(Eval("titleImage").ToString(),132,100,1) %>">

                                                </a>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><div class="figcaption">
                                                    <h2>
                                                        <a title="<%#Eval("title") %>" target="_blank" href="/Detail.aspx?id=<%#Eval("id") %>"><%#Eval("title") %></a>
                                                    </h2>
                                                    <p class="caption">
                                                        <%#HtmlHelper.SubStr(Eval("content").ToString(),109,true) %>
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
