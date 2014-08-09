<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SinglePageModel.ascx.cs" Inherits="CMS.Web.Controls.SinglePageModel" %>

<div class="news_n">
    <h3 class="n_title">中心介绍</h3>
    <div class="r_bor">
    <ul>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>

                <li <%# Eval("id").ToString()==ID.ToString()? "class='selected'":""%>>
                    <a href="SinglePage.aspx?title=<%#Eval("title") %>"><%#Eval("title") %></a>

                </li>
            </ItemTemplate>

            <FooterTemplate>

                <asp:Label ID="lblEmpty" Text="<li class='emptyData'>数据正在添加中...</li>" runat="server" Visible='<%#bool.Parse((Repeater1.Items.Count==0).ToString())%>'></asp:Label>

            </FooterTemplate>
        </asp:Repeater>
    </ul>
</div>
</div>


