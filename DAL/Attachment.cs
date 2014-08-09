/**  版本信息模板在安装目录下，可自行修改。
* Attachment.cs
*
* 功 能： N/A
* 类 名： Attachment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/1 14:16:51   N/A    初版
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
	/// 数据访问类:Attachment
	/// </summary>
	public partial class Attachment
	{
		public Attachment()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Attachment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Attachment");
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
		public int Add(CMS.Model.Attachment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Attachment(");
			strSql.Append("path,title,addTime,size,ext,fileName,userId)");
			strSql.Append(" values (");
			strSql.Append("@path,@title,@addTime,@size,@ext,@fileName,@userId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@path", SqlDbType.VarChar,500),
					new SqlParameter("@title", SqlDbType.VarChar,80),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@size", SqlDbType.Float,8),
					new SqlParameter("@ext", SqlDbType.VarChar,10),
					new SqlParameter("@fileName", SqlDbType.VarChar,80),
					new SqlParameter("@userId", SqlDbType.Int,4)};
			parameters[0].Value = model.path;
			parameters[1].Value = model.title;
			parameters[2].Value = model.addTime;
			parameters[3].Value = model.size;
			parameters[4].Value = model.ext;
			parameters[5].Value = model.fileName;
			parameters[6].Value = model.userId;

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
		public bool Update(CMS.Model.Attachment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Attachment set ");
			strSql.Append("path=@path,");
			strSql.Append("title=@title,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("size=@size,");
			strSql.Append("ext=@ext,");
			strSql.Append("fileName=@fileName,");
			strSql.Append("userId=@userId");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@path", SqlDbType.VarChar,500),
					new SqlParameter("@title", SqlDbType.VarChar,80),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@size", SqlDbType.Float,8),
					new SqlParameter("@ext", SqlDbType.VarChar,10),
					new SqlParameter("@fileName", SqlDbType.VarChar,80),
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.path;
			parameters[1].Value = model.title;
			parameters[2].Value = model.addTime;
			parameters[3].Value = model.size;
			parameters[4].Value = model.ext;
			parameters[5].Value = model.fileName;
			parameters[6].Value = model.userId;
			parameters[7].Value = model.id;

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
			strSql.Append("delete from Attachment ");
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
			strSql.Append("delete from Attachment ");
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
		public CMS.Model.Attachment GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,path,title,addTime,size,ext,fileName,userId from Attachment ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			CMS.Model.Attachment model=new CMS.Model.Attachment();
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
		public CMS.Model.Attachment DataRowToModel(DataRow row)
		{
			CMS.Model.Attachment model=new CMS.Model.Attachment();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["path"]!=null)
				{
					model.path=row["path"].ToString();
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["addTime"]!=null && row["addTime"].ToString()!="")
				{
					model.addTime=DateTime.Parse(row["addTime"].ToString());
				}
				if(row["size"]!=null && row["size"].ToString()!="")
				{
					model.size=decimal.Parse(row["size"].ToString());
				}
				if(row["ext"]!=null)
				{
					model.ext=row["ext"].ToString();
				}
				if(row["fileName"]!=null)
				{
					model.fileName=row["fileName"].ToString();
				}
				if(row["userId"]!=null && row["userId"].ToString()!="")
				{
					model.userId=int.Parse(row["userId"].ToString());
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
			strSql.Append("select id,path,title,addTime,size,ext,fileName,userId ");
			strSql.Append(" FROM Attachment ");
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
			strSql.Append(" id,path,title,addTime,size,ext,fileName,userId ");
			strSql.Append(" FROM Attachment ");
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
			strSql.Append("select count(1) FROM Attachment ");
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
			strSql.Append(")AS Row, T.*  from Attachment T ");
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
			parameters[0].Value = "Attachment";
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
            //                            FROM Attachment
            //                            WHERE id NOT IN
            //                                        (
            //                                        SELECT TOP  ({0} *( {1} -1)) id FROM product {2} {3}
            //                                        )
            //                            {4} {3}", pageSize, currentPage, condition, order, condition2);

            string strSql = string.Format(@"SELECT TOP  {0}  *
                            FROM Attachment
                            WHERE id NOT IN
                                        (
                                        SELECT TOP  {1} id FROM Attachment {2} {3}
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
                            FROM Attachment
                             {1} {2}", number, strWhere, orderby);

            return DbHelperSQL.Query(strSql);

        }
		#endregion  ExtensionMethod
	}
}

