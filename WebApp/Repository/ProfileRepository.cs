using Dapper;
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
            }).FirstOrDefault();
        }
        public void Create(RegisterAccountModel registerAccountModel)
        {
            var query = @"INSERT TOP(1) FROM Profile p WHERE p.Username = @username AND p.Password = @password";
        }

    }
}