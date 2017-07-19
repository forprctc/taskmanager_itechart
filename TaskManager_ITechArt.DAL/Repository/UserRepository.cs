using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Configuration;
using TaskManager_ITechArt.DAL.Entities;
using TaskManager_ITechArt.DAL.Interfaces;

namespace TaskManager_ITechArt.DAL.Repository
{
    public class UserRepository : IRepository<User>
    {
        string connectionString = ConfigurationManager.ConnectionStrings["taskmanager_db"].ConnectionString;
        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                users = db.Query<User>("SELECT *FROM user").ToList();
            }
            return users;
        }
        public User Get(int id)
        {
            User user = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                user = db.Query<User>("SELECT *FROM user Where user_id=@id", new { id }).FirstOrDefault();
            }
            return user;
        }
        public User Create(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO user (login, password,mail,is_admin,user_details) VALUES(@login, @password,@mail,@is_admin,@user_details);"+
                    " SELECT CAST(SCOPE_IDENTITY() as int)";
                int userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                user.user_id= userId;
            }
            return user;
        }
        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM user Where user_id=@id";
                db.Execute(sqlQuery, new { id });
            }
        }
        public void Update(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "Update user set login=@login, password=@password,mail=@mail,is_admin=@is_admin,user_details=@user_details Where user_id=@user_id";
                db.Execute(sqlQuery, user);
            }
        }
    }
}
