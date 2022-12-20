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
        protected int _xpos, _ypos, _x, _y, _height = 0, _width = 0, _radius = 0,_loopTimes,loop=0,loopLine,loopIndex;

      





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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
            pictureBox1.Refresh();
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
            //setting up an array to store users command.
            string[] program = { };

            //Checks to Seee if there are commands 
            if (richTextBox1.Text != "")
            {
                //saving the commands in array.
                program = richTextBox1.Text.Split('\n');
             
            }
            //Checking to see if we have any command in textbox.
            if (txt_cmdbx.Text != "")
            {
                //Saves the textBox Commands in array if there are commands in both then priority will be given to textbox.
                program = txt_cmdbx.Text.Split('\n');
            }
            //Setting up an integar that will increment through the forLoop allowing to see which line has error.
            int lines = 1;
            //sets up a new color for user to change.
            Color userColor = Color.Blue;
            //The for loop will loop through the lines of the textbox running the commands given by user.
            for (int i = 0; i < program.Length; i++)
            {
                try
                {
                    string ifCode = "";
                    //Converting all commands of textbox to LowerCase.
                    program = Array.ConvertAll(program, x => x.ToLower());
                    //Calls the ShapeFactory method so it can auto load the different shapes.
                    ShapeFactory factory = new ShapeFactory();
                    //Checks whether the user wants to loop their code.
                    if (program[i].Contains("loop"))
                    {
                        try
                        {
                            loopLine = i;
                            //getting the amount of time the code needs to loop.
                            string[] loopValue = program[i].Split(' ');
                            string loopVal = loopValue[1];
                            _loopTimes = Convert.ToInt32(loopVal);
                            //Iterating through the program to find where the block command ends.
                            for (int j = 0; j < program.Length; j++)
                            {
                                //Checks for where the loop ends.
                                if (program[j].Contains("stop"))
                                {
                                    //Search for the first occurence of the duplicated value.
                                    String searchString = "stop";
                                    //Saves the array index where 'stop' occurs.
                                    loopIndex = Array.IndexOf(program, searchString, i);

                                }


                            }


                        }
                        catch (IndexOutOfRangeException)
                        {
                            //Message indicating paramst are incorrect .
                            //PS need to change to drawString() for refference check demo video.
                            Console.WriteLine("The number of parameters for performing a loop was incorrect." + "Error on Line"+lines); 
                        
                        }
                        catch (FormatException)
                        {
                            //Message indicating paramst are incorrect .
                            //PS need to change to drawString() for refference check demo video.
                            Console.WriteLine("Parameter Format is incorrect." + "Error on Line" + lines);

                        }
                    
                    
                    }
                    //Checking if there is IF statement in command.
                    if (program[i].Contains("if"))
                    {
                        try
                        {
                            //Setting up variable to save comparisions.
                            int var = 0;
                            //SPlitting the command line and assigning the values to variables.
                            string[] value = program[i].Split(' ');
                            string variable = value[1];
                            string symbol = value[2];
                            string num = value[3];
                            int number = 0;
                            //Saving the variable as value for Radius.
                            if (variable == "radius")
                            {
                                var = _radius;
                            }
                            //Saving the variable as value for height.
                            else if (variable == "height")
                            {
                                var = _height;
                            }
                            //Saving the variable as value for width.
                            else if (variable == "width")
                            {
                                var = _width;

                            }
                            else
                            {
                                var = Convert.ToInt32(variable);
                            }
                            if (num == "radius")
                            {
                                number = _radius;
                            }
                            else if (num == "height")
                            {
                                number = _height;
                            }
                            else if (num == "width")
                            {
                                number = _width;
                            }
                            else
                            {
                                number = Convert.ToInt32(num);

                            }
                            if (symbol == "=")
                            {
                                //Ensure the values are equal.
                                if (var == number)
                                {
                                    //Checks to see if the if statemtn was a one line comand or a block.
                                    if (program[i].Contains("then"))
                                    {
                                        //Splits the single line command to get the command it is supposed to perform
                                        program[i] = program[i].Split(new[] { "then " }, StringSplitOptions.None)[1];


                                    }
                                    //if it is a block command.
                                    else
                                    {
                                        //For loop to iterate through the program to find where the block command ends.
                                        for (int k = i; k < program.Length; k++)
                                        {
                                            //Checks where the if statement ends.
                                            if (program[k].Contains("end"))
                                            {
                                                //Search for the first occurrence of the duplicated value.
                                                String searchString = "end";
                                                //Saves the array index where 'end' occurs.
                                                if (program[k].Contains("end"))
                                                {
                                                    //Search for the first occurence of the duplicated value
                                                    String searchSring = "end";
                                                    //Saves the array index where 'end' occurs.
                                                    int index = Array.IndexOf(program, searchString);


                                                }

                                            }

                                        }

                                    }

                                }
                                //If the number doesn't equal the variable.
                                else
                                {
                                    //If the number isnt eual to the variable but still contains 'then'.
                                    if (program[i].Contains("then"))
                                    {
                                        //Checks to see if the next index is empty in the program array.
                                        string nextIndex = program[i + 1];
                                        if (nextIndex != null)
                                        {
                                            //if it's not empty then just skip the if statement as it is false.
                                            i = i + 1;


                                        }

                                    }
                                    //if it is a block statemtn where the variable isnt equal to the number.
                                    else
                                    {
                                        //Iterate through a new loop for the program array starting from the current index.
                                        for (int l = i; l < program.Length; l++)
                                        {
                                            //Check to see where end of the if Statement is.
                                            if (program[l].Contains("end"))
                                            {
                                                //Search for the occurance of 'end'.
                                                String searchString = "end";
                                                int index = Array.IndexOf(program, searchString, i);
                                                //Skips what's in the if statemtn and move to end as the comparision was false.
                                                i = index;

                                            }

                                        }


                                    }

                                }

                            }
                            //If the variable is greater then number.
                            else if (symbol == ">")
                            {
                                if (var > number)
                                {
                                    //checking is the IF statement is a one line or block cmd.
                                    if (program[i].Contains("then"))
                                    {
                                        //Splits the single cmd to get it as it is supposed to perform.
                                        program[i] = program[i].Split(new[] { "then " }, StringSplitOptions.None)[1];



                                    }
                                    //If block cmd is specified.
                                    else
                                    {
                                        //For loop to iterate through the program to find where the block cmd ends.
                                        for (int m = i; m < program.Length; m++)
                                        {
                                            //Checks for where if statement ends.
                                            if (program[m].Contains("end"))
                                            {
                                                //Search for the first occurence of the duplicated value.
                                                String searchString = "end";
                                                //Saves the array index where 'end' occurs.
                                                int index = Array.IndexOf(program, searchString);

                                            }
                                        }

                                    }

                                }
                                //If the number is not equal to our variable.
                                else
                                {
                                    //if the number isnt equal to the ariable but still contains 'then'.
                                    if (program[i].Contains("then"))
                                    {
                                        //Checks to see if the nest index is empty in the program array.
                                        string nextIndex = program[i + 1];
                                        if (nextIndex != null)
                                        {
                                            //If it's not empty then just skip the if statement as it is false.
                                            i = i + 1;
                                        }



                                    }


                                    //If it is a block if statement where the variable isn't equal to the number.
                                    else
                                    {
                                        //Iterate through a new loop for the program array starting from current index.
                                        for (int n = i; n < program.Length; n++)
                                        {
                                            //Checks to see where the end of IF statement is.
                                            if (program[n].Contains("end"))
                                            {
                                                //Search for the occurrence of 'end'.
                                                String searchString = "end";
                                                int index = Array.IndexOf(program, searchString, i);
                                                //Skipping what is in the statement and move to end as comparison was false.
                                                i = index;

                                            }

                                        }
                                    }


                                }


                            }
                            //If the variable is less then or equal to the number.
                            else if (symbol == "<=")
                            {
                                if (var <= number)
                                {
                                    //Checks to see if the IF statement was a one line or Block cmd.
                                    if (program[i].Contains("then"))
                                    {
                                        //Splits the sinlge line cmd to get as it is supposed to perform.
                                        program[i] = program[i].Split(new[] { "then  " }, StringSplitOptions.None)[1];

                                    }
                                    //If the user specified a block command.
                                    else
                                    {
                                        //For loop to iterate through the program to find where the block cmd ends.
                                        for (int o = i; o < program.Length; o++)
                                        {
                                            //Checking where the if statement ends.
                                            if (program[o].Contains("end"))
                                            {
                                                //Search for the first occurence of the duplicated values.
                                                String searchString = "end";
                                                //Saves the array index where 'end' occurs.
                                                int index = Array.IndexOf(program, searchString);

                                            }
                                        }


                                    }



                                }
                                //If the number doesn't equal the variable
                                else
                                {

                                    //If the number isnt equal to the variable but still contains'then'.
                                    if (program[i].Contains("then"))
                                    {
                                        //Checks to see if the next index is empty in program array.
                                        string nextIndex = program[i + 1];
                                        if (nextIndex != null)
                                        {
                                            //If its not empty then skip as if its false
                                            i = i + 1;
                                        }

                                    }
                                    //If it is a block if statement where the variable isn't equal to the number.
                                    else
                                    {
                                        for (int p = i; p < program.Length; p++)
                                        {

                                            //Checks to see where the end of the if statement is.
                                            if (program[i].Contains("then"))
                                            {
                                                String searchString = "end";
                                                int index = Array.IndexOf(program, searchString, i);
                                                //Skipping whats in IF statement and move to end as if comparision was false
                                                i = index;




                                            }
                                        }
                                    }


                                }


                            }

                        }
                        //Exception in case there are too many or not enough parameters in the users command.

                        catch (IndexOutOfRangeException)
                        {
                            //Message saying that the if command needs two parameters.
                            String message = "The number of parameters for performing an If statement was unsuitable. " +
                                "Error on line: " + lines;
                            String caption = "Unable to perform If statement.";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;

                            //Displays the dialog box.
                            result = MessageBox.Show(message, caption, buttons);

                        }
                        catch (FormatException)
                        {
                            //Message saying that the parameters are incorrect, e.g strings instead of integars.
                            String message = "The format of the parameters is unsuitable. Ensure they are integars. " +
                                "Error on line: " + lines;
                            String caption = "Unable to perform If statement.";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;

                            //Displays the dialog box.
                            result = MessageBox.Show(message, caption, buttons);


                        }



                    }
                    //Checking to see if user command has word 'colour'
                    if (program[i].Contains("colour"))
                    {
                        //Sets up a colour dialog  that will allow user to select colour.
                        ColorDialog colorDilog = new ColorDialog();
                        //Enables the different options for the colour dialog.
                        colorDilog.AllowFullOpen = true;
                        colorDilog.AnyColor = true;
                        colorDilog.SolidColorOnly = false;
                        //When the user clicks 'ok' the program will continue.
                        if (colorDilog.ShowDialog() == DialogResult.OK)
                        {
                            //Changes the previously set up colour variable to the user's desired colour.
                            userColor = colorDilog.Color;

                        }


                    }
                    //Checks to see if the user entered 'drawline' command.
                    else if (program[i].Contains("drawline") || ifCode.Contains("drawline"))
                    {
                        Console.WriteLine(ifCode);
                        try
                        {
                            //Gets 'drawline' from the factory.
                            _shapes.Add(factory.GetShape("drawline"));

                        }
                        //Catches and exceptions if the cmd isnt int the factory.
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Invalid shape: " + e);
                        }
                        //Splits the user's cmd to get the diff x,y params
                        string[] stringRec = program[i].Split(' ');
                        try
                        {
                            //Saves the x,y parameters in seperate strings the converts them to integars.
                            string hei = stringRec[1];
                            string wid = stringRec[2];
                            _x = Convert.ToInt32(hei);
                            _y = Convert.ToInt32(wid);
                            //Sets up and draws the line to the screen.
                            Shape s;
                            Color newColor = userColor;
                            s = factory.GetShape("drawline");
                            s.Set(newColor, _xpos, _ypos, _x, _y);
                            _shapes.Add(s);
                            //Refreshing PictureBox so the new line is visible.
                            pictureBox1.Refresh();
                            //Updates the x,y co-ordinates so the next shape or line will draw from here.
                            _xpos = _x;
                            _ypos = _y;



                        }
                        //Exception in case there are too many or not enough parameters in the users cmd.
                        catch (IndexOutOfRangeException)
                        {
                            //Message saying that the command needs two parameters.
                            String message = "The number of parameters for drawing a line was unsuitable. It takes two parameters. " +
                                "Error on line: " + lines;
                            String caption = "Unable to draw a line.";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;

                            //Displays the dialog box.
                            result = MessageBox.Show(message, caption, buttons);

                        }
                        //Exception in case the parameters are in the wrong format.
                        catch (FormatException)
                        {
                            //Message saying that the paraemters are incorrect, e.g strings instead of integars.
                            String message = "The format of the parameters is unsuitable. Ensure they are integars. " +
                                "Error on line: " + lines;
                            String caption = "Unable to draw a line.";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;

                            //Displays the dialog box.
                            result = MessageBox.Show(message, caption, buttons);

                        }

                    }
                    //Checks to see if the user has entered 'movepen' in their commands.
                    else if (program[i].Contains("moveto"))
                    {
                        try
                        {
                            //Gets Move to from Factory.
                            _shapes.Add(factory.GetShape("moveto"));
                        }
                        //Exception in case the movepen isn't in the factory class.

                        catch (ArgumentException)
                        {

                            Console.WriteLine("Invalid shape: " + e);
                        }
                        //Splits the user's command to get the x,y parameters.
                        string[] stringRec = program[i].Split(' ');
                        try
                        {
                            //Saving x,y params individually and converting them to int.
                            string hei = stringRec[1];
                            string wid = stringRec[2];
                            _x = Convert.ToInt32(hei);
                            _y = Convert.ToInt32(wid);
                            //Sets up the pen and moves is across the screen to desired location.
                            Shape s;
                            //Makes the pen transparent so nothing actually draws.
                            Color newColor = Color.Transparent;
                            s = factory.GetShape("moveto");
                            s.Set(newColor, _xpos, _ypos, _x, _y);
                            _shapes.Add(s);
                            //Refresh the picture box to make sure the pen actually moves.
                            pictureBox1.Refresh();
                            //Updating x,y co ordinates so next shape or line will draw from there.
                            _xpos = _x;
                            _ypos = _y;


                        }
                        //Exception for if the there are too many or not enough parameters.
                        catch (IndexOutOfRangeException)
                        {
                            //Message saying that the user's command had incorrect parameters.
                            String message = "The number of parameters for moving the pen was unsuitable. It takes two parameters. " +
                                "Error on line: " + lines;
                            String caption = "Unable to move the pen.";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;

                            //Display the dialog box.
                            result = MessageBox.Show(message, caption, buttons);
                        }
                        //Exception for if the parameters are in the wrong format of the wrong data type.
                        catch (FormatException)
                        {
                            //Message saying that the parameters shoulc be integars.
                            String message = "The format of the parameters is unsuitable. Ensure they are integars. " +
                                "Error on line: " + lines;
                            String caption = "Unable to move the pen.";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;

                            //Display the dialog box.
                            result = MessageBox.Show(message, caption, buttons);
                        }


                    }
                    //checking to see if user has entered circle in cmd.
                    else if (program[i].Contains("circle"))
                    {
                        try
                        {
                            //Sets up variable for if the circle needs to be reported.
                            int repeat = 1;
                            int increment = 0;
                            string symbol = "", rad;

                            char[] myChar = new char[0];
                            int radius1 = 10;
                            //Splits the program to get parameters.
                            string[] stringRadius = program[i].Split(' ');
                            //If the users cmd also contains repeat then the circle needs extra variables.
                            if (program[i].Contains("repeat"))
                            {
                                //Split it more to see how many times circle needs to repeat itself.
                                string[] stringRep = program[i].Split(' ');
                                //Saves the radius of circle.
                                rad = stringRadius[3];
                                //Checks to see if the circle needs to add pixels.
                                if (program[i].Contains("+"))
                                {
                                    //Saves the + and makes it char.
                                    symbol = "+";
                                    myChar = symbol.ToCharArray();

                                }
                                //Checking to see if circle nees to reduce pixels
                                else if (program[i].Contains("-"))
                                {
                                    //Saving - and making it a chat.
                                    symbol = "-";
                                    myChar = symbol.ToCharArray();

                                }
                                //Checks to see if the circle needs to multiply pixels.
                                else if (program[i].Contains("*"))
                                {
                                    //Saves the * and makes it a char.
                                    symbol = "*";
                                    myChar = symbol.ToCharArray();
                                }
                                //Checking to see if the circle needs to divide pixels.
                                else if (program[i].Contains("/"))
                                {
                                    //Saves the / and makes it char.
                                    symbol = "/";
                                    myChar = symbol.ToCharArray();

                                }
                                //If the program doesn't contain any of these then the repeat command is in the wrong order and the user will be told.
                                else
                                {
                                    //Message saying that the symbol used in the repeat command is incorrect.
                                    String message = "The mathematical symbol was unsuitable. Ensure it is an +, - *, /. " +
                                        "Error on line: " + lines;
                                    String caption = "Unable to draw a repeat rectangle.";
                                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                                    DialogResult result;

                                    //Display the dialog box.
                                    result = MessageBox.Show(message, caption, buttons);
                                }
                                //Saves the repeat cmd variables and converts the cmds to int.
                                string[] stringInc = program[i].Split(myChar);
                                string inc = stringInc[1];
                                string rep = stringRep[1];
                                repeat = Convert.ToInt32(rep);
                                increment = Convert.ToInt32(inc);
                            }
                            else
                            {
                                //If the circle isn't part of a repeat cmd,just save the radius normally.
                                rad = stringRadius[1];

                            }
                            try
                            {
                                //Gets the circle command from factory
                                _shapes.Add(factory.GetShape("circle"));
                            }
                            //Catches an exception if the shape isnt in factory
                            catch (ArgumentException)
                            {
                                Console.WriteLine("Invalid shape: " + e);
                            }
                            //Checks if the radius is named as variable or a number by user.
                            if (rad == "radius")
                            {
                                //If a variable is in place of the number,save it to a new int
                                radius1 = radius1;

                            }
                            if (rad != "radius")
                            {
                                //If  number then convert the number they input to an int.
                                radius1 = Convert.ToInt32(rad);
                            }
                            /*Loops through th drawing process for the circle based on how many increments the user defined int he repeat command. If the
                            * command isn't a repeat then it will just go through once as normal.
                            */
                            for (int a = 0; a < repeat; a++)
                            {
                                //Sets up the shape and adds colour.
                                Shape s;
                                Color newColor = userColor;
                                s = factory.GetShape("circle");
                                if (program[i].Contains("texture"))
                                {
                                    Image img = new Bitmap("pttrn.jpg");
                                    TextureBrush brush = new TextureBrush(img);
                                    brush.Transform = new Matrix(
                                        75.0f / 640.0f,
                                        0.0f,
                                        0.0f,
                                        75.0f / 480.0f,
                                        0.0f,

                                        0.0f);
                                    //Draws the shapes through the factory, adjusting so the circle draws from the center.
                                    s.Set(brush, _xpos - (radius1 / 2), _ypos - (radius1 / 2), radius1);

                                }
                                else
                                {
                                    //Draws the shapes through the factory, adjusting so the circle draws from the center.
                                    s.Set(newColor, _xpos - (radius1 / 2), _ypos - (radius1 / 2), radius1);


                                }
                                _shapes.Add(s);
                                //Refresh the picture box so the circle is visible.
                                pictureBox1.Refresh();
                                //If the symbol entere by user in the repeat cmd was +.
                                if (symbol == "+")
                                {
                                    //Add the inc from radius.
                                    radius1 = radius1 + increment;

                                }
                                //If the symbol entered by the user in the repeat cmd was -
                                else if (symbol == "-")
                                {
                                    //Subtract the inc from radius.
                                    radius1 = radius1 - increment;

                                }
                                //If the symbol is *
                                else if (symbol == "*")
                                {
                                    //Multiply in radius
                                    radius1 = radius1 * increment;

                                }
                                //If the symbol is / 
                                else if (symbol == "/")
                                {
                                    //Divide the increment with radius.
                                    radius1 = radius1 / increment;
                                }
                            }
                        }
                        //Exception for if there were too many of not enough parameters for the circle.
                        catch (IndexOutOfRangeException)
                        {
                            //Message saying that the file format chosen was usuitable for the program to open.
                            String message = "The number of parameters for drawing a circle was unsuitable. It takes one parameters. " +
                                "Error on line: " + lines;
                            String caption = "Unable to draw a circle.";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;

                            //Shows the dialog box.
                            result = MessageBox.Show(message, caption, buttons);
                        }
                        //Exception for if the circle parameters were not integars.
                        catch (FormatException)
                        {
                            //Message saying that the file format chosen was usuitable for the program to open.
                            String message = "The format of the parameters is unsuitable. Ensure they are integars. " +
                                "Error on line: " + lines;
                            String caption = "Unable to draw a circle.";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;

                            //Shows the dialog box.
                            result = MessageBox.Show(message, caption, buttons);
                        }




                    }
                    //checking if the user commands contains Rectangle.
                    else if (program[i].Contains("rectangle"))
                    {
                        try
                        {
                            //Sets up the variables for if there is a repeat cmd.
                            int repeat = 1;
                            int increment = 0;
                            string symbol = "", hei, wid;
                            char[] myChar = new char[0];
                            int height1 = 10;
                            int width1 = 10;
                            //SPlits the cmd to get the different params.
                            string[] stringRec = program[i].Split(' ');
                            //Checks if the rectangle cmd needs to be repeated.
                            if (program[i].Contains("repeat"))
                            {
                                //Splits it further for the repeat cmd.
                                string[] stringRep = program[i].Split(' ');
                                //Saves the height and width of the rectangle if its a part of repeat cmd.
                                hei = stringRec[3];
                                wid = stringRec[4];
                                //Checks to see if cmd needs to add pixels btwn each rectangle.
                                if (program[i].Contains("+"))
                                {
                                    //Saves the + and converts to a char.
                                    symbol = "+";
                                    myChar = symbol.ToCharArray();
                                }
                                //Checks if the repeat cmd needs to subtract pixels btwn each rectangle.
                                else if (program[i].Contains("-"))
                                {
                                    //Saves the - and converts to a char.
                                    symbol = "-";
                                    myChar = symbol.ToCharArray();
                                }
                                //Checks if the repeat cmd needs to multiply pixels btwn each rectangle.
                                else if (program[i].Contains("*"))
                                {
                                    //Saves * and converts it into a char.
                                    symbol = "*";
                                    myChar = symbol.ToCharArray();


                                }
                                //Checks if the repeat cmd needs to divide pixels btwn each rectangle.
                                else if (program[i].Contains("/"))
                                {
                                    //Saves the / and converts to a char.
                                    symbol = "/";
                                    myChar = symbol.ToCharArray();


                                }
                                //If it contains none of these then the repeat command won't work and it will tell the user.
                                else
                                {
                                    //Message saying that the symbol is incorrect and the rectangle can't repeat.
                                    String message = "The mathematical symbol was unsuitable. Ensure it is an +, - *, /. " +
                                        "Error on line: " + lines;
                                    String caption = "Unable to draw a repeat rectangle.";
                                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                                    DialogResult result;

                                    //Shows the dialog box.
                                    result = MessageBox.Show(message, caption, buttons);
                                }
                                //Saves the repeat variables and converts them to integars.
                                string[] stringInc = program[i].Split(myChar);
                                string inc = stringInc[1];
                                string rep = stringRep[1];
                                repeat = Convert.ToInt32(rep);
                                increment = Convert.ToInt32(inc);



                            }
                            else
                            {
                                //If there is no repeat cmd then save its height and width
                                hei = stringRec[1];
                                wid = stringRec[2];

                            }
                            try
                            {
                                //Get the rectangle functions from factory.

                            }
                            //Exception if it isnt found in factory.
                            catch (ArgumentException)
                            {
                                Console.WriteLine("Invalid Shape: " + e);
                            }
                            //Checking to see if height and width of paramst use variables
                            if (hei == "height")
                            {
                                height1 = _height;
                            }
                            if (hei == "width")
                            {
                                height1 = _width;
                            }
                            if (wid == "height")
                            {
                                width1 = _height;
                            }
                            if (wid == "width")
                            {
                                width1 = _width;
                            }
                            //If height and width were entered as numbers, it just converts them to integars.
                            if (height1 != _height && width1 != _height)
                            {
                                //Converting the height to an integert.
                                height1 = Convert.ToInt32(hei);

                            }
                            if (width1 != _width && height1 != _width)
                            {
                                //Converts the width to an integar.
                                width1 = Convert.ToInt32(wid);
                            }
                            //If the repeat cmd was set then it will loop through the drawing proccess.
                            for (int b = 0; b < repeat; b++)
                            {
                                Shape s;
                                //Setting up the colour of rectangle to user specified.
                                Color newColor = userColor;
                                s = factory.GetShape("rectangle");
                                //if the command contains the repeat command, it will draw the rectangle from centre.
                                if (height1 == _width && width1 == _height && program[i].Contains("repeat"))
                                {
                                    //Passes through the variables and draws the shape to screen.
                                    s.Set(newColor, _xpos - (width1 / 2), _ypos - (height1 / 2), height1, width1);
                                    _shapes.Add(s);
                                    //Refreshes the picture box so the rectangle is visible.
                                    pictureBox1.Refresh();
                                }
                                else if (height1 != _width && width1 != _height && program[i].Contains("repeat"))
                                {
                                    //Passes through the variables and draws the shape to screen.
                                    s.Set(newColor, _xpos - (width1 / 2), _ypos - (height1 / 2), width1, height1);
                                    _shapes.Add(s);
                                    //Refreshes the picture box so the rectangle is visible.
                                    pictureBox1.Refresh();

                                }
                                else if (height1 == width1 && width1 == height1)
                                {
                                    //Passes through the variables and draws the shape to screen.
                                    s.Set(newColor, _xpos, _ypos, height1, width1);
                                    _shapes.Add(s);
                                    //Refreshes the picture box so the rectangle is visible.
                                    pictureBox1.Refresh();
                                }
                                else if (height1 == width1 && width1 == height1)
                                {
                                    //Passes through the variables and draws the shape to screen.
                                    s.Set(newColor, _xpos, _ypos, height1, width1);
                                    _shapes.Add(s);
                                    //Refresh the picture box so the rectangle is visible.
                                    pictureBox1.Refresh();
                                }
                                else if (height1 != _width && width1 != _height)
                                {
                                    //Passes through the variables and draws the shape to screen.
                                    s.Set(newColor, _xpos, _ypos, width1, height1);
                                    _shapes.Add(s);
                                    //Refreshes the picture box so the rectangle is visible.
                                    pictureBox1.Refresh();

                                }
                                //Uses the + symbol to find the pixel distance betwn the repeating rectangle.
                                if (symbol == "+")
                                {
                                    //Increments the rectangle pixels.
                                    height1 = height1 + increment;
                                    width1 = width1 + increment;

                                }
                                else if (symbol == "-")
                                {
                                    //Subtracts the rectangles pixels.
                                    height1 = height1 - increment;
                                    width1 = width1 - increment;
                                }
                                else if (symbol == "*")
                                {
                                    //Multiplying Rectangle pixels.
                                    height1 = height1 * increment;
                                    width1 = width1 * increment;


                                }
                                else if (symbol == "/")
                                {
                                    //Dividing the rectangles pixels.
                                    height1 = height1 / increment;
                                    width1 = width1 / increment;
                                }

                            }
                        }
                        //Catches the exception for if there are too many or not enough parameters.
                        catch (IndexOutOfRangeException)
                        {
                            //Message saying that the rectangle needs two parameters to draw.
                            String message = "The number of parameters for drawing a rectangle was unsuitable. It takes two parameters. " +
                                "Error on line: " + lines;
                            String caption = "Unable to draw a rectangle.";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;

                            //Display the dialog box.
                            result = MessageBox.Show(message, caption, buttons);
                        }
                        //Exception for if the parameters were the incorrect data type.
                        catch (FormatException)
                        {
                            //Message saying that the parameters should be integars.
                            String message = "The format of the parameters is unsuitable. Ensure they are integars. " +
                                "Error on line: " + lines;
                            String caption = "Unable to draw a rectangle.";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;

                            //Display the dialog box.
                            result = MessageBox.Show(message, caption, buttons);
                        }

                    }
                    //Checks to see if there is triangle in User's cmd
                    else if (program[i].Contains("traingle"))
                    {
                        try
                        {
                            //Getting triangle class from factory.
                            _shapes.Add(factory.GetShape("triangle"));
                        }
                        //Exception if it is not in factory
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Invalid Shape:"+e);

                            
                        }
                        try
                        {
                            //Set up the variables used to draw the triangle.
                            int hyp = 10;
                            int triBase = 10;
                            int adj = 10;
                            //Split the user's cmd to get the triangle parameters.
                            string[] stringTri = program[i].Split(' ');
                            string hei = stringTri[1];
                            string wid = stringTri[2];
                            string bas = stringTri[3];
                            //Convert params into integars.
                            hyp = Convert.ToInt32(hei);
                            triBase = Convert.ToInt32(wid);
                            adj = Convert.ToInt32(bas);
                            Shape s;
                            //Change the colour to the user's selected colour.
                            Color newColor=userColor;
                            s = factory.GetShape("triangle");
                            //Pass through the paramaters and draw the triangle.
                            s.Set(newColor, _xpos, _ypos, hyp, triBase, adj);
                            _shapes.Add(s);
                            //Refreshing the picture box.
                            pictureBox1.Refresh();

                        }
                        //Exception for if there are too many or not enough parameters.
                        catch (IndexOutOfRangeException)
                        {
                            //Message saying that the triangle requires three parameters.
                            String message = "The number of parameters for drawing a triangle was unsuitable. It takes three parameters. " +
                                "Error on line: " + lines;
                            String caption = "Unable to draw a triangle.";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;

                            //Display the dialog box.
                            result = MessageBox.Show(message, caption, buttons);
                        }
                        //Exception saying the paramters for the triangle are incorrect.
                        catch (FormatException)
                        {
                            //Message saying that the parameters must be integars.
                            String message = "The format of the parameters is unsuitable. Ensure they are integars. " +
                                "Error on line: " + lines;
                            String caption = "Unable to draw a triangle.";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;

                            //Display the dialog box.
                            result = MessageBox.Show(message, caption, buttons);
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
