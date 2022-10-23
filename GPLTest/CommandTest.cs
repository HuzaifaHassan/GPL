using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace GPLTest
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void testIfStatments()
        {
            try
            {
                int _a = 10;
                int _b = 20;
                string _symbol = "=";
                if (_symbol == "=")
                { 
                  Assert.AreEqual(_a, _b,00.1,"Number match successful");
                
                }
                else
                {
                    Assert.AreNotEqual(_a, _b, 00.1, "Number match unsuccessfull");

                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Symbol Error");
            }
        }
    }
}
