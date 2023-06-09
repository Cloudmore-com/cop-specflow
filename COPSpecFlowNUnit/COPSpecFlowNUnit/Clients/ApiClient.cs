using System.Text.Json;
using COPSpecFlowNUnit.Constants;
using Microsoft.Playwright;

namespace COPSpecFlowNUnit.Clients;

public class ApiClient
{
    private ScenarioContext _scenarioContext;

    public ApiClient(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    
    private async Task<IAPIRequestContext> CreateApiRequestContext(Dictionary<string, string> headers, string url)
    {
        var playwright = await Playwright.CreateAsync();
        var request = await playwright.APIRequest.NewContextAsync(new() {
            // All requests we send go to this API endpoint.
            BaseURL = url,
            ExtraHTTPHeaders = headers,
        });
        return request;
    }
    
    private async Task<IAPIRequestContext> CreateApiRequestContextForAuthentication()
    {
        var headers = new Dictionary<string, string>();
        headers.Add("Accept", "*/*");
        headers.Add("Content-Type", "application/x-www-form-urlencoded");
        return await CreateApiRequestContext(headers, ApiConstants.BaseUrl + ApiConstants.AuthUrl);
    }
    

    public async Task<JsonElement?> ConnectToken(string username, string password)
    {
        var requestContext = await CreateApiRequestContextForAuthentication();
        var formData = requestContext.CreateFormData()
            .Set("client_id", ApiConstants.ClientId)
            .Set("client_secret", ApiConstants.ClientSecret)
            .Set("grant_type", ApiConstants.GrantType)
            .Set("scope", ApiConstants.Scope)
            .Set("username",username)
            .Set("password",password);
        var response = await requestContext.PostAsync(ApiConstants.AuthUrl, new APIRequestContextOptions()
        {
            Form = formData
        });
        var responseJsonResponse = await response.JsonAsync();
        await requestContext.DisposeAsync();
        return responseJsonResponse;
    }

    private string? GetSellerAdminToken()
    {
        JsonElement hostAdminAuth = _scenarioContext.Get<JsonElement>("HostAdminAuth");
        var accessToken = hostAdminAuth.GetProperty("access_token").GetString();
        return accessToken;
    }

    
    public async Task<IAPIResponse> PostSellerAdmin(Dictionary<string, object> resellerAdminData)
    {
        var token = GetSellerAdminToken();
        var url = ApiConstants.BaseUrl + ApiConstants.SellerAdminUrl;
        var requestContext = await CreateApiRequestContext(headers: new Dictionary<string, string>()
        {
            { "accept", "application/json" },
            { "Authorization", "Bearer " + token },
            { "Content-Type", "application/json" }
        }, url);
        return await requestContext.PostAsync(url: url, new APIRequestContextOptions()
        {
            DataObject = resellerAdminData
        });
    }

    public async Task<IAPIResponse> DeleteResellerAdmin(string resellerAdminId)
    {
        var token = GetSellerAdminToken();
        var url = ApiConstants.BaseUrl + ApiConstants.SellerAdminUrl + "/" + resellerAdminId; 
        var requestContext = await CreateApiRequestContext(headers: new Dictionary<string, string>()
        {
            { "accept", "application/json" },
            { "Authorization", "Bearer " + token },
            { "Content-Type", "application/json" }
        }, url);
        return await requestContext.DeleteAsync(url: url);
    }
    
}