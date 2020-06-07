using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGE
{
    public class OperarSistemasDPW
    {
        private ChromeOptions aChromeOptions;
        private ChromeDriverService aCromeDriverService;
        protected IWebDriver aDriver;

        public OperarSistemasDPW()
        {
            aChromeOptions = new ChromeOptions();
            aChromeOptions.AddUserProfilePreference("download.default_directory", "C:\\dowloadNF");
            aChromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            aChromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
            aChromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);
           // aChromeOptions.AddArgument("--headless");

            aCromeDriverService = ChromeDriverService.CreateDefaultService();
            aCromeDriverService.HideCommandPromptWindow = true;

            aDriver = new ChromeDriver(aCromeDriverService, aChromeOptions);
            aDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            //aDriver.Manage().Window.Minimize();
        }

        protected bool realizarLogin()
        {
            
            aDriver.Navigate().GoToUrl("https://www.embraportonline.com.br/Account/LogOn");

            aDriver.FindElement(By.Id("UserName")).SendKeys("vinicius.espuri");
            aDriver.FindElement(By.Id("Password")).SendKeys("Vini#1231");
            aDriver.FindElement(By.Id("btn-login")).Click();

            return aDriver.Url == "https://www.embraportonline.com.br/Account/LogOn" ? false : true;
        }
    }
}
