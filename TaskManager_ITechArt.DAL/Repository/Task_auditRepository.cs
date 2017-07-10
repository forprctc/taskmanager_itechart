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
    public class Task_auditRepository : IRepository<Task_audit>
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public List<Task_audit> GetAll()
        {
            List<Task_audit> task_audits = new List<Task_audit>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                task_audits = db.Query<Task_audit>("SELECT *FROM task_audit").ToList();
            }
            return task_audits;
        }
        public Task_audit Get(int id)
        {
            Task_audit task_audit = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                task_audit = db.Query<Task_audit>("SELECT *FROM Task_audit Where task_audit_id=@id", new { id }).FirstOrDefault();
            }
            return task_audit;
        }
        public Task_audit Create(Task_audit task_audit)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO task_audit (user_id, status,queue) VALUES(@user_id, @status,@queue);" +
                    " SELECT CAST(SCOPE_IDENTITY() as int)";
                int task_auditId = db.Query<int>(sqlQuery, task_audit).FirstOrDefault();
                task_audit.ta_id = task_auditId;
            }
            return task_audit;
        }
        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM task_audit Where ta_id=@id";
                db.Execute(sqlQuery, new { id });
            }
        }
        public void Update(Task_audit task_audit)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "Update task_audit set user_id=@user_id,status=@status,queue=@queue";
                db.Execute(sqlQuery, task_audit);
            }
        }
    }
}
