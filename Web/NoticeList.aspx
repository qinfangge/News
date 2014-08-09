<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NoticeList.aspx.cs" Inherits="CMS.Web.NoticeList" %>

<%@ Register Src="Controls/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register Src="Controls/CategoryControl.ascx" TagName="CategoryControl" TagPrefix="uc2" %>
<%@ Register Src="Controls/CurrentPosition.ascx" TagName="CurrentPosition" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    <link href="/css/base/pager.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .pagenav {
            margin-top: 10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">

    <div class="left_sidbar">
        <uc3:CurrentPosition ID="CurrentPosition1" runat="server" ArticleTableName="Notice" />

        <div class="top15 news_list01">
            <ul>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>

                        <li>
                            <a target="_blank" href="NoticeDetail.aspx?id=<%#Eval("id") %>"><%#Eval("title") %></a>
                            <span><%# ((DateTime)Eval("addTime")).ToString("yyyy-MM-dd") %></span>
                        </li>
                    </ItemTemplate>

                    <FooterTemplate>

                        <asp:Label ID="lblEmpty" Text="<li class='emptyData'>数据正在添加中...</li>" runat="server" Visible='<%#bool.Parse((Repeater1.Items.Count==0).ToString())%>'></asp:Label>

                    </FooterTemplate>


                </asp:Repeater>

            </ul>
        </div>
        <uc1:Pager ID="Pager1" PageSize="1" runat="server" />
    </div>

    <div class="right_sidbar">
        <uc2:CategoryControl ID="CategoryControl1" runat="server" ParentId="35" ArticleTableName="Notice" />
    </div>

    
</asp:Content>
