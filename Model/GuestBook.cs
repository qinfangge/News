/**  版本信息模板在安装目录下，可自行修改。
* GuestBook.cs
*
* 功 能： N/A
* 类 名： GuestBook
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/2/21 16:47:14   N/A    初版
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
	/// GuestBook:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GuestBook
	{
		public GuestBook()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _name;
		private string _mobile;
		private string _content;
		private DateTime? _addtime;
		private string _reply;
		private DateTime? _replytime;
		private bool _ischecked= false;
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
		public string title
		{
			set{ _title=value;}
			get{return _title;}
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
		public string mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string reply
		{
			set{ _reply=value;}
			get{return _reply;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? replyTime
		{
			set{ _replytime=value;}
			get{return _replytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isChecked
		{
			set{ _ischecked=value;}
			get{return _ischecked;}
		}
		#endregion Model

	}
}

