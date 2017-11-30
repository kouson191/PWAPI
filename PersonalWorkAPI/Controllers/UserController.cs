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
    public class UserController : ApiController
    {
        private readonly PersonalWorkAPI.DAL.User dal = new PersonalWorkAPI.DAL.User();

        [HttpGet]
        public HttpResponseMessage verifyUser(string user_name, string user_pwd)
        {
            ReturnBaseObject<Boolean> returnObj = new ReturnBaseObject<Boolean>();
            try
            {
                returnObj.ReturnObject = dal.verifyUser(user_name, user_pwd);

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

    }
}
