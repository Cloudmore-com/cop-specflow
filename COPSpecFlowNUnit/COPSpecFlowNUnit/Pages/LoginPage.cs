using Microsoft.Playwright;

namespace COPSpecFlowNUnit.Pages;

public class LoginPage: BasePage
{
    public LoginPage(IPage page) : base(page)
    {
        
    }

    public async Task ClickSsoButton()
    {
        await Page.GetByTestId("corporateSsoLoginLink").ClickAsync();   
    }

    public async Task FillSsoEmail(string email)
    {
        await Page.GetByTestId("CorporateSsoUsernameTextBox").FillAsync(email);
    }

    public async Task ClickSsoSubmitButton()
    {
        await Page.GetByTestId("StartCorporateSsoButton").ClickAsync();
    }

}