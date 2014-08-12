<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewRecommendModel.ascx.cs" Inherits="CMS.Web.Controls.NewRecommendModel" %>

<%--<a href="NewsList.aspx?category=<%=this.CategoryId%>">更多</a>--%>

<div class="recent-hd">
    <asp:Literal ID="ModelName" runat="server"></asp:Literal>
</div>
<div class="recent-item-list">
    <div style="top: -186px;" class="recent-item-list-wrapper">

        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>

                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a href="/Detail.aspx?id=<%#Eval("id") %>" data-url="/Detail.aspx?id=<%#Eval("id") %>" srctype="107" class="recent-title"><%#Eval("title").ToString().Length>13?Eval("title").ToString().Substring(0,13):Eval("title") %>(<%#Eval("addTime")%>)</a>
                        <label>[<a class="nickname" href="/profile/yszheng@126.com/">yszheng40126</a>]推荐</label>
                    </div>
                </div>



            </ItemTemplate>

            <FooterTemplate>

                <asp:Label ID="lblEmpty" Text="<li class='emptyData'>数据正在添加中...</li>" runat="server" Visible='<%#bool.Parse((Repeater1.Items.Count==0).ToString())%>'></asp:Label>

            </FooterTemplate>
        </asp:Repeater>





    </div>
</div>



