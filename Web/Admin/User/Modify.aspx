<%@ Page Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="CMS.Web.Admin.User.Modify" Title="修改页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/base/form.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MinNav" runat="server">
    修改用户
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
                 
                   
	<td style="width: 8em;">
		用户名
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txtuserName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td >
		密码
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txtpassword" runat="server" Width="200px"></asp:TextBox> <span class="tip">不修改密码可不填写！</span>
	</td></tr>
	<tr>
	<td >
		邮箱
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txtemail" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	
	
	<tr>
	<td >
		联系人
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txtrealName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td >
		联系电话
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txtphone" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td >
		用户类型
	：</td>
	<td class="radioWrapper">
		
	    <asp:RadioButtonList ID="txttype" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        </asp:RadioButtonList>
	</td></tr>
            <tr>
	<td >
		激活
	：</td>
	<td class="checkBoxWrapper">
		<asp:CheckBox ID="chkisActive"  runat="server" Checked="False" />
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

