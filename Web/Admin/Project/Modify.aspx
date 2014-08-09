<%@ Page Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="CMS.Web.Admin.Project.Modify" Title="修改项目" %>
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
    修改项目
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formView">
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr class="none">
                        <td>id
	：</td>
                        <td>
                            <asp:Label ID="lblid" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
	<tr>
	<td style="width: 8em;">
		标题
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txttitle" runat="server" ></asp:TextBox>
	</td></tr>
              <tr>
	<td >
		来源
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="Source" CssClass="date" runat="server" ></asp:TextBox>
	</td></tr>
	
         <tr>
	<td >
		会员项目
	：</td>
	<td class="checkBoxWrapper">
		<asp:CheckBox id="IsMember" CssClass="date" runat="server" ></asp:CheckBox><span class="tip">如果是会员项目，请勾选上！</span>
	</td></tr>

    <tr>
	<td >
		项目编号
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txtnumber" CssClass="date" runat="server" ></asp:TextBox>
	</td></tr>
	<tr>
	<td>
		挂牌价格
	：</td>
	<td class="textWrapper">
		<asp:TextBox id="txtprice" CssClass="date" runat="server" ></asp:TextBox>
	</td></tr>
	<tr>
	<td>
		挂牌日期
	：</td>
	<td class="textWrapper">
		<asp:TextBox ID="txtstartTime" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" CssClass="date"></asp:TextBox>
	</td></tr>
	<tr>
	<td >
		截止日期
	：</td>
	<td class="textWrapper">
		<asp:TextBox ID="txtendTime" runat="server"  onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" CssClass="date"></asp:TextBox>
	</td></tr>
	<tr>
	<td >
		分类
	：</td>
	<td class="textWrapper">
		<uc1:category ID="Category1"  runat="server" ParentId="2" />
	</td></tr>
            
            <tr>
                <td>推荐到
	：</td>
                <td class="textWrapper">
                    <asp:DropDownList ID="txtrecommend" runat="server">
                        <asp:ListItem Value="0">请选择</asp:ListItem>
                        <asp:ListItem Value="1">项目推荐</asp:ListItem>
                        <asp:ListItem Value="2">重点项目展示</asp:ListItem>
                        <%--<asp:ListItem Value="3">3级置顶</asp:ListItem>
                        <asp:ListItem Value="4">4级置顶</asp:ListItem>
                        <asp:ListItem Value="5">5级置顶</asp:ListItem>
                        <asp:ListItem Value="6">6级置顶</asp:ListItem>--%>
                    </asp:DropDownList><%-- <span class="tip">越大越靠前！(6 最大)</span>--%>
                    
                </td>
            </tr>
            <tr>
                <td>幻灯片显示
	：</td>
                <td class="checkBoxWrapper">
                    <asp:CheckBox ID="IsSwitch" runat="server"  />
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
	<td class="auto-style1" >
		描述
	：</td>
	<td class="auto-style1" >
		<asp:TextBox id="txtdescription"  TextMode="MultiLine" runat="server" ></asp:TextBox>
	</td></tr>
	
            <tr>
                        <td >添加时间
	：</td>
                        <td class="textWrapper">
                            <asp:TextBox ID="txtaddTime" CssClass="date" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" ></asp:TextBox>
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
        </div>
    
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>

