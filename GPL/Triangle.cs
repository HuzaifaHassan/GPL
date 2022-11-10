using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL
{
    /// <summary>
    ///  Class For Setting up and drawing Triangle. Inherited by PArent Shape Class
    /// </summary>
    public class Triangle : Shape
    {
        // here it sets up points/co-ordinates/position of triangle..
        Point _points;
        private int _xpos, _ypos, _z;

        /// <summary>
        /// COnstructor
        /// </summary>
        public Triangle() : base()
        { }
        /// <summary>
        /// Setting Variables for Triangle
        /// </summary>
        /// <param name="_color">COlour of Shape</param>
        /// <param name="_x">x position of shape</param>
        /// <param name="_y">y position of shape </param>
        /// <param name="_z">z position of shape </param>
        /// <param name="points_">points of a triangle</param>
        public Triangle(Color _color, int _x, int _y, int _z, Point points_)
        { 
            this._points = points_;
            this._x = _x;
            this._y = _y; 
            this._z = _z;

        
        }
        /// <summary>
        /// setting the variables for parameters defined by users.
        /// </summary>
        /// <param name="_colour"></param>
        /// <param name="_list"></param>
        public override void Set(Color _colour, params int[] _list)
        {
            //list[0]=x ,list[1]=y, from list[2] starts the points...
            base.Set(_colour, _list[0], _list[1]);
            this._xpos = _list[0]; 
            this._ypos = _list[1]; 
            this._x = _list[2];
            this._y = _list[3]; 
            this._z = _list[4]; 
        }

        public override void draw(Graphics g)
        {
            Pen _p = new Pen(_color, 2);
            SolidBrush _brush = new SolidBrush(_color); 
            Point _p1=new Point(_xpos, _ypos);
            Point _p2=new Point(_x, _y);
            Point _p3=new Point(_y, _z);
            Point _p4=new Point(_xpos, _ypos);
            Point[] curvePoints =
                {
                 _p1,
                 _p2,
                 _p3,
                 _p4,
                };
        }
    }
}
