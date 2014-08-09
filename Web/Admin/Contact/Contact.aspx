<%@ Page Title="联系方式" Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CMS.Web.Admin.Contact.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/base/form.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 39px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MinNav" runat="server">
    联系方式
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formView">
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td style="width: 8em;">联系人
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="Contactor" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>联系电话
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
                </td>
                </tr>
            <tr>
                <td>传真
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="Fax"  runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >网址
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="WebSite"  runat="server"></asp:TextBox>
                </td>
            </tr>
	<tr>
        <td >邮箱
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>QQ
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="QQ" runat="server"></asp:TextBox>
                </td>
            </tr>


            <tr>
                <td>邮编
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="Zip" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >地址
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="Address"  runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="buttonWrapper alignCenter" colspan="2">
                    <asp:Button ID="btnSave" runat="server" Text="保存"
                        OnClick="btnSave_Click"
                        onmouseout="this.className='inputbutton'"></asp:Button>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
