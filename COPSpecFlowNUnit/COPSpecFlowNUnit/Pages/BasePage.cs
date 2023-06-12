using Microsoft.Playwright;

namespace COPSpecFlowNUnit.Pages;

public class BasePage
{
    protected readonly IPage Page;

    protected BasePage(IPage page)
    {
        Page = page;
    }
}