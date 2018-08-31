namespace RestApiClient.Contracts {

	/// <summary>
	/// Authorization Result received from API
	/// </summary>
	public class AuthorizationResult : ResponseBase {

		private string _token = null;
		/// <summary>
		/// Token if authorization was successful
		/// </summary>
		public string Token {
			get { return _token; }
			set {
				_token = value;
				IsValid = !string.IsNullOrWhiteSpace(value);
			}
		}

		/// <summary>
		/// Gets if token is valid
		/// </summary>
		public bool IsValid { get; private set; } = false;

	}
}
