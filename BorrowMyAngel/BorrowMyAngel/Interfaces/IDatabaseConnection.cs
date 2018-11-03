using System.Threading.Tasks;

namespace BorrowMyAngel.Interfaces
{
    public interface IDatabaseConnection
    {
        /// <summary>
        /// Creates a new standard user and uploads their record to the database.
        /// </summary>
        /// <returns></returns>
        Task CreateUser();

        //Task<User> GetUser(int id);

        /// <summary>
        /// Creates a new Angel user record with corresponding new user record and
        /// uploads them to the database.
        /// </summary>
        /// <returns></returns>
        Task CreateAngel();

        /// <summary>
        /// Promotes an existing user from a standard user to an Angel user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task PromoteUserToAngel(int userId);

        //Task<Angel> GetAngel(int id);

        //Task<ICollection<Angel>> GetAvailableAngels();

        //Task<ICollectionAngel> GetUnavailableAngels();
    }
}
