using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL
{
    /// <summary>
    /// Here code to make textbox blank is implemented. It also inherits from Shape Class
    /// </summary>
    public class Clear : Shape
    {
        //Seting the variables used by draw method.
        int _width,_height;
        public Clear() : base()
        { 
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_color"></param>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="width_"></param>
        /// <param name="height_"></param>
        public Clear(Color _color, int _x, int _y, int width_, int height_) : base(_color, _x, _y)
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
