<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="CMS.Web.Home.Profile" %>

<%@ Register Src="Controls/UploadPic.ascx" TagName="UploadPic" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    <script src="/js/jquery-1.6.1.min.js" type="text/javascript"></script>
    <link href="/css/head~tpf9An2yebrc.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
   
        
       
        <div class="mainarea clearfix" style="min-height: 2094px;">
            <div id="personal-wrapper">
                <div id="personal-info" class="item-wrapper active">
                    <div class="well">

                        <p class="form-helper">注意：密码不填，则不修改</p>
                        <div class="form-group">
                            <div class="form-label">
                                <label>昵称：</label>
                            </div>
                            <div class="form-controls">
                               
                                <asp:TextBox ID="NickName" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-label">
                                <label>邮箱：</label>
                            </div>
                            <div class="form-controls">
                                
                                 <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-label">
                                <label>新密码：</label>
                            </div>
                            <div class="form-controls">
                               
                                 <asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox>
                            </div>

                            <div class="form-label">
                                <label>头像：</label>
                            </div>
                            <div class="form-controls">
                                <asp:HiddenField ID="Avatar" runat="server" />
                                <uc1:UploadPic ID="UploadPic1" runat="server" />

                            </div>


                            <div class="form-controls">
                                <asp:Button ID="Button1" CssClass="btn-submit" runat="server" Text="保存" OnClick="Button1_Click" />
                                
                            </div>
                        </div>
                        <hr>
                       
                    </div>
                </div>
            </div>
        </div>
    
</asp:Content>
