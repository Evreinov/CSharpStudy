using CommonSnappableTypes;
using System;

namespace CSharpSnapIn
{
    [CompanyInfoAttribute(CompanyName = "FooBar", CompanyUrl = "www.FooBar.com")]
    public class CSharpModule : IAppFunctionality
    {
        void IAppFunctionality.DoIt()
        {
            Console.WriteLine("You have just used the С# snap-in!");
        }
    }
}
