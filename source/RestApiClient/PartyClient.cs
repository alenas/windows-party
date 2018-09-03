using System.Threading.Tasks;
using RestApiClient.Contracts;
using Flurl;
using Flurl.Http;
using Model;

namespace RestApiClient {

	/// <summary>
	/// Playground REST API Client
	/// </summary>
	public class PartyClient {

		/// <summary>
		/// Base URL for API
		/// </summary>
		string baseUrl { get; set; }

		/// <summary>
		/// Default constructor sets base URL
		/// </summary>
		/// <param name="url">Base URL for API</param>
		public PartyClient(string url) {
			this.baseUrl = url;
		}

		/// <summary>
		/// Authorize user with a name and a password
		/// </summary>
		/// <param name="username">User name</param>
		/// <param name="password">Password</param>
		/// <returns>Authorization token or error message</returns>
		public async Task<AuthorizationResult> Authorize(string username, string password) {
			AuthorizationResult result = null;
            try {
                result = await baseUrl.AppendPathSegment("tokens")
                    .PostUrlEncodedAsync(new {
                        username = username,
                        password = password
                    })
                    .ReceiveJson<AuthorizationResult>();
            } catch (FlurlHttpTimeoutException) {
                result = new AuthorizationResult { Message = "Connection timed out" };
			} catch (FlurlHttpException ex) {
				result = new AuthorizationResult { Message = ex.Message };
			}
			return result;
		}

		/// <summary>
		/// Gets servers for a given user
		/// </summary>
		/// <param name="username">User name</param>
		/// <param name="password">Password</param>
		/// <returns>Server list or error message</returns>
		public async Task<ServerResult> GetServers(string username, string password) {
			var auth = await Authorize(username, password);
			ServerResult result = null;
			if (auth.IsValid) {
				result = await GetServers(auth.Token);
			} else {
				result = new ServerResult { Message = auth.Message };
			}
			return result;
		}

		/// <summary>
		/// Gets servers using authorization token
		/// </summary>
		/// <param name="token">Authorization token</param>
		/// <returns>Server list or error message</returns>
		public async Task<ServerResult> GetServers(string token) {
			ServerResult result = new ServerResult();
			try {
				result.ServerList = await baseUrl.AppendPathSegment("servers")
					.WithOAuthBearerToken(token)
					.GetJsonAsync<Server[]>();
			} catch (FlurlHttpException ex) {
				result.Message = ex.Message;
			}
			return result;
		}
	}
}
