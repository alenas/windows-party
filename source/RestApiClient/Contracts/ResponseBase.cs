using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiClient.Contracts {

	/// <summary>
	/// Server response base class
	/// </summary>
	public abstract class ResponseBase {

		/// <summary>
		/// Error message
		/// </summary>
		public string Message { get; set; }

	}
}
