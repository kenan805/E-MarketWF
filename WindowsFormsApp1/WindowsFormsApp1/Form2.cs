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
    public partial class Form2 : Form
    {
        public string MyProperty { get; set; }
        public Form2()
        {
            InitializeComponent();
            label2.Text = MyProperty;
        }
        public Form2(string text)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = MyProperty;
        }

        public DialogResult ShowDialog(User user)
        {
            label3.Text = user.Id.ToString();
            label4.Text = user.Name;
            label5.Text = user.Surname;
            return ShowDialog();
        }
    }
}
