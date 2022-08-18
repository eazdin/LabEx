using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;
using OpenQA.Selenium.Edge;

namespace LabEx
{
    [TestClass]
    public class SeleniumTest1
    {
        [DataTestMethod]
        [DataRow("FF","nihar.1@gmail.com","nihar","good")]
        [DataRow("CH","mitra.1@gmail.com","mitra","all good")]
        [DataRow("MS","ranjan.1@gmail.com","ranjan","verygood")]

        public void LaunchBrowser(string browser,string Mail,string Name,string Message)
        {            
            IWebDriver driver;
            if(browser=="FF")
            {
                driver = new FirefoxDriver(@"C:\mitra c#\WebDriver");
            }
            else if (browser=="CH")
            {
                 driver = new ChromeDriver(@"C:\mitra c#\WebDriver");
            }
            else
            {
                driver = new EdgeDriver(@"C:\mitra c#\WebDriver");
            }
            driver.Navigate().GoToUrl("https://demoblaze.com/");
            driver.Manage().Window.Maximize();
            IWebElement SearchText=driver.FindElement(By.LinkText("Contact"));
            SearchText.Click();
            Thread.Sleep(3000);

            IWebElement SearchText1=driver.FindElement(By.Id("recipient-email"));
            SearchText1.SendKeys(Mail);
            Thread.Sleep(3000);

            IWebElement SearchText2=driver.FindElement(By.Id("recipient-name"));
            SearchText2.SendKeys(Name);
            Thread.Sleep(3000);

            IWebElement SearchText3=driver.FindElement(By.Id("message-text"));
            SearchText3.SendKeys(Message);
            Thread.Sleep(3000);

            IWebElement SearchText4=driver.FindElement(By.XPath("//button[text()='Send message']//preceding-sibling::button[text()='Close']"));
            SearchText4.Click();

            Thread.Sleep(3000);
            driver.Quit();
           // driver.Close();
        }
    }
}
