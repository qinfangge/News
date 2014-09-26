<%@ Page Title="找回密码" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reset.aspx.cs" Inherits="CMS.Web.Reset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    <link type="text/css" rel="stylesheet" href="css/register.css"/>
   
    <script type="text/javascript" src="Js/jquery-1.6.1.min.js">

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <script type="text/javascript">
       
        $(document).ready(function () {

            
        })

       
    </script>
    <div class="vipwrap c100">
        <div class="mem_top">
            <h3>重置密码</h3>
            <span class="reg_r">我已注册，现在就<a href="Login.aspx">登陆</a></span>
        </div>
        <div class="reg_con">
            <div class="regist_left">
                
                <dl class="cc">
                    <dt>
                        <label for="regname0">
                            用户名：</label></dt>
                    <dd class="box ip">
                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                    </dd>
                  
                </dl>
                <dl class="cc">
                    <dt>
                        <label for="regname0">
                            邮箱：</label></dt>
                    <dd class="box ip">
                        <asp:TextBox ID="Email" runat="server" ></asp:TextBox>
                    </dd>
                   
                </dl>
              
                <dl class="cc">
                    <dt>
                        <label for="regname0">
                            验证码：</label></dt>
                    <dd class="av">
                        <asp:TextBox ID="VCode"  CssClass="VCode" runat="server"></asp:TextBox>
                    </dd>
                    <dd class="tp">
                        <img src="vcode.aspx" id="vimg" style="vertical-align: middle;" />

                        <a id="refreshVCode" href="javascript:refreshCode();this.blur()">看不清，换一换</a>
                        <script type="text/javascript">
                            function refreshCode() {
                                var vimg = document.getElementById('vimg');
                                vimg.src = vimg.src + "?t=" + new Date();
                            }

                        </script>
                    </dd>
                </dl>
                <dl class="cc">
                    <dt>&nbsp;</dt>
                    <dd class="ip">
                        <label>
                            <input class="lause" type="checkbox" name="rgpermit" value="1" />我已阅读并完全同意
                               <a class="ble" onclick="permit();" style="cursor: pointer">条款内容</a>
                        </label>
                    </dd>
                    <dd class="tp">
                        <div id="regname_info2" class="txt-info-mouseout">
                        </div>
                    </dd>
                </dl>
                <dl>
                    <dt>&nbsp;</dt>
                    <dd>
                        <asp:Button ID="Button1" CssClass="confirm" runat="server" OnClick="Button1_Click" Text="发送激活链接" /></dd>

                </dl>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
