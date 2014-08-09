<%@ Page Title="投/融资" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Investment.aspx.cs" Inherits="CMS.Web.Investment" %>
<%@ Register src="Controls/Category.ascx" tagname="Category" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    
    <link href="css/base/form.css" type="text/css" rel="stylesheet" />
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
            您当前的位置是：<a href="/">首页</a> &gt;&gt;投/融资
        </div>
    <div class="formView">

        <table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td style="width: 8em;">
		标题
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txttitle" runat="server" style="width:240px;" ></asp:TextBox>
	</td></tr>
	<tr>
	<td >
		姓名
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txtname" CssClass="date" runat="server" ></asp:TextBox>
	</td></tr>
	<tr>
	<td >
		电话
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txtmobile" runat="server" CssClass="date"></asp:TextBox>
	</td></tr>
            <tr>
	<td  >
		栏目
	：</td>
	<td  >
		<uc1:Category ID="Category1" runat="server" ParentId="50" />
		
	</td></tr>
	<tr>
	<td >
		分类
	：</td>
	<td  class="radioWrapper">
		<asp:RadioButtonList ID="txttype" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Value="0" Selected="True">投资</asp:ListItem>
            <asp:ListItem Value="1">融资</asp:ListItem>
        </asp:RadioButtonList>

	</td></tr>
	<tr>
	<td >
		内容
	：</td>
	<td >
		<asp:TextBox id="txtcontent" runat="server" TextMode="MultiLine" ></asp:TextBox>
	</td></tr>
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
                <td class="buttonWrapper alignCenter" style=" text-align:center;" colspan="2">
                   
                    <asp:Button ID="btnSave" runat="server" Text="保存"
                        OnClick="btnSave_Click"
                        onmouseout="this.className='inputbutton'"></asp:Button>
                </td>
            </tr>
</table>
    </div>
    </asp:Content>
