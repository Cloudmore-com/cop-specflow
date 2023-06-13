using COPSpecFlowNUnit.Constants;
using COPSpecFlowNUnit.Pages;
using Microsoft.Playwright;
using NUnit.Framework;

namespace COPSpecFlowNUnit;

[Binding]
public class SSOStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    public SSOStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"Niklas submits his microsoft e-mail to Cloudmore portal")]
    public async Task GivenNiklasSubmitsHisMicrosoftEMailToCloudmorePortal()
    {
        var loginPage = _scenarioContext.Get<LoginPage>(ScenarioContextKeys.LoginPageKey);
        await loginPage.ClickSsoButton();
        await loginPage.FillSsoEmail(UiConstants.SsoUsername);
        await loginPage.ClickSsoSubmitButton();
    }

    [When(@"Niklas submits his microsoft credentials to Microsoft")]
    public async Task WhenNiklasSubmitsHisMicrosoftCredentialsToMicrosoft()
    {
        var msLoginPage = _scenarioContext.Get<MsLoginPage>(ScenarioContextKeys.MsLoginPageKey);
        await msLoginPage.FillEmail(UiConstants.SsoUsername);
        await msLoginPage.ClickNextButton();
        await msLoginPage.FillPassword(UiConstants.SsoPassword);
        await msLoginPage.ClickSignInButton();
        await msLoginPage.ClickStaySignedYesButton();
    }

    [Then(@"Niklas is authenticated successfully to Cloudmore portal")]
    public async Task ThenNiklasIsAuthenticatedSuccessfullyToCloudmorePortal()
    {
        var dashboardPage = _scenarioContext.Get<DashboardPage>(ScenarioContextKeys.DashboardPageKey);
        var actualProfileName = await dashboardPage.GetProfileName();
        Assert.That(actualProfileName, Is.EqualTo(UiConstants.SsoProfileName));
    }
}