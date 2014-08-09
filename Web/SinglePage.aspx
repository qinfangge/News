<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SinglePage.aspx.cs" Inherits="CMS.Web.SinglePage" %>

<%@ Register src="Controls/SinglePageModel.ascx" tagname="SinglePageModel" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    <link rel="stylesheet" href="Css/detail.css" />
    <style>

        .artcon {
            width:auto;
            margin-top:10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">

    <div class="left_sidbar">
        <div class="artcon">
            <h3>
                <asp:Literal ID="ArticleTitle" runat="server"></asp:Literal></h3>
            <div class="source">
                <ul>

                    <li>时间：<asp:Literal ID="AddTime" runat="server"></asp:Literal></li>
                    <li>点击率：<asp:Literal ID="Hits" runat="server"></asp:Literal></li>
                </ul>
                <hr color="#DD4250">
            </div>
            <div id="zoom" class="cont">
                <asp:Literal ID="Content" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="right_sidbar">
        
        <uc1:SinglePageModel ID="SinglePageModel1" runat="server" />
    </div>
</asp:Content>
