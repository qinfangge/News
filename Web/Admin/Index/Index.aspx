<%@ Page Title="欢迎页面" Language="C#" MasterPageFile="~/Admin/Master/MasterPage.master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CMS.Web.Admin.Index.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MinNav" runat="server">
    欢迎页面
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="welcome">
        <h3>
            <asp:Literal ID="Literal1" runat="server">admin</asp:Literal>
            您好，欢迎使用网站管理系统！</h3>
        <p>当前时间:<%=DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") %></p>
        <p>服务器IP:<%=Request.ServerVariables["LOCAL_ADDR"] %></p>
         <p>应用程序占用内存：<%=((Double)GC.GetTotalMemory(false) / 1048576).ToString("N2") + "M" %></p>
        <p>操作作系统:<%= Environment.OSVersion.ToString() %></p>
       
    </div>

</asp:Content>
