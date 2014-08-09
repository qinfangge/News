/**  版本信息模板在安装目录下，可自行修改。
* Notice.cs
*
* 功 能： N/A
* 类 名： Notice
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/2/20 14:52:49   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CMS.DAL
{
	/// <summary>
	/// 数据访问类:Notice
	/// </summary>
	public partial class Notice
	{
		public Notice()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Notice"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Notice");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CMS.Model.Notice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Notice(");
			strSql.Append("title,startTime,titleImage,content,keywords,description,addTime,category,recommend,userId,isDel,hit,isSwitch)");
			strSql.Append(" values (");
			strSql.Append("@title,@startTime,@titleImage,@content,@keywords,@description,@addTime,@category,@recommend,@userId,@isDel,@hit,@isSwitch)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@startTime", SqlDbType.DateTime),
					new SqlParameter("@titleImage", SqlDbType.VarChar,100),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@keywords", SqlDbType.VarChar,100),
					new SqlParameter("@description", SqlDbType.VarChar,300),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@category", SqlDbType.Int,4),
					new SqlParameter("@recommend", SqlDbType.Int,4),
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@isDel", SqlDbType.Bit,1),
					new SqlParameter("@hit", SqlDbType.Int,4),
					new SqlParameter("@isSwitch", SqlDbType.Bit,1)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.startTime;
			parameters[2].Value = model.titleImage;
			parameters[3].Value = model.content;
			parameters[4].Value = model.keywords;
			parameters[5].Value = model.description;
			parameters[6].Value = model.addTime;
			parameters[7].Value = model.category;
			parameters[8].Value = model.recommend;
			parameters[9].Value = model.userId;
			parameters[10].Value = model.isDel;
			parameters[11].Value = model.hit;
			parameters[12].Value = model.isSwitch;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CMS.Model.Notice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Notice set ");
			strSql.Append("title=@title,");
			strSql.Append("startTime=@startTime,");
			strSql.Append("titleImage=@titleImage,");
			strSql.Append("content=@content,");
			strSql.Append("keywords=@keywords,");
			strSql.Append("description=@description,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("category=@category,");
			strSql.Append("recommend=@recommend,");
			strSql.Append("userId=@userId,");
			strSql.Append("isDel=@isDel,");
			strSql.Append("hit=@hit,");
			strSql.Append("isSwitch=@isSwitch");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@startTime", SqlDbType.DateTime),
					new SqlParameter("@titleImage", SqlDbType.VarChar,100),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@keywords", SqlDbType.VarChar,100),
					new SqlParameter("@description", SqlDbType.VarChar,300),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@category", SqlDbType.Int,4),
					new SqlParameter("@recommend", SqlDbType.Int,4),
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@isDel", SqlDbType.Bit,1),
					new SqlParameter("@hit", SqlDbType.Int,4),
					new SqlParameter("@isSwitch", SqlDbType.Bit,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.startTime;
			parameters[2].Value = model.titleImage;
			parameters[3].Value = model.content;
			parameters[4].Value = model.keywords;
			parameters[5].Value = model.description;
			parameters[6].Value = model.addTime;
			parameters[7].Value = model.category;
			parameters[8].Value = model.recommend;
			parameters[9].Value = model.userId;
			parameters[10].Value = model.isDel;
			parameters[11].Value = model.hit;
			parameters[12].Value = model.isSwitch;
			parameters[13].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Notice ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Notice ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CMS.Model.Notice GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,title,startTime,titleImage,content,keywords,description,addTime,category,recommend,userId,isDel,hit,isSwitch from Notice ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			CMS.Model.Notice model=new CMS.Model.Notice();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CMS.Model.Notice DataRowToModel(DataRow row)
		{
			CMS.Model.Notice model=new CMS.Model.Notice();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["startTime"]!=null && row["startTime"].ToString()!="")
				{
					model.startTime=DateTime.Parse(row["startTime"].ToString());
				}
				if(row["titleImage"]!=null)
				{
					model.titleImage=row["titleImage"].ToString();
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
				}
				if(row["keywords"]!=null)
				{
					model.keywords=row["keywords"].ToString();
				}
				if(row["description"]!=null)
				{
					model.description=row["description"].ToString();
				}
				if(row["addTime"]!=null && row["addTime"].ToString()!="")
				{
					model.addTime=DateTime.Parse(row["addTime"].ToString());
				}
				if(row["category"]!=null && row["category"].ToString()!="")
				{
					model.category=int.Parse(row["category"].ToString());
				}
				if(row["recommend"]!=null && row["recommend"].ToString()!="")
				{
					model.recommend=int.Parse(row["recommend"].ToString());
				}
				if(row["userId"]!=null && row["userId"].ToString()!="")
				{
					model.userId=int.Parse(row["userId"].ToString());
				}
				if(row["isDel"]!=null && row["isDel"].ToString()!="")
				{
					if((row["isDel"].ToString()=="1")||(row["isDel"].ToString().ToLower()=="true"))
					{
						model.isDel=true;
					}
					else
					{
						model.isDel=false;
					}
				}
				if(row["hit"]!=null && row["hit"].ToString()!="")
				{
					model.hit=int.Parse(row["hit"].ToString());
				}
				if(row["isSwitch"]!=null && row["isSwitch"].ToString()!="")
				{
					if((row["isSwitch"].ToString()=="1")||(row["isSwitch"].ToString().ToLower()=="true"))
					{
						model.isSwitch=true;
					}
					else
					{
						model.isSwitch=false;
					}
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,title,startTime,titleImage,content,keywords,description,addTime,category,recommend,userId,isDel,hit,isSwitch ");
			strSql.Append(" FROM Notice ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,title,startTime,titleImage,content,keywords,description,addTime,category,recommend,userId,isDel,hit,isSwitch ");
			strSql.Append(" FROM Notice ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Notice ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from Notice T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Notice";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 分页获取数据列表 for sql 2000
        /// </summary>
        public DataSet GetListByPage(string condition, string order, int pageSize, int currentPage, bool isGeneral)
        {
            string condition2 = condition == "" ? "" : " AND " + condition;
            condition = condition == "" ? "" : "where " + condition;
            order = order == "" ? "" : " order by " + order;
            //            string sql = string.Format(@"SELECT TOP  {0}  *
            //                            FROM product
            //                            WHERE id NOT IN
            //                                        (
            //                                        SELECT TOP  ({0} *( {1} -1)) id FROM product {2} {3}
            //                                        )
            //                            {4} {3}", pageSize, currentPage, condition, order, condition2);

            string strSql = string.Format(@"SELECT TOP  {0}  *
                            FROM Notice
                            WHERE id NOT IN
                                        (
                                        SELECT TOP  {1} id FROM Notice {2} {3}
                                        )
                            {4} {3}", pageSize, pageSize * (currentPage - 1), condition, order, condition2);

            return DbHelperSQL.Query(strSql);

        }

        /// <summary>
        /// 获取前几条数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public DataSet GetTopList(string strWhere, string orderby, int number)
        {
            //string strWhere2 = strWhere == "" ? "" : " AND " + strWhere;
            strWhere = strWhere == "" ? "" : "where " + strWhere;

            orderby = orderby == "" ? "" : " order by " + orderby;

            string strSql = string.Format(@"SELECT TOP  {0}  *
                            FROM Notice
                             {1} {2}", number, strWhere, orderby);

            return DbHelperSQL.Query(strSql);

        }



		#endregion  ExtensionMethod
	}
}

