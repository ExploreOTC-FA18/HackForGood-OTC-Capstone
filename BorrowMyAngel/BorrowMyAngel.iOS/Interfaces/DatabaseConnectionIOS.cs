using BorrowMyAngel.iOS.Interfaces;
using BorrowMyAngel.Interfaces;
using BorrowMyAngel.Model.Database;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.Generic;

[assembly: Dependency(typeof(DatabaseConnectionIOS))]
namespace BorrowMyAngel.iOS.Interfaces
{
    class DatabaseConnectionIOS : IDatabaseConnection
    {
        private readonly SqlConnection _sqlConnection;

        public DatabaseConnectionIOS()
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