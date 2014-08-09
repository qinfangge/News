<%@ Page Title="管理项目" Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="CMS.Web.Admin.Project.List" %>
<%@ Register src="../../Controls/Pager.ascx" tagname="Pager" tagprefix="uc1" %>
<%@ Register src="../../Controls/Category.ascx" tagname="Category" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" src="../js/checkBox.js" type="text/javascript"></script>
     <link href="/css/base/table.css" type="text/css" rel="stylesheet" />
    <link href="/css/base/pager.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MinNav" runat="server">
    管理项目
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--Title -->

            <!--Title end -->

            <!--Add  -->

            <!--Add end -->

            <!--Search -->
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td style="width: 80px" align="right" class="tdbg">
                         <b>关键字：</b>
                    </td>
                    <td class="tdbg">                       
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;<uc2:Category ID="Category1" runat="server" ParentId="2" />
&nbsp;<asp:Button ID="btnSearch" runat="server" Text="查询"  OnClick="btnSearch_Click" >
                    </asp:Button>                    
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView  CssClass="list2" ID="gridView" runat="server" Width="100%" CellPadding="3"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="id"  OnRowDeleting="gridView_RowDeleting" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="False"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated" EnableModelValidation="True">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>

<ControlStyle Width="30px"></ControlStyle>
                                <HeaderStyle Width="4em" />
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="number" HeaderText="项目编号" SortExpression="number" ItemStyle-HorizontalAlign="Center"  > 
		                <HeaderStyle Width="12em" />
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
		<asp:BoundField DataField="title" HeaderText="标题" SortExpression="title" ItemStyle-HorizontalAlign="Center"  > 
                        <HeaderStyle HorizontalAlign="Left" />
<ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
		<asp:BoundField DataField="addTime" HeaderText="添加时间" SortExpression="addTime" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:yyyy-M-dd H:m:s}"  > 
		                <HeaderStyle Width="8em" />
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                                Text="编辑"  >
<ControlStyle Width="50px"></ControlStyle>
                        <HeaderStyle Width="4em" />
                        </asp:HyperLinkField>
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="True"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>

<ControlStyle Width="50px"></ControlStyle>
                                <HeaderStyle Width="4em" />
                            </asp:TemplateField>
                        </Columns>

<RowStyle HorizontalAlign="Center"></RowStyle>
                </asp:GridView>
     <asp:Button ID="btnDelete" CssClass="batchDelete" runat="server" Text="批量删除" OnClick="btnDelete_Click"/>                       
    <uc1:Pager ID="Pager1" PageSize="10" runat="server" />
             
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
