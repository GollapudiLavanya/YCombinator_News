using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace YCombinator.page
{

    public class Login_page : Base.BaseClass
    {
        public static List<int> list1 = new List<int>();
        public static void NewsHeadings(IWebDriver driver)
        {
            try
            { 
                IList<IWebElement>  Headings= driver.FindElements(By.XPath("//td[@class='title']"));
                Console.WriteLine("**********Headlines**********");
                foreach (IWebElement data in Headings)
                {
                    string Headlines = data.Text;

                    Console.WriteLine(Headlines);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void NewsPointers(IWebDriver driver)
        {
            try
            {
                Console.WriteLine("**********Points**********");
                foreach (var topic in driver.FindElements(By.XPath("//*[@class='score']")))
                {
                    string points = topic.Text;

                    string input = points;
                    string[] numbers = Regex.Split(input, @"\D+");
                    foreach (string value in numbers)
                    {
                        if (!string.IsNullOrEmpty(value))
                        {
                            int i = int.Parse(value);
                            list1.Add(i);
                            Console.WriteLine("Points: {0}", i);
                        }
                    }
                }
                HighestPoints();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void HighestPoints()
        {
            var res = list1.OrderByDescending(g => g).Take(1);
            foreach(var g in res)
            {
                Console.WriteLine("Highest Points:{0}",g);
            }
        }

        public static void NewsData(IWebDriver driver)
        {
            try
            {
                IList<IWebElement> newsdata = driver.FindElements(By.XPath("//td[@class='title']|//span[@class='score']"));
                Console.WriteLine("**********List**********");
                foreach (IWebElement data in newsdata)
                {
                    string fulldata = data.Text;
                    Console.WriteLine(fulldata);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}


