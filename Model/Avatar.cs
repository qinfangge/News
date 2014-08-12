/**  版本信息模板在安装目录下，可自行修改。
* Avatar.cs
*
* 功 能： N/A
* 类 名： Avatar
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/11 15:04:07   N/A    初版
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
	/// Avatar:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Avatar
	{
		public Avatar()
		{}
		#region Model
		private int _id;
		private string _picpath;
		private DateTime? _addtime;
		private int? _userid;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 头像
		/// </summary>
		public string picPath
		{
			set{ _picpath=value;}
			get{return _picpath;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? userID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		#endregion Model

	}
}

