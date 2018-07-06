using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvBox.Models
{
    class MyCanal
    {
        public Dictionary<int, string> chaines = new Dictionary<int, string>()
        {
            { 4, "CHN43FN_301_20170719"}
        };

        public void testCanalPlus(int chaine)
        {
            //string url = "https://www.mycanal.fr/live/&params[tab]=/live-tv/pid5170-live-tv-v2-liste-des-chaines.html&params[filter]=0&params[filters-0$g$]=0$g$2$&params[filters-1$pt$]=current&get=500?epgId=177";
            string url = "https://www.mycanal.fr/";
            //string url = "https://pass.canal-plus.com/form/authentication_sms_activation?bundle=site&ssoconf=auth_mini_actsms_myc&popin=true&pass_target=https%3A%2F%2Fwww.mycanal.fr%2F%23%3Forigref%3D&urlSource=https%3A%2F%2Fwww.mycanal.fr%2F%3Forigref%3D&pass_modal=false&socialLinksDisabled=true&omnitureChannel=Usage&distributorId=D22024";


            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("disable-infobars");
            chromeOptions.AddArgument(string.Format("user-data-dir={0}", "C:/Users/Chrys/AppData/Local/Google/Chrome/User Data"));

            var driver = new ChromeDriver(chromeOptions);
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.FullScreen();

            

            WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.Id("application")));

            driver.Navigate().GoToUrl("https://www.mycanal.fr/live/");

            //Find channel button
            var canalplus = driver.FindElementByXPath("//img[contains(@src, '"+ chaines[chaine] +".PNG')]");
            canalplus.Click();

        }
        
        void test() {
            //Login
            //var loginButton = driver.FindElementByXPath("//a[@class='link___64Swd pass_popin pass_auth_mini_actsms_myc']");
            //loginButton.Click();

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            /*driver.SwitchTo().Frame("pass_iframe");

            var userNameField = driver.FindElementByXPath("//input[@name='ssoEmail']");
            var userPasswordField = driver.FindElementByXPath("//input[@name='ssoPass']");

            userNameField.SendKeys("christophe.aroule@gmail.com");
            userPasswordField.SendKeys("raikkonen2007");

            var loginButton = driver.FindElementByXPath("//input[@value='Valider']");
            loginButton.Click();*/
        }
    }
}
