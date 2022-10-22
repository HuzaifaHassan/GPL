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
                int a = 10;
                int b = 20;
                string symbol = "=";
                if (symbol == "=")
                { 
                  Assert.AreEqual(a, b,00.1,"Number match successful");
                
                }
                else
                {
                    Assert.AreNotEqual(a, b, 00.1, "Number match unsuccessfull");

                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Symbol Error");
            }
        }
    }
}
