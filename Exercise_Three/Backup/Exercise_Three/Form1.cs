using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exercise_Three
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double valueOne = Double.Parse(textBox1.Text);
            double valueTwo = Double.Parse(textBox2.Text);
            double result = valueOne + valueTwo;
            textBox3.Text = result.ToString();
        }
    }
}
