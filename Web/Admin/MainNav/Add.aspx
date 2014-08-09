<%@ Page Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="CMS.Web.MainNav.Add" Title="增加页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/base/form.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MinNav" runat="server">
    添加信息
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="formView">
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
               <td style="width: 8em;">链接地址
	：</td>
               <td class="textWrapper">
                    <asp:TextBox ID="txtlink" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>菜单名称
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="txtname" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>新窗口打开
	：</td>
                <td class="checkBoxWrapper">
                    <asp:CheckBox ID="chktarget"  runat="server" Checked="False" />
                </td>
            </tr>

            <tr>
	<td >
		序号
	：</td>
	<td class="textWrapper"  >
		<asp:TextBox id="txtsort" runat="server" Width="200px"></asp:TextBox>
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

    <br />
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
