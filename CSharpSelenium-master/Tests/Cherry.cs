using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Project.Entities;
using Project.Pages;

namespace Tests
{
    [TestFixture]
    class Cherry:BaseTest
    {
        const string expectedTotalBefore = "0 EUR";
        readonly List<string> expectedWaletListBefore = new List<string>() { "Total Balance 0 EUR", "Real money: 0 EUR" };

        [SetUp]
        public void SetupTest()
        {
            Driver = new ChromeDriver();  
        }
       
        /*
         * test 1 Deposit money without bonuses – 
           verification 
           - wallet value should be changed
           - new value should be 0 + deposit sum = deposit  sum as real money
           - message about deposit should appear
         */
        [Test]
        public void SimpleDeposite()
        {
            const string sumToDeposit = "1000";

            string expectedTotalAfter = $"{sumToDeposit} EUR";
            List<string> expectedWaletListAfter = new List<string>() { $"Total Balance {sumToDeposit} EUR", $"Real money: {sumToDeposit} EUR"};

            string expectedMessage = "On deposit simulated";


            Driver.Navigate().GoToUrl("http://casino.sznapka.pl");
            StartPage startPage = new StartPage(Driver);
            
            //Pretest
            var bonusPage = startPage.GoToBonusManagementPage();
           
            bonusPage.DeleteAllBonuses();
            var gamePage = CreateNewPlayerAndStart();

            // Actions
            var totalBefore = gamePage.GetTotalAmount();
            var walletListBefore = gamePage.GetWalletList();
            gamePage.Deposit(sumToDeposit);
            var totalAfter = gamePage.GetTotalAmount();
            var walletListAfter = gamePage.GetWalletList();
            var message = gamePage.GetMesage();
                    
            
            //verifications
            Assert.Multiple(() =>
            {
                Assert.That(totalBefore, Is.EqualTo(expectedTotalBefore), $"new user should have empty wallet. Expected - '{expectedTotalBefore}', actual - '{totalBefore}'");
                Assert.That(walletListBefore , Is.EqualTo(expectedWaletListBefore), "Wallet before deposit");
                Assert.That(totalAfter , Is.EqualTo(expectedTotalAfter), "total after deposit");
                Assert.That(walletListAfter , Is.EqualTo(expectedWaletListAfter), "Wallet after deposit");
                Assert.True(message.Contains(expectedMessage));

            });


        }

        

        /*
         * test 2 Create bonus for deposit and deposit money 
verification
- new deposit bonus should be created (to DB later)
- wallet value should be changed
- new value should be 0 + deposit sum + bonus = deposit sum as real money and bonus sum as bonus
- total sum should be sum real money and all bonus wallets
- message about deposit should appear
         */
        [Test]
        public void DepositeWithBonus()
        {
            Bonus initialBonus = new Bonus()
            {
                Name = "DepoBonus",
                Currency = "EUR",
                Id = "",
                IsPercentage = false,
                Minimum = "",
                Reward = "50",
                Status = "ACTIVE",
                Type = "On deposit",
                Wagering = "1"
            };

            const string sumToDeposit = "1000";
            string expectedTotalAfter = "1050";
            List<string> expectedWaletListAfter = new List<string>() { $"Total Balance {expectedTotalAfter} EUR", $"Real money: {sumToDeposit} EUR", $"BONUS (currency: EUR) {initialBonus.Reward} EUR" };

            string expectedMessage = "On deposit simulated";

            Driver.Navigate().GoToUrl("http://casino.sznapka.pl");
            StartPage startPage = new StartPage(Driver);
            //Pretest
            var bonusPage = startPage.GoToBonusManagementPage();
            bonusPage.DeleteAllBonuses();
            var createdBonus = bonusPage.AddBonus(initialBonus);

            var gamePage = CreateNewPlayerAndStart();

            // Actions
            var totalBefore = gamePage.GetTotalAmount();
            var walletListBefore = gamePage.GetWalletList();
            gamePage.Deposit(sumToDeposit);
            var totalAfter = gamePage.GetTotalAmount();
            var walletListAfter = gamePage.GetWalletList();
            var message = gamePage.GetMesage();


            //verifications
            Assert.Multiple(() =>
            {
                Assert.That(totalBefore, Is.EqualTo(expectedTotalBefore), $"new user should have empty wallet. Expected - '{expectedTotalBefore}', actual - '{totalBefore}'");
                Assert.That(walletListBefore, Is.EqualTo(expectedWaletListBefore), "Wallet before deposit");
                Assert.That(totalAfter, Is.EqualTo($"{expectedTotalAfter} EUR"), "total after deposit");
                Assert.That(walletListAfter, Is.EqualTo(expectedWaletListAfter), "Wallet after deposit");
                Assert.True(message.Contains(expectedMessage));

            });
        }
        
        /*
         * test 3 Create bonus for login and get bonus for login
- new login bonus should be created (to DB later)
- new user should be created
after action
- wallet value should be changed
- new value should be 0  + login bonus = login bonus as bonus
- message about using login bonus should appear
         */
        [Test]
        public void LoginWithBonus()
        {
            Bonus initialBonus = new Bonus()
            {
                Name = "DepoBonus",
                Currency = "EUR",
                Id = "",
                IsPercentage = false,
                Minimum = "",
                Reward = "125",
                Status = "ACTIVE",
                Type = "On login",
                Wagering = "1"
            };

            string expectedTotalAfter = initialBonus.Reward;
            List<string> expectedWaletListAfter = new List<string>() { $"Total Balance {initialBonus.Reward} EUR", $"Real money: 0 EUR", $"BONUS (currency: EUR) {initialBonus.Reward} EUR" };

            string expectedMessage = "On login simulated";

            Driver.Navigate().GoToUrl("http://casino.sznapka.pl");
            StartPage startPage = new StartPage(Driver);
            //Pretest
            var bonusPage = startPage.GoToBonusManagementPage();
            bonusPage.DeleteAllBonuses();
            var createdBonus = bonusPage.AddBonus(initialBonus);

            var gamePage = CreateNewPlayerAndStart();

            // Actions
            var totalBefore = gamePage.GetTotalAmount();
            var walletListBefore = gamePage.GetWalletList();
            gamePage.Login();
            var totalAfter = gamePage.GetTotalAmount();
            var walletListAfter = gamePage.GetWalletList();
            var message = gamePage.GetMesage();


            //verifications
            Assert.Multiple(() =>
            {
                Assert.That(totalBefore, Is.EqualTo(expectedTotalBefore), $"new user should have empty wallet. Expected - '{expectedTotalBefore}', actual - '{totalBefore}'");
                Assert.That(walletListBefore, Is.EqualTo(expectedWaletListBefore), "Wallet before login");
                Assert.That(totalAfter, Is.EqualTo($"{expectedTotalAfter} EUR"), "total after lgin");
                Assert.That(walletListAfter, Is.EqualTo(expectedWaletListAfter), "Wallet after login");
                Assert.True(message.Contains(expectedMessage));
            });
        }

        [Test]
        public void Test()
        {
            int part = 1700;
            int total = 3200;
            decimal value = (part / total) * 100;
            double value1 = (part / total) * 100;
            float value2 = (part / total) * 100;
            var a = 2;
        }

        private static GamePage CreateNewPlayerAndStart()
        {
            StartPage startPage = new StartPage(Driver);
            var playerListPage = startPage.GoToPlayerManagementPage();
            Player newPlayer = playerListPage.CreateNewPlayer();
            startPage = playerListPage.GoToSimulationPage();
            var gamePage = startPage.GoToGamePage($"{newPlayer.Name} {newPlayer.LastName}");
            return gamePage;
        }

        [TearDown]
        public void Teardown()
        {
            //Step e
            Driver.Quit();
        }
    }
}
