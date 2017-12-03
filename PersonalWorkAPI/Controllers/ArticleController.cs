using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections;
using System.Configuration;
using System.Web;
using System.IO;
using System.Globalization;
using PersonalWorkAPI.DAL;
using PersonalWorkAPI.Model;
using PersonalWorkAPI.Common;
using System.Text; 

namespace PersonalWorkAPI.Controllers
{
    public class ArticleController : ApiController
    {
        private readonly PersonalWorkAPI.DAL.article dal = new PersonalWorkAPI.DAL.article();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [HttpPost]
        public HttpResponseMessage Add(PersonalWorkAPI.Model.article model)
        { 
            ReturnBaseObject<Boolean> returnObj = new ReturnBaseObject<Boolean>();
            try
            {
                returnObj.ReturnObject = dal.Add(model);

                returnObj.IsError = false;

            }
            catch (Exception ex)
            { 
                returnObj.IsError = true;
                returnObj.Error.ErrorMsg = ex.Message.ToString();
                returnObj.Error.ErrorCode = Error.EnumErrorCode.未知错误;
            }

            string str = Jil.JSON.Serialize<ReturnBaseObject<Boolean>>(returnObj);
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [HttpPost]
        public HttpResponseMessage Update(PersonalWorkAPI.Model.article model)
        {
            ReturnBaseObject<Boolean> returnObj = new ReturnBaseObject<Boolean>();
            try
            {
                returnObj.ReturnObject = dal.Update(model);

                returnObj.IsError = false;

            }
            catch (Exception ex)
            {
                returnObj.IsError = true;
                returnObj.Error.ErrorMsg = ex.Message.ToString();
                returnObj.Error.ErrorCode = Error.EnumErrorCode.未知错误;
            }

            string str = Jil.JSON.Serialize<ReturnBaseObject<Boolean>>(returnObj);
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [HttpPost]
        public HttpResponseMessage Delete(int article_id)
        {
            ReturnBaseObject<Boolean> returnObj = new ReturnBaseObject<Boolean>();
            try
            {
                returnObj.ReturnObject = dal.Delete(article_id);

                returnObj.IsError = false;

            }
            catch (Exception ex)
            {
                returnObj.IsError = true;
                returnObj.Error.ErrorMsg = ex.Message.ToString();
                returnObj.Error.ErrorCode = Error.EnumErrorCode.未知错误;
            }

            string str = Jil.JSON.Serialize<ReturnBaseObject<Boolean>>(returnObj);
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }

        /// <summary>
        /// 批量删除数据
        /// </summary> 
        [HttpPost]
        public HttpResponseMessage DeleteList(string article_id)
        {
            ReturnBaseObject<Boolean> returnObj = new ReturnBaseObject<Boolean>();
            try
            {
                returnObj.ReturnObject = dal.DeleteList(article_id);

                returnObj.IsError = false;

            }
            catch (Exception ex)
            {
                returnObj.IsError = true;
                returnObj.Error.ErrorMsg = ex.Message.ToString();
                returnObj.Error.ErrorCode = Error.EnumErrorCode.未知错误;
            }

            string str = Jil.JSON.Serialize<ReturnBaseObject<Boolean>>(returnObj);
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary> 
        [HttpGet]
        public HttpResponseMessage GetModel(int article_id)
        {
            ReturnBaseObject<PersonalWorkAPI.Model.article> returnObj = new ReturnBaseObject<PersonalWorkAPI.Model.article>();
            try
            {
                returnObj.ReturnObject = dal.GetModel(article_id);

                returnObj.IsError = false;

            }
            catch (Exception ex)
            {
                returnObj.IsError = true;
                returnObj.Error.ErrorMsg = ex.Message.ToString();
                returnObj.Error.ErrorCode = Error.EnumErrorCode.未知错误;
            }

            string str = Jil.JSON.Serialize<ReturnBaseObject<PersonalWorkAPI.Model.article>>(returnObj);
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<PersonalWorkAPI.Model.article> GetModelList(string strWhere)
        //{
        //    DataSet ds = dal.GetList(strWhere);
        //    return DataTableToList(ds.Tables[0]);
        //}

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="strWhere">查询条件%需要写成%25</param>
        /// <param name="pageSize">每页行数</param>
        /// <param name="pageIndex">第几页</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetList(string strWhere, int pageSize, int pageIndex)
        {
            strWhere = ( strWhere==null) ? "" : strWhere;
            ReturnBaseObject<IEnumerable<PersonalWorkAPI.Model.article>> returnObj = new ReturnBaseObject<IEnumerable<PersonalWorkAPI.Model.article>>() { ReturnObject = new List<PersonalWorkAPI.Model.article>() };
            try 
            {
                int pageCount = 0; 
                returnObj.ReturnObject = dal.GetModelList(strWhere, pageSize, pageIndex, ref pageCount);
                returnObj.PageCount = pageCount;
                returnObj.IsError = false; 
            }
            catch (Exception ex)
            {
                returnObj.IsError = true;
                returnObj.Error.ErrorMsg = ex.Message.ToString();
                returnObj.Error.ErrorCode = Error.EnumErrorCode.未知错误;
            }

            string str = Jil.JSON.Serialize < ReturnBaseObject<IEnumerable<PersonalWorkAPI.Model.article>>>(returnObj);
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }



    }
}
