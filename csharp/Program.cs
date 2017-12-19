using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace QuickTypeDemo
{
    class Program
    {
        static async Task<User> MakeQuery(string authToken, string query) {
			var client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Clear();
            // GraphQL returns JSON
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
            // Let's be nice and tell the server who we are
			client.DefaultRequestHeaders.Add("User-Agent", "quicktype demo app");
            // The authentication token
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + authToken);
            // The query is embedded in a JSON object
            var requestString = Serialize.ToJson(new Request { Query = query });
            var content = new StringContent(requestString);
            // Make the request
            var response = await client.PostAsync("https://api.github.com/graphql", content);
            var jsonString = await response.Content.ReadAsStringAsync();
            // FIXME: Check error
            return Query.FromJson(jsonString).Data.Viewer;
		}

        static void Main(string[] args)
        {
            // Read the authentication token
            var authToken = File.ReadAllText("../auth-token").Trim();
            // Read the query string
            var queryString = File.ReadAllText("../schema/query.graphql");
            // Do the query
            var viewer = MakeQuery(authToken, queryString).Result;
            // Print the results
			Console.WriteLine("Login: {0}\nName: {1}", viewer.Login, viewer.Name);
        }
    }
}
