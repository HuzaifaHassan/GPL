using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using GPL;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GPLTest
{

    /// <summary>
    /// This Unit test will test the functionality of creating Circle
    /// </summary>
    [TestClass]
    public class CircleTest
    {
        Form1 form = new Form1();

        /// <summary>
        /// Method to test the method below. 
        /// </summary>
        [TestMethod]
        public void Radius_negative()
        {
            //Setting up the variables
            int _expected = 10;
            int _res = 0;
            string _radius = "invalid Data Type";
            try
            {
                //if incorrect data type is entered it will fail
                _res = Convert.ToInt32(_radius);
            }
            catch (FormatException)
            { 
                Assert.AreNotEqual(_expected, _res,00.1,"Ohh Snap, Values doesn't Match!");
            
            }
        

        }

        /// <summary>
        /// This test method will test for valid radius inputs.
        /// </summary>
        [TestMethod]
        public void Radius_Positive()
        {
            //Setting up Variables
            int _expected = 10;
            int _convert = 10;
            string _radius = "10";
            //COnverting the Int value
            _convert=Convert.ToInt32(_radius);
            // It Make sures the two values are equal.
            Assert.AreEqual(_expected, _convert, 00.1, "Yay, Values Match");
        
        }
        /// <summary>
        /// This Test method will test the formatt of circle is correct or not
        /// </summary>
        [TestMethod]
        public void Draw()
        {
            try
            {
                int _x = 0;
                int _y = 0;
                int _radius=0;

                if (_radius == 50)
                {
                    Color _color = Color.Red;
                    Pen _pen = new Pen(_color, 2);
                    //Passes through Circle method
                    Circle _circle = new Circle(_color, _x, _y, _radius);

                }
                else if (_radius == -50)
                {
                    Color _color = Color.Red;
                    Pen _pen = new Pen(_color, 2);
                    
                    if (_radius < 0)
                    {
                        //Passes through Circle method
                        Circle _circle = new Circle(_color, _x, _y, _radius);


                    }


                }

            }
            catch (Exception)
            {
                //Catches the Exception.

                Assert.Fail("Snapp!! Incorrect Formatt /n Small Int value /n couldn't Pass Variable");
            }
        
        
        
        }
        /// <summary>
        /// this is test Method to test if user is entering too many params.
        /// </summary>
        [TestMethod]
        public void commandLine()
        {
            try
            {
                string[] _command = { "circle", "4" };
                string _cmd=_command[0];
                string _cmd2 = _command[1];
                string _cmd3 = _command[2];
                //Will check if there are too many.
                Assert.Fail("Dude ! Hold Thats to much ");
            }
            catch (Exception)
            {

                Console.WriteLine(" Alot of Params");
            }
        
        }



    }
   
}
