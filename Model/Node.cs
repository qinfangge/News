/**  版本信息模板在安装目录下，可自行修改。
* Node.cs
*
* 功 能： N/A
* 类 名： Node
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/3/24 14:13:07   N/A    初版
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
	/// Node:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Node
	{
		public Node()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _url;
		private int? _sort;
		private int? _groupid;
		private bool _ismenu;
		private string _menuname;
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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? groupId
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isMenu
		{
			set{ _ismenu=value;}
			get{return _ismenu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string menuName
		{
			set{ _menuname=value;}
			get{return _menuname;}
		}
		#endregion Model

	}
}

