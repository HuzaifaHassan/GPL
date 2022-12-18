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
                                    //Checks to see if the IF statement was a one line or Block cmd.#
                                    if (program[i].Contains("then"))
                                    {
                                        //Splits the sinlge line cmd to get as it is supposed to perform.
                                        program[i] = program[i].Split(new[] { "then  " }, StringSplitOptions.None)[1];

                                    }
                                    //If the user specified a block command.
                                    else
                                    {
                                        //For loop to iterate through the program to find where the block cmd ends.#
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

                }
                catch(ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Error");
                }
            }
        }

    }
}
