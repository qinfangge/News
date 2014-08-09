<%@ Page Title="网站设置" Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeBehind="Config.aspx.cs" Inherits="CMS.Web.Admin.Config.Config" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/base/form.css" type="text/css" rel="stylesheet" />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MinNav" runat="server">
    网站设置
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formView">
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
             <tr>
                  <td style="width: 8em;">温馨提示：
	：</td>
                <td style="color:#c10000;font-weight:bold;">
                  以下代码请谨慎修改，可能会影响到网站排名！
                </td>
            </tr>

            <tr>
                <td >网站名称
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="SiteName" runat="server" Width="380px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>关键词
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="KeyWords" runat="server" CssClass="date" Width="380px"></asp:TextBox>
                    <span class="tip">SEO使用</span></td>
                </tr>
            <tr>
                <td>描述：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="Description"  runat="server" TextMode="MultiLine" Width="380px"></asp:TextBox>
                      <span class="tip">SEO使用</span></td>
            </tr>
            <tr>
                <td >其它
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="Other"  runat="server" TextMode="MultiLine" Width="380px"></asp:TextBox>
                      <span class="tip">其它代码（如流量统计）</span></td>
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
