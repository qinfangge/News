<%@ Page Title="搜索结果" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="CMS.Web.Search" %>

<%@ Register Src="Controls/CurrentPosition.ascx" TagName="CurrentPosition" TagPrefix="uc1" %>
<%@ Register Src="Controls/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    <style>
        .left_sidbar {
            float: none;
            width: auto;
        }
        .hightLight {
            font-weight:bold;
            color:#ff6a00;
        }
    </style>
    <link href="/css/base/pager.css" type="text/css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <div class="left_sidbar">

        <div class="location news_lc">
            您当前的位置是：<a href="/">首页</a> &gt;&gt; 搜索结果
        </div>

        <div class="top15 news_list01">
            <ul>


                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <li>
                            <a target="_blank" href="<%#Eval("page") %>Detail.aspx?id=<%#Eval("id") %>"><%# tk.tingyuxuan.utils.HtmlHelper.HightLight(Eval("title").ToString(),keyWords,"hightLight") %></a>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblEmpty" Text="<li class='emptyData'>找不到搜索结果！</li>" runat="server" Visible='<%#bool.Parse((Repeater1.Items.Count==0).ToString())%>'></asp:Label>

                    </FooterTemplate>

                </asp:Repeater>
            </ul>
        </div>
        <uc1:Pager ID="Pager1" PageSize="1" runat="server" />

    </div>


</asp:Content>
