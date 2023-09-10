using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace my_first_DB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Prompt the user to choose a location for saving the file 
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SQLite Database File(*.db)|*.db";
            saveFileDialog.FileName = "mydatabase.db";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string targetFilePath = saveFileDialog.FileName;

                try
                {
                    string sourceFilePath = "mydatabase.db";

                    //Create a copy of the db file to the downloads folder
                    File.Copy(sourceFilePath, targetFilePath, true);
                    MessageBox.Show("Database file downloaded successfully!");
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Error downloading the database file: {ex.Message}");
                }
            }
        }
    }
}       