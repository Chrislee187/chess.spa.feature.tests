using System;
using TechTalk.SpecFlow;

namespace chess.spa.feature.tests.Steps
{
    [Binding]
    public class SpecflowFixture
    {

        [AfterTestRun]
        public static void AfterTestRun()
        {
            try
            {
                Browser.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}