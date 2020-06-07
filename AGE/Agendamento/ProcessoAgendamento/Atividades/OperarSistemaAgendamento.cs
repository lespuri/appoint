using AGE.Exceptions;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace AGE.Agendamento.Atividades
{
    public class OperarSistemaAgendamento
    {
        private ChromeOptions aChromeOptions;
        private ChromeDriverService aCromeDriverService;
        protected IWebDriver aDriver;
        protected bool operacaoSucesso;

        protected static readonly ILog Log =
             LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        private XmlDocument aXmlDoc = new XmlDocument();

        public OperarSistemaAgendamento()
        {
            aXmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            aChromeOptions = new ChromeOptions();
            aChromeOptions.AddUserProfilePreference("download.default_directory", "C:\\dowloadNF");
            aChromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            aChromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
            aChromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);
            if (!bool.Parse(obterValorSetting("modeDebug")))
                aChromeOptions.AddArgument("--headless");

                aCromeDriverService = ChromeDriverService.CreateDefaultService();
            aCromeDriverService.HideCommandPromptWindow = true;

            aDriver = new ChromeDriver(aCromeDriverService, aChromeOptions);
            aDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            
            //txtURL.Text = xmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='servidorNCR']").Attributes["value"].Value;            
        }

        private IWebElement obterElemento(string xPathElemento )
        {
            IWebElement wd = null;
            try {
                wd  = aDriver.FindElement(By.XPath(xPathElemento));
            }
            catch (NotFoundException)
            {
                throw new NotFoundException();
            }
            catch(Exception ex)
            {                                
                throw new Exception();
            }
            
            return wd;
        }

        protected void preencherCampo(string xPathElemento, string valor)
        {            
            try {
                obterElemento(xPathElemento).SendKeys(valor);
                Thread.Sleep(1500);
            }
            catch (NotFoundException)
            {
                throw new NotFoundException();
            }                       
        }

        protected void clicar(string xPathElemento)
        {            
            try
            {
                obterElemento(xPathElemento).Click();
                Thread.Sleep(1500);
            }
            catch (NotFoundException)
            {
                throw new NotFoundException();
            }            
        }

        protected string obterValorSetting(string nomeSetting)
        {
            try
            {
                return aXmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='" + nomeSetting + "']").Attributes["value"].Value;
            }
            catch(Exception ex)
            {
                throw new SistemaException(ex);
            }
        }
    }
}
