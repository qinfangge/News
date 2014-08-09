<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="XMLY.aspx.cs" Inherits="CMS.Web.XMLY" %>
<%@ Import Namespace="tk.tingyuxuan.utils" %>
<%@ Register Src="Controls/CategoryControl.ascx" TagName="CategoryControl" TagPrefix="uc2" %>
<%@ Register Src="Controls/CurrentPosition.ascx" TagName="CurrentPosition" TagPrefix="uc3" %>
<%@ Register Src="Controls/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register src="Controls/Contact.ascx" tagname="Contact" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    <style type="text/css">
        .pagenav {
            margin-top: 10px;
        }
        .left_sidbar {
            width:auto;
            float:none;
        }
    </style>
    <link href="/css/base/pager.css" type="text/css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <div class="left_sidbar">
      <div class="location news_lc">
您当前的位置是：<a href="/">首页</a> &gt;&gt; <a href="/xmly.aspx">项目路演</a>
     </div>

        <div class="">
            <ul class="clearfix last"> 

                <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>

                              <li class="pics-li">
                        <div class="p-img-wrapper"><a href="ProjectDetail.aspx?id=<%#Eval("id") %>" class="p-bigpic-link "><img src="<%#ImageUtils.GetThumbImagePath(Eval("titleImage").ToString(),208,208,1) %>"  alt="<%#Eval("title") %>"></a></div>
                         <p class="p-info-title"> <a title="<%#Eval("title") %>" href="ProjectDetail.aspx?id=<%#Eval("id") %>"><%#Eval("title").ToString().Length>20?Eval("title").ToString().Substring(0,20):Eval("title") %></a></p>
                </li>

                            

                        </ItemTemplate>
                        <FooterTemplate>
                            <td class='emptyData' colspan='5'>
                                <asp:Label ID="lblEmpty" Text="数据正在添加中..." runat="server" Visible='<%#bool.Parse((Repeater1.Items.Count==0).ToString())%>'></asp:Label>
                            </td>
                        </FooterTemplate>
                    </asp:Repeater>

               
            </ul>

            
            <uc1:Pager ID="Pager1" PageSize="12" runat="server" />

        </div>
    </div>

    

</asp:Content>

