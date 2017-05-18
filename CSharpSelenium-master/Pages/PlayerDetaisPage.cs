using System;
using Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Project.Entities;

namespace Project.Pages
{
    public class PlayerDetailsPage : StartPage
    {
        private static readonly String Title = "Cherry Casino";
        public PlayerDetailsPage(IWebDriver driver)
           : base(driver)
        { }
        #region Locators

        private string DeleteButtonId = "form_submit";
        private string BackToListButtonXpath = ".//a[contains(text(),'Back to the list')]";
        private string CreateButtonXpath = "//*[@id='cherry_casinobundle_player_submit']";

        private string EmailInputId = "cherry_casinobundle_player_email";
        private string PasswordInputId = "cherry_casinobundle_player_password";
        private string NameInputId = "cherry_casinobundle_player_name";
        private string LastNameInputId = "cherry_casinobundle_player_lastname";
        private string AgeInputId = "cherry_casinobundle_player_age";
        private string GenderInputId = "cherry_casinobundle_player_gender";

        private string IDTextXpath = "//th[.='Id']/../td";
        private string EmailTextXpath = "//th[.='Email']/../td";
        private string PasswordTextXpath = "//th[.='Password']/../td";
        private string NameTextXpath = "//th[.='Name']/../td";
        private string LastNameTextXpath = "//th[.='Lastname']/../td";
        private string AgeTextXpath = "//th[.='Age']/../td";
        private string GenderTextXpath = "//th[.='Gender']/../td";
        private string CreatedTextXpath = "//th[.='Createdat']/../td";
        private string UpdatedTextXpath = "//th[.='Updatedat']/../td";

        #endregion
        

        #region Controls
        private IWebElement DeleteButton => Driver.FindElement(By.Id(DeleteButtonId));
        private IWebElement BackToListButton => Driver.FindElement(By.XPath(BackToListButtonXpath));
        private IWebElement CreateButton => Driver.FindElement(By.XPath(CreateButtonXpath));

        private IWebElement EmailInput => Driver.FindElement(By.Id(EmailInputId));
        private IWebElement PasswordInput => Driver.FindElement(By.Id(PasswordInputId));
        private IWebElement NameInput => Driver.FindElement(By.Id(NameInputId));
        private IWebElement LastNameInput => Driver.FindElement(By.Id(LastNameInputId));
        private IWebElement AgeInput => Driver.FindElement(By.Id(AgeInputId));
        private SelectElement GenderSelect => new SelectElement(Driver.FindElement(By.Id(GenderInputId)));

        private IWebElement IDText => Driver.FindElement(By.XPath(IDTextXpath));
        private IWebElement EmailText => Driver.FindElement(By.XPath(EmailTextXpath));
        private IWebElement PasswordText => Driver.FindElement(By.XPath(PasswordTextXpath));
        private IWebElement NameText => Driver.FindElement(By.XPath(NameTextXpath));
        private IWebElement LastNameText => Driver.FindElement(By.XPath(LastNameTextXpath));
        private IWebElement AgeText => Driver.FindElement(By.XPath(AgeTextXpath));
        private IWebElement GenderText => Driver.FindElement(By.XPath(GenderTextXpath));
        private IWebElement CreatedText => Driver.FindElement(By.XPath(CreatedTextXpath));
        private IWebElement UpdatedText => Driver.FindElement(By.XPath(UpdatedTextXpath));


        #endregion
       
        #region Methods
        public PlayerManagementPage Delete()
        {
            DeleteButton.Click();
            return new PlayerManagementPage(Driver);
        }

        public PlayerManagementPage BackToList()
        {
            BackToListButton.Click();
            return new PlayerManagementPage(Driver);
        }

        public void Fillfields()
        {
            Player randomPlayer = new Player(
                $"{StringHelper.GetRandomString(6)}@gmail.com",
                $"{StringHelper.GetRandomString(8)}",
                $"Name{StringHelper.GetRandomString(6)}",
                $"LastName{StringHelper.GetRandomString(6)}",
                $"{StringHelper.GetRandomNumberString(2)}",
                "Female");

            EmailInput.Clear();
            EmailInput.SendKeys(randomPlayer.Email);
            PasswordInput.Clear();
            PasswordInput.SendKeys(randomPlayer.Password);
            NameInput.Clear();
            NameInput.SendKeys(randomPlayer.Name);
            LastNameInput.Clear();
            LastNameInput.SendKeys(randomPlayer.LastName);
            AgeInput.Clear();
            AgeInput.SendKeys(randomPlayer.Age);
            GenderSelect.SelectByText(randomPlayer.Gender);
        }

        public void Save()
        {
            CreateButton.Click();
        }

        public Player GetFields()
        {
            Player result = new Player
            {
                Id = IDText.Text,
                Email = EmailText.Text,
                Password = PasswordText.Text,
                Name = NameText.Text,
                LastName = LastNameText.Text,
                Age = AgeText.Text,
                Gender = GenderText.Text,
                Created = CreatedText.Text,
                Updated = UpdatedText.Text
            };
            return result;
        }

        #endregion


    }

}
