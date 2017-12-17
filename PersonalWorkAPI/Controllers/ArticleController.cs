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
        /// 列表
        /// </summary> 
        [HttpPost]
        public RetResult GetList(dynamic mode)
        { 
            //pageSize
            //pageIndex
            var retResult = new RetResult();
            retResult.SetSuccess("查询文章详细信息成功！");
            var pageCount = 0;
            try
            {
                var res = dal.GetModelList(mode, ref pageCount); 

                if (res != null && res.Rows.Count != 0)
                {
                    retResult.RetData = res;
                     retResult.pageCount = pageCount;
                }
            }
            catch (Exception ex)
            {
                retResult.SetFail("查询文章详细信息失败！");
                retResult.Exception = ex.Message;
            }

            return retResult; 
        }

    }
}
