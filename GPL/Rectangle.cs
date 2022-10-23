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
        /// 
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
        public override void draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
