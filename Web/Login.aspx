<%@ Page Title="会员登录" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CMS.Web.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="c100">
            <div class="member">
                <div class="mem_pic">
                    <img width="500" height="335" src="images/login.jpg"></div>
                <div class="login_content">
                    <h3>会员登录</h3>
                    <ul class="login-bd">
                        <li>
                            <label class="login-label">用户名：</label><asp:TextBox CssClass="txt" ID="UserName" runat="server" Text="admin"></asp:TextBox>
                            </li>
                        <li>
                            <label class="login-label">密码：</label><asp:TextBox CssClass="txt" ID="Password" runat="server"  Text="fqmhw@qq.com" TextMode="Password"></asp:TextBox>
                           </li>

                         <li>
                            <label class="login-label">验证码：</label><asp:TextBox CssClass="txt" ID="VCode" runat="server" MaxLength="4" Width="4em"></asp:TextBox>
                             <img <%--id="codeimg"--%> src="vcode.aspx" id="vimg" style="vertical-align:middle;margin-right:4px;"><a id="refreshVCode" href="javascript:refreshCode();this.blur()">看不清，换一换</a>
                                                                            <script type="text/javascript">
                                                                                function refreshCode() {
                                                                                    var vimg = document.getElementById('vimg');
                                                                                    vimg.src = vimg.src + "?t=" + new Date();
                                                                                }

                                                                            </script>
                           </li>

                        <li class="login-auto">
                            <span class="bug"><a title="" href="">忘记密码？</a></span>
                            <span class="f10">
                                <label>
                                    <input id="cktime1" type="checkbox" checked="" value="31536000" name="cktime">
                                    下次自动登录</label>
                            </span>
                        </li>
                        <li class="login-btn">还不是网站用户？<a title="" href="Regist.aspx">赶紧注册去</a></li>
                        <li class="login-auto">
                            <asp:Button ID="Button1" CssClass="btn_login" runat="server" Text="登录" OnClick="Button1_Click" />
                            
                            </li>

                    </ul>
                </div>
            </div>
        </div>
</asp:Content>
