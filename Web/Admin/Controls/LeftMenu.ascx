<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftMenu.ascx.cs" Inherits="CMS.Web.Admin.Controls.LeftMenu" %>
<table width="100%" height="280" border="0" cellpadding="0" cellspacing="0" bgcolor="#EEF2FB">
    <tr>
        <td width="182" valign="top">
            <div id="container">
                <asp:Repeater ID="NodeGroupRepeater" runat="server" OnItemDataBound="NodeGroupRepeater_ItemDataBound">
                    <ItemTemplate>
                        <h1 class="type"><a href="javascript:void(0)"><%#Eval("name")%></a></h1>
                        <div class="content" style="display: block;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <img src="../images/menu_topline.gif" width="182" height="5" /></td>
                                </tr>
                            </table>
                            <ul class="MM">
                                <asp:Repeater ID="NodeRepeater" runat="server">
                                    <ItemTemplate>

                                        <li><a href="<%#Eval("url")%>"><%#Eval("menuName")%></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <%--<h1 class="type"><a href="javascript:void(0)">项目频道</a></h1>
                <div class="content" style="display: block;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <img src="../images/menu_topline.gif" width="182" height="5" /></td>
                        </tr>
                    </table>
                    <ul class="MM">
                        <li><a href="../Project/Add.aspx">添加项目</a></li>
                        <li><a href="../Project/List.aspx">管理项目</a></li>

                    </ul>
                </div>
                <h1 class="type"><a href="javascript:void(0)">涉诉资产</a></h1>
                <div class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <img src="../images/menu_topline.gif" width="182" height="5" /></td>
                        </tr>
                    </table>
                    <ul class="MM">
                        <li><a href="../Notice/Add.aspx">添加信息</a></li>
                        <li><a href="../Notice/List.aspx">管理信息</a></li>

                    </ul>
                </div>
                <h1 class="type"><a href="javascript:void(0)">新闻相关</a></h1>
                <div class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <img src="../images/menu_topline.gif" width="182" height="5" /></td>
                        </tr>
                    </table>
                    <ul class="MM">
                        <li><a href="../News/Add.aspx">添加信息</a></li>
                        <li><a href="../News/List.aspx">管理信息</a></li>
                    </ul>
                </div>
                <h1 class="type"><a href="javascript:void(0)">投/融资</a></h1>
                <div class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <img src="../images/menu_topline.gif" width="182" height="5" /></td>
                        </tr>
                    </table>
                    <ul class="MM">
                        <li><a href="../Investment/Add.aspx">添加信息</a></li>
                        <li><a href="../Investment/List.aspx">管理信息</a></li>
                    </ul>
                </div>
                <h1 class="type"><a href="javascript:void(0)">在线咨询</a></h1>
                <div class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <img src="../images/menu_topline.gif" width="182" height="5" /></td>
                        </tr>
                    </table>
                    <ul class="MM">
                        <li><a href="../GuestBook/Add.aspx">添加信息</a></li>
                        <li><a href="../GuestBook/List.aspx">管理信息</a></li>
                    </ul>
                </div>

                <h1 class="type"><a href="javascript:void(0)">用户信息</a></h1>
                <div class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <img src="../images/menu_topline.gif" width="182" height="5" /></td>
                        </tr>
                    </table>
                    <ul class="MM">
                        <li><a href="../User/Add.aspx">添加用户</a></li>
                        <li><a href="../User/List.aspx">管理用户</a></li>
                        <li><a href="../Role/Add.aspx">添加角色</a></li>
                        <li><a href="../Role/List.aspx">管理角色</a></li>

                        <li><a href="../Node/Add.aspx">添加权限</a></li>
                        <li><a href="../Node/List.aspx">管理权限</a></li>
                        <li><a href="../NodeGroup/Add.aspx">添加权限组</a></li>
                        <li><a href="../NodeGroup/List.aspx">管理权限组</a></li>
                    </ul>
                </div>
                <h1 class="type"><a href="javascript:void(0)">个人资料</a></h1>
                <div class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <img src="../images/menu_topline.gif" width="182" height="5" /></td>
                        </tr>
                    </table>
                    <ul class="MM">
                        <li><a href="../User/ModifyProfile.aspx">修改资料</a></li>
                    </ul>
                </div>
                <h1 class="type"><a href="javascript:void(0)">广告位</a></h1>
                <div class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <img src="../images/menu_topline.gif" width="182" height="5" /></td>
                        </tr>
                    </table>
                    <ul class="MM">
                        <li><a href="../Advertisement/Add.aspx">添加广告</a></li>
                        <li><a href="../Advertisement/List.aspx">管理广告</a></li>

                    </ul>
                </div>
                <h1 class="type"><a href="javascript:void(0)">友情链接</a></h1>
                <div class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <img src="../images/menu_topline.gif" width="182" height="5" /></td>
                        </tr>
                    </table>
                    <ul class="MM">
                        <li><a href="../FriendLink/Add.aspx">添加链接</a></li>
                        <li><a href="../FriendLink/List.aspx">管理链接</a></li>


                    </ul>

                </div>

                <h1 class="type"><a href="javascript:void(0)">关于我们</a></h1>
                <div class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <img src="../images/menu_topline.gif" width="182" height="5" /></td>
                        </tr>
                    </table>
                    <ul class="MM">
                        <li><a href="../SinglePage/Add.aspx">添加信息</a></li>
                        <li><a href="../SinglePage/List.aspx">管理信息</a></li>
                        <li><a href="../Contact/Contact.aspx">联系方式</a></li>
                    </ul>
                </div>
                <h1 class="type"><a href="javascript:void(0)">栏目管理</a></h1>
                <div class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <img src="../images/menu_topline.gif" width="182" height="5" /></td>
                        </tr>
                    </table>
                    <ul class="MM">
                        <li><a href="../Category/Add.aspx">添加栏目</a></li>
                        <li><a href="../Category/List.aspx">管理栏目</a></li>
                    </ul>
                </div>

                <h1 class="type"><a href="javascript:void(0)">其它参数管理</a></h1>
                <div class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <img src="../images/menu_topline.gif" width="182" height="5" /></td>
                        </tr>
                    </table>
                    <ul class="MM">

                        <li><a href="../Config/Config.aspx">网站设置</a></li>

                    </ul>
                </div>--%>
        </td>
    </tr>
</table>
