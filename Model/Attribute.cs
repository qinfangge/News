using System;
namespace CMS.Model
{
	/// <summary>
	/// Attribute:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Attribute
	{
		public Attribute()
		{}
		#region Model
		private int? _id;
		private string _name;
		private string _style;
		/// <summary>
		/// 
		/// </summary>
		public int? id
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
		public string style
		{
			set{ _style=value;}
			get{return _style;}
		}
		#endregion Model

	}
}

