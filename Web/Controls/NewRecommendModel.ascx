<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewRecommendModel.ascx.cs" Inherits="CMS.Web.Controls.NewRecommendModel" %>

<%--<a href="NewsList.aspx?category=<%=this.CategoryId%>">更多</a>--%>

<div class="recent-hd">
            大家刚刚推荐
        </div>
        <div class="recent-item-list">
            <div style="top: -186px;" class="recent-item-list-wrapper">

                 <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>

                <div class="recent-item">
                    <i></i>
                    <div class="recent-detail">
                        <a href="/Detail.aspx?id=<%#Eval("id") %>" data-url="/Detail.aspx?id=<%#Eval("id") %>"   class="recent-title"><%#Eval("title").ToString().Length>18?Eval("title").ToString().Substring(0,18):Eval("title") %></a>
                        <label>[<a class="nickname" href="http://j.news.163.com/profile/zouxm1984/">天戟沧雄</a>]推荐</label>
                    </div>
                </div>


                



            </ItemTemplate>

            <FooterTemplate>

                <asp:Label ID="lblEmpty" Text="<div class='emptyData'>暂无信息...</div>" runat="server" Visible='<%#bool.Parse((Repeater1.Items.Count==0).ToString())%>'></asp:Label>

            </FooterTemplate>
        </asp:Repeater>

                


            </div>
        </div>



