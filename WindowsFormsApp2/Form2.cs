using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public static String path = @"C:\Users\Michael\AppData\Roaming\PATS ST\PATS ST";
        public static String originalPath = @"C:\Users\Michael\AppData\Roaming\PATS ST\PATS ST";
        public static bool enabledBool = false;
        public static bool editBool = false;
        public static string type;

        public static bool refresh = true;
        
        public static string[] array = new string[3];

        public Form2()
        {
            InitializeComponent();
            CenterToScreen();

            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            timer1.Start();

            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Password Length", "Password Length");
            dataGridView1.Columns.Add("Last Changed", "Last Changed");

            timer1.Start();

        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (refresh) {
                dataGridView1.Rows.Clear();
                DirectoryInfo d = new DirectoryInfo(originalPath);
                FileInfo[] Files = d.GetFiles();
                foreach (FileInfo file in Files)
                {
                    dataGridView1.Rows.Add(Convert.turnFrom(file.Name), Convert.turnFrom(IO.readFile(originalPath + @"\" + file.Name, true)).Length, file.LastWriteTime);
                }

                refresh = false;
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            array[0] = "";
            array[1] = "";
            array[2] = "";

            enabledBool = false;
            editBool = true;
            type = "add";

            Universal universal = new Universal();
            universal.ShowDialog();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0) {
                to("edit");
            }   
        }

        private void View_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0) {
                to("view");
            }
        }

        public void to(string type1) {
            array[0] = dataGridView1.SelectedCells[0].Value.ToString();
            array[1] = Convert.turnFrom(IO.readFile(originalPath + @"/" + Convert.turnTo(dataGridView1.SelectedCells[0].Value.ToString()), true));
            array[2] = Convert.turnFrom(IO.readFile(originalPath + @"/" + Convert.turnTo(dataGridView1.SelectedCells[0].Value.ToString()), false));

            type = type1;
            path = originalPath + @"/" + Convert.turnTo(dataGridView1.SelectedCells[0].Value.ToString());

            Universal universal = new Universal();
            universal.ShowDialog();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0) {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this file?\t\t\t\t\t", "Delete file", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    IO.deleteFile(originalPath + @"\" + Convert.turnTo(dataGridView1.SelectedCells[0].Value.ToString()));

                    refresh = true;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                to("view");
            }
        }
    }
}
