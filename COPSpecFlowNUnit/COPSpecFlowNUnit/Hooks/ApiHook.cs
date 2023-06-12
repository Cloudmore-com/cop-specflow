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

    [BeforeScenario(tags:"CopApi")]
    public async Task BeforeScenario()
    {
        var responseJsonResponse = await _apiClient.ConnectToken(ApiConstants.HostAdminUsername, ApiConstants.HostAdminPassword);
        _scenarioContext.Add(ScenarioContextKeys.MichealAuthKey, responseJsonResponse);
        var markTokenResponse = await _apiClient.ConnectToken(ApiConstants.MarkUsername, ApiConstants.MarkPassword);
        _scenarioContext.Add(ScenarioContextKeys.MarkAuthKey, markTokenResponse);
        var allisterTokenResponse = await _apiClient.ConnectToken(ApiConstants.AllisterUsername, ApiConstants.AllisterPassword);
        _scenarioContext.Add(ScenarioContextKeys.AllisterAuthKey, allisterTokenResponse);
    }

    [AfterScenario]
    [Scope(Tag = "CopApi")]
    public async Task AfterScenario()
    {
        //TODO: implement logic that has to run after executing each scenario
        var response = _scenarioContext.Get<IAPIResponse>("PostResellerAdminResponse");
        response.Headers.TryGetValue("location", out string? locationUrl);
        if (locationUrl != null)
        {
            string[] splitedLocation = locationUrl.Split("/");
            // it is for cleaning environment from the test data, so it auth key might be host admin.
            // It is not related with the test scenario.
            await _apiClient.DeleteResellerAdmin(resellerAdminId: splitedLocation[7], ScenarioContextKeys.MichealAuthKey);
        }
    }
}