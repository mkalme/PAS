using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private static String pas = "JFJ 54N 345 G3V FSE BDD F4F";
        private static String pas1 = "FKR EKX 4YH GJ5 SJ6 956 CDK";

        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
            passwordLabel.Text = pas + "\n\r" + pas1;
            textBox1.UseSystemPasswordChar = true;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            String[] tokens = pas.Split(' ');
            String text = tokens[0] + " " + tokens[1] + " " + tokens[2] + " " + tokens[3] + " " + tokens[4] + " " + tokens[5] + " " + tokens[6];

            if (textBox1.Text.Equals(text)) {
                Hide();
                Form2 form = new Form2();
                form.ShowDialog();

                Close();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.CapsLock)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
