<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FriendLinks.ascx.cs" Inherits="CMS.Web.Controls.FriendLinks" %>
<asp:Repeater ID="Repeater1" runat="server">
     <ItemTemplate>
       <a target="_blank" href="<%#Eval("url") %>"><%#Eval("name")%></a>
    </ItemTemplate>
    <FooterTemplate>
        <asp:Label ID="lblEmpty" Text="数据正在添加中..." runat="server" Visible='<%#bool.Parse((Repeater1.Items.Count==0).ToString())%>'></asp:Label>
    </FooterTemplate>
</asp:Repeater>

