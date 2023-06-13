using Microsoft.Playwright;

namespace COPSpecFlowNUnit.Pages;

public class DashboardPage: BasePage
{
    public DashboardPage(IPage page) : base(page)
    {
    }

    public async Task<string?> GetProfileName()
    {
        return await Page.GetByTestId("TopNavbarContainer_UserMenu_ProfileName").TextContentAsync();
    }
}