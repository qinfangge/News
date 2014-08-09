<%@ Page Title=" 管理栏目" Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="CMS.Web.Admin.Category.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" src="/Js/jquery-1.6.1.min.js" type="text/javascript"></script>
    <script language="javascript"  type="text/javascript">
        var id = "0";
        $(document).ready(function () {
            $("#<%=this.txtcategory.ClientID%>").change(function () {
                id = $(this).val();
                $("#modifyCategory").attr("href","Modify.aspx?id=" + id);
            });

            $("#modifyCategory").click(function () {
                if (id == "0") {

                    alert("请选择要修改的栏目");
                    return false;
                }

            });
        });

    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MinNav" runat="server">
    管理栏目
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:DropDownList ID="txtcategory" runat="server">
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <a id="modifyCategory" href="Modify.aspx">修改&nbsp; |&nbsp; <asp:LinkButton ID="DelButton" runat="server" OnClick="DelButton_Click">删除</asp:LinkButton>
    </a>


&nbsp;


</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
