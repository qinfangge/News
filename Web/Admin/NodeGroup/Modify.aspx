<%@ Page Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="CMS.Web.Admin.NodeGroup.Modify" Title="修改权限组" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/base/form.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MinNav" runat="server">
    修改权限组
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formView">
        <table cellSpacing="0" cellPadding="0" width="100%" border="0">
	    <tr style="display:none">
                        <td>id
	：</td>
                        <td>
                            <asp:Label ID="lblid" runat="server"></asp:Label>
                        </td>
                    </tr>
                 
                   
	<tr><td style="width: 8em;">
		组
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="RoleName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
              <tr>  <td style="width: 8em;">
		排序
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="Sort" runat="server" Width="200px"></asp:TextBox>
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
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>

