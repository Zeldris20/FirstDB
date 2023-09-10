using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace my_first_DB
{
    public partial class Form1 : Form
    {
        private SQLiteConnection connection;
        public Form1()
        {
            InitializeComponent();
            // Initalize your SQLite connection here
            connection = new SQLiteConnection("Data Source=mydatabase.db;Version=3;");
            connection.Open();
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

        private void button2_Click(object sender, EventArgs e)
        {
            int userIdToUpdate = 1;

            // Prompt the user to select what data they want to edit 
            DialogResult dialogResult = MessageBox.Show("Do you want to edit Name?", "Edit Options", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                // Edit Name 
                string newName = string.Empty;

                // Prompt the user for the new name 
                if (MessageBox.Show("Press OK to Continue", "Name", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    newName = Microsoft.VisualBasic.Interaction.InputBox("Enter New Name: ", "Name Input", "");
                }
                else
                {
                    return;
                }

                // Update the name in the database 
                using (SQLiteCommand command = new SQLiteCommand("UPDATE Users SET Name = @NewName WHERE Id = @UserId", connection))
                {
                    command.Parameters.AddWithValue("@NewName", newName);
                    command.Parameters.AddWithValue("@UserId", userIdToUpdate);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Name updated successfully!");
                }

            }
            else if (dialogResult == DialogResult.No)
            {
                int newAge = 2;

                // Prompt the user for the new age 
                if (MessageBox.Show("Enter New Age:", "Age Input", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string newAgeInput = Microsoft.VisualBasic.Interaction.InputBox("Enter New Age:", "Age Input", "");
                    if (int.TryParse(newAgeInput, out newAge) == false)
                    {
                        MessageBox.Show("Invalid age input.");
                        return;
                    }

                }
                else
                {
                    return;
                }
                using (SQLiteCommand command = new SQLiteCommand("UPDATE Users SET Age = @NewAge WHERE Id = @UserId", connection))
                {
                    command.Parameters.AddWithValue("@NewAge", newAge);
                    command.Parameters.AddWithValue("@UserId", userIdToUpdate);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Age updated successfully!");
                }
            }
            else
            {
                return;
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string name = string.Empty;
            int age = 3;

            // Prompt the user for name 
            if (MessageBox.Show("Press OK to Continue", "Name", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                name = Microsoft.VisualBasic.Interaction.InputBox("Enter Name:", "Name Input", "");

            }
            else
            {
                return;
            }

            // prompt user for age 
            if (MessageBox.Show("Enter Age:", "Age Input", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string ageInput = Microsoft.VisualBasic.Interaction.InputBox("Enter Age:", "Age Input", "");
                if (int.TryParse(ageInput, out age) == false)
                {
                    MessageBox.Show("Invalid age input.");
                }

            }
            else
            {
                return;
            }
            // Insert the record into the database
            using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Users (Name, Age) VALUES (@Name, @Age)", connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Age", age);
                command.ExecuteNonQuery();

                MessageBox.Show("Record Added successfully!");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            int userIdToDelete = 4; // deletes what id 

            // Prompt the user to confirm the deletion
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                // Execute the DELETE SQL statement
                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM Users WHERE Id = @UserId", connection))
                {
                    command.Parameters.AddWithValue("@UserId", userIdToDelete);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record deleted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Record not found");
                    }

                }
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            //Prompt the user to confirm the reset 
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to reset the database? This action will delete all data and recreate the tables.", "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                // Delete all records from the tables using DELETE statement 
                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM Users", connection))
                {
                    command.ExecuteNonQuery();
                }    
                // You can add more DELETE statements for other tables 


                // Recreate the tables (if necessary) using CREATE TABLE 
                using (SQLiteCommand createTableCommand = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY, Name TEXT, Age INTEGER)", connection))
                {
                    createTableCommand.ExecuteNonQuery();
                }

                // You can add more CREATE TABLE statements for other tables if needed 
                MessageBox.Show("Database has been reset. The database is now empty");
            
            }
        }
    }
}