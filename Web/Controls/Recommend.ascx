<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Recommend.ascx.cs" Inherits="CMS.Web.Controls.Recommend" %>

<%--<a href="NewsList.aspx?category=<%=this.CategoryId%>">更多</a>--%>


<div class="ep-title-2 clearfix">
    <h2 class="title"><asp:Literal ID="ModelName" runat="server"></asp:Literal></h2>
</div>

<div>
    <ul class="mod-f12list">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>

                        <li>
                           <a title="<%#Eval("title") %>" href="/Detail.aspx?id=<%#Eval("id") %>"><%#Eval("title").ToString().Length>13?Eval("title").ToString().Substring(0,13):Eval("title") %></a>
                        </li>

                    </ItemTemplate>

                    <FooterTemplate>

                        <asp:Label ID="lblEmpty" Text="<li class='emptyData'>数据正在添加中...</li>" runat="server" Visible='<%#bool.Parse((Repeater1.Items.Count==0).ToString())%>'></asp:Label>

                    </FooterTemplate>
                </asp:Repeater>
    </ul>
</div>




