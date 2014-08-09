using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.Model;
using Maticsoft.Common;
using tk.tingyuxuan.utils;

namespace CMS.Web.Admin.Config
{
    public partial class Config : CommonPage
    {
        private string ConfigPath { set; get; }

        public Config()
        {
            ConfigPath = "~/App_Data/Config.txt";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CMS.Model.Config config = this.ReadConfig();
                SiteName.Text = config.SiteName;
                KeyWords.Text = config.KeyWords;
                Other.Text = config.Other;
                Description.Text = config.Description;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CMS.Model.Config config = new CMS.Model.Config();
            config.SiteName = SiteName.Text;
            config.KeyWords = KeyWords.Text;
            config.Description = Description.Text;
            config.Other = Other.Text;
            WriteConfig(config);
            MessageBoxTip.Alert(this, "保存成功！");
        }

        public void WriteConfig(CMS.Model.Config config)
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string result = serializer.Serialize(config);
                StreamWriter writer = File.CreateText(Server.MapPath(ConfigPath));
                writer.Write(result);
               // writer.Close();
                writer.Dispose();
                
            }
            catch (Exception ex)
            {
                throw new Exception("保存出错了，请重试！原因：" + ex.Message);
            }
        }

        public CMS.Model.Config ReadConfig()
        {
            CMS.Model.Config config = new CMS.Model.Config();
            try
            {
                StreamReader reader = File.OpenText(Server.MapPath(ConfigPath));
                string str = reader.ReadToEnd();
                //reader.Close();
                reader.Dispose();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                config = serializer.Deserialize<CMS.Model.Config>(str);
                

            }
            catch (Exception ex)
            {
                //throw new Exception("读取联系方式出错了！原因："+ex.Message);
            }

            return config;
        }

    }
}