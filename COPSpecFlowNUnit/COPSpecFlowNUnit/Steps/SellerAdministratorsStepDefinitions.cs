using System.Text.Json;
using COPSpecFlowNUnit.Clients;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace COPSpecFlowNUnit;

[Binding]
public class SellerAdministratorsStepDefinitions: PlaywrightTest
{
    
    private readonly ScenarioContext _scenarioContext;
    private ApiClient _apiClient;

    public SellerAdministratorsStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _apiClient = new ApiClient(_scenarioContext);
    }

    [When(@"Micheal sends valid information to create seller admin for Gridheart")]
    public async Task WhenMichealSendsValidInformationToCreateSellerAdminForGridheart()
    {
        var response = await _apiClient.PostSellerAdmin(resellerAdminData: GetSellerAdminValidData());
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