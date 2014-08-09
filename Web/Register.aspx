<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CMS.Web.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    <link rel="stylesheet" href="/css2&#47;global.css?201405071000"/><link rel="stylesheet" href="/css2&#47;skin.css?201405071000"/><link rel="stylesheet" href="/css2&#47;autoComplete.css?201405071000"/><link rel="stylesheet" href="/css2&#47;reg&#47;reg.css?201405071000"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="g-bd">
    	<div class="g-in">
        	
            <!-- tab模块 -->
        	<div class="m-tab">
            	<div class="tabHd">
                    <ul class="f-cbli">
                        <li class="z-on"><a href="javascript:void(0);">邮箱帐号注册</a></li>
                    </ul>
                </div>
                <div class="tabBd">
                    <form autocomplete="off" action="https://reg.163.com/reg/all/submit.do" method="post">
                    	<div id="regEmail">
                        
                            <input type="hidden" value="" name="url" id="url">
                            <input type="hidden" value="" name="product" id="product">
                            <input type="hidden" value="" name="refererPdt" id="refererPdt">
                            <input type="hidden" value="http://reg.163.com/" name="loginurl" id="loginurl">	
                            <input type="hidden" value="http%3A%2F%2Fj.news.163.com%2F" name="fromUrl" id="fromUrl">
                            <input type="hidden" value="0" name="u1" id="u1">
                            <input type="hidden" value="" name="codez" id="codez">
                            <input type="hidden" value="564505e7c3f85d410896616a74aae1e9d63db28f" id="syscheckcode" name="radomPassID">
                            
                        	<div class="m-ipt f-mb0">
                                <div class="u-ipt"><div class="iptctn"><input type="text" myholder="常用邮箱地址" autocapitalize="off" value="" id="email_name_r" name="username_r" placeholder="常用邮箱地址"></div></div>
                                <p class="u-tips">
                                	<em>&nbsp;</em><span></span>
                                </p>
                            </div>
                            <div class="regFormSplit">
                            	<a href="http://reg.163.com/reg/innerDomainReg.do?product=&amp;url=&amp;loginurl=http%3A%2F%2Freg.163.com%2F">没有邮箱？注册网易邮箱</a>
                            </div>
                            <div class="m-ipt">
                                <div class="u-ipt"><div class="iptctn"><input type="password" myholder="设置密码" autocapitalize="off" value="" id="password" name="password" placeholder="设置密码"></div></div>
                                <p class="u-tips">
                                	<em>&nbsp;</em><span></span>
                                </p>
                            </div>
                            <div class="m-ipt">
                                <div class="u-ipt"><div class="iptctn"><input type="password" myholder="确认密码" autocapitalize="off" value="" id="re_password" name="cpassword" placeholder="确认密码"></div></div>
                                <p class="u-tips">
                                	<em>&nbsp;</em><span></span>
                                </p>
                            </div>
                            <div class="m-ipt m-ipt-code">
                                <div class="u-ipt "><div class="iptctn"><input type="text" style="width:170px;" myholder="验证码" autocapitalize="off" id="usercheckcode" name="radomPass" placeholder="验证码"></div></div>
                                <img width="128" height="40" title="验证码" alt="验证码" src="/services/getimg?v=1407567422219&amp;id=564505e7c3f85d410896616a74aae1e9d63db28f" id="checkCode">
                                <a class="u-btn u-btn-img u-btn-img-code" href="javascript:void(0);"><span><em></em></span></a>
                                <p class="u-tips ">
                                	<em>&nbsp;</em><span></span>
                                </p>
                            </div>
                            <button class="u-btn2" type="submit">立即注册</button>
                        </div>
                        
<span class="u-check"><input type="checkbox" checked="checked" id="agree" name="agree"><label for="agree">我同意  <a target="_blank" href="http://reg.163.com/agreement.shtml?201405071000">" 服务条款  "</a> 和  <a target="_blank" href="http://reg.163.com/agreement_game.shtml?201405071000">" 网络游戏用户隐私权保护和个人信息利用政策 "</a></label></span>
                    </form>
                </div>
            </div>
            <!-- \tab模块 -->
            
        </div>
    </div>
</asp:Content>
