<%@ Page Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Assign.aspx.cs" Inherits="CMS.Web.Admin.Role.Assign" Title="分配权限" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/base/form.css" type="text/css" rel="stylesheet" />
    <style>
        .childNode {
            margin-left:20px;
            margin-bottom:10px;
            margin-top:5px;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
           
            $(".parentLabel  :checkbox").click(function () {
                var childNode=$(this).parents(".parentNode").find(".childNode").find(":checkbod");
                if ($(this).is(":checked")) {
                    childNode.attr("checked", "checked");
                } else {
                    childNode.attr("checked", "");
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MinNav" runat="server">
    <p>
        分配权限</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <div class="formView">
        <table cellSpacing="0" cellPadding="0" width="100%" border="0">
            <asp:HiddenField Value="" runat="server" ID="RoleId" />
	<tr>
	<td style="width:8em;" >
		当前角色
	：</td>
	<td class="textWrapper">
        <asp:Literal ID="RoleName" runat="server"></asp:Literal>
	</td></tr>
	
            <tr>
	<td >
		权限
	：</td>
	<td class="checkBoxWrapper">
        <asp:Repeater ID="NodeGroupReapter" runat="server"  OnItemDataBound="NodeGroupReapter_ItemDataBound">

            <ItemTemplate>
                <div class="parentNode">
               <label class="parentLabel"><input type="checkbox" /> <%#Eval("name") %></label>
                <div class="childNode">
                <asp:CheckBoxList ID="Node" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" >
        </asp:CheckBoxList></div>
                    </div>
            </ItemTemplate>
        </asp:Repeater>
	    
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
