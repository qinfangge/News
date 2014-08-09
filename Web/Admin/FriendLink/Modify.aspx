<%@ Page Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="CMS.Web.Admin.FriendLink.Modify" Title="修改链接" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/base/form.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MinNav" runat="server">
   修改链接
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <div class="formView">
        <table cellSpacing="0" cellPadding="0" width="100%" border="0">
            <tr style="display:none">
	<td >
		id
	：</td>
	<td >
		<asp:label id="lblid" runat="server"></asp:label>
	</td></tr>
	
	<tr>
	<td style="width: 8em;">
		网站名称
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txtname" runat="server" ></asp:TextBox>
	</td></tr>
	<tr>
	<td >
		网站链接
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txturl" runat="server" ></asp:TextBox>
	</td></tr>
	<tr>
	<td >
		网站LOGO
	：</td>
	<td >
         <asp:FileUpload ID="FileUpload1" runat="server" />
       
	</td></tr>
            <tr>
	<td>
		排序
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txtsort" runat="server" ></asp:TextBox>
	</td></tr>
             <tr>
                <td class="buttonWrapper alignCenter" colspan="2">
                    <asp:Button ID="btnSave" runat="server" Text="保存"
                        OnClick="btnSave_Click"
                        onmouseout="this.className='inputbutton'"></asp:Button>
                    <asp:Button ID="btnCancle" runat="server" Text="取消"
                        OnClick="btnCancle_Click"></asp:Button>
                </td>
            </tr>
</table>
        <asp:Panel ID="Panel1" runat="server"  Visible="false">
                友情链接：<br />
                <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank">HyperLink
                </asp:HyperLink>
            </asp:Panel>

        </div>
    
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>

