<%@ Page Title="在线咨询" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GuestBook.aspx.cs" Inherits="CMS.Web.GuestBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    <link href="/css/base/form.css" type="text/css" rel="stylesheet" />
    <style>

        td {
            padding-bottom:15px;
        }

        table tr td {
    text-align: left;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div class="location news_lc">
            您当前的位置是：<a href="/">首页</a> &gt;&gt;在线咨询
        </div>
    <div class="formView">
      
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td style="width: 8em;">标题
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="txttitle" style="width:240px;" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>姓名
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="txtname" CssClass="date" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>电话
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="txtmobile" CssClass="date" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>内容
	：</td>
                <td>
                    <asp:TextBox ID="txtcontent" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>验证码
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="VCode" CssClass="date" runat="server"></asp:TextBox><img height="40px" style="vertical-align: middle;" src="vcode.aspx" id="vimg" />
                    <a id="refreshVCode" href="javascript:refreshCode();this.blur()">看不清，换一换</a>
                    <script type="text/javascript">
                        function refreshCode() {
                            var vimg = document.getElementById('vimg');
                            vimg.src = vimg.src + "?t=" + new Date();
                        }

                    </script>
                </td>
            </tr>

            <tr>
                <td class="buttonWrapper" style=" text-align:center;" colspan="2">

                    <asp:Button ID="btnSave" runat="server" Text="保存"
                        OnClick="btnSave_Click"
                        onmouseout="this.className='inputbutton'"></asp:Button>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
