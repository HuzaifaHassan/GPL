using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL
{
    /// <summary>
    /// Here code to make form blank is implemented. It also inherits from Shape Class
    /// </summary>
    public class Clear : Shape
    {
        //Seting the variables used by draw method.
        int _width,_height;
        public Clear() : base()
        { 
        
        }

        /// <summary>
        /// Setting up variables for clearing the screen.
        /// </summary>
        /// <param name="_color">it will reset the screen and color</param>
        /// <param name="_x"> will clear from x-axis</param>
        /// <param name="_y">will clear from y-axis</param>
        /// <param name="width_">width of screen to be cleared</param>
        /// <param name="height_">height of screen to be cleared</param>
        public Clear(Color _color, int _x, int _y, int width_, int height_) : base(_color, _x, _y)
        { 
        
          this._width = width_;
            this._height = height_;
        }

        /// <summary>
        /// Setting up the variables
        /// </summary>
        /// <param name="_colour">Color of background</param>
        /// <param name="_list">list of variables</param>
        public override void Set(Color _colour, params int[] _list)
        {
            //[0] is x,[1] is y,[2] is width,3 is height
            base.Set(_colour, _list);
            this._width = _list[2];
            this._height = _list[3];
        }
        /// <summary>
        /// Resetting it back 
        /// </summary>
        /// <param name="g"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void draw(Graphics g)
        {
            Color _color = Color.Black;
            Pen _p = new Pen(_color, 2);
            SolidBrush _b = new SolidBrush(_color);
            g.FillRectangle(_b, _x, _y, _width, _height);
            g.DrawRectangle(_p, _x, _y, _width, _height);
        }
    }
}
