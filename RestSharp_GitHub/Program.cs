using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Text.Json;

//HOW TO EXECUTE GET REQUEST

var client = new RestClient("https://api.github.com");
// FOR POST
client.Authenticator = new HttpBasicAuthenticator("ivantenchev", "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");

//var request = new RestRequest("/users/ivantenchev/repos");

// For the Repos

string url = "/repos/ivantenchev/postman/issues";
var request = new RestRequest(url);

request.AddBody(new { title = "New issue from RestSharp" });

//var request = new RestRequest("/repos/{user}/{repos}/issues/{id}");
//request.AddUrlSegment("user", "ivantenchev");
//request.AddUrlSegment("repos", "postman");

var response = await client.ExecuteAsync(request, Method.Post);

System.Console.WriteLine("Status Code" + response.StatusCode);
System.Console.WriteLine("Status Code" + response.Content);


// HOW TO DECEARLISE AKA DECODE THE TEXT


// GETTING REPOS
//var repos = JsonSerializer.Deserialize<List<Repo>>(response.Content);

// GETTING ISSUES

//var issues = JsonSerializer.Deserialize<List<Issue>>(response.Content);


//foreach (var issue in issues)
//{
//    System.Console.WriteLine("Issue numbers" + issue.number);
//    System.Console.WriteLine("ID number" + issue.id);
//    System.Console.WriteLine("ID number" + issue.html_url);
//    System.Console.WriteLine("*************************");
//}


//foreach (var repo in repos)
//{
  //  System.Console.WriteLine("REPO FULL NAME" + repo.full_name);
//}

//System.Console.WriteLine("Status code: " + response.StatusCode);
//System.Console.WriteLine("BODY: " + response.Content);




