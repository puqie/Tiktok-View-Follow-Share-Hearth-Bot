using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            var MyIni = new Class1("Settings.ini"); // Edit this

            var proxy = MyIni.Read("Proxy");
            var link = MyIni.Read("Link");

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            int i = 0;
            int j = 1;
            int k = 0;
            sorry:
            Menu();
            var info = Console.ReadKey();
            Console.WriteLine();
            if(info.KeyChar.ToString() == "1" || info.KeyChar.ToString() == "2" || info.KeyChar.ToString() == "3" || info.KeyChar.ToString() == "4" || info.KeyChar.ToString() == "5" || info.KeyChar.ToString() == "6" || info.KeyChar.ToString() == "7")
            {
                i = Convert.ToInt32(info.KeyChar.ToString());
            }
            else
            {
                goto sorry;
            }
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-javascript");
            chromeOptions.AddArgument("--silent");
            chromeOptions.AddArgument("--log-level=3");
            chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
            chromeOptions.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36");
            chromeOptions.AddArguments("-proxy-server=" + proxy);
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.SuppressInitialDiagnosticInformation = true;
            var driver = new ChromeDriver(chromeOptions);
            
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5000));
            WebDriverWait fastwait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

            driver.Url = "https://zefoy.com/";
            Console.WriteLine("Waiting for captcha...");
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[4]/div[1]/div[3]/div/div[2]/div/button")));
            Console.WriteLine("Captcha solved");
            if (i == 1)
            {
                Console.WriteLine("Auto View Bot Started");
                driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[3]/div/div[4]/div/button")).Click(); //Viewbot Select
                k = 5;
            }
            else if (i == 2)
            {
                Console.WriteLine("Auto Like Bot Started");
                driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[3]/div/div[2]/div/button")).Click();
                k = 3;
               
            }
            else if (i == 3)
            {
                Console.WriteLine("Auto Comment Like Bot Started");
                driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[3]/div/div[3]/div/button")).Click();
                k = 4;
            }
            else if (i == 4)
            {
                Console.WriteLine("Auto Followers Started");
                driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[3]/div/div[1]/div/button")).Click();
                k = 2;
               
            }
            else if (i == 5)
            {
                Console.WriteLine("Auto Share Started");
                driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[3]/div/div[5]/div/button")).Click();
                k = 6;
            }
            else if (i == 6)
            {
                Console.WriteLine("Live Bot Started");
                driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[3]/div/div[6]/div/button")).Click();
                k = 7;
            }
            driver.FindElement(By.XPath("/html/body/div[4]/div[" + k + "]/ div/form/div/input")).SendKeys(link); //Link Sender
            driver.FindElement(By.XPath("/html/body/div[4]/div[" + k + "]/ div/form/div/div/button")).Click(); //Click Search Button 
            try
            {
                fastwait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[4]/div[" + k + "]/div/div/div[1]/div/form/button"))); //Wait Send Button
            }
            catch
            {
                wait.Until(d => d.FindElement(By.XPath("/html/body/div[4]/div[" + k + "]/div/div/h4")).Text.Contains("Next Submit: READY....!"));//Waiting timer finish
                driver.FindElement(By.XPath("/html/body/div[4]/div[" + k + "]/div/form/div/div/button")).Click(); //Click Search Button 
                fastwait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[4]/div[" + k + "]/div/div/div[1]/div/form/button"))); //Wait Send Button
            }
            driver.FindElement(By.XPath("/html/body/div[4]/div[" + k + "]/div/div/div[1]/div/form/button")).Click(); //Click Send Button
            back:
            Console.WriteLine(j + ". Part Sended");
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[4]/div[" + k + "]/div/div/h4"))); //Wait timer text
            wait.Until(d => d.FindElement(By.XPath("/html/body/div[4]/div[" + k + "]/div/div/h4")).Text.Contains("Next Submit: READY....!"));//Waiting timer finish
            driver.FindElement(By.XPath("/html/body/div[4]/div[" + k + "]/div/form/div/div/button")).Click();//Click Search Button
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[4]/div[" + k + "]/div/div/div[1]/div/form/button")));//Wait Send Button
            driver.FindElement(By.XPath("/html/body/div[4]/div[" + k + "]/div/div/div[1]/div/form/button")).Click();//Click Send Button
            ++j;
            goto back;
        }

        private static void Menu()
        {
            Logo();
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                               Menu                              ║");
            Console.WriteLine("║ 1- Auto Views(500)                                       TikTok ║");
            Console.WriteLine("║ 2- Auto Like                                             Tiktok ║");
            Console.WriteLine("║ 3- Auto Like First Comment                               Tiktok ║");
            Console.WriteLine("║ 4- Auto Followers                                        Tiktok ║");
            Console.WriteLine("║ 5- Auto Share                                            Tiktok ║");
            Console.WriteLine("║ 7- Live Stream                                           Tiktok ║");
            Console.WriteLine("║                                                                 ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════╝");
            Console.Write("Choose it (1-7): ");

        }

        private static void Logo()
        {
            Console.Clear();
            Console.WriteLine("   ▄███████▄ ████████▄      ▄████████    ▄████████    ▄█    █▄    ");
            Console.WriteLine("  ███    ███ ███    ███    ███    ███   ███    ███   ███    ███   ");
            Console.WriteLine("  ███    ███ ███    ███    ███    ███   ███    █▀    ███    ███   ");
            Console.WriteLine("  ███    ███ ███    ███   ▄███▄▄▄▄██▀   ███         ▄███▄▄▄▄███▄▄ ");
            Console.WriteLine("▀█████████▀  ███    ███  ▀▀███▀▀▀▀▀   ▀███████████ ▀▀███▀▀▀▀███▀  ");
            Console.WriteLine("  ███        ███    ███  ▀███████████          ███   ███    ███   ");
            Console.WriteLine("  ███        ███  ▀ ███    ███    ███    ▄█    ███   ███    ███   ");
            Console.WriteLine(" ▄████▀       ▀██████▀▄█   ███    ███  ▄████████▀    ███    █▀    ");
            Console.WriteLine("                           ███    ███          Tiktok Viewers Bot ");
            Console.WriteLine("");
        }
    }
}
