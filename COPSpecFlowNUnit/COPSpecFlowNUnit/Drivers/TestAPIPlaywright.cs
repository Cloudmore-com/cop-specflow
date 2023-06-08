using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace COPSpecFlowNUnit.Drivers;

public class TestAPIPlaywright: PlaywrightTest
{
    private static readonly string ApiUrl = "https://api-staging.cloudmore.com";
    private static readonly string ApiAuthUrl = ApiUrl + "/connect/token";

    private IAPIRequestContext Request = null;
    
    [SetUp]
    public async Task SetUpAPITesting()
    {
        await CreateAPIRequestContext();
    }

    private async Task CreateAPIRequestContext()
    {
        var headers = new Dictionary<string, string>();
        // We set this header per GitHub guidelines.
        headers.Add("Accept", "*/*");
        headers.Add("Content-Type", "application/x-www-form-urlencoded");

        Request = await this.Playwright.APIRequest.NewContextAsync(new() {
            // All requests we send go to this API endpoint.
            BaseURL = ApiAuthUrl,
            ExtraHTTPHeaders = headers,
        });
    }


    [Test]
    public async Task SetHostAdminAuthentication()
    {
        var formData = Request.CreateFormData()
            .Set("client_id", "ro.customer.client")
            .Set("client_secret", "CloudM88reAPiSecr37")
            .Set("grant_type", "password")
            .Set("scope", "api")
            .Set("username","adm_boris.tsarjov@domain01.net")
            .Set("password","MB49!cP#8xP3");

        var response = await Request.PostAsync(ApiAuthUrl, new APIRequestContextOptions()
        {
            Form = formData
        });

        var responseJsonResponse = await response.JsonAsync();
        var responseJson = responseJsonResponse?.EnumerateObject();
        
    }

    [TearDown]
    public async Task TearDownAPITesting()
    {
        await Request.DisposeAsync();
    }
    
    
}