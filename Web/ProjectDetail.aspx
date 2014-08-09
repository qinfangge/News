<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectDetail.aspx.cs" Inherits="CMS.Web.ProjectDetail" %>

<%@ Register Src="Controls/CurrentPosition.ascx" TagName="CurrentPosition" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    <link rel="stylesheet" href="Css/detail.css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">

    <uc1:CurrentPosition ID="CurrentPosition1" runat="server" ArticleTableName="Project" />

    <div class="middle">
                               <span class="ctl0"><asp:Literal ID="ArticleTitle" runat="server"></asp:Literal></span>
                                 <table width="90%" align="center" cellspacing="0" cellpadding="0" border="0">
                                      <tbody><tr>
                                         <td bgcolor="#eeeeee" style="font-weight:bold; text-align: center;width:147px;">项目名称</td>
                                         <td valign="top" bgcolor="#ffffff" style=" text-align: left;padding-left:12px;">
                                             <span><%=ArticleTitle.Text %></span>
                                           </td>
                                      </tr>
                                      <tr>
                                         <td bgcolor="#eeeeee" style="font-weight:bold; text-align: center;width:147px;">项目编号</td>
                                         <td valign="top" bgcolor="#ffffff" style=" text-align: left;padding-left:12px;">
                                             <span>B1400182</span>
                                           </td>
                                      </tr>
                                      <tr>
                                         <td bgcolor="#eeeeee" style="font-weight:bold; text-align: center;width:147px;">点击数</td>
                                         <td valign="top" bgcolor="#ffffff" style=" text-align: left;padding-left:12px;">
                                             <asp:Literal ID="Hits" runat="server"></asp:Literal><span>次</span>
                                           </td>
                                      </tr>
                                       <tr>
                                         <td bgcolor="#eeeeee" style="font-weight:bold; text-align: center;width:147px;">挂牌价格</td>
                                         <td valign="top" bgcolor="#ffffff" style=" text-align: left;padding-left:12px;">
                                             <span><%=Price.Text %></span>
                                           </td>
                                      </tr>
                                       <tr>
                                         <td bgcolor="#eeeeee" style="font-weight:bold; text-align: center;width:147px;">发布时间</td>
                                         <td valign="top" bgcolor="#ffffff" style=" text-align: left;padding-left:12px;">
                                             <span><asp:Literal ID="AddTime" runat="server"></asp:Literal></span>
                                           </td>
                                      </tr>
                              </tbody></table><br>
                              <table width="90%" align="center" cellspacing="0" cellpadding="0" border="0">
                                 <tbody><tr>
                                    <td bgcolor="#EEEEEE" align="center" colspan="4" style="text-align: left;font-weight:bold; color:#F00;padding-left:12px"> 项目简况</td>
                                   </tr>
                                  <tr>
                                      <td width="40" rowspan="3" class="bjjc">基本<br>情况</td>
                                      <td width="107" class="bjjc">标的名称</td>
                                      <td colspan="2" class="zw"><%=ArticleTitle.Text %></td>
                                 </tr>
                                
                                 <tr>
                                      <td width="107" class="bjjc">挂牌价格</td>
                                       <td colspan="2" class="zw"><asp:Literal ID="Price" runat="server"></asp:Literal></td>
                                 </tr>

                                     <tr>
                                      <td width="107" class="bjjc">挂牌期限</td>
                                       <td colspan="2" class="zw">
        <asp:Literal ID="StartTime" runat="server"></asp:Literal>——<asp:Literal ID="EndTime" runat="server"></asp:Literal></td>
                                 </tr>
                                
                                <tr>
                                   <td width="107" class="bjjc">信息描述</td>
                                   <td width="717" style="text-align:left;" colspan="2" class="zw">
                                 
                                       <asp:Literal ID="Content" runat="server"></asp:Literal>


                                   </td>
                             </tr></tbody></table>
    
                 </div>
    

</asp:Content>

