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
using Newtonsoft.Json;

namespace PersonalWorkAPI.Controllers
{
    public class ArticleController : ApiController
    {
        private readonly PersonalWorkAPI.DAL.article dal = new PersonalWorkAPI.DAL.article();


        /// <summary>
        /// 新增一条数据
        /// </summary>
        [HttpPost]
        public RetResult Add(dynamic model)
        {
            var retResult = new RetResult();
            retResult.SetSuccess("新增文章成功！");

            try
            {
                var rslt = dal.Add(model); ;
                retResult.RetData = rslt;
            }
            catch (Exception ex)
            {
                retResult.SetFail("新增文章失败！");
                retResult.Exception = ex.Message;
            }

            return retResult;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [HttpPost]
        public RetResult Update(dynamic model)
        {
            var retResult = new RetResult();
            retResult.SetSuccess("保存文章成功！");

            try
            {
                var rslt = dal.Update(model); ;
                retResult.RetData = rslt;
            }
            catch (Exception ex)
            {
                retResult.SetFail("保存文章失败！");
                retResult.Exception = ex.Message;
            }

            return retResult;
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        [HttpGet]
        public RetResult Delete(int article_id)
        {
            var retResult = new RetResult();
            retResult.SetSuccess("删除文章详细信息成功！");

            try
            {
                var res = dal.Delete(article_id);
                retResult.RetData = res;
            }
            catch (Exception ex)
            {
                retResult.SetFail("删除文章详细信息失败！");
                retResult.Exception = ex.Message;
            }

            return retResult;
        }


        /// <summary>
        /// 批量删除数据
        /// </summary>
        [HttpGet]
        public RetResult DeleteList(string article_id)
        {
            var retResult = new RetResult();
            retResult.SetSuccess("删除文章详细信息成功！");

            try
            {
                var res = dal.DeleteList(article_id);
                retResult.RetData = res;
            }
            catch (Exception ex)
            {
                retResult.SetFail("删除文章详细信息失败！");
                retResult.Exception = ex.Message;
            }

            return retResult;
        }
  
        /// <summary>
        /// 获取明细
        /// </summary> 
        [HttpGet]
        public RetResult GetModel(int article_id)
        {
            var retResult = new RetResult();
            retResult.SetSuccess("查询文章详细信息成功！");

            try
            {
                var res = dal.GetModel(article_id); ;

                if (res != null && res.Rows.Count != 0)
                {
                    retResult.RetData = res;
                }
            }
            catch (Exception ex)
            {
                retResult.SetFail("查询文章详细信息失败！");
                retResult.Exception = ex.Message;
            }

            return retResult;
        }



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
            strWhere = (strWhere == null) ? "" : strWhere;
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

            string str = Jil.JSON.Serialize<ReturnBaseObject<IEnumerable<PersonalWorkAPI.Model.article>>>(returnObj);
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }



    }
}
