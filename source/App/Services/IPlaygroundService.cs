using System.Threading.Tasks;
using RestApiClient.Contracts;

namespace App.Services {

    /// <summary>
    /// Interface for Playground Service
    /// </summary>
    public interface IPlaygroundService {

        /// <summary>
        /// Authenticates user
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>token</returns>
        Task<AuthorizationResult> Authorize(string username, string password);

        /// <summary>
        /// Gets list of servers
        /// </summary>
        /// <returns>list of servers</returns>
        Task<ServerResult> GetServers();

        /// <summary>
        /// Logs out
        /// </summary>
        void LogOut();

    }
}
