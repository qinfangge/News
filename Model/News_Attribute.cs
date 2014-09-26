/**  版本信息模板在安装目录下，可自行修改。
* News_Attribute.cs
*
* 功 能： N/A
* 类 名： News_Attribute
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/31 12:40:07   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace CMS.Model
{
	/// <summary>
	/// News_Attribute:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class News_Attribute
	{
		public News_Attribute()
		{}
		#region Model
		private int _id;
		private int? _newsid;
		private int? _attributeid;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? NewsID
		{
			set{ _newsid=value;}
			get{return _newsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AttributeID
		{
			set{ _attributeid=value;}
			get{return _attributeid;}
		}
		#endregion Model

	}
}

