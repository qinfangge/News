<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadPic.ascx.cs" Inherits="CMS.Web.Admin.Controls.UploadPic" %>
<link href="/js/libs/uploadify/uploadify.css" rel="stylesheet" type="text/css" />
<script src="/js/libs/uploadify/jquery.uploadify.min.js" type="text/javascript"></script>
<script src="/js/base64.js" type="text/javascript"></script>
 <style>
        #picUpload {
           
            clear: both;
        }
        #fileQueue {
            background:#fff;
            border:1px solid #ccc;
            padding:10px;
            z-index:9999;
            display:none;
        }
            #picUpload table {
                width:auto;
                border-spacing:10px 5px;
                border-collapse:initial;
            }
            .formView #picUpload table td {
                width:100px;
                height:100px;
                vertical-align:middle;
                border:1px solid #ccc;
                padding:0;
                margin-right:10px;
                position:relative;
            }

         #picUpload .close {
            position:absolute;
            top:5px;
            right:5px;
            width:auto;
            cursor:pointer;
        }

     #picPreView td {
         text-align:center;
         vertical-align:middle;
     }
           

                #picUpload  img {
                  
                    margin:2px;
                }
    </style>
    <script type="text/javascript">
        //设置标题图片
        function setTitleImage() {
            var ids = "";
            $("img.close").each(function () {
                ids += $(this).attr("id") + ",";

            });
            ids = ids.substring(0, ids.length - 1);
           
            $("#<%=this.Parent.FindControl("Avatar").ClientID%>").val(ids);
        }

        function initPreViewImage(id) {
            var b = new Base64();
            var rand = Math.random();
            //var src = "/avatar/" + b.encode("100|100|" + id) + ".jpg?"+rand;
            var big = "/avatar/" + b.encode("120|120|" + id) + ".jpg?" + rand;
            var middle = "/avatar/" + b.encode("48|48|" + id) + ".jpg?" + rand;
            var small = "/avatar/" + b.encode("38|38|" + id) + ".jpg?" + rand;
            $("#picPreView tr:eq(0)").empty().append('<td><img class="prevView" src="' + big + '"/><br/>120*120</td><td><img class="prevView" src="' + middle + '"/><br/>48*48</td><td><img class="prevView" src="' + small + '"/><br/>38*38</td>');
        }
        $(function () {

            var ids = $("#<%=this.Parent.FindControl("Avatar").ClientID%>").val();
            if (ids != "") {
                var idsArray = ids.split(",");
                for (var id in idsArray) {
                    initPreViewImage(idsArray[id]);
                }
            }

            $("img.close").live("click", function () {
                var length = $("img.close").length;

                var animate = { width: "0px" };

                if (length == 1) {
                    animate = { height: "0px" };
                }
                var currentTD = $(this).parent();
                var url = "/ashx/UploadHandler.ashx";
                var path = $(this).attr("id");
                var data = { a: "del", path: path };
                $.post(url, data, function (data) {
                    if (data == "1") {
                        currentTD.animate(animate, 1000, function () {
                            currentTD.remove();
                            setTitleImage();//设置标题图片
                        });

                    } else {
                        alert(data);
                    }
                });


            });

            var auth = "<% = Request.Cookies[FormsAuthentication.FormsCookieName]==null ? string.Empty : Request.Cookies[FormsAuthentication.FormsCookieName].Value %>";
            var ASPSESSID = "<%= Session.SessionID %>";

            $("#<%=FileUpload1.ClientID%>").uploadify({
                //指定swf文件
                'swf': '../js/libs/uploadify/uploadify.swf',
                //后台处理的页面
                'uploader': '/ashx/UploadHandler.ashx?a=add',
                //按钮显示的文字
                'buttonText': '上传图片',
                //显示的高度和宽度，默认 height 30；width 120
                //'height': 15,
                //'width': 80,
                //上传文件的类型  默认为所有文件    'All Files'  ;  '*.*'
                //在浏览窗口底部的文件类型下拉菜单中显示的文本
                'fileTypeDesc': '图片',

                //允许上传的文件后缀
                'fileTypeExts': '*.gif; *.jpg; *.png',
                //发送给后台的其他参数通过formData指定


                formData: { ASPSESSID: ASPSESSID, AUTHID: auth },
                //上传文件页面中，你想要用来作为文件队列的元素的id, 默认为false  自动生成,  不带#
                'queueID': 'fileQueue',
                //选择文件后自动上传
                'auto': true,
                //设置为true将允许多文件上传
                'multi': true,

                'fileSizeLimit': '2MB',
                //上传数量
                'queueSizeLimit': 1,
                'onUploadSuccess': function (file, data, response) {

                    $('#' + file.id).find('.data').html(' 上传完毕');
                    initPreViewImage(data);
                },
                'onUploadStart': function (file) {
                    $('#fileQueue').show();
                },
                'onSelect': function (file) {
                    //alert(
                    //      "文件名：" + file.name + "\r\n" +
                    //      "文件大小：" + file.size + "\r\n" +
                    //      "创建时间：" + file.creationDate + "\r\n" +
                    //      "最后修改时间：" + file.modificationDate + "\r\n" +
                    //      "文件类型：" + file.type
                    //);

                },
                onQueueComplete: function (stats) {//当队列中的所有文件全部完成上传时触发
                    //alert( '成功上传的文件数: ' + stats.successful_uploads
                    //+ ' - 上传出错的文件数: ' + stats.upload_errors
                    //+ ' - 取消上传的文件数: ' + stats.upload_cancelled
                    //+ ' - 出错的文件数' + stats.queue_errors);
                    $('#fileQueue').hide();

                    setTitleImage();//设置标题图片



                },
                //返回一个错误，选择文件的时候触发
                'onSelectError': function (file, errorCode, errorMsg) {
                    switch (errorCode) {
                        case -100:
                            alert("上传的文件数量已经超出系统限制的" + $('#file_upload').uploadify('settings', 'queueSizeLimit') + "个文件！");
                            break;
                        case -110:
                            alert("文件 [" + file.name + "] 大小超出系统限制的" + $('#file_upload').uploadify('settings', 'fileSizeLimit') + "大小！");
                            break;
                        case -120:
                            alert("文件 [" + file.name + "] 大小异常！");
                            break;
                        case -130:
                            alert("文件 [" + file.name + "] 类型不正确！");
                            break;
                    }
                },
            });
        });

    </script>
  <asp:FileUpload ID="FileUpload1" runat="server" />
                        <div id="picUpload" style="position:relative;">
                             <div id="fileQueue" style="position:absolute;">

                        </div>
                            <table id="picPreView"  cellpadding="5px" cellspacing="5px">
                                <tr>
                                   </tr>
                            </table>
                           
                       <%-- <p>
             <a href="javascript:$('#<%=FileUpload1.ClientID %>').uploadify('upload')">上传</a>| 
            <a href="javascript:$('#<%=FileUpload1.ClientID %>').uploadify('cancel')">取消上传</a>
                        </p>--%>
                    </div>