using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL
{
    public class Rectangle : Shape
    {
        int _width, _height;
        public Rectangle() : base()
        { }

        /// <summary>
        /// Setting Up Parameters for Rectangle
        /// </summary>
        /// <param name="_color"></param>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="width_"></param>
        /// <param name="height_"></param>
        public Rectangle(Color _color,int _x,int _y,int width_,int height_) : base (_color,_x,_y)
        { 
            this._width = width_;
            this._height = height_;     
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_colour"></param>
        /// <param name="_list"></param>
        public override void Set(Color _colour, params int[] _list)
        {
            //list[0] indicates x-axis,list[1] does y, list[2] is width and list[3] is height
            base.Set(_colour, _list[0], _list[1]);
            this._width = _list[2];
            this._height = _list[3];
        }
        /// <summary>
        /// Drawing Rectangle..
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            Pen _p = new Pen(_color, 2);
            SolidBrush _b = new SolidBrush(_color);
            g.DrawRectangle(_p, _x, _y, _width, _height);
        }
    }
}
