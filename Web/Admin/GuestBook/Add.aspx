<%@ Page Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="CMS.Web.Admin.GuestBook.Add" Title="添加信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/base/form.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="/Js/jquery-1.6.1.min.js"></script>
    <script type="text/javascript" src="/Js/libs/My97DatePicker/WdatePicker.js"></script>
    <!-- 配置文件 -->
    <script type="text/javascript">
        
         
    </script>
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
<asp:Content ID="Content4" ContentPlaceHolderID="MinNav" runat="server">
    添加信息
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formView">

        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td style="width: 8em;">标题
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="txttitle" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>姓名
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="txtname" CssClass="date" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>电话
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="txtmobile" CssClass="date" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>内容
	：</td>
                <td>
                    <asp:TextBox ID="txtcontent" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>添加时间
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="txtaddTime" CssClass="date" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>回复
	：</td>
                <td class="checkBoxWrapper">
                    <asp:TextBox ID="txtreply" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>回复时间
	：</td>
                <td class="textWrapper">
                    <asp:TextBox ID="txtreplyTime" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" CssClass="date" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>审核
	：</td>
                <td class="checkBoxWrapper">
                    <asp:CheckBox ID="chkisChecked" runat="server" Checked="True" />
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
    <br />
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
