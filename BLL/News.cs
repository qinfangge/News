/**  版本信息模板在安装目录下，可自行修改。
* News.cs
*
* 功 能： N/A
* 类 名： News
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/2/20 14:09:46   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CMS.Model;
namespace CMS.BLL
{
	/// <summary>
	/// News
	/// </summary>
	public partial class News
	{
		private readonly CMS.DAL.News dal=new CMS.DAL.News();
		public News()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CMS.Model.News model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CMS.Model.News model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CMS.Model.News GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CMS.Model.News GetModelByCache(int id)
        {

            string CacheKey = "NewsModel-" + id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CMS.Model.News)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CMS.Model.News> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CMS.Model.News> DataTableToList(DataTable dt)
        {
            List<CMS.Model.News> modelList = new List<CMS.Model.News>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CMS.Model.News model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
		#region  ExtensionMethod

           /// <summary>
        /// 获得用户推荐的新闻
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public DataSet GetMyRecommend(int userId)
        {
            return dal.GetMyRecommend(userId);
        }


          /// <summary>
        /// 我推荐的新闻 分页获取数据列表 for sql 2000
        /// </summary>
        public DataSet GetMyRecommendByPage(string condition, string order, int pageSize, int currentPage)
        {
            return dal.GetMyRecommendByPage(condition, order, pageSize, currentPage);
        }

          /// <summary>
        /// 获取我推荐的新闻总数
        /// </summary>
        public int GetMyRecommendRecordCount(int userId)
        {
            return dal.GetMyRecommendRecordCount(userId);
        }
        /// <summary>
        /// 得到上一个对象实体
        /// </summary>
        public CMS.Model.News GetPreviousModel(int id)
        {
            return dal.GetPreviousModel(id);
        }

        /// <summary>
        /// 得到下一个对象实体
        /// </summary>
        public CMS.Model.News GetNextModel(int id)
        {
            return dal.GetNextModel(id);
        }
        /// <summary>
        /// 分页获取数据列表 for sql 2000
        /// </summary>
        public DataSet GetListByPage(string condition, string order, int pageSize, int currentPage, bool isGeneral)
        {
            return dal.GetListByPage(condition, order, pageSize, currentPage, isGeneral);
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
            return dal.GetTopList(strWhere, orderby, number);
        }

        public int CacheTime { set; get; }

        public News Cache(int time)
        {
            this.CacheTime = time;
            return this;
        }

        public DataSet GetTopList(string strWhere, string orderby, int number,int cacheTime)
        {
            return dal.GetTopList(strWhere, orderby, number,cacheTime);
        }
        
        /// <summary>
        /// 获得文章的属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<string> GetAttribute(int id)
        {
            return dal.GetAttribute(id);
        }
        #endregion  ExtensionMethod
    }
}

