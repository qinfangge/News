<%@ Page Title="用户注册" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Regist.aspx.cs" Inherits="CMS.Web.Regist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    <link type="text/css" rel="stylesheet" href="css/register.css"/>
   
    <script type="text/javascript" src="Js/jquery-1.6.1.min.js">

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <script type="text/javascript">
        function selectUserType() {
            var userType = $("#<%=UserType.ClientID%>").val();
            if (userType == "2") {
                $("#type a").eq(0).trigger("click");
            }

            if (userType == "3") {
                $("#type a").eq(1).trigger("click");
            }

        }
        $(document).ready(function () {

            $("#class").click(function () {
                $("#type").show();
                return false;
            });
            
            var userType = $("#<%=UserType.ClientID%>").val(userType);
            if (userType == "2") {
                var val = $("#type a").eq(0).text();
                $("#class").val(val);
            }

            if (userType == "3") {
                var val = $("#type a").eq(1).text();
                $("#class").val(val);
            }

            $("body").click(function () {
                $("#type").hide();
            });




            $("#type a").click(function () {
                var val = $(this).text();
                $("#class").val(val);
                $("#type").hide();
                var userType = -1;
                if (val == "拍卖公司") {
                    userType = 2;
                }
                if (val == "审计") {
                    userType = 3;
                }
                $("#<%=UserType.ClientID%>").val(userType);
            });

        })

       
    </script>
    <div class="vipwrap c100">
        <div class="mem_top">
            <h3>用户注册</h3>
            <span class="reg_r">我已注册，现在就<a href="Login.aspx">登陆</a></span>
        </div>
        <div class="reg_con">
            <div class="regist_left">
                <dl class="cc">
                    <dt>
                        <label for="regname0">
                            用户类型：</label></dt>
                    <dd class="box ip">
                       <style>
                           .checkBoxWrapper {
                               margin-top:10px;
                           }
                           .checkBoxWrapper input {
                               width: auto !important;
                               vertical-align: middle;
                               height:auto;
                           }

                           .checkBoxWrapper label {
                               display: inline;
                               margin-right:10px;
                               margin-left:3px;
                           }
                       </style>
                        <div class=" checkBoxWrapper">
                     <asp:RadioButtonList ID="UserType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                       </asp:RadioButtonList>
                            </div>
                    </dd>
                </dl>
                <dl class="cc">
                    <dt>
                        <label for="regname0">
                            用户名：</label></dt>
                    <dd class="box ip">
                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                    </dd>
                    <dd class="tp">
                        <div id="regname_info" class="txt-info-mouseout">
                            *  	
                                 6~12个字符，包括字母、数字、下划线，以字母开头，字母或数字结尾
                        </div>
                    </dd>
                </dl>
                <dl class="cc">
                    <dt>
                        <label for="regname0">
                            密码：</label></dt>
                    <dd class="box ip">
                        <asp:TextBox ID="Password" runat="server"></asp:TextBox>
                    </dd>
                    <dd class="tp">
                        <div id="regname_info0" class="txt-info-mouseout">
                            *  	
                                  6~16个字符，包括字母、数字、特殊符号，区分大小写
                        </div>
                    </dd>
                </dl>
                <dl class="cc">
                    <dt>
                        <label for="regname0">
                            确认密码：</label></dt>
                    <dd class="box ip">
                        <asp:TextBox ID="ConfirmPassword" runat="server"></asp:TextBox>
                    </dd>
                    <dd class="tp">
                        <div id="regname_info1" class="txt-info-mouseout">
                            *  	
                                   请再次输入密码
                        </div>
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
                        <asp:Button ID="Button1" CssClass="confirm" runat="server" OnClick="Button1_Click" Text="立即注册" /></dd>

                </dl>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
