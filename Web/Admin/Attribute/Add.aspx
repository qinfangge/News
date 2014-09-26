<%@ Page Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="CMS.Web.Admin.Attribute.Add" Title="增加页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/base/form.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MinNav" runat="server">
    添加属性
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
<div class="formView">
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	
	<tr>
	<td style="width: 8em;">
		属性名称
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txtname" runat="server" ></asp:TextBox>
	</td></tr>
	<tr>
	<td >
		类名
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txtcssClass" runat="server" ></asp:TextBox>
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
                     </div>

</asp:Content>

