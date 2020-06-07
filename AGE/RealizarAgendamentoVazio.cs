using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGE
{
    public class RealizarAgendamentoVazio : OperarSistemasDPW
    {

        public RealizarAgendamentoVazio()
        {
            
        }

        public void agendar()
        {
            if (realizarLogin())
            {
                if (aDriver.Url == "https://www.embraportonline.com.br/Main")
                    aDriver.Navigate().GoToUrl("http://www.embraportonline.com.br/Main");

                aDriver.FindElement(By.XPath("/html/body/section/section[2]/section/article[1]/nav/ul/li[8]/a")).Click();
                aDriver.FindElement(By.XPath("/html/body/section[2]/section/article[1]/fieldset/table/tbody/tr[1]/td[2]/table/tbody/tr/td/div/div/input")).SendKeys("02805610000279");
                Thread.Sleep(1000);
                aDriver.FindElement(By.XPath("/html/body/section[2]/section/article[1]/fieldset/table/tbody/tr[1]/td[2]/table/tbody/tr/td/div/div/input")).SendKeys(OpenQA.Selenium.Keys.ArrowDown);
                aDriver.FindElement(By.XPath("/html/body/section[2]/section/article[1]/fieldset/table/tbody/tr[1]/td[2]/table/tbody/tr/td/div/div/input")).SendKeys(OpenQA.Selenium.Keys.Enter);
                Thread.Sleep(1000);
                aDriver.FindElement(By.Id("sGate")).SendKeys(OpenQA.Selenium.Keys.Enter + OpenQA.Selenium.Keys.ArrowDown + OpenQA.Selenium.Keys.Enter);
                aDriver.FindElement(By.XPath("/html/body/section[2]/section/article[2]/fieldset/table[1]/tbody/tr/td/button")).Click();
                Thread.Sleep(1000);
                aDriver.FindElement(By.Id("cmbTipoMovimento")).SendKeys(OpenQA.Selenium.Keys.Enter + OpenQA.Selenium.Keys.ArrowDown + OpenQA.Selenium.Keys.Enter);
                aDriver.FindElement(By.XPath("/html/body/section[3]/section/article[2]/fieldset/div/section/table/tbody/tr[1]/td[2]/table/tbody/tr/td/div/div/input")).SendKeys("13657558");
                Thread.Sleep(1000);
                aDriver.FindElement(By.XPath("/html/body/section[3]/section/article[2]/fieldset/div/section/table/tbody/tr[1]/td[2]/table/tbody/tr/td/div/div/input")).SendKeys(OpenQA.Selenium.Keys.ArrowDown + OpenQA.Selenium.Keys.Enter);
                Thread.Sleep(1000);
                aDriver.FindElement(By.XPath("/html/body/section[3]/section/article[2]/fieldset/div/section/center/button")).Click();
                Thread.Sleep(1000);
                aDriver.FindElement(By.XPath("/html/body/section[2]/section/article[2]/fieldset/table[3]/tbody/tr/td/button")).Click();

                //sDiaJanela
                //IWebElement elem = driver.FindElement(By.XPath("//select[@name='time_zone']"));

                var selectList = aDriver.FindElement(By.Id("sDiaJanela")).FindElements(By.TagName("option"));
            }
        }
    }
}
