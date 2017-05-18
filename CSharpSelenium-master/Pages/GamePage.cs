using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;


namespace Project.Pages
{
    public class GamePage : StartPage
    {
        
        private static readonly String Title = "Cherry Casino";
        public GamePage(IWebDriver driver)
    : base(driver)
        { }

        #region Locators

        private string DepositButtonXpath = "//button[.='Deposit']";
        private string DepositInputXpath = "//input[@name='deposit']";
        private string SpinButtonXpath = "//button[.='Spin!']";
        private string LoginButtonLink = "Login";
        private string TotalId = "total-balance";
        private string TableRowsXpath = "//*[@id='content']//table//tr";
        private string MessageId = "alerts";


        #endregion

        #region Controls
        private IWebElement DepositeButton => Driver.FindElement(By.XPath(DepositButtonXpath));
        private IWebElement DepositeInput => Driver.FindElement(By.XPath(DepositInputXpath));
        private IWebElement SpinButton => Driver.FindElement(By.XPath(SpinButtonXpath));
        private IWebElement LoginButton => Driver.FindElement(By.LinkText(LoginButtonLink));
        private IWebElement Total => Driver.FindElement(By.Id(TotalId));
        private IWebElement Message => Driver.FindElement(By.Id(MessageId));

        #endregion

        #region Methods

        public string GetTotalAmount()
        {
            return Total.Text;
        }


        public void Deposit(string s)
        {
            DepositeInput.Clear();
            DepositeInput.SendKeys(s);
            DepositeButton.Click();
        }

        public void Login()
        {
            LoginButton.Click();
        }

        public List<string> GetWalletList()
        {
            var rowList = Driver.FindElements(By.XPath(TableRowsXpath));
            return rowList.Select(row => row.Text).ToList();
        }

        public string GetMesage()
        {
           return Message.Text;
        }

        #endregion

       
    }

}
