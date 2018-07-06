using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TvBox.Models;

namespace TvBox.Views
{
    public partial class MainWindow
    {

        public MainWindow()
        {
            InitializeComponent();

            MyCanal myCanal = new MyCanal();
            myCanal.testCanalPlus(4);

            //testF1tv();
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            //Chrome tests
            var chrome = new Chrome("http://localhost:9222");
            var sessions = chrome.GetAvailableSessions();

            if (sessions.Count == 0)
                throw new Exception("All debugging sessions are taken.");

            // Will drive first tab session
            var sessionWSEndpoint = sessions[0].webSocketDebuggerUrl;
            chrome.SetActiveSession(sessionWSEndpoint);
            //chrome.NavigateTo("https://www.mycanal.fr/live/&params[tab]=/live-tv/pid5170-live-tv-v2-liste-des-chaines.html&params[filter]=0&params[filters-0$g$]=0$g$2$&params[filters-1$pt$]=current&get=500?epgId=177");
            var button = sender as Button;
            var code = button.Tag;
            //chrome.NavigateTo(code.ToString());
            chrome.Eval("window.location='"+ code.ToString() +"';");

            //chrome.Eval("document.querySelector('[data-sp-action=\"fullscreenBtPressed\"]').click();");

            //var result = chrome.Eval("document.getElementById('lst-ib').value='Hello World'");
            //result = chrome.Eval("document.forms[0].submit()");

            //Console.ReadLine();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            var chrome = new Chrome("http://localhost:9222");
            var sessions = chrome.GetAvailableSessions();

            if (sessions.Count == 0)
                throw new Exception("All debugging sessions are taken.");

            // Will drive first tab session
            var sessionWSEndpoint = sessions[0].webSocketDebuggerUrl;
            chrome.SetActiveSession(sessionWSEndpoint);
            chrome.Eval("window.close()");
            System.Windows.Application.Current.Shutdown();
        }
        

        private void testF1tv()
        {
            string url = "https://account.formula1.com/#/FR/login";
            

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("disable-infobars");

            var driver = new ChromeDriver(chromeOptions);

            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.FullScreen();

            //Login
            var userNameField = driver.FindElementByXPath("//input[@name='Login']");
            var userPasswordField = driver.FindElementByXPath("//input[@name='Password']");
            userNameField.SendKeys("ramzi.haddad00@gmail.com");
            userPasswordField.SendKeys("raikkonen2007");
            var loginButton = driver.FindElementByXPath("//button[@type='submit']");
            loginButton.Click();


            WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.Id("accountManagementDiv")));

            driver.Navigate().GoToUrl("https://f1tv.formula1.com/FR/");

            //Play live
            WebDriverWait waitForElement2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitForElement2.Until(ExpectedConditions.ElementIsVisible(By.ClassName("episode__circle-wrapper-__-IiO58")));

            var playLive = driver.FindElementByClassName("episode__circle-wrapper-__-IiO58");
            //playLive.Click();

            var playButton = playLive.FindElement(By.TagName("a"));
            playButton.Click();

            //Play Raikko
            var raikko = driver.FindElementByXPath("//div[text()='RAI']");
            raikko.Click();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            textbox1.Text = "You Entered: " + e.Key.ToString();
        
        }
    }
}
