using System.Text.Json;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace COPSpecFlowNUnit;

[Binding]
public class SellerAdministratorsStepDefinitions: PlaywrightTest
{
    
    private readonly ScenarioContext _scenarioContext;
    private IAPIRequestContext Request = null;
    
    private readonly string _apiSellerAdminUrl =
        "https://api-staging.cloudmore.com/api/sellers/01ebab7a-e130-e245-92a3-c0cafc8dc63e/selleradministrators";


    public SellerAdministratorsStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"Micheal sends valid information to create seller admin for Gridheart")]
    public async Task WhenMichealSendsValidInformationToCreateSellerAdminForGridheart()
    {
        JsonElement hostAdminAuth = _scenarioContext.Get<JsonElement>("HostAdminAuth");
        var accessToken = hostAdminAuth.GetProperty("access_token").GetString();
        var validSellerAdminData = GetSellerAdminValidData();

        var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        var requestContext = await playwright.APIRequest.NewContextAsync(new()
        {
            BaseURL = _apiSellerAdminUrl,
            ExtraHTTPHeaders = new Dictionary<string, string>()
            {
                { "accept", "application/json" },
                { "Authorization", "Bearer " + accessToken },
                { "Content-Type", "application/json" }
            }
        });

        var response = await requestContext.PostAsync(url: _apiSellerAdminUrl, new APIRequestContextOptions()
        {
            DataObject = validSellerAdminData
        });
        
        _scenarioContext.Add("PostResellerAdminResponse", response);
    }

    [Then(@"Seller administrator is created successfully for Gridheart")]
    public void ThenSellerAdministratorIsCreatedSuccessfullyForGridheart()
    {
        var response = _scenarioContext.Get<IAPIResponse>("PostResellerAdminResponse");
        Assert.AreEqual(201, response.Status);
    }

    private Dictionary<string, object> GetSellerAdminValidData()
    {
        var randomInt = new Random().Next(1, 1000);
        var validSellerAdminData = new Dictionary<string, object>();
        var validAddressData = new Dictionary<string, string>();
        validAddressData.Add("countryCode","UY");
        validAddressData.Add("street", "823 Kathy Plain Apt. 422");
        validAddressData.Add("postalCode","03744");
        validAddressData.Add("city","Harrisfort");
        validSellerAdminData.Add("name", randomInt + "auto_data_20230608_144314417029_box@testsellercloudmore.com");
        validSellerAdminData.Add("password","aE_iLmJOs$f0");
        validSellerAdminData.Add("firstName","auto_Jasmine");
        validSellerAdminData.Add("lastName","auto_Gray");
        validSellerAdminData.Add("displayName","auto_Jasmine auto_Gray");
        validSellerAdminData.Add("roleId","6");
        validSellerAdminData.Add("title","auto_source");
        validSellerAdminData.Add("email", "auto_morning@jackson.com");
        validSellerAdminData.Add("cellPhone", "5000000");
        validSellerAdminData.Add("cellPhonePrefix", "372");
        validSellerAdminData.Add("address", validAddressData);
        return validSellerAdminData;
    }
}