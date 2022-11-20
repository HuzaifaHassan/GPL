using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GPL
{
    /// <summary>
    /// Class  to set up and draw circle ..
    /// </summary>
    public class Circle : Shape
    {
        //Radius variable..
        int _radius;

        /// <summary>
        /// Constructor having smae functionality as base class.
        /// </summary>

        public Circle() : base()
        { 
        
        }

        /// <summary>
        ///This Method is to set up different params of a circle
        /// </summary>
        /// <param name="_colour"></param>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="_radius"></param>
        public Circle(Color _colour,int _x,int _y,int _radius): base(_colour,_x,_y)
        { 
            this._radius = _radius;
        
        }
        /// <summary>
        /// this will set params defined by users
        /// </summary>
        /// <param name="_colour"></param>
        /// <param name="_list"></param>
        public override void Set(Color _colour, params int[] _list)
        {
            base.Set(_colour, _list[0], _list[1]);
            this._radius = _list[2];
        }

        /// <summary>
        /// this will set params defined by users
        /// </summary>
        /// <param name="_brush"></param>
        /// <param name="_list"></param>
        public override void Set(TextureBrush _brush, params int[] _list)
        {
            base.Set(_brush, _list[0], _list[1]);
            this._radius= _list[2];
        }

        /// <summary>
        /// Method to draw circle
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            //setting up the pen to draw circle with the color defined by user.
            Pen _p = new Pen(_color, 2);
            SolidBrush _b = new SolidBrush(_color);
            g.DrawEllipse(_p, _x, _y, _radius, _radius);
            
        }
    }
}
