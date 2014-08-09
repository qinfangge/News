<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Contact.ascx.cs" Inherits="CMS.Web.Controls.Contact" %>
<style>

    .contact li {
        line-height:36px;
         font-family: "微软雅黑";
         color:#666;
    }
</style>
<div class="news_n contact">
    <h3 class="n_title">
        联系方式</h3>
    <div class="r_bor">

        
                    
                   

        <ul>
            
                    <li>
                        客服电话：<asp:Literal ID="Mobile" runat="server"></asp:Literal>
                    </li>
                    <li>
                       联系人：<asp:Literal ID="Contactor" runat="server"></asp:Literal>
                    </li>
                    <li>
                        传真：<asp:Literal ID="Fax" runat="server"></asp:Literal>
                    </li>
                
                    <li>
                         邮编：<asp:Literal ID="Zip" runat="server"></asp:Literal>
                    </li>
                
                    <li>
                        公司地址：<asp:Literal ID="Address" runat="server"></asp:Literal>
                    </li>
                
                    <li>
                        QQ:<asp:Literal ID="QQ" runat="server"></asp:Literal>
                    </li>
                
        </ul>
    </div>
</div>