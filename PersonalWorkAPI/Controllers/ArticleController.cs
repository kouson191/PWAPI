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

namespace PersonalWorkAPI.Controllers
{
    public class ArticleController : ApiController
    { 
        [AcceptVerbs("GET", "POST")] 
        public void upLoadDocImage()
        {
            HttpContext context = HttpContext.Current; 
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            //上传配置
            string pathbase = "upload/";                                                          //保存路径
            int size = 10;                     //文件大小限制,单位mb                                                                                   //文件大小限制，单位KB
            string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };                    //文件允许格式

            string callback = context.Request["callback"];
            string editorId = context.Request["editorid"];

            //上传图片
            Hashtable info;
            Uploader up = new Uploader();
            info = up.upFile(context, pathbase, filetype, size); //获取上传状态
            string json = BuildJson(info);

            context.Response.ContentType = "text/html";
            if (callback != null)
            {
                context.Response.Write(String.Format("<script>{0}(JSON.parse(\"{1}\"));</script>", callback, json));
            }
            else
            {
                context.Response.Write(json);
            }
             
        }
        private string BuildJson(Hashtable info)
        {
            List<string> fields = new List<string>();
            string[] keys = new string[] { "originalName", "name", "url", "size", "state", "type" };
            for (int i = 0; i < keys.Length; i++)
            {
                fields.Add(String.Format("\"{0}\": \"{1}\"", keys[i], info[keys[i]]));
            }
            return "{" + String.Join(",", fields) + "}";
        }
    }
}
