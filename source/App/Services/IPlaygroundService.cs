using System.Threading.Tasks;
using RestApiClient.Contracts;

namespace App.Services {

    /// <summary>
    /// Interface for Playground Service
    /// </summary>
    public interface IPlaygroundService {

        Task<AuthorizationResult> Authorize(string username, string password);

        void LogOut();

    }
}
