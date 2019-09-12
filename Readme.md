# Funda Assignment
This project contains the assignment from [Funda.nl](https://www.funda.nl/).

## Requirements
In order to run the project you will need the following installed
- [.NET Core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) *Community version should be fine!
- [NodeJS v10.16.6](https://nodejs.org/en/download/) *Should install with Visual Studio if you select Node project development

## Technologies Used
For this project I used the following technologies
- .NET Core 2.2
- React.JS
- C#
- JavaScript
- CSS

## Installation
Installing the project is straight forward:
1. Clone the Repository by running `git clone https://github.com/lakylekidd/funda-assignment.git funda-project`
2. Run `cd funda-project`
3. Run `start Funda.sln`
4. Right click on the project solution name and select `Set StartUp Projects...`
5. In the new window select `Multiple startup projects`
6. For `FundaReactClient` and `FundWebApplication` set action to `Start`
7. Make sure `FundaWebApplication` is first on the list, use the arrows to arrange the order then click `OK`
8. Select Start Without Debugging `Ctrl + F5`.

Wait for the application to download all packages and npm modules and then the client browser window will launch.
> **Note**: For this project to run you need to have ports: 60398, 56219, 5000 and 3000 available. Check launchSettings.json for port configurations for Client and API Projects.

## Assignment Description
Determine which makelaar's in Amsterdam have the most object listed for sale. Make a table of the top 10. 
Then do the same thing but only for objects with a tuin which are listed for sale. 
For the assignment you may write a program in any object oriented language of your choice and you may 
use any libraries that you find useful.

**Tips:**
- If you perform too many API requests in a short period of time (>100 per minute), the API will
reject the requests. Your implementation should mitigate (avoid) errors and handle any errors
that occur, so take both into account.
- Different people will look at your solution, so make sure it is easy to understand and go through.
- We don't expect solutions to have a comprehensive test suite, but we do expect solutions to be testable.

We value creative problem-solving. If you are not sure about implementation details of the exercise, please remember: 
It is more important to show your competencies than to get "the right answer". 
Please explain your decisions and thought process.

## Too many Requests
While the API allows for configuring the number of properties to display in one result, there is a fixed limit of 25 properties.
Even if the query includes `pageSize=n` where `n > 25`, the limit will still apply.

In order to overcome this we will be implementing some policies based on the article  
[Implement Http call retries with exponential bacckoff with HttpClientFactory and Polly policies](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly) 
as this is the recommended approach for retries with exponential backoff.

For this we will implement the following function:

```
static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()

    #region Status Codes for Retrying
        // Handle 500 status codes
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                // Handle 502 status codes
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.BadGateway)
                // Handle 504 status codes
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.GatewayTimeout)
                // Handle 503 status codes 
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
                // Handle 429 status codes Too Many Requests
                .OrResult(msg => (int)msg.StatusCode == 429)
                // Handle 401 status codes
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.Unauthorized && msg.ReasonPhrase == "Request limit exceeded")
    #endregion

        // Will retry a maximum of 6 times
        .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
}
```

And include it inside the `ConfigureServices()` of the `Startup.cs` file:

```
// Configure the client with polly's retry policy
services.AddHttpClient<IFundaService, FundaService>()
    .SetHandlerLifetime(TimeSpan.FromMinutes(5)) // Set the lifetime to 5 minutes
    .AddPolicyHandler(GetRetryPolicy());
```

In order to prevent any errors, the policy will attempt to retry when the following status codes are encountered
- 500 - Internal Server Error
- 502 - Bad Gateway
- 504 - Gateway Timeout
- 503 - Service Unavailable
- 429 - Too Many Requests
- 401 - Unauthorized with Reason Phrase `Request limit exceeded`

### Testing
In order to test the application and make sure the new implementations work, I will be following [this article](https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-2.2) 
that explains how to better perform integration tests in .NET Core 2.2.

