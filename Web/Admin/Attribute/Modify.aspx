<%@ Page Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="CMS.Web.Admin.Attribute.Modify" Title="修改页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/base/form.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MinNav" runat="server">
    修改属性
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="formView">
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr style="display:none">
                <td>id
	：</td>
                <td>
                   <asp:label id="lblid" runat="server"></asp:label>
                </td>
            </tr>
                <tr>
                    <td style="width: 8em;">属性名称
	：</td>
                    <td class="textWrapper">
                        <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>类名
	：</td>
                    <td class="textWrapper">
                        <asp:TextBox ID="txtcssClass" runat="server"></asp:TextBox>
                    </td>
                </tr>
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
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>

