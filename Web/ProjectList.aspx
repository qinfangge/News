<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectList.aspx.cs" Inherits="CMS.Web.ProjectList" %>

<%@ Register Src="Controls/CategoryControl.ascx" TagName="CategoryControl" TagPrefix="uc2" %>
<%@ Register Src="Controls/CurrentPosition.ascx" TagName="CurrentPosition" TagPrefix="uc3" %>
<%@ Register Src="Controls/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register src="Controls/Contact.ascx" tagname="Contact" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    <style type="text/css">
        .pagenav {
            margin-top: 10px;
        }
    </style>
    <link href="/css/base/pager.css" type="text/css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <div class="left_sidbar">
        <uc3:CurrentPosition ID="CurrentPosition1" runat="server" ArticleTableName="Project" />

        <div class="news_list01">
            <table class="" width="100%" cellspacing="0" cellpadding="0" border="0" style="display: table;">
                <tbody>
                    <tr class="table_tab_bg">
                        <th width="12%" class="auto-style1">项目编号</th>
                        <th>项目名称</th>
                        <th width="12%" class="auto-style1">挂牌价格</th>
                        <th width="12%" class="auto-style1">点击率</th>
                        <th width="12%" class="auto-style1">挂牌日期</th>
                        <th width="12%" class="auto-style1">截止日期</th>
                    </tr>

                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("number") %></td>
                                <td>
                                    <a title="<%#Eval("title") %>" href="ProjectDetail.aspx?id=<%#Eval("id") %>"><%#Eval("title").ToString().Length>20?Eval("title").ToString().Substring(0,20):Eval("title") %></a>
                                </td>
                                <td><%#Eval("price") %></td>
                                <td><%#Eval("hit") %></td>
                                <td><%# ((DateTime)Eval("startTime")).ToString("yyyy-MM-dd") %></td>
                                <td><%# ((DateTime)Eval("endTime")).ToString("yyyy-MM-dd") %></td>
                            </tr>


                        </ItemTemplate>
                        <FooterTemplate>
                            <td class='emptyData' colspan='5'>
                                <asp:Label ID="lblEmpty" Text="数据正在添加中..." runat="server" Visible='<%#bool.Parse((Repeater1.Items.Count==0).ToString())%>'></asp:Label>
                            </td>
                        </FooterTemplate>
                    </asp:Repeater>

                </tbody>
            </table>
            <uc1:Pager ID="Pager1" PageSize="12" runat="server" />

        </div>
    </div>

    <div class="right_sidbar">
        <uc2:CategoryControl ID="CategoryControl1" runat="server" ParentId="2" ArticleTableName="Project" />
        <uc4:Contact ID="Contact1" runat="server" />
    </div>

</asp:Content>

