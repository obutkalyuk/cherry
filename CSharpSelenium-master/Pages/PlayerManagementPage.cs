using System;
using OpenQA.Selenium;
using Project.Entities;

namespace Project.Pages
{
    public class PlayerManagementPage : StartPage
    {
        
        private static readonly String Title = "Cherry Casino";
        public PlayerManagementPage(IWebDriver driver)
           : base(driver)
        {


        }

        #region Locators
        const string tableXPath = "//*[@id='content']/table";



        #endregion

        #region Controls

        private IWebElement playerTable => Driver.FindElement(By.Id(tableXPath));


        #endregion

        #region Methods

        public Player CreateNewPlayer()
        {
            var playerDetails = GoToNewPlayer();
            playerDetails.Fillfields();
            playerDetails.Save();
            return playerDetails.GetFields();
        }

        private PlayerDetailsPage GoToNewPlayer()
        {
            string playerDetailUrl = $"{Driver.Url}new";
            Driver.Navigate().GoToUrl(playerDetailUrl);
            return new PlayerDetailsPage(Driver);
        }

        public void DeletePlayer(string newPlayerId)
        {
            string playerDetailUrl = $"{Driver.Url}{newPlayerId}";
            Driver.Navigate().GoToUrl(playerDetailUrl);
            var playerPage =  new PlayerDetailsPage(Driver);
            playerPage.Delete();
        }
        #endregion


    }

}
