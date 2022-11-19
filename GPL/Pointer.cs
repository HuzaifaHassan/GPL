using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL
{
    /// <summary>
    /// This is pointer/cursor/pen class will move it around the scren without needing it to draw.
    /// it inherits it's method from shape class
    /// </summary>
    public class Pointer : Shape
    {
        //Setting up the starting x & y positions of our pointer/pen/cursor
        int _xpos, _ypos;

        /// <summary>
        /// Constructor to be same as Shape Class
        /// </summary>
        public Pointer() : base()
        { 
        
        }

        /// <summary>
        /// This Pointer method sets up the variables
        /// </summary>
        /// <param name="_color">This color will be transparent</param>
        /// <param name="_x">x co-ordinate</param>
        /// <param name="_y">y co-ordinate</param>
        public Pointer(Color _color, int _x, int _y) : base(_color, _x, _y)
        {
            //Difference from Shape.
            this._x = _x;
            this._y = _y;
        
        
        }
        /// <summary>
        /// setting up the variables for user defined parameters.
        /// </summary>
        /// <param name="_colour"></param>
        /// <param name="_list"></param>
        public override void Set(Color _colour, params int[] _list)
        {
            //list[0] is starting x, list[1] is starting y.
            base.Set(_colour, _list[0], _list[1]);
            this._xpos = _list[0];
            this._ypos = _list[1];
            //list[2] is ending x, list[3] is ending y
            this._x = _list[2];
            this._y= _list[3];
        }
        /// <summary>
        /// Method to Perform Pointers function
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            //Create pen make color transparent
            Pen _pen = new Pen(Color.Transparent, 1);
            //points to define line
            Point _p1 = new Point(_xpos, _ypos);
            Point _p2 = new Point(_x, _y);
            _pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            //drawline on screen
            g.DrawLine(_pen, _p1, _p2);
        }
    }
}
