using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL
{
    /// <summary>
    /// Class to set up and draw Square. Inherited by Rectangle. 
    /// A Square is basically a special form of Rectangle where all sides are equal. so general form is Rectangle
    /// Square is its specialization. So Square can be inherited by Rectangle but not the other way around..
    /// </summary>
    public class Square : Rectangle
    {
        private int _size;

        public Square() : base()
        { }

        /// <summary>
        /// Setting variables for Square 
        /// </summary>
        /// <param name="colour">Color for Square</param>
        /// <param name="_x">x-cordinates of the Shape</param>
        /// <param name="_y">y-cordinates of the Shape</param>
        /// <param name="_size">Size of The Shape</param>
        public Square(Color colour, int _x, int _y, int _size) : base(colour, _x, _y,_size,_size)
        { 
            this._size = _size; 
        
       
        }
        // Here we dont need any Draw method as it is provided by its Parent Class
        public override void draw(Graphics g)
        {
            //Draw the Square
           base.draw(g);
        }
    }
}
