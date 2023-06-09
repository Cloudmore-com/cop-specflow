using COPSpecFlowNUnit.Clients;
using COPSpecFlowNUnit.Constants;
using Microsoft.Playwright;

namespace COPSpecFlowProject.Hooks;

[Binding]
public class ApiHook
{
    // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

    private ScenarioContext _scenarioContext;
    private ApiClient _apiClient;

    public ApiHook(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _apiClient = new ApiClient(_scenarioContext);
    }

    [BeforeScenario]
    public async Task BeforeScenario()
    {
        var responseJsonResponse = await _apiClient.ConnectToken(ApiConstants.HostAdminUsername, ApiConstants.HostAdminPassword);
        _scenarioContext.Add("HostAdminAuth", responseJsonResponse);
    }

    [AfterScenario]
    public async Task AfterScenario()
    {
        //TODO: implement logic that has to run after executing each scenario
        var response = _scenarioContext.Get<IAPIResponse>("PostResellerAdminResponse");
        response.Headers.TryGetValue("location", out string? locationUrl);
        if (locationUrl != null)
        {
            string[] splitedLocation = locationUrl.Split("/");
            await _apiClient.DeleteResellerAdmin(resellerAdminId: splitedLocation[7]);
        }
        
        
    }
}