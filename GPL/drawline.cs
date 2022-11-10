using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL
{
    /// <summary>
    /// Class To Draw Line on screen and Inherits it methods from shape
    /// </summary>
    public class drawline : Shape
    {
        
        int x_, y_;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public drawline() : base()
        { }

        /// <summary>
        /// Setting up variables 
        /// </summary>
        /// <param name="_color">Colour of Line</param>
        /// <param name="_x">x-axis of line</param>
        /// <param name="_y">y-axis of line</param>
        public drawline(Color _color, int _x, int _y) : base(_color, _x, _y)
        { 
          this._x = x_;
          this._y = y_;
        }

        /// <summary>
        /// Setting up the variables.
        /// </summary>
        /// <param name="_colour">colour of line</param>
        /// <param name="_list">list of variables</param>
        public override void Set(Color _color, params int[] _list)
        {

            //Here list[0] is x, [1] is y ,[2] is width.thickness of a line 
            base.Set(_color, _list[0], _list[1]);
            this.x_ = _list[0];
            this.y_=_list[1];
            this._x = _list[2];
        }


        /// <summary>
        /// Draws Line
        /// </summary>
        /// <param name="g"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void draw(Graphics g)
        {
            Pen _pen = new Pen(_color, 1);
            //these variables are to create points that define line
            Point _p1 = new Point(x_, y_);
            Point _p2 = new Point(_x, _y);
           
            _pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            g.DrawLine(_pen, _p1, _p2);

            //throw new NotImplementedException();
        }
    }
}
