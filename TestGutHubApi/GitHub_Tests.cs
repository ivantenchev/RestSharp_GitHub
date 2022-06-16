using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestGutHubApi
{
    public class GitHub_Tests
    {
        private RestClient client;
        private RestRequest request;


        [SetUp]
        public void Setup()
        {
            this.client = new RestClient("https://api.github.com");

            client.Authenticator = new HttpBasicAuthenticator("ivantenchev", "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");

            string url = "/repos/ivantenchev/postman/issues";

            this.request = new RestRequest(url);
        }

        [Test]
        public async Task Test_GetIssue()  // WE WRITE ASYNC BECAUSE WE HAVE AWAIT
        {
            var response = await client.ExecuteAsync(request);

            var issues = JsonSerializer.Deserialize<List<Issue>>(response.Content);

            foreach (var issue in issues)
            {
                Assert.IsNotNull(issue.html_url);
                Assert.IsNotNull(issue.id, "Issue ID must not be null");

            }

            Assert.IsNotNull(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }
    }
}