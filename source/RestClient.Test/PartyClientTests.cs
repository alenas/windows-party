using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestApiClient;

namespace RestApiClient.Test {

	/// <summary>
	/// Tests for Playground REST API
	/// </summary>
	[TestClass]
	public class PartyClientTests {

		/// <summary>
		/// Party REST API Client
		/// </summary>
		PartyClient client = null;

		/// <summary>
		/// Initializes web client
		/// </summary>
		public PartyClientTests() {
			client = new PartyClient(Properties.Resources.URL);
		}

		/// <summary>
		/// Tests authorization call with invalid user credentials
		/// </summary>
		[TestMethod]
		public void InvalidAuthorizationTest() {
			var result = client.Authorize("", null).Result;
			Assert.IsNull(result.Token);
			Assert.IsNotNull(result.Message);
		}

		/// <summary>
		/// Tests authorization call with user credentials from resource file
		/// </summary>
		[TestMethod]
		public void AuthorizationTest() {
			var result = client.Authorize(Properties.Resources.UserName, Properties.Resources.Password).Result;
			Assert.IsNotNull(result.Token);
			Assert.IsNull(result.Message);
		}

		/// <summary>
		/// Tests get server list with user credentials from resource file
		/// </summary>
		[TestMethod]
		public void ServersTest() {
			var result = client.GetServers(Properties.Resources.UserName, Properties.Resources.Password).Result;
			Assert.IsNotNull(result.ServerList);
			Assert.IsNull(result.Message);
		}

		/// <summary>
		/// Tests get server list with invalid user credentials
		/// </summary>
		[TestMethod]
		public void WrongServersTest() {
			var result = client.GetServers(null, "").Result;
			Assert.IsNull(result.ServerList);
			Assert.IsNotNull(result.Message);
		}

	}
}
