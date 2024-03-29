﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL
{
   /// <summary>
   /// This is Factory Class....
   /// Factory Class gets the shape defined by user and points the program to run the code for that shape.
   /// 
   /// </summary>
    class ShapeFactory
    {
        /// <summary>
        /// Draw Shapes on Uers'Input
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        public Shape GetShape(String shapeType)
        {
            //using .Trim to keep consistency of shapes
            shapeType = shapeType.ToUpper().Trim();

            // Defining on these classes the specific class will run when called.
            if (shapeType.Equals("CIRCLE"))
            {
                return new Circle();
            }
            if (shapeType.Equals("SQUARE"))
            {
                return new Square();
            }
            if (shapeType.Equals("RECTANGLE"))
            {
                return new Rectangle();
            }
            if (shapeType.Equals("TRIANGLE"))
            {
                return new Triangle();
            }
            
            //if DrawTO is defined..
                if (shapeType.Equals("DRAWLINE"))
                {
                    return new drawline();
                }
                //if moveTO is defined here it will run pointer class..
                if (shapeType.Equals("MOVETO"))
                {
                    return new Pointer();
                }
                if (shapeType.Equals("CLEAR"))
                {
                    return new Clear();
                }
                else
                {
                 //Exception will be thrown if any undefined shape is called.
                 ArgumentException ex = new ArgumentException("Error:"+shapeType+"Doesn't exists");
                 throw ex;
                }
            
        }

    }
}
