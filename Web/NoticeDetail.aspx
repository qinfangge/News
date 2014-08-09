<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NoticeDetail.aspx.cs" Inherits="CMS.Web.NoticeDetail" %>

<%@ Register Src="Controls/CurrentPosition.ascx" TagName="CurrentPosition" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">


    <div class="location news_lc" style="border-bottom: none;">
        <uc1:CurrentPosition ID="CurrentPosition1" ArticleTableName="Notice" runat="server" />
    </div>
    <div class="artcon">
        <h3>
            <asp:Literal ID="ArticleTitle" runat="server"></asp:Literal></h3>

        <div class="source">
            <ul>
                <li>时间：<asp:Literal ID="AddTime" runat="server"></asp:Literal></li>
                <li>点击率：<asp:Literal ID="Hits" runat="server"></asp:Literal></li>
            </ul>
            <hr color="#DD4250" />
        </div>
        <div id="zoom" class="cont">
            <asp:Literal ID="Content" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>

