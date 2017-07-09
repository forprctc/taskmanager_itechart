using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Configuration;
using TaskManager_ITechArt.DAL.Entities;

namespace TaskManager_ITechArt.DAL.Repository
{
    public class TaskRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public List<Task> GetTasks()
        {
            List<Task> tasks = new List<Task>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                tasks = db.Query<Task>("SELECT *FROM task").ToList();
            }
            return tasks;
        }
        public Task Get(int id)
        {
            Task task = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                task = db.Query<Task>("SELECT *FROM task Where task_id=@id", new { id }).FirstOrDefault();
            }
            return task;
        }
        public Task Create(Task task)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO task (title, task_beginning,task_end,period,descriptions,category,owner_id,status,task_details)"+
                    " VALUES(@title, @task_beginning,@task_end,@period,@descriptions,@category,@owner_id,@status,@task_details);" +
                    " SELECT CAST(SCOPE_IDENTITY() as int)";
                int taskId = db.Query<int>(sqlQuery, task).FirstOrDefault();
                task.task_id= taskId;
            }
            return task;
        }
        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM task Where id=@id";
                db.Execute(sqlQuery, new { id });
            }
        }
        public void Update(Task task)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "Update task set title=@title, task_beginning=@task_beginning,"+
                    "task_end=@task_end,period=@period,descriptions=@descriptions,category=@category,owner_id=@owner_id,status=@status,task_details=@task_details";
                db.Execute(sqlQuery, task);
            }
        }
    }
}
