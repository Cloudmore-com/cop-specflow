using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using TechTalk.SpecFlow;

namespace COPSpecFlowProject.Hooks;

[Binding]
public sealed class UiHook
{
    // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

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