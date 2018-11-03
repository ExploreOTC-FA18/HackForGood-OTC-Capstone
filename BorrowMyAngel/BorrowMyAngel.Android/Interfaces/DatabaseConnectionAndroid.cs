using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BorrowMyAngel.Droid.Interfaces;
using BorrowMyAngel.Interfaces;
using BorrowMyAngel.Model.Database;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseConnectionAndroid))]
namespace BorrowMyAngel.Droid.Interfaces
{
    class DatabaseConnectionAndroid : IDatabaseConnection
    {
        private readonly SqlConnection _sqlConnection;

        public DatabaseConnectionAndroid()
        {
            _sqlConnection = new SqlConnection(APIKeys.ConnectionString);
        }

        /// <inheiritdoc/>
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task CreateAngel()
        {
            throw new System.NotImplementedException();
        }

        /// <inheiritdoc/>
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task CreateUser()
        {
            throw new System.NotImplementedException();
        }

        /// <inheiritdoc/>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task CreateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        /// <inheiritdoc/>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Angel> GetAngel(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <inheiritdoc/>
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<ICollection<Angel>> GetAvailableAngels()
        {
            throw new System.NotImplementedException();
        }

        /// <inheiritdoc/>
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<ICollection<Angel>> GetUnavailableAngels()
        {
            throw new System.NotImplementedException();
        }

        /// <inheiritdoc/>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<User> GetUser(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <inheiritdoc/>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task PromoteUserToAngel(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}