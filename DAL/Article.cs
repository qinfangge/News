using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CMS.DAL
{
	/// <summary>
	/// 数据访问类:Article
	/// </summary>
	public partial class Article
	{
		public Article()
		{}
		#region  BasicMethod

		

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Article ");
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
			strSql.Append(")AS Row, T.*  from Article T ");
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
			parameters[0].Value = "Article";
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
                            FROM Article
                            WHERE id NOT IN
                                        (
                                        SELECT TOP  {1} id FROM Article {2} {3}
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
                            FROM Article
                             {1} {2}", number, strWhere, orderby);

            return DbHelperSQL.Query(strSql);

        }
		#endregion  ExtensionMethod
	}
}

