using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLTest
{
    /// <summary>
    /// Test Class that will test the functions for drawing of a recatangle.
    /// </summary>

    [TestClass]
    public class RectangleTest
    {
        /// <summary>
        /// Test method for checking rectangle params are valid or not.
        /// </summary>
        [TestMethod]
        public void Rectanlge_check()
        {
            //initializing variables
            int _expected = 10;
            int _height = 0;
            int _width = 0;
            string height_ = "Oi! Data Type of Height is not valid";
            string widht_ = "Oi! Data Type of width is not valid";
            try
            {
                _height = Convert.ToInt32(_height);
                _width = Convert.ToInt32(_width);

            }
            //Herewe catch exceptin if format is wrong
            catch (FormatException)
            {
                
                Assert.AreNotEqual(_expected, _height, 00.1, "Dude ! these numbers for height dont match");
                Assert.AreNotEqual(_expected, _width, 00.1, "Dude ! these numbers for width dont match ");
            }
        }
    }
}
