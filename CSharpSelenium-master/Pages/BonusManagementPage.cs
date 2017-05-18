using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Project.Entities;

namespace Project.Pages
{
    public class BonusManagementPage : StartPage
    {
  
        private static readonly String Title = "Cherry Casino";
        public BonusManagementPage(IWebDriver driver)
    : base(driver)
        {


        }

        #region Locators

        const string allIdXPath = "//*[@id='content']/table//td[1]/a";
        const string tableXPath = "//*[@id='content']/table";

        #endregion

        #region Controls

        private IWebElement bonusTable => Driver.FindElement(By.Id(tableXPath));


        #endregion

        #region Methods

        public void DeleteAllBonuses()
        {
            List<string> idList = GetAllId();
            foreach (var id in idList)
            {
                string bonusDetailUrl = $"{Driver.Url}{id}";
                Driver.Navigate().GoToUrl(bonusDetailUrl);
                BonusDetailsPage page = new BonusDetailsPage(Driver);
                page.DeleteBonus();
            }
        }

        private List<string> GetAllId()
        {
            var idElementList = Driver.FindElements(By.XPath(allIdXPath));
            List<string> result = idElementList.Select(webElement => webElement.Text).ToList();
            return result;
        }

        public Bonus AddBonus(Bonus bonus)
        {
            var details = GoToNewBonus();
            details.Fillfields(bonus);
            details.Save();
            return details.GetFields();
        }

        private BonusDetailsPage GoToNewBonus()
        {
            string bonusDetailUrl = $"{Driver.Url}new";
            Driver.Navigate().GoToUrl(bonusDetailUrl);
            return new BonusDetailsPage(Driver);
        }

        #endregion


    }

}
