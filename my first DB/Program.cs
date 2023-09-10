using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace my_first_DB
{

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create an instance of your main form (Form1 in this example)
            Form1 mainForm = new Form1();

            //Run the application with your main form 
            Application.Run(mainForm);

            // Connection string to your SQLite database (creates the database if it doesnt exist)
            string connectionString = "Data Source=mydatabase.db;Version=3;";

            // Create a new SQLite connection
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Create a table
                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY, Name TEXT, Age INTEGER)", connection))
                {
                    command.ExecuteNonQuery();
                }
                // Insert data into the table
                using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Users (Name, Age) VALUES (@Name, @Age)", connection))
                {
                    command.Parameters.AddWithValue("@Name", "John");
                    command.Parameters.AddWithValue("@Age", 30);
                    command.ExecuteNonQuery();
                }

                // Query data from the table
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Users", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string name = Convert.ToString(reader["Name"]);
                            int age = Convert.ToInt32(reader["Age"]);
                            Console.WriteLine($"ID: {id}, Name: {name}, Age: {age}");
                        }
                    }
                }


                // Closes the connection 
                connection.Close();
            }
        }

    }
 }


