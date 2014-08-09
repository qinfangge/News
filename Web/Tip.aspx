<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tip.aspx.cs" Inherits="CMS.Web.Admin.Tip" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>提示信息</title>
    <style type="text/css">
    @import url('css/base/tip.css');
</style>
<script type="text/javascript" src="js/correctPNG.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
<%--提示框--%>
<div class="tipWrapper">
    <asp:Panel ID="TipView" CssClass="tips" runat="server">
        <div class="tipIcon"><asp:Image ID="ImageIcon" runat="server" ImageUrl="~/Css/base/images/warning.png" /></div>
        <div class="info">
            <%--提示标题--%>
            <h1>
                <asp:Literal ID="TipTitle" runat="server" Text="温馨提示：" /></h1>
            <%--信息提示列表，常用于表单验证出错！--%>
            <asp:BulletedList BulletStyle="Numbered" ID="TipList" CssClass="tipsList" runat="server" />
        </div>
        <%--返回链接--%>
        <asp:Panel CssClass="btnBox" ID="LinkButtonView" runat="server" />
    </asp:Panel>
    
</div>
    </div>
    </form>
</body>
</html>
