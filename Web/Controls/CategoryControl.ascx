<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryControl.ascx.cs" Inherits="CMS.Web.Controls.CategoryControl" %>


<%if (Repeater1.Items.Count>0){ %>

<div class="news_n">
    <h3 class="n_title">
        <asp:Literal ID="Literal1" runat="server" Text="新闻中心"></asp:Literal></h3>
    <div class="r_bor">
        <ul>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <li <%# Eval("id").ToString()==CategoryId.ToString()? "class='selected'":"" %>>
                        <a href="<%=ArticleTableName %>List.aspx?category=<%#Eval("id") %>&pid=<%=ParentId %>"><%#Eval("name") %></a>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblEmpty" Text="<li class='emptyData'>数据正在添加中...</li>" runat="server" Visible='<%#bool.Parse((Repeater1.Items.Count==0).ToString())%>'></asp:Label>
                </FooterTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
<%} %>