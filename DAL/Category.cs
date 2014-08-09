/**  版本信息模板在安装目录下，可自行修改。
* Category.cs
*
* 功 能： N/A
* 类 名： Category
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/2/25 15:16:50   N/A    初版
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
using Maticsoft.DBUtility;
using tk.tingyuxuan.utils;//Please add references
namespace CMS.DAL
{
    /// <summary>
    /// 数据访问类:Category
    /// </summary>
    public partial class Category
    {
        public Category()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "Category");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Category");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CMS.Model.Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Category(");
            strSql.Append("name,pid,sort,keywords,description)");
            strSql.Append(" values (");
            strSql.Append("@name,@pid,@sort,@keywords,@description)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@keywords", SqlDbType.VarChar,100),
					new SqlParameter("@description", SqlDbType.VarChar,300)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.pid;
            parameters[2].Value = model.sort;
            parameters[3].Value = model.keywords;
            parameters[4].Value = model.description;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(CMS.Model.Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Category set ");
            strSql.Append("name=@name,");
            strSql.Append("pid=@pid,");
            strSql.Append("sort=@sort,");
            strSql.Append("keywords=@keywords,");
            strSql.Append("description=@description");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@keywords", SqlDbType.VarChar,100),
					new SqlParameter("@description", SqlDbType.VarChar,300),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.pid;
            parameters[2].Value = model.sort;
            parameters[3].Value = model.keywords;
            parameters[4].Value = model.description;
            parameters[5].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Category ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Category ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public CMS.Model.Category GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,name,pid,sort,keywords,description from Category ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            CMS.Model.Category model = new CMS.Model.Category();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public CMS.Model.Category DataRowToModel(DataRow row)
        {
            CMS.Model.Category model = new CMS.Model.Category();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["pid"] != null && row["pid"].ToString() != "")
                {
                    model.pid = int.Parse(row["pid"].ToString());
                }
                if (row["sort"] != null && row["sort"].ToString() != "")
                {
                    model.sort = int.Parse(row["sort"].ToString());
                }
                if (row["keywords"] != null)
                {
                    model.keywords = row["keywords"].ToString();
                }
                if (row["description"] != null)
                {
                    model.description = row["description"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,name,pid,sort,keywords,description ");
            strSql.Append(" FROM Category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,name,pid,sort");
            strSql.Append(" FROM Category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("order by sort asc");
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,name,pid,sort,keywords,description ");
            strSql.Append(" FROM Category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from Category T ");
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
            parameters[0].Value = "Category";
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
        public DataTable GetCategoryForSelect(int pid)
        {

            DataSet ds = GetAllList("");
            DataTable table = ds.Tables["ds"];
            DataTable newTable = new DataTable();
            DataColumn column = new DataColumn();
            DataRow newRow = newTable.NewRow();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            newTable.Columns.Add(column);
            //再创建一个新列
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "name";
            newTable.Columns.Add(column);
            //再创建一个新列
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "level";
            newTable.Columns.Add(column);

            tk.tingyuxuan.utils.Category.unlimitedLayer(table, pid, newTable, "　", 0);

            return newTable;
        }

        public DataTable GetChildren(int pid)
        {
            DataSet ds = GetAllList("");
            DataTable table = ds.Tables["ds"];
            DataTable newTable = new DataTable();
            DataColumn column = new DataColumn();
            DataRow newRow = newTable.NewRow();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            newTable.Columns.Add(column);
            //再创建一个新列
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "name";
            newTable.Columns.Add(column);

            tk.tingyuxuan.utils.Category.GetChildren(table, pid, newTable);
            return newTable;
        }

        public DataTable GetParents(int id)
        {
            DataSet ds = GetAllList("");
            DataTable table = ds.Tables["ds"];
            DataTable newTable = new DataTable();
            DataColumn column = new DataColumn();
            DataRow newRow = newTable.NewRow();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            newTable.Columns.Add(column);
            //再创建一个新列
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "name";
            newTable.Columns.Add(column);
            //再创建一个新列
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "pid";
            newTable.Columns.Add(column);

            tk.tingyuxuan.utils.Category.GetParents(table, id, newTable);

           


            DataTable reverseTable = newTable.Clone();

            int count = newTable.Rows.Count - 1;
            for (int i = count; i >= 0; i--)
            {
                reverseTable.Rows.Add(newTable.Rows[i].ItemArray);
            }
            return reverseTable;
        }

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
                            FROM Category
                            WHERE id NOT IN
                                        (
                                        SELECT TOP  {1} id FROM Category {2} {3}
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
                            FROM Category
                             {1} {2}", number, strWhere, orderby);

            return DbHelperSQL.Query(strSql);

        }



        #endregion  ExtensionMethod
    }
}

