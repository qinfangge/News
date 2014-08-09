using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CMS.DAL
{
	/// <summary>
	/// 数据访问类:Attribute
	/// </summary>
	public partial class Attribute
	{
		public Attribute()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CMS.Model.Attribute model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Attribute(");
			strSql.Append("id,name,style)");
			strSql.Append(" values (");
			strSql.Append("@id,@name,@style)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@style", SqlDbType.VarChar,100)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.name;
			parameters[2].Value = model.style;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(CMS.Model.Attribute model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Attribute set ");
			strSql.Append("id=@id,");
			strSql.Append("name=@name,");
			strSql.Append("style=@style");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@style", SqlDbType.VarChar,100)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.name;
			parameters[2].Value = model.style;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Attribute ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public CMS.Model.Attribute GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,name,style from Attribute ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			CMS.Model.Attribute model=new CMS.Model.Attribute();
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
		public CMS.Model.Attribute DataRowToModel(DataRow row)
		{
			CMS.Model.Attribute model=new CMS.Model.Attribute();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["style"]!=null)
				{
					model.style=row["style"].ToString();
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
			strSql.Append("select id,name,style ");
			strSql.Append(" FROM Attribute ");
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
			strSql.Append(" id,name,style ");
			strSql.Append(" FROM Attribute ");
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
			strSql.Append("select count(1) FROM Attribute ");
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
			strSql.Append(")AS Row, T.*  from Attribute T ");
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
			parameters[0].Value = "Attribute";
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
                            FROM Attribute
                            WHERE id NOT IN
                                        (
                                        SELECT TOP  {1} id FROM Attribute {2} {3}
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
                            FROM Attribute
                             {1} {2}", number, strWhere, orderby);

            return DbHelperSQL.Query(strSql);

        }



		#endregion  ExtensionMethod
	}
}

