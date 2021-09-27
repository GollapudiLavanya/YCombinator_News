using NUnit.Framework;

namespace YCombinator
{
    public class Tests : Base.BaseClass
    {

        [Test]
        public void NewsInHacker()
        {
            page.Login_page.NewsHeadings(driver);
            page.Login_page.NewsPointers(driver);
            page.Login_page.NewsData(driver);
            
        }
    }
}