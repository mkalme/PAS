using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp2
{
    public partial class Universal : Form
    {
        public static bool allowedToCheck = false;
        public static bool theNeedToDelete = false;

        public Universal()
        {
            InitializeComponent();
            CenterToScreen();

            checkBox1.Checked = true;

            allowedToCheck = false;
            theNeedToDelete = false;

            textBox1.Text = Form2.array[0];
            textBox2.Text = Form2.array[1];
            richTextBox1.Text = Form2.array[2];

            allowedToCheck = true;

            if (Form2.type.Equals("view"))
            {
                Cancel.Hide();
                checkBox1.Checked = false;
            }
        }

        private void Universal_Load(object sender, EventArgs e)
        {
            check();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            check();
        }

        public void check() {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = true;

                textBox2.Enabled = true;

                randomPAS.Enabled = true;
                maskedTextBox1.Enabled = true;
                richTextBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;

                textBox2.Enabled = false;

                randomPAS.Enabled = false;
                maskedTextBox1.Enabled = false;

                richTextBox1.Enabled = false;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Done_Click(object sender, EventArgs e)
        {
            if (Form2.type.Equals("add")) {
                IO.createFile(Convert.turnTo(textBox1.Text), Convert.turnTo(textBox2.Text) + Environment.NewLine + Convert.turnTo(richTextBox1.Text), Form2.originalPath, false);
            } else if (Form2.type.Equals("edit")){
                if (theNeedToDelete) {
                    IO.deleteFile(Form2.path);
                }
                IO.createFile(Convert.turnTo(textBox1.Text), Convert.turnTo(textBox2.Text) + Environment.NewLine + Convert.turnTo(richTextBox1.Text), Form2.originalPath, false);
            } else if (Form2.type.Equals("view")) {
                if (theNeedToDelete) {
                    IO.deleteFile(Form2.array[0]);
                }
                IO.createFile(Convert.turnTo(textBox1.Text), Convert.turnTo(textBox2.Text) + Environment.NewLine + Convert.turnTo(richTextBox1.Text), Form2.originalPath, false);
            }

            Form2.refresh = true;

            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (allowedToCheck) {
                theNeedToDelete = true;
            }
        }

        private void randomPAS_Click(object sender, EventArgs e)
        {
            maskedTextBox1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (!maskedTextBox1.Text.Equals("")) {
                textBox2.Text = Convert.Random(Int32.Parse(maskedTextBox1.Text), "", new Random());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(textBox2.Text);
        }
    }
}
