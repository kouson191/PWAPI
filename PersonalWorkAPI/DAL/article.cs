
using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using PersonalWorkAPI.Common;
using PersonalWorkAPI.Model;
using System.Collections.Generic;

namespace PersonalWorkAPI.DAL
{
    /// <summary>
    /// 数据访问类:article
    /// </summary>
    public partial class article
    {
        public article()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("id", "article");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from article");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
            parameters[0].Value = id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        public bool Add(dynamic model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into article(");
            strSql.Append("title,created,creator,sort_id,content,up,support,status,summary,carousel_url,thumbnail_url,description)");
            strSql.Append(" values (");
            strSql.Append("@title,unix_timestamp(now()),@creator,@sort_id,@content,@up,@support,@status,@summary,@carousel_url,@thumbnail_url,@description)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@title", MySqlDbType.VarChar,128), 
					new MySqlParameter("@creator", MySqlDbType.VarChar,32), 
					new MySqlParameter("@sort_id", MySqlDbType.Int32,11),
					new MySqlParameter("@content", MySqlDbType.Text),
					new MySqlParameter("@up", MySqlDbType.Int16,3),
					new MySqlParameter("@support", MySqlDbType.Int16,3),
					new MySqlParameter("@status", MySqlDbType.Int16,3),
					new MySqlParameter("@summary", MySqlDbType.VarChar,255),
					new MySqlParameter("@carousel_url", MySqlDbType.VarChar,255),
					new MySqlParameter("@thumbnail_url", MySqlDbType.VarChar,255),
					new MySqlParameter("@description", MySqlDbType.VarChar,255)  
                                          };
            parameters[0].Value = model.title;
            parameters[1].Value = "Admin";
            parameters[2].Value = model.sort_id;
            parameters[3].Value = model.content;
            parameters[4].Value = model.up;
            parameters[5].Value = model.support;
            parameters[6].Value = model.status;
            parameters[7].Value = model.summary;
            parameters[8].Value = model.carousel_url;
            parameters[9].Value = model.thumbnail_url;
            parameters[10].Value = model.description;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(dynamic model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update article set ");
            strSql.Append("title=@title,");
            strSql.Append("changed=unix_timestamp(now()),");
            strSql.Append("changer=@changer,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("content=@content,");
            strSql.Append("up=@up,");
            strSql.Append("support=@support,");
            strSql.Append("status=@status,");
            strSql.Append("summary=@summary,");
            strSql.Append("carousel_url=@carousel_url,");
            strSql.Append("thumbnail_url=@thumbnail_url,");
            strSql.Append("description=@description");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@title", MySqlDbType.VarChar,128),  
					new MySqlParameter("@changer", MySqlDbType.VarChar,32), 
					new MySqlParameter("@sort_id", MySqlDbType.Int32,11),
					new MySqlParameter("@content", MySqlDbType.Text),
					new MySqlParameter("@up", MySqlDbType.Int16,3),
					new MySqlParameter("@support", MySqlDbType.Int16,3),
					new MySqlParameter("@status", MySqlDbType.Int16,3),
					new MySqlParameter("@id", MySqlDbType.Int32,11),
					new MySqlParameter("@summary", MySqlDbType.VarChar,255),
					new MySqlParameter("@carousel_url", MySqlDbType.VarChar,255),
					new MySqlParameter("@thumbnail_url", MySqlDbType.VarChar,255),
					new MySqlParameter("@description", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.title;
            parameters[1].Value = "Admin";
            parameters[2].Value = model.sort_id;
            parameters[3].Value = model.content;
            parameters[4].Value = model.up;
            parameters[5].Value = model.support;
            parameters[6].Value = model.status;
            parameters[7].Value = model.id;
            parameters[8].Value = model.summary;
            parameters[9].Value = model.carousel_url;
            parameters[10].Value = model.thumbnail_url;
            parameters[11].Value = model.description;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
            strSql.Append("delete from article ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
            parameters[0].Value = id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
            strSql.Append("delete from article ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,FROM_UNIXTIME(created) created,creator,FROM_UNIXTIME(changed) changed,changer,click,sort_id,content,up,support,status,summary,carousel_url,thumbnail_url,description from article ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
            parameters[0].Value = id;

            PersonalWorkAPI.Model.article model = new PersonalWorkAPI.Model.article();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        //public PersonalWorkAPI.Model.article GetModel(int id)
        //{

        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select id,title,created,creator,changed,changer,click,sort_id,content,up,support,status from article ");
        //    strSql.Append(" where id=@id");
        //    MySqlParameter[] parameters = {
        //            new MySqlParameter("@id", MySqlDbType.Int32)
        //    };
        //    parameters[0].Value = id;

        //    PersonalWorkAPI.Model.article model = new PersonalWorkAPI.Model.article();
        //    DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        return DataRowToModel(ds.Tables[0].Rows[0]);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PersonalWorkAPI.Model.article DataRowToModel(DataRow row)
        {
            PersonalWorkAPI.Model.article model = new PersonalWorkAPI.Model.article();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["title"] != null)
                {
                    model.title = row["title"].ToString();
                }
                if (row["created"] != null && row["created"].ToString() != "")
                {
                    model.created = row["created"].ToString();
                }
                if (row["creator"] != null)
                {
                    model.creator = row["creator"].ToString();
                }
                if (row["changed"] != null && row["changed"].ToString() != "")
                {
                    model.changed = row["changed"].ToString();
                }
                if (row["changer"] != null)
                {
                    model.changer = row["changer"].ToString();
                }
                if (row["click"] != null && row["click"].ToString() != "")
                {
                    model.click = int.Parse(row["click"].ToString());
                }
                if (row["sort_id"] != null && row["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(row["sort_id"].ToString());
                }
                if (row["content"] != null)
                {
                    model.content = row["content"].ToString();
                }
                if (row["up"] != null && row["up"].ToString() != "")
                {
                    model.up = int.Parse(row["up"].ToString());
                }
                if (row["support"] != null && row["support"].ToString() != "")
                {
                    model.support = int.Parse(row["support"].ToString());
                }
                if (row["status"] != null && row["status"].ToString() != "")
                {
                    model.status = int.Parse(row["status"].ToString());
                }

                if (row["sort_name"] != null)
                {
                    model.sort_name = row["sort_name"].ToString();
                }


                if (row["summary"] != null && row["summary"].ToString() != "")
                {
                    model.summary = row["summary"].ToString();
                }
                if (row["carousel_url"] != null && row["carousel_url"].ToString() != "")
                {
                    model.carousel_url = row["carousel_url"].ToString();
                }
                if (row["thumbnail_url"] != null && row["thumbnail_url"].ToString() != "")
                {
                    model.thumbnail_url = row["thumbnail_url"].ToString();
                }
                if (row["description"] != null && row["description"].ToString() != "")
                {
                    model.description = row["description"].ToString();
                }

            }
            return model;
        }


        public DataTable GetCarousel(int num)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select id,title,from_unixtime(created, '%Y-%m-%d %H:%i:%S') created,creator,from_unixtime(changed, '%Y-%m-%d %H:%i:%S') changed,
                            changer,click,article.sort_id,content,up,support,status, summary,carousel_url,thumbnail_url,description 
                            from article where carousel_url <> '' order by  created desc  limit 0," + num.ToString() + @" ");

            return DbHelperMySQL.Query(  strSql.ToString()).Tables[0];

        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(dynamic mode,   ref int rowCount)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder countSql = new StringBuilder();
            StringBuilder selectSql = new StringBuilder();
            selectSql.Append("select id,title,from_unixtime(created, '%Y-%m-%d %H:%i:%S') created,creator,from_unixtime(changed, '%Y-%m-%d %H:%i:%S') changed,changer,click,article.sort_id,content,up,support,status,article_sort.sort_name,summary,carousel_url,thumbnail_url,description ");
            countSql.Append("select count(1) ");

            strSql.Append(" FROM article  inner join article_sort on article.sort_id = article_sort.sort_id where 1 = 1  ");

             
            if (!string.IsNullOrEmpty(mode.sort_id.Value))
            {
                strSql.Append("  and  article.sort_id = @sort_id ");
            }

            if (!string.IsNullOrEmpty(mode.status.Value))
            {
                strSql.Append("  and  ( status = @status or @status = -1  ) ");
            }

            if (!string.IsNullOrEmpty(mode.up.Value))
            {
                strSql.Append("  and  article.up = @up ");
            }
            
            if (!string.IsNullOrEmpty(mode.support.Value))
            {
                strSql.Append("  and  article.support = @support ");
            }

            if (!string.IsNullOrEmpty(mode.search.Value))
            {
                strSql.Append("  and  ( article.title like @search or summary like @search or  content like @search  ) ");
            } 



            MySqlParameter[] parameter = { 
               new MySqlParameter("@sort_id",mode.sort_id.Value),
               new MySqlParameter("@status",mode.status.Value),
               new MySqlParameter("@up",mode.up.Value),
               new MySqlParameter("@support",mode.support.Value),
               new MySqlParameter("@search","%"+mode.search.Value+"%")
             };

            rowCount = Convert.ToInt16(DbHelperMySQL.Query(countSql.ToString() + strSql.ToString(), parameter).Tables[0].Rows[0][0].ToString());
            int pageIndex = Convert.ToInt16(mode.pageIndex.Value);
            int pageSize = Convert.ToInt16(mode.pageSize.Value);  

            strSql.Append(" order by  created desc,id desc ");
            strSql.Append(" limit @index,@PageSize;");
            MySqlParameter[] parameter2 = {  
                new MySqlParameter("@sort_id",mode.sort_id.Value),
                new MySqlParameter("@status",mode.status.Value),
               new MySqlParameter("@up",mode.up.Value),
               new MySqlParameter("@support",mode.support.Value),
               new MySqlParameter("@search","%"+mode.search.Value+"%"),
                new MySqlParameter("@index",(pageIndex - 1) * pageSize ),
                new MySqlParameter("@PageSize",pageSize), 
                 
            }; 

            return DbHelperMySQL.Query(selectSql.ToString() + strSql.ToString(), parameter2).Tables[0];
        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(string strWhere)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select id,title,from_unixtime(created) created,creator,from_unixtime(changed) changed,changer,click,article.sort_id,content,up,support,status,sort.sort_name ");
        //    strSql.Append(" FROM article  inner join sort on article.sort_id = sort.sort_id ");
        //    if (strWhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    strSql.Append(" order by  created desc ");

        //    return DbHelperMySQL.Query(strSql.ToString());
        //}

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM article ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
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
            strSql.Append(")AS Row, T.*  from article T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@PageSize", MySqlDbType.Int32),
                    new MySqlParameter("@PageIndex", MySqlDbType.Int32),
                    new MySqlParameter("@IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("@OrderType", MySqlDbType.Bit),
                    new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "article";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetModelList(dynamic mode, ref int rowCount)
        {
            DataTable rslt = GetList(mode, ref rowCount);
            //int pageIndex = Convert.ToInt16(mode.pageIndex.Value );
            //int pageSize = Convert.ToInt16(mode.pageSize.Value);
            //DataTable rslt = Pagination.getOnePageTable(ds.Tables[0], pageIndex, pageSize, ref totalPage);
            return rslt;
        }





        /// <summary>
        /// 获得数据列表
        ///// </summary>
        //public List<PersonalWorkAPI.Model.article> GetModelList(string strWhere, int pageSize, int pageIndex, ref int totalPage)
        //{
        //    DataSet ds = GetList(strWhere);

        //    DataTable rslt = Pagination.getOnePageTable(ds.Tables[0], pageIndex, pageSize, ref totalPage);
        //    return DataTableToList(rslt);
        //}




        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PersonalWorkAPI.Model.article> DataTableToList(DataTable dt)
        {
            List<PersonalWorkAPI.Model.article> modelList = new List<PersonalWorkAPI.Model.article>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PersonalWorkAPI.Model.article model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }




        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

