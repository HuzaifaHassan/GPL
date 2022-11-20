using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Collections;
using MetroFramework;

namespace GPL
{
    /// <summary>
    /// Windows form work that shows all the functionality on the UI.
    /// </summary>
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Form1()
        {
            //Method to set up manufactured code
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //setting up an array to store in the shapes..
        ArrayList _shapes = new ArrayList();
        //Protected integars used for position of pointer and measurements of shapes.
        protected int _xpos, _ypos, _x, _y, _height = 0, _width = 0, _radius = 0;

      





        /// <summary>
        /// Method that allows user to load previously saved file..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If file doesnt open program will show an error
            try
            {
                //Allowing user to select the file
                OpenFileDialog _file=new OpenFileDialog();
                if (_file.ShowDialog() == DialogResult.OK)
                { 
                   //Reads the file and save it to a string..
                   string _source=File.ReadAllText(_file.FileName);
                    richTextBox1.AppendText(_source);
                
                
                }
            }
            //Exception for Errors with file
            catch(IOException)
            {
                //Incorrect file format Message..
                string _msg = "Cannot open the file";
                string _txt = "Unable to Open..";
                MessageBoxButtons _btns = MessageBoxButtons.OK;
                DialogResult _res;
                _res = MessageBox.Show(_msg, _txt, _btns);
            
            
            
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Functionality to save Users command..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog _saveFile= new SaveFileDialog();
            //if user press Ok button it will save the progress.
            if (_saveFile.ShowDialog() == DialogResult.OK)
            {
                string _code = richTextBox1.Text;
                File.WriteAllText(_saveFile.FileName, _code);

            }

        }

        /// <summary>
        /// Here Lies Functionality to the exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Displays a confirmation message to exit the program..
            String _mes = "Exit the Program.. !!";
            String _txt = "Exit";
            MessageBoxButtons _btns = MessageBoxButtons.YesNo;
            DialogResult _res;

            //Displaying exit popup here..
            _res = MessageBox.Show(_mes, _txt, _btns);

            //if its a yes then close..
            if (_res == DialogResult.Yes)
            {
                //Close the Program..
                Application.Exit();
            }
        }
        /// <summary>
        /// Method to perform Clear Functionality..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Del_Click(object sender, EventArgs e)
        {
            ShapeFactory _fact = new ShapeFactory();
            try
            {
                //will search in shapefactory for clear
                _shapes.Add(_fact.GetShape("clear"));


            }
            //exception handling if no such functionality existss..
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid Function:" + e);

             
            }
            //Reseting the Screen to Black...
            Shape shape_;
            Color _color = Color.Black;
            shape_ = _fact.GetShape("clear");
            shape_.Set(_color, 0, 0, 10000, 10000);
            _shapes.Add(shape_);
            //Resetting x and y co-ords as well..
            _xpos = 0;
            _ypos = 0;
        }
        /// <summary>
        /// MEthod to draw lines and shapes on screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //Increment over the saved shapes define by user
            for (int i = 0; i < _shapes.Count; i++)
            {
                //To Get Shapes from the array..
                Shape shape_;
                shape_=(Shape)_shapes[i];
                if (shape_ != null)
                {
                    //Pass through the shapes to the method which will draw them. 
                    shape_.draw(g);
                
                }
                //If there is unavailable shape
                else
                    Console.WriteLine("invalid shape in array");

            }
        }
        /// <summary>
        /// FUnctionality for Run button to run the commands written by user..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Run_Click(object sender, EventArgs e)
        {
            //setting up an array to store user commands.
            string[] cmd = { };
            //To check if there are any commands in textbox
            if (txt_cmdbx.Text != "")
            {
                //Saves the textbox commands in array.
                cmd = txt_cmdbx.Text.Split('\n');
            }
            //setting up the color..
            Color _color = Color.Red;
            for (int i = 0; i < cmd.Length; i++)
            {


                try
                {
                    //COnverting all of the user commands to lower case so upper case or lower doesnt matter.
                    cmd = Array.ConvertAll(cmd, x => x.ToLower());

                    ShapeFactory _shape = new ShapeFactory();
                    //To check if command of user contains keyword 'color'.
                    if (cmd[i].Contains("color"))
                    {
                        //Sets up a color dialog that will pop up and allow user to select there color
                        ColorDialog _colorDialog = new ColorDialog();
                        _colorDialog.AllowFullOpen = true;
                        _colorDialog.AnyColor = true;
                        _colorDialog.SolidColorOnly = false;

                        //if user will click on 'Ok' the program will continue.
                        if (_colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            _color = _colorDialog.Color;

                        }

                    }


                    else if (cmd[i].Contains("moveTo"))
                    {
                        try
                        {
                            //Getting MoveTo from Factory
                            _shapes.Add(_shape.GetShape("moveTo"));

                        }
                        //Exception in case the it is not in factor class.
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Invalid shape:" + e);
                        }
                        //splitting the user command to get x,y params.
                        string[] _spv = cmd[i].Split(' ');
                        try
                        {
                            //Saing x,y paramst and converting them to Int.
                            string _h = _spv[1];
                            string _v = _spv[2];
                            _x = Convert.ToInt32(_h);
                            _y = Convert.ToInt32(_v);
                            //Now Setting up the pen and moving it to desired location.
                            Shape shape_;
                            //making it transparent for not letting it to draw.
                            Color color_ = Color.Transparent;
                            shape_ = _shape.GetShape("moveTo");
                            shape_.Set(color_, _xpos, _ypos, _x, _y);
                            _shapes.Add(shape_);
                            //Refreshing picture box to ake sure the pen actually moves
                            pictureBox1.Refresh();
                            //updating x,y co ordinates for next shape
                            _xpos = _x;
                            _ypos = _y;

                        }
                        //Exception Handling if command has params more or less then 2.
                        catch (IndexOutOfRangeException)
                        {
                            string _msg = "It takes only 2 parameters no more and no less";
                            string _txt = "Unabe to move pen";
                            MessageBoxButtons _btns = MessageBoxButtons.OK;
                            DialogResult _res;
                            _res = MessageBox.Show(_msg, _txt, _btns);

                        }
                        //Exception  if the parameters are in the wrong format of the wrong data type.
                        catch (FormatException)
                        {
                            //Message saying that the parameters shoulc be integars.
                            String _msg = "Format  must be in Integers";
                            String _txt = "Unable to move the pen.";
                            MessageBoxButtons _btns = MessageBoxButtons.OK;
                            DialogResult _res;

                            //Display the dialog box.
                            _res = MessageBox.Show(_msg, _txt, _btns);
                        }


                    }
                    //checks to see if user commands contains a circle
                    else if (cmd[i].Contains("circle"))
                    {
                        try
                        {
                            //sets up variable for circle
                            int _rep = 1;
                            int _inc = 0;
                            string _symbol = "", _rad;
                            char[] _nChar = new char[0];
                            int _radius = 10;
                            //splitting the line to get params.
                            string[] _sRadius = cmd[i].Split(' ');
                            //saving the radius here
                            _rad = _sRadius[1];
                            try
                            {
                                //Getting circle command from factory.
                                _shapes.Add(_shape.GetShape("circle"));


                            }
                            //Exception Handling if the shape isnt in the factory pattern.
                            catch (ArgumentException)
                            {
                                Console.WriteLine("Invalid Shape: " + e);

                            }
                            if (_rad != "radius")
                            {
                                _radius = Convert.ToInt32(_rad);

                            }
                            for (int j = 0; j < _rep; j++)
                            {
                                //setting up the shape and adding color to it
                                Shape shape_;
                                Color color_ = _color;
                                shape_ = _shape.GetShape("circle");
                                if (cmd[i].Contains("texture"))
                                {
                                    Image _image = new Bitmap("pttrn.jpg");
                                    TextureBrush _brush = new TextureBrush(_image);
                                    _brush.Transform = new Matrix(
                                         75.0f / 640.0f,
                                       0.0f,
                                       0.0f,
                                       75.0f / 480.0f,
                                       0.0f,
                                       0.0f);
                                    //To draw circle from centre
                                    shape_.Set(_brush, _xpos - (_radius / 2), _ypos - (_radius / 2), _radius);

                                }
                                else
                                {
                                    shape_.Set(_color,_xpos-(_radius/2),_ypos-(_radius/2),_radius);
                                
                                }
                                _shapes.Add(shape_);
                                //Refreshing the picture box so circle becomes visible
                                pictureBox1.Refresh();
                            }
                        }
                        //Exception if there are too many or not enough params for circle
                        catch (IndexOutOfRangeException)
                        {
                            string _msg = "Only one parameter for circle";
                            string _txt = "Unable to draw a circle";
                            MessageBoxButtons _btns = MessageBoxButtons.OK;
                            DialogResult _res;
                            _res = MessageBox.Show(_msg, _txt, _btns);


                        }
                        //Exception  if the parameters are in the wrong format of the wrong data type.
                        catch (FormatException)
                        {
                            //Message saying that the parameters shoulc be integars.
                            String _msg = "Format  must be in Integers";
                            String _txt = "Unable to draw circle.";
                            MessageBoxButtons _btns = MessageBoxButtons.OK;
                            DialogResult _res;

                            //Display the dialog box.
                            _res = MessageBox.Show(_msg, _txt, _btns);
                        }




                    }




                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Error");
                }
            }

        }

    }
}
