using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            Hide();
            User user = new User() { Id = int.Parse(textBox1.Text), Name = textBox2.Text, Surname = textBox3.Text };

            form2.ShowDialog(user);
            Close();

        }
    }
}
