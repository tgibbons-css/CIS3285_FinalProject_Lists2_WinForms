using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CIS3285_FinalProject
{
    class ToDoItemRepository : IListRepository
    {
        // DEBT --- connection string should not be hard coded here
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FinalProjLists.mdf;Integrated Security=True;Connect Timeout=30;";

        public IListItem CreateToDoItem(string name)
        {
            ToDoItem newToDo = new ToDoItem(name);
            saveItem(newToDo);
            return newToDo;
        }


        public void saveItem(ToDoItem item)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // DEBT --- Skips dateAdded field which is currently not used anywhere
                string SQLtext = "INSERT INTO ToDoItemsTable(Id, activity, completedYN) VALUES(@Id, @activity, @completedYN)";

                using (SqlCommand command = new SqlCommand(SQLtext, connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", item.Id));
                    command.Parameters.Add(new SqlParameter("activity", item.Activity));
                    command.Parameters.Add(new SqlParameter("completedYN", item.CompletedYN));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public List<IListItem> ReadAll()
        {
            List<IListItem> items = new List<IListItem>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM ToDoItemsTable", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Guid id = (Guid)reader["Id"];
                        string name = reader["activity"].ToString();
                        int completedInt = (int)reader["completedYN"];
                        bool completedYN = (completedInt == 1);
                        items.Add(new ToDoItem(id, name, completedYN));
                    }
                }
            }
            return items;
        }

        public void updateChecked(Guid id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string SQLtext = "UPDATE ToDoItemsTable SET completedYN = 1 WHERE (Id = @Id)";
                using (SqlCommand command = new SqlCommand(SQLtext, connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", id));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


    }
}
