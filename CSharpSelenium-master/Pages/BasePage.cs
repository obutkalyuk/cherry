using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Project.Pages
{

    public class BasePage
    {
        public IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            this.Driver = driver;

        }
        protected BasePage(IWebDriver driver,String Title)
        {
            this.Driver = driver;
            
            if (!Title.Equals(Driver.Title))
            {
                string msg = "Page with title : " + Title + " is not found";
                //takescreenshot();
                throw new NoSuchWindowException(msg);
                
            }
        }

        public void TakeScreenshot(string filename)
        {
            Screenshot ss = ((ITakesScreenshot)this.Driver).GetScreenshot();
            ss.SaveAsFile(filename, System.Drawing.Imaging.ImageFormat.Gif);
        }
    }
}
