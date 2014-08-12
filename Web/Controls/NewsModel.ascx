<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsModel.ascx.cs" Inherits="CMS.Web.Controls.NewsModel" %>

<%--<a href="NewsList.aspx?category=<%=this.CategoryId%>">更多</a>--%>


<div class="ranking-list">
    <ul class="nav-list">
        <li>
            <a class="item">
                <asp:Literal ID="ModelName" runat="server"></asp:Literal></a>
        </li>
    </ul>
    <div>
        <div class="item-wrapper active">
            <ul id="ranking-wrapper">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                       
                        <li  <%#Container.ItemIndex<3  ? "class='item-top3'":""%> >
                            <span class="num <%#Container.ItemIndex<3  ? "num-red":""%> "><%#Container.ItemIndex+1%></span>
                            <div class="name">
                                <a title="<%#Eval("title") %>" href="/Detail.aspx?id=<%#Eval("id") %>"><%#Eval("title").ToString().Length>13?Eval("title").ToString().Substring(0,13):Eval("title") %></a>
                            </div>
                        </li>

                    </ItemTemplate>

                    <FooterTemplate>

                        <asp:Label ID="lblEmpty" Text="<li class='emptyData'>数据正在添加中...</li>" runat="server" Visible='<%#bool.Parse((Repeater1.Items.Count==0).ToString())%>'></asp:Label>

                    </FooterTemplate>
                </asp:Repeater>


            </ul>
        </div>
    </div>
</div>


