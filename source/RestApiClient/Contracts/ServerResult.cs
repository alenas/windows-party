using Model;

namespace RestApiClient.Contracts {

	/// <summary>
	/// Result with a server list or error message
	/// </summary>
	public class ServerResult : ResponseBase {

		/// <summary>
		/// Server list
		/// </summary>
		public Server[] ServerList { get; set; }

	}
}
