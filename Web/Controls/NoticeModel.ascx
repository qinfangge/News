<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NoticeModel.ascx.cs" Inherits="CMS.Web.Controls.NoticeModel" %>
最新项目
<asp:Repeater ID="Repeater1" runat="server">
     <ItemTemplate>

                <li>
                    <a target="_blank" href="NewsDetail.aspx?id=<%#Eval("id") %>"><%#Eval("title") %></a>
                   
                </li>
            </ItemTemplate>

            <FooterTemplate>
                
                        <asp:Label ID="lblEmpty" Text="<li class='emptyData'>数据正在添加中...</li>" runat="server" Visible='<%#bool.Parse((Repeater1.Items.Count==0).ToString())%>'></asp:Label>
                
            </FooterTemplate>
</asp:Repeater>

