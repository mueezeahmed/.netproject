using MySql.Data.MySqlClient;
using System.Diagnostics;
using TodoLIstApp.DataBase;

namespace TodoLIstApp.tasks.update
{
    public partial class UpdateTaskForm : Form
    {
        private readonly int taskId;
        public event EventHandler FormClosedEvent;
        private List<Category> categories;

        public UpdateTaskForm(int taskId)
        {
            InitializeComponent();
            InitializeErrorLabels();

            this.taskId = taskId;

            // Load and display the task details in the form
            LoadTaskDetails();

        }

        private void LoadTaskDetails()
        {
            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {
                    // Assuming you have a stored procedure or query to get task details by ID
                    string query = "SELECT * FROM tasks WHERE id = @taskId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@taskId", taskId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Debug.WriteLine(reader["description"].ToString());
                                // Populate the form fields with task details
                                txtTitle.Text = reader["title"].ToString();
                                txtDescription.Text = reader["description"].ToString();
                                // Add other fields as needed
                            }
                            else
                            {
                                MessageBox.Show("Task not found.");
                                Close(); // Close the form if the task is not found
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void LoadCategories()
        {
            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {
                    string query = "SELECT id, name FROM categories";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            categories = new List<Category>();
                            while (reader.Read())
                            {
                                Category category = new Category
                                {
                                    Id = reader.GetInt32("id"),
                                    Name = reader.GetString("name")
                                };
                                categories.Add(category);
                            }
                        }
                    }
                }

                // Populate the dropdown with roles
                cmbRoles.DataSource = categories;
                cmbRoles.DisplayMember = "Name";
                cmbRoles.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void UpdateTaskForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void txtTilte_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Reset error labels
            lblErrorTitle.Text = "";
            // Perform validation and then update
            if (ValidateFormData())
            {
                // Successful login logic here
                //MessageBox.Show("Login successful!");
                string title = txtTitle.Text.Trim();
                string description = txtDescription.Text.Trim();
                int categoryId = (int)cmbRoles.SelectedValue;

                ProcessForm(title, description, categoryId);
            }
        }

        private void ProcessForm(string title, string description, int categoryId)
        {
            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {
                    string query = "UPDATE tasks SET title = @title, description = @description, " +
                        "category_id = @categoryId WHERE id = @taskId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@title", title);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.AddWithValue("@taskId", taskId);
                        command.Parameters.AddWithValue("@categoryId", categoryId);

                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Task updated successfully.");
                            Close(); // Close the form after successful update
                        }
                        else
                        {
                            MessageBox.Show("Task update failed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle database error
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private bool ValidateFormData()
        {
            bool valid = true;
            string title = txtTitle.Text.Trim();
            if (string.IsNullOrWhiteSpace(title))
            {
                lblErrorTitle.Text = "Please enter some task";
                valid = false;
            }
            return valid;
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblDescription_Click(object sender, EventArgs e)
        {

        }

        private void updateTaskForm_FormClosing(object sender, EventArgs e)
        {
            // Notify the main form about the closing
            FormClosedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
