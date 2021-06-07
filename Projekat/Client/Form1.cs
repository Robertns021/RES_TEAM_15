using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO
            //Saljemo datum(dateTimePicker1) i potrosnju(textBox1)
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
