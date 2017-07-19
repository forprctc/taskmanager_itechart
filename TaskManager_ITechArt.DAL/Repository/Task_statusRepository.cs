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
    public class Task_statusRepository : IRepository<Task_status>
    {
        string connectionString = ConfigurationManager.ConnectionStrings["taskmanager_db"].ConnectionString;
        public List<Task_status> GetAll()
        {
            List<Task_status> task_statuss = new List<Task_status>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                task_statuss = db.Query<Task_status>("SELECT *FROM task_status").ToList();
            }
            return task_statuss;
        }
        public Task_status Get(int id)
        {
            Task_status task_status = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                task_status = db.Query<Task_status>("SELECT *FROM task_status Where status_id=@id", new { id }).FirstOrDefault();
            }
            return task_status;
        }
        public Task_status Create(Task_status task_status)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO task_status (status, status_details) VALUES(@status, @status_details);" +
                    " SELECT CAST(SCOPE_IDENTITY() as int)";
                int task_statusId = db.Query<int>(sqlQuery, task_status).FirstOrDefault();
                task_status.status_id = task_statusId;
            }
            return task_status;
        }
        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM task_status Where status_id=@id";
                db.Execute(sqlQuery, new { id });
            }
        }
        public void Update(Task_status task_status)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "Update task_status set status=@status, status_details=@status_details Where status_id=@status_id";
                db.Execute(sqlQuery, task_status);
            }
        }
    }
}
