using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace GPL
{
    /// <summary>
    /// Abstract class that set up methods to be used be shapes class to draw
    /// </summary>
    public abstract class Shape
    {
        protected TextureBrush _brush;
        protected Color _color;
        protected int _x,_y;// co-ords of the shape.




        public Shape()
        { 
        
        }
        /// <summary>
        /// variable for shapes
        /// </summary>
        /// <param name="color_">Shapes Color</param>
        /// <param name="x_">x-axis(position)</param>
        /// <param name="y_">y-axis(position)</param>

        public Shape(Color color_, int x_, int y_)
        {
            this._brush = _brush;
            this._color = color_; //Shapes Color
            this._x = x_;//it's X axis
            this._y = y_;//it's Y axis
        }

        //below methods belong to shapes interface
        //Passing on obligations to implement shapes to derived class by declaring them as abstract
        public abstract void draw(Graphics g);//derived class is implemented in this method


        /// <summary>
        /// to be implemented by child classes
        /// </summary>
        /// <param name="_colour">Color of shape</param>
        /// <param name="_list">array to save parameters for different shapes</param>
        public virtual void Set(Color _colour, params int[] _list)
        { 
            this._color=_colour;
            this._x = _list[0];
            this._y=_list[1];
        }
        public virtual void Set(TextureBrush _brush, params int[] _list)
        { 
          this._brush= _brush;
            this._x = _list[0];
            this._y=_list[1];
        
        }

    }
}
