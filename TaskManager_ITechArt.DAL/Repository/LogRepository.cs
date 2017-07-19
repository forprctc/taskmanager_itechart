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
    public class LogRepository : IRepository<Log>
       
    {
        string connectionString = ConfigurationManager.ConnectionStrings["taskmanager_db"].ConnectionString;
        public List<Log> GetAll()
        {
            List<Log> logs = new List<Log>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                logs = db.Query<Log>("SELECT *FROM log").ToList();
            }
            return logs;
        }
        public Log Get(int id)
        {
            Log log = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                log = db.Query<Log>("SELECT *FROM log Where log_id=@id", new { id }).FirstOrDefault();
            }
            return log;
        }
        public Log Create(Log log)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO log (date,satatus,task_id,user_id) VALUES(@date,@satatus,@task_id,@user_id);" +
                    " SELECT CAST(SCOPE_IDENTITY() as int)";
                int logId = db.Query<int>(sqlQuery, log).FirstOrDefault();
                log.log_id = logId;
            }
            return log;
        }
        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM log Where log_id=@id";
                db.Execute(sqlQuery, new { id });
            }
        }
        public void Update(Log log)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "Update log set  date=@date,satatus=@status,task_id=@task_id,user_id=@user_id Where log_id=@log_id";
                db.Execute(sqlQuery, log);
            }
        }
    }
}
