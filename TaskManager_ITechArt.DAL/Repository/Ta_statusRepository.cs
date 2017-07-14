using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_ITechArt.DAL.Entities;
using TaskManager_ITechArt.DAL.Interfaces;

namespace TaskManager_ITechArt.DAL.Repository
{
    public class Ta_statusRepository : IRepository<Ta_status>
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public Ta_status Create(Ta_status ta_status)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO ta_status (status) VALUES(@status);" +
                    " SELECT CAST(SCOPE_IDENTITY() as int)";
                int task_statusId = db.Query<int>(sqlQuery, ta_status).FirstOrDefault();
                ta_status.ta_status_id = task_statusId;
            }
            return ta_status;
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM ta_status Where ta_status_id=@id";
                db.Execute(sqlQuery, new { id });
            }

        }

        public Ta_status Get(int id)
        {
            Ta_status task_status = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                task_status = db.Query<Ta_status>("SELECT *FROM ta_status Where ta_status_id=@id", new { id }).FirstOrDefault();
            }
            return task_status;
        }

        public List<Ta_status> GetAll()
        {
            List<Ta_status> task_statuss = new List<Ta_status>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                task_statuss = db.Query<Ta_status>("SELECT *FROM ta_status").ToList();
            }
            return task_statuss;
        }

        public void Update(Ta_status ta_status)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "Update ta_status set status=@status Where ta_status_id=@ta_status_id";
                db.Execute(sqlQuery, ta_status);
            }
        }
    }
}
