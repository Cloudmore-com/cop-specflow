using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;

namespace COPSpecFlowProject.Hooks;

[Binding]
public sealed class ApiHook: PlaywrightTest
{
    // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

    private ScenarioContext _scenarioContext;
    
    private static readonly string ApiUrl = "https://api-staging.cloudmore.com";
    private static readonly string ApiAuthUrl = ApiUrl + "/connect/token";

    private IAPIRequestContext Request = null;

    public ApiHook(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    
    
    [BeforeScenario]
    public void BeforeScenario()
    {
        //TODO: implement logic that has to run before executing each scenario
    }

    [AfterScenario]
    public void AfterScenario()
    {
        //TODO: implement logic that has to run after executing each scenario
    }
}