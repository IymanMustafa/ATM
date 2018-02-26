using Dapper;
using System;
using System.Data;
using System.Linq;
using WebApp.Models;

namespace WebApp.Repository
{
    public class ProfileRepository
    {
        private readonly IDbConnection dbConnection;
        public ProfileRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }
        public Profile Login(string username, string password)
        {
            var query = @"SELECT TOP(1) FROM Profile p WHERE p.Username = @username AND p.Password = @password";
            return dbConnection.Query<Profile>(query, new
            {
                username,
                password
            }).SingleOrDefault();
        }
        public Account GetAccount(int userId)
        {
            var query = @"SELECT * FROM Account WHERE Id = @Id";
            return dbConnection.Query<Account>(query, new
            {
                Id = userId
            }).Single();
        }
        public Account GetAccount(string username)
        {
            var query = @"SELECT * FROM Account a INNER JOIN Profile p ON a.Id = p.Id WHERE p.Username = @Username";
            return dbConnection.Query<Account>(query, new
            {
                Username = username
            }).Single();
        }
        public bool UpdateBalance(int userId, decimal balance)
        {
            var query = @"UPDATE Account SET Balance = @Balance WHERE Id = @Id";
            return dbConnection.Execute(query, new
            {
                Balance = balance,
                Id = userId
            }) == 1;
        }
        public int Create(RegisterAccountModel registerAccountModel)
        {
            var query = @"INSERT INTO Profile (Username, Password) 
            VALUES (@Username, @Password);
                SELECT CAST(SCOPE_IDENTITY() as int)";
            int userId = dbConnection.Query<int>(query, new { registerAccountModel.Username, registerAccountModel.Password }).Single();
            query = @"INSERT INTO [dbo].[Account]
           ([Id],[Name],[Number],[Balance] ,[Pin]) VALUES (@Id , @Name,  @Number,  @Balance ,@Pin,)";
            dbConnection.Execute(query, new
            {
                Id = userId,
                registerAccountModel.Name,
                registerAccountModel.Number,
                registerAccountModel.Balance,
                registerAccountModel.Pin
            });
            return userId;


        }


        public bool Delete(int userId)
        {
            return dbConnection.Execute("DELETE FROM Profile WHERE Id = @Id", new
            {
                Id = userId
            }) == 1;
        }
    }
}