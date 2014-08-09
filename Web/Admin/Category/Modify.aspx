<%@ Page Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="CMS.Web.Admin.Category.Modify" Title="修改页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/base/form.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MinNav" runat="server">
    修改栏目
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <div class="formView">
        <table cellSpacing="0" cellPadding="0" width="100%" border="0">
              <tr style="display:none;">
	<td >
		id
	：</td>
	<td >
		<asp:label id="lblid" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td style="width: 8em;">
		栏目名称
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txtname" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td >
		请选择父栏目
	：</td>
	<td >
         <asp:DropDownList ID="txtcategory" runat="server">
         </asp:DropDownList>
	</td></tr>
	<tr>
	<td >
		排序
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txtsort" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
    <tr>
	<td>
		关键词
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txtkeywords" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td >
		描述
	：</td>
	<td >
		<asp:TextBox id="txtdescription" runat="server" TextMode="MultiLine" ></asp:TextBox>
	</td></tr>
            <tr>
            <td class="buttonWrapper alignLeft" colspan="2">
                <asp:Button ID="btnSave" runat="server" Text="保存"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                <asp:Button ID="btnCancle" runat="server" Text="取消"
                    OnClick="btnCancle_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
        </tr>
</table>
     </div>
  
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>

