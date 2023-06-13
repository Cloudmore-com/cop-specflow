using Microsoft.Playwright;

namespace COPSpecFlowNUnit.Pages;

public class MsLoginPage : BasePage
{
    public MsLoginPage(IPage page) : base(page)
    {
        
    }

    public async Task FillEmail(string email)
    {
        await Page.GetByPlaceholder("Email address, phone number or Skype").FillAsync(email);
    }

    public async Task ClickNextButton()
    {
        await Page.GetByText("Next").ClickAsync();
    }

    public async Task FillPassword(string password)
    {
        await Page.GetByPlaceholder("Password").FillAsync(password);
    }

    public async Task ClickSignInButton()
    {
        await Page.GetByText("Sign in").ClickAsync();
    }

    public async Task ClickStaySignedYesButton()
    {
        await Page.GetByText("Yes").ClickAsync();
    }
}