using BorrowMyAngel.Model.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BorrowMyAngel.Interfaces
{
    public interface IDatabaseConnection
    {
        /// <summary>
        /// Creates a new standard user and uploads their record to the database.
        /// </summary>
        /// <param name="user">User object to add to the database.</param>
        /// <returns></returns>
        Task CreateUser(User user);

        /// <summary>
        /// Retrieve a user object from the database.
        /// </summary>
        /// <param name="id">ID of the user to retrieve.</param>
        /// <returns></returns>
        Task<User> GetUser(int id);

        /// <summary>
        /// Creates a new Angel user record with corresponding new user record and
        /// uploads them to the database.
        /// </summary>
        /// <returns></returns>
        Task CreateAngel();

        /// <summary>
        /// Promotes an existing user from a standard user to an Angel user.
        /// </summary>
        /// <param name="userId">ID of the User to promote to an Angel.</param>
        /// <returns></returns>
        Task PromoteUserToAngel(int userId);

        /// <summary>
        /// Gets an Angel object from the database.
        /// </summary>
        /// <param name="id">ID of the Angel to retrieve.</param>
        /// <returns></returns>
        Task<Angel> GetAngel(int id);

        /// <summary>
        /// Gets a list of Angels with the Available status.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<Angel>> GetAvailableAngels();

        /// <summary>
        /// Gets a list of Angels with the Unavailable status.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<Angel>> GetUnavailableAngels();
    }
}
