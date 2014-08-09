<%@ Page Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="CMS.Web.Admin.SinglePage.Modify" Title="修改信息" %>
<%@ Register src="../../Controls/Category.ascx" tagname="Category" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="/css/base/form.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="/Js/jquery-1.6.1.min.js"></script>
    <script type="text/javascript" src="/Js/libs/My97DatePicker/WdatePicker.js"></script>
    <!-- 配置文件 -->
    
    <script type="text/javascript" src="../js/libs/ueditor/ueditor.config.js"></script>
    <!-- 编辑器源码文件 -->
    <script type="text/javascript" src="../js/libs/ueditor/ueditor.all.js"></script>
    <!-- 语言包文件(建议手动加在语言，避免在ie下有时因为加载语言失败导致编辑器加载失败) -->
    <script type="text/javascript" src="../js/libs/ueditor/lang/zh-cn/zh-cn.js"></script>

    <script type="text/javascript" src="../js/libs/ueditor/ueditor.custom.config.js"></script>

    <script type="text/javascript">
        var editor = UE.getEditor('<%=txtcontent.ClientID%>');
    </script>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MinNav" runat="server">
    修改信息
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <div class="formView">
        <table cellSpacing="0" cellPadding="0" width="100%" border="0">
            <tr  class="none">
	<td >
		id
	：</td>
	<td >
		<asp:label id="lblid" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td style="width: 8em;">
		标题
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txttitle" runat="server" ></asp:TextBox>
	</td></tr>

            <tr>
                        <td >栏目
	：</td>
                        <td >
                   
                    <uc1:Category ID="Category1" runat="server" ParentId="62" />
                   
                        </td>
                    </tr>
	<tr>
	<td >
		内容
	：</td>
	<td >
		<asp:TextBox id="txtcontent" TextMode="MultiLine" runat="server" ></asp:TextBox>
	</td></tr>
	<tr>
	<td >
		关键词
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txtkeywords" runat="server" ></asp:TextBox>
	</td></tr>
	<tr>
	<td >
		描述
	：</td>
	<td >
		<asp:TextBox id="txtdescription" TextMode="MultiLine" runat="server" ></asp:TextBox>
	</td></tr>

	
	<tr>
	<td class="textWrapper">
		排序
	：</td>
	<td >
		<asp:TextBox id="txtsort" CssClass="date" runat="server" ></asp:TextBox>
        <span class="tip">请输入数值 1、2、3...</span></td></tr>
            <tr>
	<td >
		添加时间
	：</td>
	<td >
		<asp:TextBox ID="txtaddTime" runat="server" CssClass="date"   onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
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

