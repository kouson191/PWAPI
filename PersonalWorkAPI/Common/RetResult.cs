using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalWorkAPI.Common
{
    public class RetResult
    {
        /// <summary>
        /// 结果 1：Success 2:Fail
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public object RetData { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        /// 总页数
        /// </summary>
        public int pageCount { get; set; }


        /// <summary>
        /// 异常
        /// </summary>
        public string Exception { get; set; }
        /// <summary>
        /// 设置失败信息
        /// </summary>
        /// <param name="msg"></param>
        public void SetFail(string msg)
        {
            this.Result = "Fail";
            this.Message = !string.IsNullOrEmpty(msg) ? msg : "失败";
        }
        /// <summary>
        /// 设置页面过期失效提示重新登录的信息
        /// </summary>
        public void SetFailAndRelogin()
        {
            this.Result = "Fail";
            this.Message = "页面过期失效，请刷新页面或重新登录后再操作！";
        }
        /// <summary>
        /// 设置成功信息
        /// </summary>
        /// <param name="msg"></param>
        public void SetSuccess(string msg)
        {
            this.Result = "Success";
            this.Message = !string.IsNullOrEmpty(msg) ? msg : "成功";
        }
    }
}