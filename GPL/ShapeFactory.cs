using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL
{
   /// <summary>
   /// Factory Class
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
            
                if (shapeType.Equals("DRAWLINE"))
                {
                    return new drawline();
                }
                if (shapeType.Equals("MOVEPEN"))
                {
                    return new Pointer();
                }
                if (shapeType.Equals("Clear"))
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
