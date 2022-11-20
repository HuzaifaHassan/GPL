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
    }
}
