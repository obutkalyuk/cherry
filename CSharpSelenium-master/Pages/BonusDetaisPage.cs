using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Project.Entities;

namespace Project.Pages
{
    public class BonusDetailsPage : StartPage
    {
        private static readonly String Title = "Cherry Casino";
        public BonusDetailsPage(IWebDriver driver)
    : base(driver)
        { }

        #region Locators

        private string DeleteButtonId = "form_submit";

        private string NameInputId = "cherry_casinobundle_bonus_name";
        private string TypeSelectId = "cherry_casinobundle_bonus_type";
        private string RewardInputId = "cherry_casinobundle_bonus_reward";
        private string CurrencySelectId = "cherry_casinobundle_bonus_rewardCurrency";
        private string MultiplierInputId = "cherry_casinobundle_bonus_wageringMultiplier";
        private string MinimumInputId = "cherry_casinobundle_bonus_minimum";
        private string CreateButtonId = "cherry_casinobundle_bonus_submit";

        private string IDTextXpath = "//th[.='Id']/../td";
        private string NameTextXpath = "//th[.='Name']/../td";
        private string TypeTextXpath = "//th[.='Type']/../td";
        private string RewardTextXpath = "//th[.='Reward']/../td";
        private string IsPercentageTextXpath = "//th[.='Is reward percentage?']/../td";
        private string CurrencyTextXpath = "//th[.='Reward currency']/../td";
        private string MultiplierTextXpath = "//th[.='Wagering multiplier']/../td";
        private string MinimumTextXpath = "//th[.='Minimum']/../td";
        private string StatusTextXpath = "//th[.='Status']/../td";

        


        #endregion

        #region Controls
        private IWebElement DeleteButton => Driver.FindElement(By.Id(DeleteButtonId));

        private IWebElement IDText => Driver.FindElement(By.XPath(IDTextXpath));
        private IWebElement NameText => Driver.FindElement(By.XPath(NameTextXpath));
        private IWebElement TypeText => Driver.FindElement(By.XPath(TypeTextXpath));
        private IWebElement RewardText => Driver.FindElement(By.XPath(RewardTextXpath));
        private IWebElement IsPercentageText => Driver.FindElement(By.XPath(IsPercentageTextXpath));
        private IWebElement CurrencyText => Driver.FindElement(By.XPath(CurrencyTextXpath));
        private IWebElement MultiplierText => Driver.FindElement(By.XPath(MultiplierTextXpath));
        private IWebElement MinimumText => Driver.FindElement(By.XPath(MinimumTextXpath));
        private IWebElement StatusText => Driver.FindElement(By.XPath(StatusTextXpath));

        private IWebElement NameInput => Driver.FindElement(By.Id(NameInputId));
        private SelectElement TypeSelect => new SelectElement(Driver.FindElement(By.Id(TypeSelectId)));
        private IWebElement RewardInput => Driver.FindElement(By.Id(RewardInputId));
        private SelectElement CurrencySelect => new SelectElement(Driver.FindElement(By.Id(CurrencySelectId)));
        private IWebElement MultiplierInput => Driver.FindElement(By.Id(MultiplierInputId));
        private IWebElement MinimumInput => Driver.FindElement(By.Id(MinimumInputId));
        private IWebElement CreateButton => Driver.FindElement(By.Id(CreateButtonId));


        #endregion

        #region Methods
        public BonusManagementPage DeleteBonus()
        {
            DeleteButton.Click();
            return new BonusManagementPage(Driver);
        }

        public void Fillfields(Bonus bonus)
        {
            NameInput.Clear();
            NameInput.SendKeys(bonus.Name);
            TypeSelect.SelectByText(bonus.Type);
            RewardInput.Clear();
            RewardInput.SendKeys(bonus.Reward);
            CurrencySelect.SelectByText(bonus.Currency);
            MultiplierInput.Clear();
            MultiplierInput.SendKeys(bonus.Wagering);
            MinimumInput.Clear();
            MinimumInput.SendKeys(bonus.Minimum);
        }
        public void Save()
        {
            CreateButton.Click();
        }
        public Bonus GetFields()
        {
            Bonus result = new Bonus
            {
                Id = IDText.Text,
                Name = NameText.Text,
                Currency = CurrencyText.Text,
                IsPercentage = IsPercentageText.Text=="1",
                Minimum = MinimumText.Text,
                Reward = RewardText.Text,
                Status = StatusText.Text,
                Type = TypeText.Text,
                Wagering = MultiplierText.Text
            };
            return result;
        }
        #endregion


    }

}
