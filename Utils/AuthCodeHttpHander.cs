/**
 * 
 * Summary:验证码产生器 高仿腾讯
 * Coder:Hwx
 * DateTime:2010/11/26 16:10:46
 * 
 * Version:1.0.1
 * 
 * Example:
 *  <httpHandlers>
 *      <add verb="*" path="vcode.aspx" type="tk.tingyuxuan.utils.AuthCodeHttpHander"/>
 *  </httpHandlers>
 */

using System;
using System.Web;
using System.Web.SessionState;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Text;

namespace tk.tingyuxuan.utils
{
    public class AuthCodeHttpHander : IHttpHandler, IRequiresSessionState
    {
        protected static string VCODE_SESSION = "vcode";//session 中的值

        protected static Types VCODE_TYPE = Types.Number;//验证码类型

        protected static int VCODE_LENGTH = 4;//字符串长度

        protected static bool VCODE_IsEncrypt = false;//是否加密

        protected static bool VCODE_IsIgnore = false;//忽略大小写。

        //产生图片 宽度：_WIDTH, 高度：_HEIGHT
        //private static readonly int _WIDTH = 130, _HEIGHT = 53;
        private static readonly int _WIDTH = 100, _HEIGHT = 50;
        //字体集
        //private static readonly string[] _FONT_FAMIly = { "Arial", "Arial Black", "Arial Italic", "Courier New", "Courier New Bold Italic", "Courier New Italic", "Courier New Italic", "Courier New Bold Italic" };
        private static readonly string[] _FONT_FAMIly = { "Arial", "Arial Black", "Arial Italic", "Courier New", "Courier New Bold Italic", "Courier New Italic" };
        //字体大小集
        private static readonly int[] _FONT_SIZE = { 20, 22, 24 };
        //前景字体颜色集
        private static readonly Color[] _COLOR_FACE = { Color.FromArgb(113, 153, 67), Color.FromArgb(30, 99, 140), Color.FromArgb(206, 60, 19), Color.FromArgb(227, 60, 0) };
        //背景颜色集
        private static readonly Color[] _COLOR_BACKGROUND = { Color.FromArgb(247, 254, 236), Color.FromArgb(234, 248, 255), Color.FromArgb(244, 250, 246), Color.FromArgb(248, 248, 248) };

        //文本布局信息
        private static StringFormat _DL_FORMAT = new StringFormat(StringFormatFlags.NoClip);
        //左右旋转角度
        private static readonly int _ANGLE = 60;
        private Random rnd=new Random();

        private string RandomNum(int length)
        {
            string randomNum = "";
            int i = 0;
            while (i < length)
            {
                randomNum += rnd.Next(0, 9).ToString();
                i++;
            }
            return randomNum;
        }


        public char getRandomChar()
        {
            int ret = rnd.Next(122);
            while (ret < 48 || (ret > 57 && ret < 65) || (ret > 90 && ret < 97))
            {
                ret = rnd.Next(122);
            }
            return (char)ret;
        }
        public string RandomString(int length)
        {
            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                sb.Append(getRandomChar());
            }
            return sb.ToString();
        }

        private string GetCheckCode(HttpContext context)
        {
            Random rnd = new Random();
            string _checkCode = string.Empty;

            if (VCODE_TYPE == Types.Number)
                _checkCode = RandomNum(VCODE_LENGTH);
            else
                _checkCode = RandomString(VCODE_LENGTH);

            if (VCODE_IsEncrypt)
            {
                //context.Session[VCODE_SESSION] = MD5.Encode(VCODE_IsIgnore ? _checkCode : _checkCode.ToLower());
            }else
                context.Session[VCODE_SESSION] = VCODE_IsIgnore ? _checkCode : _checkCode.ToLower();

            return _checkCode;
        }

        private void CreateImage(string code, HttpContext context)
        {

            _DL_FORMAT.Alignment = StringAlignment.Center;
            _DL_FORMAT.LineAlignment = StringAlignment.Center;

            long tick = DateTime.Now.Ticks;
            Random Rnd = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));

            using (Bitmap _img = new Bitmap(_WIDTH, _HEIGHT))
            {
                using (Graphics g = Graphics.FromImage(_img))
                {
                    g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                    Point dot = new Point(20, 20);

                    // 定义一个无干扰线区间和一个起始位置
                    int nor = Rnd.Next(53), rsta = Rnd.Next(130);
                    // 绘制干扰正弦曲线 M:曲线平折度, D:Y轴常量 V:X轴焦距
                    int M = Rnd.Next(15) + 5, D = Rnd.Next(20) + 15, V = Rnd.Next(5) + 1;

                    int ColorIndex = Rnd.Next(4);

                    float Px_x = 0.0F;
                    float Px_y = Convert.ToSingle(M * Math.Sin(V * Px_x * Math.PI / 180) + D);
                    float Py_x, Py_y;

                    //填充背景
                    g.Clear(_COLOR_BACKGROUND[Rnd.Next(4)]);

                    //前景刷子 //背景刷子
                    using (Brush _BrushFace = new SolidBrush(_COLOR_FACE[ColorIndex]))
                    {
                        #region 绘制正弦线
                        for (int i = 0; i < 131; i++)
                        {

                            //初始化y点
                            Py_x = Px_x + 1;
                            Py_y = Convert.ToSingle(M * Math.Sin(V * Py_x * Math.PI / 180) + D);

                            //确定线条颜色
                            if (rsta >= i || i > (rsta + nor))
                                //初始化画笔
                                using (Pen _pen = new Pen(_BrushFace, Rnd.Next(2, 4) + 1.5F))
                                {
                                    //绘制线条
                                    g.DrawLine(_pen, Px_x, Px_y, Py_x, Py_y);
                                }

                            //交替x,y坐标点
                            Px_x = Py_x;
                            Px_y = Py_y;
                        }
                        #endregion

                        //初始化光标的开始位置
                        g.TranslateTransform(18, 4);

                        #region 绘制校验码字符串
                        for (int i = 0; i < code.Length; i++)
                        {
                            //随机旋转 角度
                            int angle = Rnd.Next(-_ANGLE, _ANGLE);
                            //移动光标到指定位置
                            g.TranslateTransform(dot.X, dot.Y);
                            //旋转
                            g.RotateTransform(angle);

                            //初始化字体
                            using (Font _font = new Font(_FONT_FAMIly[Rnd.Next(0, 6)], _FONT_SIZE[Rnd.Next(0, 3)]))
                            {
                                //绘制
                                g.DrawString(code[i].ToString(), _font, _BrushFace, 1, 1, _DL_FORMAT);
                            }
                            //反转
                            g.RotateTransform(-angle);
                            //重新定位光标位置
                            g.TranslateTransform(-2, -dot.Y);
                        }
                        #endregion

                    }
                }

                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    context.Response.ContentType = "Image/PNG";
                    context.Response.Clear();
                    context.Response.BufferOutput = true;
                    _img.Save(ms, ImageFormat.Png);
                    ms.Flush();
                    context.Response.BinaryWrite(ms.GetBuffer());
                    context.Response.End();
                }
            }

        }

        protected enum Types
        {
            Number,
            Character
        }



        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            CreateImage(GetCheckCode(context), context);
        }
    }
}