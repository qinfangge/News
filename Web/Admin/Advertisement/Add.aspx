<%@ Page Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="CMS.Web.Admin.Advertisement.Add" Title="增加广告" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/base/form.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="/Js/libs/My97DatePicker/WdatePicker.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MinNav" runat="server">
    添加广告
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <div class="formView">
        <table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td style="width: 8em;">
		广告名称
	：</td>
	<td >
		<asp:TextBox id="txtname" runat="server" ></asp:TextBox>
	</td></tr>
	<tr>
	<td >
		上传图片
	：</td>
	<td >
		<asp:FileUpload ID="FileUpload1" runat="server" />
	</td></tr>
	<tr>
	<td >
		链接
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txturl" runat="server" ></asp:TextBox>
	</td></tr>
	<tr>
	<td >
		开始时间
	：</td>
	<td class="textWrapper">
		<asp:TextBox ID="txtstartTime" runat="server"  onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" CssClass="date" ></asp:TextBox>
	</td></tr>
	<tr>
	<td >
		结束时间
	：</td>
	<td class="textWrapper">
		<asp:TextBox ID="txtendTime" runat="server" CssClass="date"  onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"  ></asp:TextBox>
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
