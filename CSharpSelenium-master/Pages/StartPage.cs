using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace Project.Pages
{
    public class StartPage : BasePage
    {
        private static readonly String Title = "Cherry Casino";
        public StartPage(IWebDriver driver)
            : base(driver, Title)
        {
            PageFactory.InitElements(driver, this);
        }

        #region Locators
        private string SimulationLink = "Simulation";
        private string PlayerListLink = "Players management";
        private string BonusListLink = "Bonuses management";

        private string PlayerSelectId = "player-select";
        private string ChangeButtonXpath = "//button[.='Change']";
        #endregion

        #region Controls
        private IWebElement SimulationMenuItem => Driver.FindElement(By.LinkText(SimulationLink));
        private IWebElement PlayerMenuItem => Driver.FindElement(By.LinkText(PlayerListLink));
        private IWebElement BonusMenuItem => Driver.FindElement(By.LinkText(BonusListLink));

        private SelectElement PlayerSelect => new SelectElement(Driver.FindElement(By.Id(PlayerSelectId)));
        private IWebElement ChangeButton => Driver.FindElement(By.XPath(ChangeButtonXpath));
#endregion


    

        #region Methods
        private void SelectPlayer(string playerFullName)
        {
            PlayerSelect.SelectByText(playerFullName);
        }

        public StartPage GoToSimulationPage()
        {
            SimulationMenuItem.Click();
            return new StartPage(Driver);
        }

        public GamePage GoToGamePage(string playerFullName)
        {
            var startPage = GoToSimulationPage();
            startPage.SelectPlayer(playerFullName);
            startPage.ChangeButton.Click();
            return new GamePage(Driver);
        }

        public PlayerManagementPage GoToPlayerManagementPage()
        {
            PlayerMenuItem.Click();
            return new PlayerManagementPage(Driver);

        }

        public BonusManagementPage GoToBonusManagementPage()
        {
            BonusMenuItem.Click();
            return new BonusManagementPage(Driver);

        }


        #endregion

    }

}
