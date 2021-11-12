using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaCRUDAPI.Models
{
    public class PizzaRepository
    {
        private string connectionString;
        public PizzaRepository()
        {
            // тут данные для подключения к БД ( я юзал прежде MSSQL, для подключения к ней этого хватало)
            connectionString = @"User ID=sa;password=123;Initial Catalog=PizzaCat; Data Source=DESKTOP-TAT0UU1\Arseny;Connection Timeout=100000;";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        // Добавить новую пиццу
        public void Add(Pizza piz)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO PizzaDescription (Name,Price,Picture,Description,Active,New,Listofingredients,Typeofdough,Typeofadditionalingredients) VALUES(@Name,@Price,@Picture,@Description,@Active,@New,@Listofingredients,@Typeofdough,@Typeofadditionalingredients)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, piz);
            }
        }
        // Получить весь список пицц
        public IEnumerable<Pizza> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM PizzaDescription";
                dbConnection.Open();
                return dbConnection.Query<Pizza>(sQuery);
            }

        }
        // Получить пиццы по имени
        public IEnumerable<Pizza> GetByName(string name)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM PizzaDescription WHERE Name=@Name";
                dbConnection.Open();
                return (IEnumerable<Pizza>)dbConnection.Query<Pizza>(sQuery,new { Name = name }).FirstOrDefault();
            }

        }
        // Получить пиццы по активности
        public IEnumerable<Pizza> GetByActive(string active)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM PizzaDescription WHERE Active=@Active";
                dbConnection.Open();
                return (IEnumerable<Pizza>)dbConnection.Query<Pizza>(sQuery, new { Active = active }).FirstOrDefault();
            }

        }
        // Получить пиццы по статусу недавно добавленной или со статусом новой
        public IEnumerable<Pizza> GetByNews(string news)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM PizzaDescription WHERE New=@New";
                dbConnection.Open();
                return (IEnumerable<Pizza>)dbConnection.Query<Pizza>(sQuery, new { New = news }).FirstOrDefault();
            }

        }
        // Удаление пиццы из каталога по имени
        public void Delete(string name)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM PizzaDescription WHERE Name=@Name";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Name = name });
                
            }

        }
        // Обновление пиццы из каталога 
        public void Update(Pizza piz)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE PizzaDescription SET Name=@Name,Price=@Price,Picture=@Picture,Description=@Description,Active=@Active,New=@New,Listofingredients=@Listofingredients,Typeofdough=@Typeofdough,Typeofadditionalingredients=@Typeofadditionalingredients";
                dbConnection.Open();
                dbConnection.Execute(sQuery, piz);

            }

        }
    }
}
