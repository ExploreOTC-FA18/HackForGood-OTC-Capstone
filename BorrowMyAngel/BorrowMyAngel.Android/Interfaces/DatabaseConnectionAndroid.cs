using System.Threading.Tasks;
using BorrowMyAngel.Droid.Interfaces;
using BorrowMyAngel.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseConnectionAndroid))]
namespace BorrowMyAngel.Droid.Interfaces
{
    class DatabaseConnectionAndroid : IDatabaseConnection
    {
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