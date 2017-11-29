 
using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
//using Maticsoft.DBUtility;//Please add references
using PersonalWorkAPI.Common;
using PersonalWorkAPI.Model;

namespace PersonalWorkAPI.DAL
{
	/// <summary>
	/// 数据访问类:article
	/// </summary>
	public partial class article
	{
		public article()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("article_id", "article"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int article_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from article");
			strSql.Append(" where article_id=@article_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@article_id", MySqlDbType.Int32)
			};
			parameters[0].Value = article_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(PersonalWorkAPI.Model.article model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into article(");
			strSql.Append("article_title,article_created,article_creator,article_changed,article_changer,article_click,sort_id,article_content,article_up,article_support,article_status)");
			strSql.Append(" values (");
			strSql.Append("@article_title,@article_created,@article_creator,@article_changed,@article_changer,@article_click,@sort_id,@article_content,@article_up,@article_support,@article_status)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@article_title", MySqlDbType.VarChar,128),
					new MySqlParameter("@article_created", MySqlDbType.Int32,11),
					new MySqlParameter("@article_creator", MySqlDbType.VarChar,32),
					new MySqlParameter("@article_changed", MySqlDbType.Int32,11),
					new MySqlParameter("@article_changer", MySqlDbType.VarChar,32),
					new MySqlParameter("@article_click", MySqlDbType.Int32,11),
					new MySqlParameter("@sort_id", MySqlDbType.Int32,11),
					new MySqlParameter("@article_content", MySqlDbType.Text),
					new MySqlParameter("@article_up", MySqlDbType.Int16,3),
					new MySqlParameter("@article_support", MySqlDbType.Int16,3),
					new MySqlParameter("@article_status", MySqlDbType.Int16,3)};
			parameters[0].Value = model.article_title;
			parameters[1].Value = model.article_created;
			parameters[2].Value = model.article_creator;
			parameters[3].Value = model.article_changed;
			parameters[4].Value = model.article_changer;
			parameters[5].Value = model.article_click;
			parameters[6].Value = model.sort_id;
			parameters[7].Value = model.article_content;
			parameters[8].Value = model.article_up;
			parameters[9].Value = model.article_support;
			parameters[10].Value = model.article_status;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
        public bool Update(PersonalWorkAPI.Model.article model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update article set ");
			strSql.Append("article_title=@article_title,");
			strSql.Append("article_created=@article_created,");
			strSql.Append("article_creator=@article_creator,");
			strSql.Append("article_changed=@article_changed,");
			strSql.Append("article_changer=@article_changer,");
			strSql.Append("article_click=@article_click,");
			strSql.Append("sort_id=@sort_id,");
			strSql.Append("article_content=@article_content,");
			strSql.Append("article_up=@article_up,");
			strSql.Append("article_support=@article_support,");
			strSql.Append("article_status=@article_status");
			strSql.Append(" where article_id=@article_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@article_title", MySqlDbType.VarChar,128),
					new MySqlParameter("@article_created", MySqlDbType.Int32,11),
					new MySqlParameter("@article_creator", MySqlDbType.VarChar,32),
					new MySqlParameter("@article_changed", MySqlDbType.Int32,11),
					new MySqlParameter("@article_changer", MySqlDbType.VarChar,32),
					new MySqlParameter("@article_click", MySqlDbType.Int32,11),
					new MySqlParameter("@sort_id", MySqlDbType.Int32,11),
					new MySqlParameter("@article_content", MySqlDbType.Text),
					new MySqlParameter("@article_up", MySqlDbType.Int16,3),
					new MySqlParameter("@article_support", MySqlDbType.Int16,3),
					new MySqlParameter("@article_status", MySqlDbType.Int16,3),
					new MySqlParameter("@article_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.article_title;
			parameters[1].Value = model.article_created;
			parameters[2].Value = model.article_creator;
			parameters[3].Value = model.article_changed;
			parameters[4].Value = model.article_changer;
			parameters[5].Value = model.article_click;
			parameters[6].Value = model.sort_id;
			parameters[7].Value = model.article_content;
			parameters[8].Value = model.article_up;
			parameters[9].Value = model.article_support;
			parameters[10].Value = model.article_status;
			parameters[11].Value = model.article_id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int article_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from article ");
			strSql.Append(" where article_id=@article_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@article_id", MySqlDbType.Int32)
			};
			parameters[0].Value = article_id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string article_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from article ");
			strSql.Append(" where article_id in ("+article_idlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
        public PersonalWorkAPI.Model.article GetModel(int article_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select article_id,article_title,article_created,article_creator,article_changed,article_changer,article_click,sort_id,article_content,article_up,article_support,article_status from article ");
			strSql.Append(" where article_id=@article_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@article_id", MySqlDbType.Int32)
			};
			parameters[0].Value = article_id;

            PersonalWorkAPI.Model.article model = new PersonalWorkAPI.Model.article();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
        public PersonalWorkAPI.Model.article DataRowToModel(DataRow row)
		{
            PersonalWorkAPI.Model.article model = new PersonalWorkAPI.Model.article();
			if (row != null)
			{
				if(row["article_id"]!=null && row["article_id"].ToString()!="")
				{
					model.article_id=int.Parse(row["article_id"].ToString());
				}
				if(row["article_title"]!=null)
				{
					model.article_title=row["article_title"].ToString();
				}
				if(row["article_created"]!=null && row["article_created"].ToString()!="")
				{
					model.article_created=int.Parse(row["article_created"].ToString());
				}
				if(row["article_creator"]!=null)
				{
					model.article_creator=row["article_creator"].ToString();
				}
				if(row["article_changed"]!=null && row["article_changed"].ToString()!="")
				{
					model.article_changed=int.Parse(row["article_changed"].ToString());
				}
				if(row["article_changer"]!=null)
				{
					model.article_changer=row["article_changer"].ToString();
				}
				if(row["article_click"]!=null && row["article_click"].ToString()!="")
				{
					model.article_click=int.Parse(row["article_click"].ToString());
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
				}
				if(row["article_content"]!=null)
				{
					model.article_content=row["article_content"].ToString();
				}
				if(row["article_up"]!=null && row["article_up"].ToString()!="")
				{
					model.article_up=int.Parse(row["article_up"].ToString());
				}
				if(row["article_support"]!=null && row["article_support"].ToString()!="")
				{
					model.article_support=int.Parse(row["article_support"].ToString());
				}
				if(row["article_status"]!=null && row["article_status"].ToString()!="")
				{
					model.article_status=int.Parse(row["article_status"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select article_id,article_title,article_created,article_creator,article_changed,article_changer,article_click,sort_id,article_content,article_up,article_support,article_status ");
			strSql.Append(" FROM article ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM article ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.article_id desc");
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
			parameters[1].Value = "article_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

