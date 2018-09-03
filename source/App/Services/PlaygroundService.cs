using System;
using System.Threading.Tasks;
using RestApiClient;
using RestApiClient.Contracts;

namespace App.Services {

    public class PlaygroundService : IPlaygroundService {

        /// <summary>
        /// Party Client
        /// </summary>
        PartyClient client;

        /// <summary>
        /// User token
        /// </summary>
        string token;

        public PlaygroundService() {
            client = new PartyClient(BaseURL.PlaygroundAPI);
        }

        /// <summary>
        /// Logs in and stores token
        /// </summary>
        /// <param name="username">User name</param>
        /// <param name="password">Password</param>
        /// <returns>Authorization result</returns>
        public async Task<AuthorizationResult> Authorize(string username, string password) {
            var result = await client.Authorize(username, password);
            if (result.IsValid) token = result.Token;
            return result;
        }

        /// <summary>
        /// Gets a list of servers
        /// </summary>
        /// <returns>list of servers</returns>
        public async Task<ServerResult> GetServers() {
            return await client.GetServers(token);
        }

        /// <summary>
        /// Logs out - i.e. clears the token
        /// </summary>
        public void LogOut() {
            token = String.Empty;
        }
    }

}
