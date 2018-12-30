using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
	public class User
	{
        public string U_ID { set; get; }
        public string U_Password { set; get; }
        public string U_Role { set; get; }
        public User()
        { }
        public User(string id,string password,string role)
        {
            U_ID = id;
            U_Password = password;
            U_Role = role;
        }
        public static List<User> getList(OdbcDataReader reader)
        {
            List<User> list = new List<User>();
            User user;
            while (reader.Read())
            {
                user = new User();
                user.U_ID = reader.GetInt32(0).ToString();
                user.U_Password = reader.GetString(1);
                user.U_Role = reader.GetString(2);
                list.Add(user);
            }
            return list;
        }
    }   
}