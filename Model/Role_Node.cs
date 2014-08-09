/**  版本信息模板在安装目录下，可自行修改。
* Role_Node.cs
*
* 功 能： N/A
* 类 名： Role_Node
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/3/25 16:23:41   N/A    初版
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
	/// Role_Node:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Role_Node
	{
		public Role_Node()
		{}
		#region Model
		private int _id;
		private int? _roleid;
		private int? _nodeid;
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
		public int? roleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? nodeId
		{
			set{ _nodeid=value;}
			get{return _nodeid;}
		}
		#endregion Model

	}
}

