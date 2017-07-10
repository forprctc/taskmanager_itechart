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
    public class CategoryRepository:IRepository<Category>
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public List<Category> GetAll()
        {
            List<Category> categorys = new List<Category>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                categorys = db.Query<Category>("SELECT *FROM category").ToList();
            }
            return categorys;
        }
        public Category Get(int id)
        {
            Category category = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                category = db.Query<Category>("SELECT *FROM log Where category_id=@id", new { id }).FirstOrDefault();
            }
            return category;
        }
        public Category Create(Category category)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO category (category_name,category_details) VALUES(@category_name,@category_details);" +
                    " SELECT CAST(SCOPE_IDENTITY() as int)";
                int categoryId = db.Query<int>(sqlQuery, category).FirstOrDefault();
                category.category_id= categoryId;
            }
            return category;
        }
        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM category Where category_id=@id";
                db.Execute(sqlQuery, new { id });
            }
        }
        public void Update(Category category)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "Update category set category_name=@category_name,category_details=@category_details";
                db.Execute(sqlQuery, category);
            }
        }
    }
}
