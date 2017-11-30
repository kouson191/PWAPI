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
    /// </summar 
    public class User
    {
        public Boolean verifyUser(string user_name, string user_pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from user");
            strSql.Append(" where user_name=@user_name and  user_pwd=@user_pwd ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@user_name", MySqlDbType.String),
					new MySqlParameter("@user_pwd", MySqlDbType.String),
			};
            parameters[0].Value = user_name;
            parameters[1].Value = user_pwd;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        
        }

    }
}