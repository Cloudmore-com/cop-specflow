using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;

namespace COPSpecFlowProject.Hooks;

[Binding]
public class ApiHook: PlaywrightTest
{
    // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

    private ScenarioContext _scenarioContext;
    private FeatureContext _featureContext;
    
    private static readonly string ApiUrl = "https://api-staging.cloudmore.com";
    private static readonly string ApiAuthUrl = ApiUrl + "/connect/token";
    
    public ApiHook(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    
    private async Task<IAPIRequestContext> CreateAPIRequestContextForAuthentication()
    {
        var headers = new Dictionary<string, string>();
        headers.Add("Accept", "*/*");
        headers.Add("Content-Type", "application/x-www-form-urlencoded");
        var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        var request = await playwright.APIRequest.NewContextAsync(new() {
            // All requests we send go to this API endpoint.
            BaseURL = ApiAuthUrl,
            ExtraHTTPHeaders = headers,
        });
        return request;
    }
    
    
    [BeforeScenario]
    public async Task BeforeScenario()
    {
        //TODO: implement logic that has to run before executing each scenario
        var requestContext = await CreateAPIRequestContextForAuthentication();
        var formData = requestContext.CreateFormData()
            .Set("client_id", "ro.customer.client")
            .Set("client_secret", "CloudM88reAPiSecr37")
            .Set("grant_type", "password")
            .Set("scope", "api")
            .Set("username","adm_boris.tsarjov@domain01.net")
            .Set("password","MB49!cP#8xP3");

        var response = await requestContext.PostAsync(ApiAuthUrl, new APIRequestContextOptions()
        {
            Form = formData
        });
        var responseJsonResponse = await response.JsonAsync();
        //var responseJson = responseJsonResponse?.EnumerateObject();
        
        _scenarioContext.Add("HostAdminAuth", responseJsonResponse);
        
        await requestContext.DisposeAsync();
    }

    [AfterScenario]
    public void AfterScenario()
    {
        //TODO: implement logic that has to run after executing each scenario
    }
}