using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recursion
{
    class Program
    {
        
        static void Main(string[] args)
        {
            IWebDriver driver;

            driver = new ChromeDriver();
            driver.Url = "https://ek.ua/";

            void ReadAllList()
            {
                IWebElement categories_list = driver.FindElement(By.ClassName("mainmenu-list"));
                ICollection<IWebElement> categories = categories_list.FindElements(By.TagName("li"));

                IWebElement last = categories.Last();
                try
                {
                    foreach (IWebElement category in categories)
                    {
                        IWebElement items_list = category.FindElement(By.ClassName("mainmenu-subwrap"));
                        ICollection<IWebElement> items = items_list.FindElements(By.TagName("a"));
                        Console.WriteLine($"Processing item {category.Text}");

                        foreach (IWebElement item in items)
                        {
                            string actualItem = item.GetAttribute("textContent");
                            Console.WriteLine($"Processing item {actualItem}");
                        }

                        if (category.Equals(last))
                        {
                            driver.Close();
                            break;
                            
                        }
                       
                        
                    }
                    ReadAllList();
                }
                catch (Exception excpt)
                {
                    Console.WriteLine(excpt.Message);
                }
                
            }

            


            ReadAllList();
        }
    }
}
