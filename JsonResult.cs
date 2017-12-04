
        //            var data = {
        //                UserID: "10",
        //                UserName: "Long",
        //                AppInstanceID: "100",
        //                ProcessGUID: "BF1CC2EB-D9BD-45FD-BF87-939DD8FF9071"
        //            };
        //            var request = JSON.stringify(data);
        //            request = encodeURIComponent(request);
        //
        //            $.ajax({
        //                url: "http://192.168.12.3/EAGO.WebApi/api/Applys/StartProcess?data=",
        //                type: "GET",
        //                dataType: "json",
        //                data: request,
        //                success: function(response) {
        //
        //                },
        //                error: function() {
        //                    alert("请重新登录");
        //                }
        //            });

        [HttpGet]
        public System.Web.Mvc.JsonResult StartProcess()
        {
           dynamic queryJson = ParseHttpGetJson(Request.RequestUri.Query);
           int appInstanceID = int.Parse(queryJson.AppInstanceID.Value);
           Guid processGUID = Guid.Parse(queryJson.ProcessGUID.Value);
           int userID = int.Parse(queryJson.UserID.Value);
           string userName = queryJson.UserName.Value;
           System.Web.Mvc.JsonResult jr = new System.Web.Mvc.JsonResult();
           return jr;
        }

        private dynamic ParseHttpGetJson(string query)
        {
           if (!string.IsNullOrEmpty(query))
           {
               try
               {
                   var json = query.Substring(7, query.Length - 7);  // the number 7 is for "?data=&"
                   json = System.Web.HttpUtility.UrlDecode(json);
                   dynamic queryJson = JsonConvert.DeserializeObject<dynamic>(json);

                   return queryJson;
               }
               catch (System.Exception e)
               {
                   throw new ApplicationException("wrong json format in the query string！", e);
               }
           }
           else
           {
               return null;
           }
        }





////userManager
public RetResult QueryUserDetailById(string id)
        {
            var retResult = new RetResult();
            retResult.SetSuccess("查询用户详细信息成功！");

            try
            {
                var dtUserInfo = new UserService().QueryUserDetailById(id);

                if (dtUserInfo != null && dtUserInfo.Rows.Count != 0)
                {
                    retResult.RetData = dtUserInfo;
                }
            }
            catch (Exception ex)
            {
                retResult.SetFail("查询用户详细信息失败！");
                retResult.Exception = ex.Message;
            }

            return retResult;
        }
		
		
////UserController.cs
public JsonResult QueryUserDetailById(string id)
        {
            var userManager = new UserManager();
            var res = userManager.QueryUserDetailById(id);
            var jsonStr = JsonConvert.SerializeObject(res);
            return Json(jsonStr, JsonRequestBehavior.AllowGet);
        }
		
		
		
		
		 public class RetResult
    {
        /// <summary>
        /// 结果 1：Success 2:Fail
        /// </summary>
        public string Result{get;set;}
        /// <summary>
        /// 返回数据
        /// </summary>
        public object RetData { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }
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