using COPSpecFlowNUnit.Constants;
using COPSpecFlowNUnit.Pages;
using Microsoft.Playwright;

namespace COPSpecFlowProject.Hooks;

[Binding]
public sealed class UiHook
{
    // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
    
    private ScenarioContext _scenarioContext;

    public UiHook(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    
    private async Task<IPage> InitPage()
    {
        var playwright = await Playwright.CreateAsync();
        playwright.Selectors.SetTestIdAttribute("id");
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
        {
            Headless = false
        });
        var context = await browser.NewContextAsync();

        return await context.NewPageAsync();
    }
    
    [BeforeScenario]
    [Scope(Tag = "CopUI")]
    public async Task BeforeScenario()
    {
        //TODO: implement logic that has to run before executing each scenario
        var page = await InitPage();
        await page.GotoAsync(UiConstants.BaseUrl + UiConstants.LoginUrl);
        _scenarioContext.Add(ScenarioContextKeys.PageKey, page);
        var msLoginPage = new MsLoginPage(page);
        var loginPage = new LoginPage(page);
        var dashBoardPage = new DashboardPage(page);
        _scenarioContext.Add(ScenarioContextKeys.LoginPageKey, loginPage);
        _scenarioContext.Add(ScenarioContextKeys.MsLoginPageKey, msLoginPage);
        _scenarioContext.Add(ScenarioContextKeys.DashboardPageKey, dashBoardPage);
    }

    [AfterScenario]
    [Scope(Tag = "CopUI")]
    public void AfterScenario()
    {
        //TODO: implement logic that has to run after executing each scenario
    }
}