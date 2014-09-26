/**  版本信息模板在安装目录下，可自行修改。
* MyRecommend.cs
*
* 功 能： N/A
* 类 名： MyRecommend
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/24 13:51:30   N/A    初版
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
	/// MyRecommend:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MyRecommend
	{
		public MyRecommend()
		{}
		#region Model
		private int _id;
		private int _newsid;
		private int? _userid;
		private DateTime? _addtime;
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
		public int newsID
		{
			set{ _newsid=value;}
			get{return _newsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? userID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

