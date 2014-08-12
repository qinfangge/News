<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="CMS.Web.Comment.Modify" Title="修改页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">
                
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td>
		id
	：</td>
	<td>
		<asp:label id="lblid" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td>
		评论
	：</td>
	<td>
		<asp:TextBox id="txtcontent" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td>
		评论时间
	：</td>
	<td>
		<asp:TextBox ID="txtaddTime" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td>
		ip
	：</td>
	<td>
		<asp:TextBox id="txtip" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td>
		newsId
	：</td>
	<td>
		<asp:TextBox id="txtnewsId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td>
		dig
	：</td>
	<td>
		<asp:TextBox id="txtdig" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td>
		Pid
	：</td>
	<td>
		<asp:TextBox id="txtPid" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td>
		审核
	：</td>
	<td>
		<asp:CheckBox ID="chkisCheck" Text="审核" runat="server" Checked="False" />
	</td></tr>
	<tr>
	<td>
		userId
	：</td>
	<td>
		<asp:TextBox id="txtuserId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
</table>
<script src="/js/calendar1.js" type="text/javascript"></script>

            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="保存"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                <asp:Button ID="btnCancle" runat="server" Text="取消"
                    OnClick="btnCancle_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>

