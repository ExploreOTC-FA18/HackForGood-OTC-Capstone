using BorrowMyAngel.iOS.Interfaces;
using BorrowMyAngel.Interfaces;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Data.SqlClient;

[assembly: Dependency(typeof(DatabaseConnectionIOS))]
namespace BorrowMyAngel.iOS.Interfaces
{
    class DatabaseConnectionIOS : IDatabaseConnection
    {
        private readonly SqlConnection _sqlConnection;

        public DatabaseConnectionIOS()
        {
            _sqlConnection = new SqlConnection("");
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
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task PromoteUserToAngel(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}